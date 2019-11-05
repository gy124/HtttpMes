namespace UI
{
    partial class form
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.comboBox_Port = new System.Windows.Forms.ComboBox();
            this.comboBox_BaudRate = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button_Send = new System.Windows.Forms.Button();
            this.textBox_Send = new System.Windows.Forms.TextBox();
            this.button_Switch = new System.Windows.Forms.Button();
            this.textBox_Receive = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.radioButton_Hex = new System.Windows.Forms.RadioButton();
            this.radioButton_ASCII = new System.Windows.Forms.RadioButton();
            this.radioButton_UTF8 = new System.Windows.Forms.RadioButton();
            this.radioButton_Unicode = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox_DataBits = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox_StopBits = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBox_Port
            // 
            this.comboBox_Port.FormattingEnabled = true;
            this.comboBox_Port.Location = new System.Drawing.Point(11, 28);
            this.comboBox_Port.Name = "comboBox_Port";
            this.comboBox_Port.Size = new System.Drawing.Size(73, 20);
            this.comboBox_Port.TabIndex = 0;
           // this.comboBox_Port.SelectedIndexChanged += new System.EventHandler(this.comboBox_Port_SelectedIndexChanged);
            // 
            // comboBox_BaudRate
            // 
            this.comboBox_BaudRate.FormattingEnabled = true;
            this.comboBox_BaudRate.Items.AddRange(new object[] {
            "600",
            "1200",
            "2400",
            "4800",
            "9600",
            "14400",
            "19200"});
            this.comboBox_BaudRate.Location = new System.Drawing.Point(11, 75);
            this.comboBox_BaudRate.Name = "comboBox_BaudRate";
            this.comboBox_BaudRate.Size = new System.Drawing.Size(69, 20);
            this.comboBox_BaudRate.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "串口选择";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "波特率";
            // 
            // button_Send
            // 
            this.button_Send.Location = new System.Drawing.Point(89, 193);
            this.button_Send.Name = "button_Send";
            this.button_Send.Size = new System.Drawing.Size(59, 23);
            this.button_Send.TabIndex = 4;
            this.button_Send.Text = "发送";
            this.button_Send.UseVisualStyleBackColor = true;
            this.button_Send.Click += new System.EventHandler(this.button_Send_Click_1);
            // 
            // textBox_Send
            // 
            this.textBox_Send.Location = new System.Drawing.Point(27, 166);
            this.textBox_Send.Name = "textBox_Send";
            this.textBox_Send.Size = new System.Drawing.Size(121, 21);
            this.textBox_Send.TabIndex = 5;
            // 
            // button_Switch
            // 
            this.button_Switch.Location = new System.Drawing.Point(27, 193);
            this.button_Switch.Name = "button_Switch";
            this.button_Switch.Size = new System.Drawing.Size(50, 23);
            this.button_Switch.TabIndex = 6;
            this.button_Switch.Text = "开关";
            this.button_Switch.UseVisualStyleBackColor = true;
            this.button_Switch.Click += new System.EventHandler(this.button_Switch_Click_1);
            // 
            // textBox_Receive
            // 
            this.textBox_Receive.Location = new System.Drawing.Point(27, 241);
            this.textBox_Receive.Name = "textBox_Receive";
            this.textBox_Receive.Size = new System.Drawing.Size(121, 21);
            this.textBox_Receive.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(95, 226);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "接收数据";
            // 
            // radioButton_Hex
            // 
            this.radioButton_Hex.AutoSize = true;
            this.radioButton_Hex.Location = new System.Drawing.Point(29, 115);
            this.radioButton_Hex.Name = "radioButton_Hex";
            this.radioButton_Hex.Size = new System.Drawing.Size(41, 16);
            this.radioButton_Hex.TabIndex = 9;
            this.radioButton_Hex.TabStop = true;
            this.radioButton_Hex.Text = "hex";
            this.radioButton_Hex.UseVisualStyleBackColor = true;
            // 
            // radioButton_ASCII
            // 
            this.radioButton_ASCII.AutoSize = true;
            this.radioButton_ASCII.Location = new System.Drawing.Point(89, 115);
            this.radioButton_ASCII.Name = "radioButton_ASCII";
            this.radioButton_ASCII.Size = new System.Drawing.Size(53, 16);
            this.radioButton_ASCII.TabIndex = 10;
            this.radioButton_ASCII.TabStop = true;
            this.radioButton_ASCII.Text = "ascII";
            this.radioButton_ASCII.UseVisualStyleBackColor = true;
            // 
            // radioButton_UTF8
            // 
            this.radioButton_UTF8.AutoSize = true;
            this.radioButton_UTF8.Location = new System.Drawing.Point(29, 137);
            this.radioButton_UTF8.Name = "radioButton_UTF8";
            this.radioButton_UTF8.Size = new System.Drawing.Size(53, 16);
            this.radioButton_UTF8.TabIndex = 11;
            this.radioButton_UTF8.TabStop = true;
            this.radioButton_UTF8.Text = "uint8";
            this.radioButton_UTF8.UseVisualStyleBackColor = true;
            // 
            // radioButton_Unicode
            // 
            this.radioButton_Unicode.AutoSize = true;
            this.radioButton_Unicode.Location = new System.Drawing.Point(88, 137);
            this.radioButton_Unicode.Name = "radioButton_Unicode";
            this.radioButton_Unicode.Size = new System.Drawing.Size(65, 16);
            this.radioButton_Unicode.TabIndex = 12;
            this.radioButton_Unicode.TabStop = true;
            this.radioButton_Unicode.Text = "undefin";
            this.radioButton_Unicode.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(95, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 14;
            this.label4.Text = "数据位";
         //   this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // comboBox_DataBits
            // 
            this.comboBox_DataBits.FormattingEnabled = true;
            this.comboBox_DataBits.Items.AddRange(new object[] {
            "8",
            "16",
            "32",
            "64",
            "128"});
            this.comboBox_DataBits.Location = new System.Drawing.Point(95, 28);
            this.comboBox_DataBits.Name = "comboBox_DataBits";
            this.comboBox_DataBits.Size = new System.Drawing.Size(69, 20);
            this.comboBox_DataBits.TabIndex = 13;
         //   this.comboBox_DataBits.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(93, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 16;
            this.label5.Text = "停止位";
            // 
            // comboBox_StopBits
            // 
            this.comboBox_StopBits.FormattingEnabled = true;
            this.comboBox_StopBits.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.comboBox_StopBits.Location = new System.Drawing.Point(93, 75);
            this.comboBox_StopBits.Name = "comboBox_StopBits";
            this.comboBox_StopBits.Size = new System.Drawing.Size(69, 20);
            this.comboBox_StopBits.TabIndex = 15;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.comboBox_Port);
            this.panel1.Controls.Add(this.comboBox_StopBits);
            this.panel1.Controls.Add(this.comboBox_BaudRate);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.comboBox_DataBits);
            this.panel1.Controls.Add(this.button_Send);
            this.panel1.Controls.Add(this.radioButton_Unicode);
            this.panel1.Controls.Add(this.textBox_Send);
            this.panel1.Controls.Add(this.radioButton_UTF8);
            this.panel1.Controls.Add(this.button_Switch);
            this.panel1.Controls.Add(this.radioButton_ASCII);
            this.panel1.Controls.Add(this.textBox_Receive);
            this.panel1.Controls.Add(this.radioButton_Hex);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(177, 287);
            this.panel1.TabIndex = 17;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "form";
            this.Size = new System.Drawing.Size(198, 304);
          //  this.Load += new System.EventHandler(this.UserControl1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_Port;
        private System.Windows.Forms.ComboBox comboBox_BaudRate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_Send;
        private System.Windows.Forms.TextBox textBox_Send;
        private System.Windows.Forms.Button button_Switch;
        private System.Windows.Forms.TextBox textBox_Receive;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton radioButton_Hex;
        private System.Windows.Forms.RadioButton radioButton_ASCII;
        private System.Windows.Forms.RadioButton radioButton_UTF8;
        private System.Windows.Forms.RadioButton radioButton_Unicode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox_DataBits;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox_StopBits;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Timer timer1;
    }
}
