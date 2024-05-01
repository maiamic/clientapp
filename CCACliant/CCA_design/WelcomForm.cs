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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CCA_design
{
    public partial class WelcomForm : Form
    {
        //ニックネーム
        public string UserName;
        public WelcomForm()
        {
            InitializeComponent();
        }

        private void welcom_a_pb_Click(object sender, EventArgs e)
        {
            MessageBox.Show("CCA(コミュニケーションチャットアプリ)にようこそ！" + Environment.NewLine +
                "ニックネームを入力して、【はじめる】を押してね" + Environment.NewLine +
                "ニックネームを決めないときは「匿名」になります");

        }
        //開始ボタン
        private void welcome_start_btn_Click(object sender, EventArgs e)
        {
            //ニックネーム入力しないとき　
            if (welcom_namein_tb.Text == "")
            {
                UserName = "匿名さん";
            }
            //するとき
            else
            {
                UserName = welcom_namein_tb.Text;
            }

            // ここでサーバーに接続します。
            try
            {// サーバーPC　IP　172.31.98.77　　ローカル　127.0.0.1
                Program.client = new TcpClient("172.31.98.77", 34567); //"127.0.0.1"はローカルホストアドレスです。
                Program.stream = Program.client.GetStream();
            }

            //接続できないときは
            catch (Exception ex)
            {
                MessageBox.Show("Error connecting to server: " + ex.Message);
                Program.client?.Close();
                Program.stream?.Close();
                this.Close();
            }
            //MeinFormを開いて、UserNameとこのformの情報を引数で渡している
            MainForm mf = new MainForm(UserName,this);
            mf.Show();
            //フォーム隠す
            this.Hide();
        }
        //名前を入力するボックスをクリックしたとき上にあるラベルが非表示になる
        private void welcom_namein_tb_Click(object sender, EventArgs e)
        {
            welcom_namein_lb.Visible = false;
        }

        private void welcom_namein_tb_TextChanged(object sender, EventArgs e)
        {
            welcom_namein_lb.Visible = false;
        }
    }
    }

