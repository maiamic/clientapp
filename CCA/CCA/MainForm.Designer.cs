namespace CCA
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
            this.main_end_btn = new System.Windows.Forms.Button();
            this.main_log_btn = new System.Windows.Forms.Button();
            this.main_send_btn = new System.Windows.Forms.Button();
            this.main_output_tb = new System.Windows.Forms.TextBox();
            this.main_input_tb = new System.Windows.Forms.TextBox();
            this.main_inplayer_lb = new System.Windows.Forms.Label();
            this.main_connect_lbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // main_end_btn
            // 
            this.main_end_btn.Location = new System.Drawing.Point(673, 386);
            this.main_end_btn.Name = "main_end_btn";
            this.main_end_btn.Size = new System.Drawing.Size(75, 23);
            this.main_end_btn.TabIndex = 0;
            this.main_end_btn.Text = "終了";
            this.main_end_btn.UseVisualStyleBackColor = true;
            this.main_end_btn.Click += new System.EventHandler(this.main_end_btn_Click);
            // 
            // main_log_btn
            // 
            this.main_log_btn.Location = new System.Drawing.Point(673, 256);
            this.main_log_btn.Name = "main_log_btn";
            this.main_log_btn.Size = new System.Drawing.Size(96, 23);
            this.main_log_btn.TabIndex = 1;
            this.main_log_btn.Text = "過去メッセージ";
            this.main_log_btn.UseVisualStyleBackColor = true;
            this.main_log_btn.Click += new System.EventHandler(this.main_log_btn_Click);
            // 
            // main_send_btn
            // 
            this.main_send_btn.Location = new System.Drawing.Point(421, 386);
            this.main_send_btn.Name = "main_send_btn";
            this.main_send_btn.Size = new System.Drawing.Size(75, 23);
            this.main_send_btn.TabIndex = 2;
            this.main_send_btn.Text = "送信";
            this.main_send_btn.UseVisualStyleBackColor = true;
            this.main_send_btn.Click += new System.EventHandler(this.main_send_btn_Click);
            // 
            // main_output_tb
            // 
            this.main_output_tb.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.main_output_tb.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.main_output_tb.Location = new System.Drawing.Point(12, 12);
            this.main_output_tb.Multiline = true;
            this.main_output_tb.Name = "main_output_tb";
            this.main_output_tb.ReadOnly = true;
            this.main_output_tb.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.main_output_tb.Size = new System.Drawing.Size(623, 351);
            this.main_output_tb.TabIndex = 6;
            // 
            // main_input_tb
            // 
            this.main_input_tb.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.main_input_tb.Location = new System.Drawing.Point(61, 379);
            this.main_input_tb.Multiline = true;
            this.main_input_tb.Name = "main_input_tb";
            this.main_input_tb.Size = new System.Drawing.Size(343, 30);
            this.main_input_tb.TabIndex = 7;
            // 
            // main_inplayer_lb
            // 
            this.main_inplayer_lb.AutoSize = true;
            this.main_inplayer_lb.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.main_inplayer_lb.Location = new System.Drawing.Point(666, 54);
            this.main_inplayer_lb.Name = "main_inplayer_lb";
            this.main_inplayer_lb.Size = new System.Drawing.Size(103, 16);
            this.main_inplayer_lb.TabIndex = 8;
            this.main_inplayer_lb.Text = "〇〇人接続中";
            // 
            // main_connect_lbl
            // 
            this.main_connect_lbl.AutoSize = true;
            this.main_connect_lbl.Location = new System.Drawing.Point(671, 92);
            this.main_connect_lbl.Name = "main_connect_lbl";
            this.main_connect_lbl.Size = new System.Drawing.Size(41, 12);
            this.main_connect_lbl.TabIndex = 10;
            this.main_connect_lbl.Text = "未接続";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.main_connect_lbl);
            this.Controls.Add(this.main_inplayer_lb);
            this.Controls.Add(this.main_input_tb);
            this.Controls.Add(this.main_output_tb);
            this.Controls.Add(this.main_send_btn);
            this.Controls.Add(this.main_log_btn);
            this.Controls.Add(this.main_end_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseMove);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button main_end_btn;
        private System.Windows.Forms.Button main_log_btn;
        private System.Windows.Forms.Button main_send_btn;
        private System.Windows.Forms.TextBox main_output_tb;
        private System.Windows.Forms.TextBox main_input_tb;
        private System.Windows.Forms.Label main_inplayer_lb;
        private System.Windows.Forms.Label main_connect_lbl;
    }
}