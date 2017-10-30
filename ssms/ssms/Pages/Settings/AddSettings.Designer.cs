namespace ssms.Pages.Settings
{
    partial class AddSettings
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblAntenna = new System.Windows.Forms.Label();
            this.lblIP = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.buttonAddAntenna = new System.Windows.Forms.Button();
            this.buttonRemoveAntenna = new System.Windows.Forms.Button();
            this.flpAntennaConfig = new System.Windows.Forms.FlowLayoutPanel();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxStore = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSettingsName = new System.Windows.Forms.TextBox();
            this.dataGridViewReaders = new System.Windows.Forms.DataGridView();
            this.IPaddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numAntennas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonAddReader = new System.Windows.Forms.Button();
            this.buttonRemoveReader = new System.Windows.Forms.Button();
            this.buttonBack = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lblName = new System.Windows.Forms.Label();
            this.lblReader = new System.Windows.Forms.Label();
            this.lblStore = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReaders)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblAntenna);
            this.panel1.Controls.Add(this.lblIP);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.button6);
            this.panel1.Controls.Add(this.buttonAddAntenna);
            this.panel1.Controls.Add(this.buttonRemoveAntenna);
            this.panel1.Controls.Add(this.flpAntennaConfig);
            this.panel1.Controls.Add(this.txtIP);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Location = new System.Drawing.Point(479, 21);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(538, 326);
            this.panel1.TabIndex = 278;
            this.panel1.Visible = false;
            // 
            // lblAntenna
            // 
            this.lblAntenna.AutoSize = true;
            this.lblAntenna.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAntenna.ForeColor = System.Drawing.Color.Red;
            this.lblAntenna.Location = new System.Drawing.Point(351, 273);
            this.lblAntenna.Name = "lblAntenna";
            this.lblAntenna.Size = new System.Drawing.Size(125, 18);
            this.lblAntenna.TabIndex = 289;
            this.lblAntenna.Text = "Antennas Invalid!";
            this.lblAntenna.Visible = false;
            // 
            // lblIP
            // 
            this.lblIP.AutoSize = true;
            this.lblIP.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIP.ForeColor = System.Drawing.Color.Red;
            this.lblIP.Location = new System.Drawing.Point(299, 49);
            this.lblIP.Name = "lblIP";
            this.lblIP.Size = new System.Drawing.Size(136, 18);
            this.lblIP.TabIndex = 288;
            this.lblIP.Text = "IP Address Invalid!";
            this.lblIP.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(479, 307);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 18);
            this.label8.TabIndex = 286;
            this.label8.Text = "Submit";
            // 
            // button6
            // 
            this.button6.BackgroundImage = global::ssms.Properties.Resources.ok_appproval_acceptance__1_;
            this.button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button6.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Location = new System.Drawing.Point(482, 263);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(51, 41);
            this.button6.TabIndex = 286;
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // buttonAddAntenna
            // 
            this.buttonAddAntenna.BackColor = System.Drawing.Color.MidnightBlue;
            this.buttonAddAntenna.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonAddAntenna.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonAddAntenna.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddAntenna.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAddAntenna.ForeColor = System.Drawing.Color.White;
            this.buttonAddAntenna.Location = new System.Drawing.Point(3, 290);
            this.buttonAddAntenna.Name = "buttonAddAntenna";
            this.buttonAddAntenna.Size = new System.Drawing.Size(150, 28);
            this.buttonAddAntenna.TabIndex = 285;
            this.buttonAddAntenna.Text = "Add Antenna";
            this.buttonAddAntenna.UseVisualStyleBackColor = false;
            this.buttonAddAntenna.Click += new System.EventHandler(this.button4_Click);
            // 
            // buttonRemoveAntenna
            // 
            this.buttonRemoveAntenna.BackColor = System.Drawing.Color.MidnightBlue;
            this.buttonRemoveAntenna.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonRemoveAntenna.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonRemoveAntenna.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRemoveAntenna.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRemoveAntenna.ForeColor = System.Drawing.Color.White;
            this.buttonRemoveAntenna.Location = new System.Drawing.Point(159, 290);
            this.buttonRemoveAntenna.Name = "buttonRemoveAntenna";
            this.buttonRemoveAntenna.Size = new System.Drawing.Size(150, 28);
            this.buttonRemoveAntenna.TabIndex = 286;
            this.buttonRemoveAntenna.Text = "Remove Antenna";
            this.buttonRemoveAntenna.UseVisualStyleBackColor = false;
            this.buttonRemoveAntenna.Click += new System.EventHandler(this.button5_Click);
            // 
            // flpAntennaConfig
            // 
            this.flpAntennaConfig.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flpAntennaConfig.AutoScroll = true;
            this.flpAntennaConfig.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpAntennaConfig.Location = new System.Drawing.Point(6, 77);
            this.flpAntennaConfig.Name = "flpAntennaConfig";
            this.flpAntennaConfig.Size = new System.Drawing.Size(527, 180);
            this.flpAntennaConfig.TabIndex = 284;
            // 
            // txtIP
            // 
            this.txtIP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIP.Location = new System.Drawing.Point(99, 45);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(187, 26);
            this.txtIP.TabIndex = 283;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label7.Location = new System.Drawing.Point(5, 49);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(97, 19);
            this.label7.TabIndex = 282;
            this.label7.Text = "IP Address:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label6.Location = new System.Drawing.Point(3, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(169, 33);
            this.label6.TabIndex = 258;
            this.label6.Text = "Add Reader";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(11, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 19);
            this.label2.TabIndex = 266;
            this.label2.Text = "Store Name:";
            // 
            // comboBoxStore
            // 
            this.comboBoxStore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxStore.FormattingEnabled = true;
            this.comboBoxStore.Location = new System.Drawing.Point(147, 66);
            this.comboBoxStore.Name = "comboBoxStore";
            this.comboBoxStore.Size = new System.Drawing.Size(245, 28);
            this.comboBoxStore.TabIndex = 265;
            
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(865, 503);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 25);
            this.label5.TabIndex = 263;
            this.label5.Text = "Add";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(11, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 33);
            this.label1.TabIndex = 257;
            this.label1.Text = "Add Settings";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(11, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 19);
            this.label3.TabIndex = 280;
            this.label3.Text = "Settings Name:";
            // 
            // txtSettingsName
            // 
            this.txtSettingsName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSettingsName.Location = new System.Drawing.Point(147, 103);
            this.txtSettingsName.Name = "txtSettingsName";
            this.txtSettingsName.Size = new System.Drawing.Size(245, 26);
            this.txtSettingsName.TabIndex = 281;
            // 
            // dataGridViewReaders
            // 
            this.dataGridViewReaders.AllowUserToAddRows = false;
            this.dataGridViewReaders.AllowUserToDeleteRows = false;
            this.dataGridViewReaders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewReaders.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewReaders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewReaders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IPaddress,
            this.numAntennas});
            this.dataGridViewReaders.GridColor = System.Drawing.Color.White;
            this.dataGridViewReaders.Location = new System.Drawing.Point(17, 163);
            this.dataGridViewReaders.MultiSelect = false;
            this.dataGridViewReaders.Name = "dataGridViewReaders";
            this.dataGridViewReaders.ReadOnly = true;
            this.dataGridViewReaders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewReaders.Size = new System.Drawing.Size(394, 142);
            this.dataGridViewReaders.TabIndex = 282;
            // 
            // IPaddress
            // 
            this.IPaddress.HeaderText = "IP Address";
            this.IPaddress.Name = "IPaddress";
            this.IPaddress.ReadOnly = true;
            // 
            // numAntennas
            // 
            this.numAntennas.HeaderText = "Number of Antennas";
            this.numAntennas.Name = "numAntennas";
            this.numAntennas.ReadOnly = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(13, 141);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 19);
            this.label4.TabIndex = 283;
            this.label4.Text = "Readers:";
            // 
            // buttonAddReader
            // 
            this.buttonAddReader.BackColor = System.Drawing.Color.MidnightBlue;
            this.buttonAddReader.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonAddReader.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonAddReader.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddReader.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAddReader.ForeColor = System.Drawing.Color.White;
            this.buttonAddReader.Location = new System.Drawing.Point(135, 311);
            this.buttonAddReader.Name = "buttonAddReader";
            this.buttonAddReader.Size = new System.Drawing.Size(135, 28);
            this.buttonAddReader.TabIndex = 284;
            this.buttonAddReader.Text = "Add Reader";
            this.buttonAddReader.UseVisualStyleBackColor = false;
            this.buttonAddReader.Click += new System.EventHandler(this.button2_Click);
            // 
            // buttonRemoveReader
            // 
            this.buttonRemoveReader.BackColor = System.Drawing.Color.MidnightBlue;
            this.buttonRemoveReader.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonRemoveReader.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonRemoveReader.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRemoveReader.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRemoveReader.ForeColor = System.Drawing.Color.White;
            this.buttonRemoveReader.Location = new System.Drawing.Point(276, 311);
            this.buttonRemoveReader.Name = "buttonRemoveReader";
            this.buttonRemoveReader.Size = new System.Drawing.Size(135, 28);
            this.buttonRemoveReader.TabIndex = 285;
            this.buttonRemoveReader.Text = "Remove Reader";
            this.buttonRemoveReader.UseVisualStyleBackColor = false;
            this.buttonRemoveReader.Click += new System.EventHandler(this.button3_Click);
            // 
            // buttonBack
            // 
            this.buttonBack.BackgroundImage = global::ssms.Properties.Resources.reply__1_;
            this.buttonBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonBack.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.buttonBack.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonBack.Location = new System.Drawing.Point(938, 415);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(61, 113);
            this.buttonBack.TabIndex = 264;
            this.buttonBack.Text = "Back";
            this.buttonBack.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackgroundImage = global::ssms.Properties.Resources.ok_appproval_acceptance__1_;
            this.btnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAdd.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Location = new System.Drawing.Point(852, 439);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(80, 61);
            this.btnAdd.TabIndex = 262;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.Color.Red;
            this.lblName.Location = new System.Drawing.Point(132, 402);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(161, 18);
            this.lblName.TabIndex = 286;
            this.lblName.Text = "Settings name invalid!";
            this.lblName.Visible = false;
            // 
            // lblReader
            // 
            this.lblReader.AutoSize = true;
            this.lblReader.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReader.ForeColor = System.Drawing.Color.Red;
            this.lblReader.Location = new System.Drawing.Point(132, 430);
            this.lblReader.Name = "lblReader";
            this.lblReader.Size = new System.Drawing.Size(121, 18);
            this.lblReader.TabIndex = 287;
            this.lblReader.Text = "Readers invalid!";
            this.lblReader.Visible = false;
            // 
            // lblStore
            // 
            this.lblStore.AutoSize = true;
            this.lblStore.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStore.ForeColor = System.Drawing.Color.Red;
            this.lblStore.Location = new System.Drawing.Point(132, 370);
            this.lblStore.Name = "lblStore";
            this.lblStore.Size = new System.Drawing.Size(142, 18);
            this.lblStore.TabIndex = 288;
            this.lblStore.Text = "Store name invalid!";
            this.lblStore.Visible = false;
            // 
            // AddSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblStore);
            this.Controls.Add(this.lblReader);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.buttonRemoveReader);
            this.Controls.Add(this.buttonAddReader);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dataGridViewReaders);
            this.Controls.Add(this.txtSettingsName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxStore);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.label1);
            this.Name = "AddSettings";
            this.Size = new System.Drawing.Size(1031, 532);
            this.Load += new System.EventHandler(this.AddSettings_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReaders)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxStore;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSettingsName;
        private System.Windows.Forms.DataGridView dataGridViewReaders;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonAddReader;
        private System.Windows.Forms.Button buttonRemoveReader;
        private System.Windows.Forms.FlowLayoutPanel flpAntennaConfig;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonAddAntenna;
        private System.Windows.Forms.Button buttonRemoveAntenna;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridViewTextBoxColumn IPaddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn numAntennas;
        private System.Windows.Forms.Label lblAntenna;
        private System.Windows.Forms.Label lblIP;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblReader;
        private System.Windows.Forms.Label lblStore;
    }
}
