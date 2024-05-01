namespace CCAServer
{
    partial class MainForm
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.getdata_btn = new System.Windows.Forms.Button();
            this.reception_btn = new System.Windows.Forms.Button();
            this.logTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 21;
            this.dataGridView1.Size = new System.Drawing.Size(618, 368);
            this.dataGridView1.TabIndex = 2;
            // 
            // getdata_btn
            // 
            this.getdata_btn.Location = new System.Drawing.Point(12, 386);
            this.getdata_btn.Name = "getdata_btn";
            this.getdata_btn.Size = new System.Drawing.Size(618, 42);
            this.getdata_btn.TabIndex = 3;
            this.getdata_btn.Text = "データ取得";
            this.getdata_btn.UseVisualStyleBackColor = true;
            this.getdata_btn.Click += new System.EventHandler(this.getdata_btn_Click);
            // 
            // reception_btn
            // 
            this.reception_btn.Location = new System.Drawing.Point(636, 386);
            this.reception_btn.Name = "reception_btn";
            this.reception_btn.Size = new System.Drawing.Size(152, 42);
            this.reception_btn.TabIndex = 4;
            this.reception_btn.Text = "受信開始";
            this.reception_btn.UseVisualStyleBackColor = true;
            this.reception_btn.Click += new System.EventHandler(this.reception_btn_Click);
            // 
            // logTextBox
            // 
            this.logTextBox.Location = new System.Drawing.Point(636, 12);
            this.logTextBox.Multiline = true;
            this.logTextBox.Name = "logTextBox";
            this.logTextBox.ReadOnly = true;
            this.logTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.logTextBox.Size = new System.Drawing.Size(152, 368);
            this.logTextBox.TabIndex = 5;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.logTextBox);
            this.Controls.Add(this.reception_btn);
            this.Controls.Add(this.getdata_btn);
            this.Controls.Add(this.dataGridView1);
            this.Name = "MainForm";
            this.Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button getdata_btn;
        private System.Windows.Forms.Button reception_btn;
        private System.Windows.Forms.TextBox logTextBox;
    }
}

