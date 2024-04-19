using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CCA
{
    public partial class MainForm : Form
    {
        public string Name;
        // マウスポインタの位置を保存する
        private Point mousePoint;

        public LogForm f = new LogForm();
        public MainForm()
        {
            InitializeComponent();
            Start();
        }

        private void main_end_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void Start()
        {
            WelcomeForm f = new WelcomeForm();
            f.ShowDialog();
            Name = f.UserName;
            f.Close();
        }

        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                //位置を記憶する
                mousePoint = new Point(e.X, e.Y);
            }
        }

        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                this.Left += e.X - mousePoint.X;
                this.Top += e.Y - mousePoint.Y;
            }
        }

        private void main_log_btn_Click(object sender, EventArgs e)
        {

            //ログ画面を複数開かないようにする奴
            if (f.IsDisposed)
                f = new LogForm();
            f.MdiParent = this.MdiParent;
            f.Show();
            f.BringToFront();
        }

        private void main_send_btn_Click(object sender, EventArgs e)
        {

        }
    }
}
