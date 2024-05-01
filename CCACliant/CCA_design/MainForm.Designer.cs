namespace CCA_design
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.main_output_tb = new System.Windows.Forms.TextBox();
            this.main_send_btn = new System.Windows.Forms.Button();
            this.main_input_tb = new System.Windows.Forms.TextBox();
            this.main_log_btn = new System.Windows.Forms.Button();
            this.main_end_btn = new System.Windows.Forms.Button();
            this.main_output_lb = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.main_sarch_pb = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.main_sarch_pb)).BeginInit();
            this.SuspendLayout();
            // 
            // main_output_tb
            // 
            this.main_output_tb.BackColor = System.Drawing.SystemColors.Window;
            this.main_output_tb.Font = new System.Drawing.Font("HG丸ｺﾞｼｯｸM-PRO", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.main_output_tb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.main_output_tb.Location = new System.Drawing.Point(34, 36);
            this.main_output_tb.Multiline = true;
            this.main_output_tb.Name = "main_output_tb";
            this.main_output_tb.ReadOnly = true;
            this.main_output_tb.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.main_output_tb.Size = new System.Drawing.Size(452, 319);
            this.main_output_tb.TabIndex = 0;
            // 
            // main_send_btn
            // 
            this.main_send_btn.BackColor = System.Drawing.Color.Lime;
            this.main_send_btn.Font = new System.Drawing.Font("HG丸ｺﾞｼｯｸM-PRO", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.main_send_btn.ForeColor = System.Drawing.Color.DarkGreen;
            this.main_send_btn.Location = new System.Drawing.Point(385, 361);
            this.main_send_btn.Name = "main_send_btn";
            this.main_send_btn.Size = new System.Drawing.Size(101, 22);
            this.main_send_btn.TabIndex = 3;
            this.main_send_btn.Text = "送信";
            this.main_send_btn.UseVisualStyleBackColor = false;
            this.main_send_btn.Click += new System.EventHandler(this.main_send_btn_Click);
            // 
            // main_input_tb
            // 
            this.main_input_tb.Font = new System.Drawing.Font("HG丸ｺﾞｼｯｸM-PRO", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.main_input_tb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.main_input_tb.Location = new System.Drawing.Point(34, 363);
            this.main_input_tb.MaxLength = 100;
            this.main_input_tb.Name = "main_input_tb";
            this.main_input_tb.Size = new System.Drawing.Size(345, 20);
            this.main_input_tb.TabIndex = 4;
            this.main_input_tb.Text = "一度に送れるメッセージは100文字までです";
            this.main_input_tb.Click += new System.EventHandler(this.main_input_tb_Click);
            // 
            // main_log_btn
            // 
            this.main_log_btn.BackColor = System.Drawing.Color.White;
            this.main_log_btn.Font = new System.Drawing.Font("HG丸ｺﾞｼｯｸM-PRO", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.main_log_btn.ForeColor = System.Drawing.Color.Blue;
            this.main_log_btn.Location = new System.Drawing.Point(502, 306);
            this.main_log_btn.Name = "main_log_btn";
            this.main_log_btn.Size = new System.Drawing.Size(99, 29);
            this.main_log_btn.TabIndex = 5;
            this.main_log_btn.Text = "過去メッセージ";
            this.main_log_btn.UseVisualStyleBackColor = false;
            this.main_log_btn.Click += new System.EventHandler(this.main_log_btn_Click);
            // 
            // main_end_btn
            // 
            this.main_end_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.main_end_btn.Font = new System.Drawing.Font("HG丸ｺﾞｼｯｸM-PRO", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.main_end_btn.ForeColor = System.Drawing.Color.Red;
            this.main_end_btn.Location = new System.Drawing.Point(602, 354);
            this.main_end_btn.Name = "main_end_btn";
            this.main_end_btn.Size = new System.Drawing.Size(36, 34);
            this.main_end_btn.TabIndex = 7;
            this.main_end_btn.Text = "✖";
            this.main_end_btn.UseVisualStyleBackColor = false;
            this.main_end_btn.Click += new System.EventHandler(this.main_end_btn_Click);
            // 
            // main_output_lb
            // 
            this.main_output_lb.AutoSize = true;
            this.main_output_lb.Font = new System.Drawing.Font("HG丸ｺﾞｼｯｸM-PRO", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.main_output_lb.Location = new System.Drawing.Point(30, 8);
            this.main_output_lb.Name = "main_output_lb";
            this.main_output_lb.Size = new System.Drawing.Size(337, 15);
            this.main_output_lb.TabIndex = 8;
            this.main_output_lb.Text = "ニックネーム：チャットログの順で表示されます";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CCA_design.Properties.Resources.ふきだし1;
            this.pictureBox1.Location = new System.Drawing.Point(492, 93);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(155, 111);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // main_sarch_pb
            // 
            this.main_sarch_pb.Image = ((System.Drawing.Image)(resources.GetObject("main_sarch_pb.Image")));
            this.main_sarch_pb.Location = new System.Drawing.Point(492, 292);
            this.main_sarch_pb.Name = "main_sarch_pb";
            this.main_sarch_pb.Size = new System.Drawing.Size(146, 56);
            this.main_sarch_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.main_sarch_pb.TabIndex = 6;
            this.main_sarch_pb.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(650, 400);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.main_output_lb);
            this.Controls.Add(this.main_end_btn);
            this.Controls.Add(this.main_log_btn);
            this.Controls.Add(this.main_input_tb);
            this.Controls.Add(this.main_send_btn);
            this.Controls.Add(this.main_output_tb);
            this.Controls.Add(this.main_sarch_pb);
            this.Cursor = System.Windows.Forms.Cursors.PanNW;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.main_sarch_pb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox main_output_tb;
        private System.Windows.Forms.Button main_send_btn;
        private System.Windows.Forms.TextBox main_input_tb;
        private System.Windows.Forms.Button main_log_btn;
        private System.Windows.Forms.PictureBox main_sarch_pb;
        private System.Windows.Forms.Button main_end_btn;
        private System.Windows.Forms.Label main_output_lb;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}