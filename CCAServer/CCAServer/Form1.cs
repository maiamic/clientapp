using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CCAServer
{
    public partial class MainForm : Form
    {
        DateTime time = DateTime.Now;
        NpgsqlConnection conn = null;
        ChatlogDTO logdto = null;
        ChatlogDAO logdao = null;
        DataTable datatable = null;
        string disconnect;
        string log;
        const int BUFFER_SIZE = 1024;

        private static List<TcpClient> ClientList { get; set; }
        private static TcpListener Server { get; set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public MainForm()


        {
            InitializeComponent();
            ClientList = new List<TcpClient>();

            // postgresqlに接続する処理
            try
            {
                conn = new NpgsqlConnection(
                    ConfigurationManager.ConnectionStrings["PosgreConnection"].ConnectionString);
                Debug.WriteLine("コネクション確立");

                logdao = new ChatlogDAO(conn);
            }
            catch (NpgsqlException ne)
            {
                conn = null;
                MessageBox.Show(ne.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            // サーバーを作成して監視開始
            try
            {
                var localEndPoint = new IPEndPoint(IPAddress.Parse("172.31.98.77"), 34567);
                Server = new TcpListener(localEndPoint);
                Server.Start();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }

        private async void reception_btn_Click(object sender, EventArgs e)
        {
            logTextBox.Text += ("接続受け入れ開始。");

            // サーバーが監視中の間は接続を受け入れ続ける
            while (Server != null)
            {
                try
                {
                    // 非同期で接続を待ち受ける
                    var client = await Server.AcceptTcpClientAsync();

                    // 接続ログを出力
                    logTextBox.Text += ($"{client.Client.RemoteEndPoint}からの接続");

                    // 接続中クライアントを追加
                    ClientList.Add(client);

                    // クライアントからのデータ受信を待機
                    ReceiveData(client);

                    // 接続中クライアント(接続したクライアント以外)に対してクライアントが接続した情報を送信する
                    //SendDataToAllClient(client, $"{client.Client.RemoteEndPoint}がサーバーに接続しました。");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"接続受け入れでエラーが発生しました。{ex.Message}");
                    break;
                }

            }
        }

        // データ取得ボタンが押されたらDBから貰ったデータをデータグリッドビューで表示する
        private void getdata_btn_Click(object sender, EventArgs e)
        {
            try
            {
                logdao.select_all_data();
                NpgsqlDataAdapter data = logdao.select_all_data();
                datatable = new DataTable();

                data.Fill(datatable);

                dataGridView1.DataSource = datatable;

                dataGridView1.Columns[1].HeaderText = "名前";
                dataGridView1.Columns[2].HeaderText = "メッセージ";
                dataGridView1.Columns[3].HeaderText = "送信時間";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"データ取得できませんでした。{ex.Message}");
            }
        }
        // わかんね…
        public void ReceiveData(TcpClient client)
        {
            var state = new StateObject { Client = client };
            client.Client.BeginReceive(state.Buffer, 0, StateObject.BufferSize, SocketFlags.None, ReceiveCallback, state);
        }

        private class StateObject
        {
            public const int BufferSize = BUFFER_SIZE;
            public byte[] Buffer = new byte[BufferSize];
            public TcpClient Client;
        }
        // クライアントから送信されたメッセージを送信者以外に返すメソッド
        public void SendDataToAllClient(TcpClient sender, string text)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(text);

            foreach (var client in ClientList.Where(c => c != sender))
            {
                // データ送信
                client.Client.Send(buffer);

                log = $"データ送信>>{text}" + Environment.NewLine;

                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(this.UpdateText));
                }
                else
                {
                    logTextBox.Text += ($"{client.Client.RemoteEndPoint}にデータ送信>>{text}");
                }
                // 送信ログを出力
                //logTextBox.Text += ($"{client.Client.RemoteEndPoint}にデータ送信>>{text}");
            }
        }
        private void ReceiveCallback(IAsyncResult result)
        {
            StateObject state = result.AsyncState as StateObject;
            TcpClient client = state.Client;
            ChatlogDAO dao = new ChatlogDAO(conn);


            try
            {
                int bytesRead = client.Client.EndReceive(result);

                // 受信データが0byteの場合切断と判定
                if (bytesRead == 0)
                {
                    // 切断ログを出力
                    disconnect = ($"{client.Client.RemoteEndPoint}からの切断");
                    if (this.InvokeRequired)
                    {
                        this.Invoke(new Action(this.UpdateText2));
                    }
                    else
                    {
                        logTextBox.Text += ($"{client.Client.RemoteEndPoint}からの切断");
                    }
                    //logTextBox.Text += ($"{client.Client.RemoteEndPoint}からの切断");

                    // 接続中クライアントを削除
                    ClientList.Remove(client);

                    // 接続中クライアント(切断したクライアント以外)に対してクライアントが切断した情報を送信する
                     // SendDataToAllClient(client, $"{client.Client.RemoteEndPoint}がサーバーから切断しました。");

                    // データ受信を終了
                    return;
                }

                // 受信データを出力
                string receivedData = Encoding.UTF8.GetString(state.Buffer, 0, bytesRead);
                log = $"データ受信 <<{receivedData}" + Environment.NewLine;

                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(this.UpdateText));
                }
                else
                {
                    logTextBox.Text += ($"{client.Client.RemoteEndPoint}からデータ受信<<{receivedData}" + Environment.NewLine);
                }

                if (receivedData == "getdata")
                {
                    // クライアントにデータを送信
                    SendAllDataToClient(client);
                }
                else if (receivedData.StartsWith("search:"))
                {
                    // クライアントに対応するデータを検索して送信
                    string searchText = receivedData.Substring(7); // "search:" の部分を削除して検索文字列を取得
                    SearchAndSendDataToClient(client, searchText);
                }
                else if (receivedData.StartsWith("time:"))
                {
                    // クライアントに時間での検索結果を送信
                    string timeCondition = receivedData.Substring(5); // "time:" の部分を削除して検索条件を取得
                    SearchByTimeAndSendDataToClient(client, timeCondition);
                    // 通常のメッセージ処理
                }
                else
                {
                    // 接続中クライアント(送信したクライアント以外)に対して受信したデータを送信する
                    SendDataToAllClient(client, receivedData);
                }
                string[] parts = receivedData.Split(new char[] { '：' }, 2);
                if (parts.Length == 2)
                {
                    string username = parts[0];
                    string text = string.Join("：", parts.Skip(1));

                    // データベースに保存
                    dao.insert_message(username, text);
                }

                // サーバーが監視中の場合、再度クライアントからのデータ受信を待機
                ReceiveData(client);
            }
            catch (Exception ex)
            {
                ClientList.Remove(client);
                Debug.WriteLine(ex.Message);
            }


        }
        // 別のスレッドからテキストボックスにアクセスできないので、インヴォークで使うようのメソッド
        private void UpdateText()
        {
            this.logTextBox.Text += log;
        }
        // サーバーのログに切断情報が表示させる。
        private void UpdateText2()
        {
            this.logTextBox.Text += disconnect;
        }

        // DAOのchatlog_getメソッドにアクセスして貰ったデータをクライアント側に全件返す
        private void SendAllDataToClient(TcpClient tcpClient)
        {
            // データの取得処理を実行して、取得したデータをクライアントに送信するロジックを記述する
            // ここでは、ダミーデータを送信する例を示します
            try
            {
                // データベースからチャットログを取得
                var chatLogs = logdao.chatlog_get();

                // チャットログを文字列に変換
                StringBuilder sb = new StringBuilder();
                foreach (var log in chatLogs)
                {
                    sb.AppendLine($"[{log.Time}] {log.UserName}: {log.Message}");
                }
                string dataToSend = sb.ToString();

                // 文字列をバイト配列に変換してクライアントに送信
                byte[] data = Encoding.UTF8.GetBytes(dataToSend);
                NetworkStream clientStream = tcpClient.GetStream();
                clientStream.Write(data, 0, data.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show("データの送信に失敗しました。\n" + ex.Message);
            }
        }
        // クライアント側から入力された文字列を参照して、HITしたデータをクライアント側に返す
        private void SearchAndSendDataToClient(TcpClient tcpClient, string searchText)
        {
            try
            {
                // 検索文字列を使用してデータベースからデータを検索
                var searchResult = logdao.SearchData(searchText); // このメソッドは実際に実装する必要があります

                // 検索結果を文字列に変換
                StringBuilder sb = new StringBuilder();
                foreach (var result in searchResult)
                {
                    sb.AppendLine($"[{result.Time}] {result.UserName}: {result.Message}");
                }
                string dataToSend = sb.ToString();

                // 文字列をバイト配列に変換してクライアントに送信
                byte[] data = Encoding.UTF8.GetBytes(dataToSend);
                NetworkStream clientStream = tcpClient.GetStream();
                clientStream.Write(data, 0, data.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show("データの送信に失敗しました。\n" + ex.Message);
            }
        }
        // クライアント側から入力された時間帯を参照して、HITしたデータをクライアント側に返す
        private void SearchByTimeAndSendDataToClient(TcpClient tcpClient, string timeCondition)
        {
            // timeConditionが"開始時間～終了時間"の形式であることを確認し、開始時間と終了時間を取得します
            string[] timeRange = timeCondition.Split('～');
            if (timeRange.Length != 2)
            {
                // 開始時間と終了時間が正しく指定されていない場合はエラーメッセージを送信します
                SendErrorMessageToClient(tcpClient, "検索条件が無効です。yyyy-MM-dd HH:mm:ss形式で入力してください。");
                return;
            }

            // 開始時間と終了時間をDateTime型に変換します
            if (!DateTime.TryParse(timeRange[0], out DateTime startTime) || !DateTime.TryParse(timeRange[1], out DateTime endTime))
            {
                // 時間のパースに失敗した場合はエラーメッセージを送信します
                SendErrorMessageToClient(tcpClient, "時間の形式が無効です。yyyy-MM-dd HH:mm:ss形式で入力してください。");
                return;
            }

            // ChatlogDAOを使用して、指定された時間範囲内のデータを検索します
            List<ChatlogDTO> searchResult = logdao.SearchByTime(startTime, endTime);

            // 検索結果をクライアントに送信します
            SendDataToClient(tcpClient, searchResult);
        }
        // エラーが発生した際のテキストをUTF-8に変換する
        private void SendErrorMessageToClient(TcpClient tcpClient, string errorMessage)
        {
            // エラーメッセージをUTF-8でエンコードしてクライアントに送信します
            byte[] errorMessageBytes = Encoding.UTF8.GetBytes(errorMessage);
            tcpClient.GetStream().Write(errorMessageBytes, 0, errorMessageBytes.Length);
        }
        private void SendDataToClient(TcpClient tcpClient, List<ChatlogDTO> data)
        {
            // データリスト内の各チャットログをテキスト形式でクライアントに送信します

            StringBuilder sb = new StringBuilder();
            foreach (var chatlog in data)
            {
                sb.AppendLine($"[{chatlog.Time}] {chatlog.UserName}: {chatlog.Message}");
            }
            string dataToSend = sb.ToString();

            // 文字列をバイト配列に変換してクライアントに送信
            byte[] message = Encoding.UTF8.GetBytes(dataToSend);
            NetworkStream clientStream = tcpClient.GetStream();
            clientStream.Write(message, 0, message.Length);

            //foreach (var chatlog in data)
            //{
            //    string message = $"{chatlog.Id}:{chatlog.UserName}:{chatlog.Message}:{chatlog.Time}" + Environment.NewLine;
            //    byte[] messageBytes = Encoding.UTF8.GetBytes(message);
            //    tcpClient.GetStream().Write(messageBytes, 0, messageBytes.Length);
            //}

            // すべてのメッセージが送信されたことを示すために、終了を示すメッセージを送信します
            //string endMessage = "EndOfData";
            //byte[] endMessageBytes = Encoding.UTF8.GetBytes(endMessage);
            //tcpClient.GetStream().Write(endMessageBytes, 0, endMessageBytes.Length);
        }
    }
}
