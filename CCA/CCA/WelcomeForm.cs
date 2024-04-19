using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CCA
{
    public partial class WelcomeForm : Form
    {
        public string UserName;
        // マウスポインタの位置を保存する
        private Point mousePoint;

        public WelcomeForm()
        {
            InitializeComponent();
        }

        private void welcom_start_btn_Click(object sender, EventArgs e)
        {
            UserName = welcom_namein_tb.Text;
            this.Hide();
        }
        //マウスのボタンが押されたとき
        private void WelcomeForm_MouseDown(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                //位置を記憶する
                mousePoint = new Point(e.X, e.Y);
            }
        }
        //マウスが動いたとき
        private void WelcomeForm_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                this.Left += e.X - mousePoint.X;
                this.Top += e.Y - mousePoint.Y;
            }
        }
    }
}
