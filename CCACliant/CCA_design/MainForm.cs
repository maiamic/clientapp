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
    public partial class MainForm : Form
    {
        //ニックネーム+メッセージ
        private string log;
        //受信したニックネーム+メッセージ
        private string receivelog;

        //Username がNameに入る
        public new string Name;

        //MainからlogformとwelconFormを触れるようにしている
        public LogForm lf;
        WelcomForm Wf;
        public MainForm(string name,WelcomForm wf)
        {
            InitializeComponent();
            //ここで引数でわたってきたUserNameが変数Nameに入る
            Name = name;
            Wf = wf;

            // 4月30日追記分
            main_input_tb.KeyDown += Main_input_tb_KeyDown;

            // データ受信待機開始
            var data = new StateObject();
            // 非同期受信
            Program.client?.GetStream().BeginRead(data.Data, 0, data.Data.Length, ReceiveCallback, data);
           
        }

        //✕ボタン
        private void main_end_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //過去メッセージボタン
        private void main_log_btn_Click(object sender, EventArgs e)
        {
            //ログ画面を複数開かないようにする

            //ログ画面廃棄　true のとき　ニューする
            //if (lf.IsDisposed)
                lf = new LogForm();

            //ログ画面表示して
            lf.Show();

            //表示位置は前
            lf.BringToFront();
        }
        //送信ボタン
        private void main_send_btn_Click(object sender, EventArgs e)
        {
            //ニックネーム　：　メッセージ　+改行　が入る
            log = Name + "：" + main_input_tb.Text + Environment.NewLine;
            //初期メッセージが送信されないように
            if (main_input_tb.Text == "一度に送れるメッセージは100文字までです"|| main_input_tb.Text =="")
                log = "";

            //空文字を送れないようにする
            if (log != "")
            {
                //テキストボックスに　追加される
                main_output_tb.Text += log;

                //サーバーに送るように入れる
                string message = Name + "：" + main_input_tb.Text;

                //サーバーに送るとき文字化けしないように
                byte[] data = Encoding.UTF8.GetBytes(message);

                //サーバーに送る
                try
                {
                    Program.stream.Write(data, 0, data.Length);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("サーバーとの接続エラーが発生しました。" + ex.Message);
                    Program.client?.Close();
                    Program.stream?.Close();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("メッセージを入力してね！");
            }
            
           

            //テキストボックス空にする
            main_input_tb.Text = "";
        }

        private void ReceiveCallback(IAsyncResult result)
        {
            try
            {
                var data = (StateObject)result.AsyncState;
                int bytesRead = Program.client.GetStream().EndRead(result);
                if (bytesRead <= 0)
                {
                    Console.WriteLine("サーバー切断");
                    return;
                }

                //サーバから受け取ったメッセージ　の型式を整える
                var receivedMessage = Encoding.UTF8.GetString(data.Data, 0, bytesRead);
                //Console.WriteLine($"受信: {receivedMessage}");

                //受け取ったデータをテキストボックスにいれる

                //同期してると他のうごきがとまるので非同期、非同期だとテキスト書き込めない、を回避→インボーグ

                //インボーグのとき
                receivelog = receivedMessage + Environment.NewLine;
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(this.UpdateText));
                }

                //インボーグが必要ないなら
                else
                {
                    this.UpdateText();
                }

                // 再度データ受信を待機
                Program.client.GetStream().BeginRead(data.Data, 0, data.Data.Length, ReceiveCallback, data);
            }
            catch (Exception ex)
            {
                //接続が閉じられていたら↑が動かないようにしている
                Program.client?.Close();
                Program.stream?.Close();
            }
            
        }
        private class StateObject
        {
            /// 通信データサイズ最大値
            const int MAX_COMMUNICATION_DATA_SIZE = 5120;
            /// 通信データバッファ。
            public byte[] Data = new byte[MAX_COMMUNICATION_DATA_SIZE];
            public TcpClient Client;
        }
        //テキストボックスに　受信したニックネーム+メッセージ追加していく
        private void UpdateText()
        {
            // 受信したメッセージをテキストボックスに追加
            main_output_tb.AppendText(receivelog);

            // テキストボックスの最後の文字の位置にスクロール
            main_output_tb.SelectionStart = main_output_tb.TextLength;
            main_output_tb.ScrollToCaret();
        }
        //メッセージ入力boxをクリックすると入っていた説明文が消える用
        private void main_input_tb_Click(object sender, EventArgs e)
        {
            main_input_tb.Text = "";
        }
        //mainformが閉じられたときに動く
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {

            MessageBox.Show("またね！");

            //接続をクローズ
            Program.stream?.Close();
            Program.client?.Close();
            //hideしていたwelcomeFormを閉じる
            Wf.Close();

        }
        // 4月30日追記分
        private void Main_input_tb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !e.Shift)
            {
                //　e.SuppressKeyPress = true; // Enterキーの押下を抑制する
                main_send_btn.PerformClick(); // 送信ボタンをクリックします
            }
        }
    }
}
