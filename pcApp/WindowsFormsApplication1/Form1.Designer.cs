namespace WindowsFormsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.outPutText = new System.Windows.Forms.RichTextBox();
            this.sendBox = new System.Windows.Forms.CheckBox();
            this.receviceBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "开始通信";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.beginSerial);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(179, 13);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(90, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "结束通信";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.endSerial);
            this.button2.Enabled = false;
            // 
            // outPutText
            // 
            this.outPutText.Location = new System.Drawing.Point(13, 59);
            this.outPutText.Name = "outPutText";
            this.outPutText.Size = new System.Drawing.Size(456, 180);
            this.outPutText.TabIndex = 2;
            this.outPutText.Text = "";
            // 
            // sendBox
            // 
            this.sendBox.AutoSize = true;
            this.sendBox.Location = new System.Drawing.Point(314, 17);
            this.sendBox.Name = "sendBox";
            this.sendBox.Size = new System.Drawing.Size(48, 16);
            this.sendBox.TabIndex = 3;
            this.sendBox.Text = "发送";
            this.sendBox.UseVisualStyleBackColor = true;
            // 
            // receviceBox
            // 
            this.receviceBox.AutoSize = true;
            this.receviceBox.Location = new System.Drawing.Point(383, 17);
            this.receviceBox.Name = "receviceBox";
            this.receviceBox.Size = new System.Drawing.Size(48, 16);
            this.receviceBox.TabIndex = 4;
            this.receviceBox.Text = "接收";
            this.receviceBox.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 283);
            this.Controls.Add(this.receviceBox);
            this.Controls.Add(this.sendBox);
            this.Controls.Add(this.outPutText);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RichTextBox outPutText;
        private System.Windows.Forms.CheckBox sendBox;
        private System.Windows.Forms.CheckBox receviceBox;
    }
}

