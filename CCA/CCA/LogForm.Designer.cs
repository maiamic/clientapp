namespace CCA
{
    partial class LogForm
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
            this.log_output_tb = new System.Windows.Forms.TextBox();
            this.log_end_btn = new System.Windows.Forms.Button();
            this.log_result_lb = new System.Windows.Forms.Label();
            this.log_time_tb = new System.Windows.Forms.TextBox();
            this.log_message_tb = new System.Windows.Forms.TextBox();
            this.log_name_tb = new System.Windows.Forms.TextBox();
            this.log_name_lb = new System.Windows.Forms.Label();
            this.log_message_lb = new System.Windows.Forms.Label();
            this.log_time_lb = new System.Windows.Forms.Label();
            this.log_input_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // log_output_tb
            // 
            this.log_output_tb.Location = new System.Drawing.Point(12, 3);
            this.log_output_tb.Multiline = true;
            this.log_output_tb.Name = "log_output_tb";
            this.log_output_tb.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.log_output_tb.Size = new System.Drawing.Size(554, 435);
            this.log_output_tb.TabIndex = 1;
            // 
            // log_end_btn
            // 
            this.log_end_btn.Location = new System.Drawing.Point(682, 415);
            this.log_end_btn.Name = "log_end_btn";
            this.log_end_btn.Size = new System.Drawing.Size(75, 23);
            this.log_end_btn.TabIndex = 4;
            this.log_end_btn.Text = "終了";
            this.log_end_btn.UseVisualStyleBackColor = true;
            this.log_end_btn.Click += new System.EventHandler(this.log_end_btn_Click);
            // 
            // log_result_lb
            // 
            this.log_result_lb.AutoSize = true;
            this.log_result_lb.Location = new System.Drawing.Point(601, 196);
            this.log_result_lb.Name = "log_result_lb";
            this.log_result_lb.Size = new System.Drawing.Size(109, 12);
            this.log_result_lb.TabIndex = 5;
            this.log_result_lb.Text = "検索結果は0件です。";
            // 
            // log_time_tb
            // 
            this.log_time_tb.Location = new System.Drawing.Point(572, 126);
            this.log_time_tb.Name = "log_time_tb";
            this.log_time_tb.Size = new System.Drawing.Size(201, 19);
            this.log_time_tb.TabIndex = 7;
            // 
            // log_message_tb
            // 
            this.log_message_tb.Location = new System.Drawing.Point(572, 83);
            this.log_message_tb.Name = "log_message_tb";
            this.log_message_tb.Size = new System.Drawing.Size(201, 19);
            this.log_message_tb.TabIndex = 8;
            // 
            // log_name_tb
            // 
            this.log_name_tb.Location = new System.Drawing.Point(572, 40);
            this.log_name_tb.Name = "log_name_tb";
            this.log_name_tb.Size = new System.Drawing.Size(201, 19);
            this.log_name_tb.TabIndex = 9;
            // 
            // log_name_lb
            // 
            this.log_name_lb.AutoSize = true;
            this.log_name_lb.Location = new System.Drawing.Point(572, 25);
            this.log_name_lb.Name = "log_name_lb";
            this.log_name_lb.Size = new System.Drawing.Size(65, 12);
            this.log_name_lb.TabIndex = 10;
            this.log_name_lb.Text = "ニックネーム：";
            // 
            // log_message_lb
            // 
            this.log_message_lb.AutoSize = true;
            this.log_message_lb.Location = new System.Drawing.Point(572, 68);
            this.log_message_lb.Name = "log_message_lb";
            this.log_message_lb.Size = new System.Drawing.Size(56, 12);
            this.log_message_lb.TabIndex = 11;
            this.log_message_lb.Text = "メッセージ：";
            // 
            // log_time_lb
            // 
            this.log_time_lb.AutoSize = true;
            this.log_time_lb.Location = new System.Drawing.Point(572, 111);
            this.log_time_lb.Name = "log_time_lb";
            this.log_time_lb.Size = new System.Drawing.Size(35, 12);
            this.log_time_lb.TabIndex = 12;
            this.log_time_lb.Text = "時間：";
            // 
            // log_input_btn
            // 
            this.log_input_btn.Location = new System.Drawing.Point(698, 160);
            this.log_input_btn.Name = "log_input_btn";
            this.log_input_btn.Size = new System.Drawing.Size(75, 23);
            this.log_input_btn.TabIndex = 13;
            this.log_input_btn.Text = "検索";
            this.log_input_btn.UseVisualStyleBackColor = true;
            // 
            // LogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 450);
            this.Controls.Add(this.log_input_btn);
            this.Controls.Add(this.log_time_lb);
            this.Controls.Add(this.log_message_lb);
            this.Controls.Add(this.log_name_lb);
            this.Controls.Add(this.log_name_tb);
            this.Controls.Add(this.log_message_tb);
            this.Controls.Add(this.log_time_tb);
            this.Controls.Add(this.log_result_lb);
            this.Controls.Add(this.log_end_btn);
            this.Controls.Add(this.log_output_tb);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LogForm";
            this.Text = "LogForm";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LogForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.LogForm_MouseMove);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox log_output_tb;
        private System.Windows.Forms.Button log_end_btn;
        private System.Windows.Forms.Label log_result_lb;
        private System.Windows.Forms.TextBox log_time_tb;
        private System.Windows.Forms.TextBox log_message_tb;
        private System.Windows.Forms.TextBox log_name_tb;
        private System.Windows.Forms.Label log_name_lb;
        private System.Windows.Forms.Label log_message_lb;
        private System.Windows.Forms.Label log_time_lb;
        private System.Windows.Forms.Button log_input_btn;
    }
}