namespace ssms.Pages.Items
{
    partial class ScanItemsInStore
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxStore = new System.Windows.Forms.ComboBox();
            this.button4 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnC = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbxMissing = new System.Windows.Forms.ListBox();
            this.lbxIn = new System.Windows.Forms.ListBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbReader = new System.Windows.Forms.ListBox();
            this.setName = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblConnect = new System.Windows.Forms.Label();
            this.lblStartRead = new System.Windows.Forms.Label();
            this.lblStop = new System.Windows.Forms.Label();
            this.lblSelect = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(452, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 19);
            this.label2.TabIndex = 323;
            this.label2.Text = "Store Name:";
            // 
            // comboBoxStore
            // 
            this.comboBoxStore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxStore.FormattingEnabled = true;
            this.comboBoxStore.Location = new System.Drawing.Point(562, 12);
            this.comboBoxStore.Name = "comboBoxStore";
            this.comboBoxStore.Size = new System.Drawing.Size(245, 28);
            this.comboBoxStore.TabIndex = 322;
            this.comboBoxStore.SelectedIndexChanged += new System.EventHandler(this.comboBoxStore_SelectedIndexChanged);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Silver;
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button4.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Location = new System.Drawing.Point(813, 3);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(196, 46);
            this.button4.TabIndex = 318;
            this.button4.Text = "Export PDF";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(14, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(269, 33);
            this.label1.TabIndex = 316;
            this.label1.Text = "Scan Items in Store";
            // 
            // btnC
            // 
            this.btnC.BackColor = System.Drawing.Color.White;
            this.btnC.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnC.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnC.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnC.ForeColor = System.Drawing.Color.DimGray;
            this.btnC.Image = global::ssms.Properties.Resources.icons8_RFID_Signal_64;
            this.btnC.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnC.Location = new System.Drawing.Point(3, 87);
            this.btnC.Name = "btnC";
            this.btnC.Size = new System.Drawing.Size(150, 35);
            this.btnC.TabIndex = 329;
            this.btnC.Text = "Connect";
            this.btnC.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnC.UseVisualStyleBackColor = false;
            this.btnC.Click += new System.EventHandler(this.button5_Click);
            // 
            // btnStart
            // 
            this.btnStart.BackgroundImage = global::ssms.Properties.Resources.play_button__1_;
            this.btnStart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnStart.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.btnStart.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStart.Location = new System.Drawing.Point(3, 129);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(67, 47);
            this.btnStart.TabIndex = 327;
            this.btnStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnStop
            // 
            this.btnStop.BackgroundImage = global::ssms.Properties.Resources.stop;
            this.btnStop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnStop.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.btnStop.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnStop.Location = new System.Drawing.Point(3, 182);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(67, 47);
            this.btnStop.TabIndex = 326;
            this.btnStop.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackgroundImage = global::ssms.Properties.Resources.reply__1_;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.button2.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button2.Location = new System.Drawing.Point(948, 408);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(61, 113);
            this.button2.TabIndex = 325;
            this.button2.Text = "Back";
            this.button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DimGray;
            this.label6.Location = new System.Drawing.Point(67, 138);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 22);
            this.label6.TabIndex = 332;
            this.label6.Text = "Start";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 14.25F);
            this.label7.ForeColor = System.Drawing.Color.DimGray;
            this.label7.Location = new System.Drawing.Point(67, 191);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 22);
            this.label7.TabIndex = 333;
            this.label7.Text = "Stop";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(587, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(124, 23);
            this.label5.TabIndex = 337;
            this.label5.Text = "Missing Items";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(318, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 23);
            this.label4.TabIndex = 336;
            this.label4.Text = "Inventory";
            // 
            // lbxMissing
            // 
            this.lbxMissing.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbxMissing.ForeColor = System.Drawing.Color.Red;
            this.lbxMissing.FormattingEnabled = true;
            this.lbxMissing.HorizontalScrollbar = true;
            this.lbxMissing.ItemHeight = 19;
            this.lbxMissing.Location = new System.Drawing.Point(514, 119);
            this.lbxMissing.Name = "lbxMissing";
            this.lbxMissing.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lbxMissing.Size = new System.Drawing.Size(261, 346);
            this.lbxMissing.TabIndex = 335;
            // 
            // lbxIn
            // 
            this.lbxIn.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbxIn.ForeColor = System.Drawing.Color.Black;
            this.lbxIn.FormattingEnabled = true;
            this.lbxIn.HorizontalScrollbar = true;
            this.lbxIn.ItemHeight = 19;
            this.lbxIn.Location = new System.Drawing.Point(235, 119);
            this.lbxIn.Name = "lbxIn";
            this.lbxIn.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lbxIn.Size = new System.Drawing.Size(261, 346);
            this.lbxIn.TabIndex = 334;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbReader);
            this.panel1.Controls.Add(this.setName);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(795, 119);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(219, 194);
            this.panel1.TabIndex = 338;
            this.panel1.Visible = false;
            // 
            // lbReader
            // 
            this.lbReader.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbReader.FormattingEnabled = true;
            this.lbReader.ItemHeight = 16;
            this.lbReader.Location = new System.Drawing.Point(18, 44);
            this.lbReader.Name = "lbReader";
            this.lbReader.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lbReader.Size = new System.Drawing.Size(183, 132);
            this.lbReader.TabIndex = 3;
            // 
            // setName
            // 
            this.setName.AutoSize = true;
            this.setName.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setName.Location = new System.Drawing.Point(119, 19);
            this.setName.Name = "setName";
            this.setName.Size = new System.Drawing.Size(0, 14);
            this.setName.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 44);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(0, 13);
            this.label8.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 14);
            this.label3.TabIndex = 0;
            this.label3.Text = "Settings Name:";
            // 
            // lblConnect
            // 
            this.lblConnect.AutoSize = true;
            this.lblConnect.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConnect.ForeColor = System.Drawing.Color.Red;
            this.lblConnect.Location = new System.Drawing.Point(17, 268);
            this.lblConnect.Name = "lblConnect";
            this.lblConnect.Size = new System.Drawing.Size(85, 16);
            this.lblConnect.TabIndex = 339;
            this.lblConnect.Text = "Connecting...";
            this.lblConnect.Visible = false;
            // 
            // lblStartRead
            // 
            this.lblStartRead.AutoSize = true;
            this.lblStartRead.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStartRead.ForeColor = System.Drawing.Color.Red;
            this.lblStartRead.Location = new System.Drawing.Point(17, 309);
            this.lblStartRead.Name = "lblStartRead";
            this.lblStartRead.Size = new System.Drawing.Size(65, 16);
            this.lblStartRead.TabIndex = 340;
            this.lblStartRead.Text = "Starting...";
            this.lblStartRead.Visible = false;
            // 
            // lblStop
            // 
            this.lblStop.AutoSize = true;
            this.lblStop.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStop.ForeColor = System.Drawing.Color.Red;
            this.lblStop.Location = new System.Drawing.Point(17, 353);
            this.lblStop.Name = "lblStop";
            this.lblStop.Size = new System.Drawing.Size(71, 16);
            this.lblStop.TabIndex = 341;
            this.lblStop.Text = "Stopping...";
            this.lblStop.Visible = false;
            // 
            // lblSelect
            // 
            this.lblSelect.AutoSize = true;
            this.lblSelect.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelect.ForeColor = System.Drawing.Color.Red;
            this.lblSelect.Location = new System.Drawing.Point(559, 43);
            this.lblSelect.Name = "lblSelect";
            this.lblSelect.Size = new System.Drawing.Size(203, 16);
            this.lblSelect.TabIndex = 342;
            this.lblSelect.Text = "Please select a valid Store Name!";
            this.lblSelect.Visible = false;
            // 
            // ScanItemsInStore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblSelect);
            this.Controls.Add(this.lblStop);
            this.Controls.Add(this.lblStartRead);
            this.Controls.Add(this.lblConnect);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbxMissing);
            this.Controls.Add(this.lbxIn);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnC);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxStore);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label1);
            this.Name = "ScanItemsInStore";
            this.Size = new System.Drawing.Size(1031, 532);
            this.Load += new System.EventHandler(this.ScanItemsInStore_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxStore;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnStart;
        public System.Windows.Forms.Button btnC;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox lbxMissing;
        private System.Windows.Forms.ListBox lbxIn;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label setName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lbReader;
        private System.Windows.Forms.Label lblConnect;
        private System.Windows.Forms.Label lblStartRead;
        private System.Windows.Forms.Label lblStop;
        private System.Windows.Forms.Label lblSelect;
    }
}
