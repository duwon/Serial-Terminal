namespace SerialTerminal
{
    partial class SerialForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SerialForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.debugText = new System.Windows.Forms.TextBox();
            this.debugHex = new System.Windows.Forms.TextBox();
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.cbPortName = new System.Windows.Forms.ComboBox();
            this.tbBoudrate = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCOMOpen = new System.Windows.Forms.Button();
            this.panel_sendData = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.sbOpacity = new System.Windows.Forms.HScrollBar();
            this.btnFileSend = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Location = new System.Drawing.Point(0, 309);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.debugText);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.debugHex);
            this.splitContainer1.Size = new System.Drawing.Size(985, 252);
            this.splitContainer1.SplitterDistance = 497;
            this.splitContainer1.TabIndex = 17;
            // 
            // debugText
            // 
            this.debugText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.debugText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.debugText.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.debugText.Location = new System.Drawing.Point(0, 0);
            this.debugText.Multiline = true;
            this.debugText.Name = "debugText";
            this.debugText.ReadOnly = true;
            this.debugText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.debugText.Size = new System.Drawing.Size(495, 250);
            this.debugText.TabIndex = 0;
            this.debugText.Text = "TEXT\r\n";
            // 
            // debugHex
            // 
            this.debugHex.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.debugHex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.debugHex.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.debugHex.Location = new System.Drawing.Point(0, 0);
            this.debugHex.Multiline = true;
            this.debugHex.Name = "debugHex";
            this.debugHex.ReadOnly = true;
            this.debugHex.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.debugHex.Size = new System.Drawing.Size(482, 250);
            this.debugHex.TabIndex = 0;
            this.debugHex.Text = "HEX \r\n";
            // 
            // serialPort
            // 
            this.serialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort_DataReceived);
            // 
            // cbPortName
            // 
            this.cbPortName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbPortName.DropDownWidth = 80;
            this.cbPortName.FormattingEnabled = true;
            this.cbPortName.Location = new System.Drawing.Point(3, 4);
            this.cbPortName.Name = "cbPortName";
            this.cbPortName.Size = new System.Drawing.Size(67, 23);
            this.cbPortName.Sorted = true;
            this.cbPortName.TabIndex = 19;
            // 
            // tbBoudrate
            // 
            this.tbBoudrate.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbBoudrate.Location = new System.Drawing.Point(3, 32);
            this.tbBoudrate.Name = "tbBoudrate";
            this.tbBoudrate.Size = new System.Drawing.Size(67, 22);
            this.tbBoudrate.TabIndex = 21;
            this.tbBoudrate.Text = "115200";
            this.tbBoudrate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tbBoudrate);
            this.panel1.Controls.Add(this.btnCOMOpen);
            this.panel1.Controls.Add(this.cbPortName);
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(75, 88);
            this.panel1.TabIndex = 22;
            // 
            // btnCOMOpen
            // 
            this.btnCOMOpen.BackgroundImage = global::SerialTerminal.Properties.Resources.btnRClose;
            this.btnCOMOpen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCOMOpen.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.btnCOMOpen.FlatAppearance.BorderSize = 0;
            this.btnCOMOpen.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.btnCOMOpen.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.btnCOMOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCOMOpen.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCOMOpen.Location = new System.Drawing.Point(3, 58);
            this.btnCOMOpen.Margin = new System.Windows.Forms.Padding(0);
            this.btnCOMOpen.Name = "btnCOMOpen";
            this.btnCOMOpen.Size = new System.Drawing.Size(67, 25);
            this.btnCOMOpen.TabIndex = 18;
            this.btnCOMOpen.Text = "OPEN";
            this.btnCOMOpen.UseVisualStyleBackColor = true;
            this.btnCOMOpen.Click += new System.EventHandler(this.btnCOMOpen_Click);
            // 
            // panel_sendData
            // 
            this.panel_sendData.Location = new System.Drawing.Point(316, 1);
            this.panel_sendData.Name = "panel_sendData";
            this.panel_sendData.Size = new System.Drawing.Size(667, 302);
            this.panel_sendData.TabIndex = 24;
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::SerialTerminal.Properties.Resources.btnLEDRed;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(129, 46);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(38, 38);
            this.button1.TabIndex = 25;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.MouseLeave += new System.EventHandler(this.button1_MouseLeave);
            this.button1.MouseHover += new System.EventHandler(this.button1_MouseHover);
            // 
            // button2
            // 
            this.button2.BackgroundImage = global::SerialTerminal.Properties.Resources.btnLEDGreen;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(173, 46);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(38, 38);
            this.button2.TabIndex = 26;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.BackgroundImage = global::SerialTerminal.Properties.Resources.btnLEDYellow;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(217, 46);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(38, 38);
            this.button3.TabIndex = 27;
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.BackgroundImage = global::SerialTerminal.Properties.Resources.btnLEDGray;
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.button4.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Location = new System.Drawing.Point(261, 46);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(38, 38);
            this.button4.TabIndex = 28;
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.BackgroundImage = global::SerialTerminal.Properties.Resources.btnLEDBlue;
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.button5.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Location = new System.Drawing.Point(85, 46);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(38, 38);
            this.button5.TabIndex = 29;
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // sbOpacity
            // 
            this.sbOpacity.Location = new System.Drawing.Point(86, 9);
            this.sbOpacity.Name = "sbOpacity";
            this.sbOpacity.Size = new System.Drawing.Size(213, 22);
            this.sbOpacity.TabIndex = 31;
            this.sbOpacity.Value = 100;
            this.sbOpacity.Scroll += new System.Windows.Forms.ScrollEventHandler(this.sbOpacity_Scroll);
            // 
            // btnFileSend
            // 
            this.btnFileSend.Location = new System.Drawing.Point(27, 126);
            this.btnFileSend.Name = "btnFileSend";
            this.btnFileSend.Size = new System.Drawing.Size(75, 23);
            this.btnFileSend.TabIndex = 32;
            this.btnFileSend.Text = "button6";
            this.btnFileSend.UseVisualStyleBackColor = true;
            this.btnFileSend.Click += new System.EventHandler(this.btnFileSendSend_Click);
            // 
            // SerialForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(985, 561);
            this.Controls.Add(this.btnFileSend);
            this.Controls.Add(this.sbOpacity);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel_sendData);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "SerialForm";
            this.Opacity = 0.99D;
            this.Text = "시리얼통신 테스트 프로그램";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SerialForm_FormClosing);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox debugText;
        private System.Windows.Forms.TextBox debugHex;
        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.ComboBox cbPortName;
        private System.Windows.Forms.Button btnCOMOpen;
        private System.Windows.Forms.TextBox tbBoudrate;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel_sendData;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.HScrollBar sbOpacity;
        private System.Windows.Forms.Button btnFileSend;
    }
}