namespace CCA
{
    partial class WelcomeForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.welcom_start_btn = new System.Windows.Forms.Button();
            this.welcom_msg_lb = new System.Windows.Forms.Label();
            this.welcom_start_lb = new System.Windows.Forms.Label();
            this.welcom_namein_tb = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // welcom_start_btn
            // 
            this.welcom_start_btn.Location = new System.Drawing.Point(594, 365);
            this.welcom_start_btn.Name = "welcom_start_btn";
            this.welcom_start_btn.Size = new System.Drawing.Size(75, 23);
            this.welcom_start_btn.TabIndex = 0;
            this.welcom_start_btn.Text = "始める";
            this.welcom_start_btn.UseVisualStyleBackColor = true;
            this.welcom_start_btn.Click += new System.EventHandler(this.welcom_start_btn_Click);
            // 
            // welcom_msg_lb
            // 
            this.welcom_msg_lb.AutoSize = true;
            this.welcom_msg_lb.Font = new System.Drawing.Font("MS UI Gothic", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.welcom_msg_lb.Location = new System.Drawing.Point(145, 83);
            this.welcom_msg_lb.Name = "welcom_msg_lb";
            this.welcom_msg_lb.Size = new System.Drawing.Size(404, 64);
            this.welcom_msg_lb.TabIndex = 1;
            this.welcom_msg_lb.Text = "ようこそ！！！";
            // 
            // welcom_start_lb
            // 
            this.welcom_start_lb.AutoSize = true;
            this.welcom_start_lb.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.welcom_start_lb.Location = new System.Drawing.Point(61, 211);
            this.welcom_start_lb.Name = "welcom_start_lb";
            this.welcom_start_lb.Size = new System.Drawing.Size(320, 32);
            this.welcom_start_lb.TabIndex = 2;
            this.welcom_start_lb.Text = "ニックネームを入力してください。\r\n※６文字まで！未入力だと匿名で参加できるよ！";
            // 
            // welcom_namein_tb
            // 
            this.welcom_namein_tb.Location = new System.Drawing.Point(408, 224);
            this.welcom_namein_tb.Name = "welcom_namein_tb";
            this.welcom_namein_tb.Size = new System.Drawing.Size(122, 19);
            this.welcom_namein_tb.TabIndex = 3;
            // 
            // WelcomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 420);
            this.Controls.Add(this.welcom_namein_tb);
            this.Controls.Add(this.welcom_start_lb);
            this.Controls.Add(this.welcom_msg_lb);
            this.Controls.Add(this.welcom_start_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "WelcomeForm";
            this.Text = "WelcomeForm";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.WelcomeForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.WelcomeForm_MouseMove);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button welcom_start_btn;
        private System.Windows.Forms.Label welcom_msg_lb;
        private System.Windows.Forms.Label welcom_start_lb;
        private System.Windows.Forms.TextBox welcom_namein_tb;
    }
}

