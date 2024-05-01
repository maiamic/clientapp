using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CCA_design
{
    public partial class LogForm : Form
    {
        private TcpClient client;
        private NetworkStream stream;
        // マウスポインタの位置を保存する
        private Point mousePoint;

        public LogForm()
        {

            InitializeComponent();
            //検索結果とメッセージを受信するときの差別化するため別のコネクションを用意
            ConnectToServer("172.31.98.77", 34567);
        }
        private void ConnectToServer(string serverIP, int port)
        {
            try
            {
                client = new TcpClient(serverIP, port);
                stream = client.GetStream();
            }
            catch (Exception ex)
            {
                MessageBox.Show("サーバーへの接続に失敗しました。\n" + ex.Message);
                this.Close();
                stream?.Close();
                client?.Close();
            }
        }
        //閉じるボタン
        private void log_end_btn_Click(object sender, EventArgs e)
        {
            //LogFormを閉じる
            this.Close();
           
        }
        //全件検索ボタン
        private async void get_data_button_Click(object sender, EventArgs e)
        {
            try
            {
                // 検索用テキストボックスから入力された文字列を取得
                string searchText = "search:" + search_textBox.Text;

                // サーバーに検索要求を非同期で送信
                byte[] requestData = Encoding.UTF8.GetBytes(searchText);
                await stream.WriteAsync(requestData, 0, requestData.Length);

                // サーバーからの応答を非同期で受信
                byte[] responseData = new byte[8192];
                int bytesRead = await stream.ReadAsync(responseData, 0, responseData.Length);
                string responseString = Encoding.UTF8.GetString(responseData, 0, bytesRead);

                // 受信したデータを結果表示用テキストボックスに表示
                result_textBox.Text = responseString;
            }
            catch (Exception ex)
            {
                MessageBox.Show("データの取得に失敗しました。\n" + ex.Message);
                this.Close();
                stream?.Close();
                client?.Close();
            }
        }

        //private async void get_all_data_button_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        // サーバーに "getdata" という要求を送信
        //        byte[] data = Encoding.UTF8.GetBytes("getdata");
        //        await stream.WriteAsync(data, 0, data.Length);

        //        // サーバーからの応答を受信
        //        data = new byte[4096];
        //        int bytesRead = stream.Read(data, 0, data.Length);
        //        string responseData = Encoding.UTF8.GetString(data, 0, bytesRead);

        //        // 受信したデータを textBox1 に表示
        //        result_textBox.Text = responseData;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("データの取得に失敗しました。\n" + ex.Message);
        //    }
        //}

        private async void get_time_data_button_Click(object sender, EventArgs e)
        {
            try
            {
                // 開始日時と終了日時のテキストボックスから入力された値を取得
                string startTime = startTime_textBox.Text;
                string endTime = endTime_textBox.Text;

                // 日時の形式を変換する
                DateTime startDateTime, endDateTime;
                if (!DateTime.TryParse(startTime, out startDateTime) || !DateTime.TryParse(endTime, out endDateTime))
                {
                    MessageBox.Show("日時の形式が無効です。yyyy-MM-dd HH:mm:ssの形式で入力してください。");
                    return;
                }

                // 検索条件を整形してサーバーに送信
                string timeFilter = $"time:{startDateTime.ToString("yyyy-MM-dd HH:mm:ss")}～{endDateTime.ToString("yyyy-MM-dd HH:mm:ss")}";
                byte[] requestData = Encoding.UTF8.GetBytes(timeFilter);
                await stream.WriteAsync(requestData, 0, requestData.Length);

                // サーバーからの応答を受信
                byte[] responseData = new byte[8192];
                int bytesRead = await stream.ReadAsync(responseData, 0, responseData.Length);
                string responseString = Encoding.UTF8.GetString(responseData, 0, bytesRead);

                // 受信したデータを結果表示用テキストボックスに表示
                result_textBox.Text = responseString;
            }
            catch (Exception ex)
            {
                MessageBox.Show("データの取得に失敗しました。\n" + ex.Message);
                this.Close();
                stream?.Close();
                client?.Close();
            }
        }

        private void LogForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Log用の接続を閉じる
            client?.Close();
            stream?.Close();
        }
    }
}
