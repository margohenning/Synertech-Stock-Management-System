namespace ssms.Pages.Settings
{
    partial class Settings
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
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewSettings = new System.Windows.Forms.DataGridView();
            this.SettingsID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SettingsName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SettingsSelect = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AmountReaders = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AmountAntennas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StoreName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonExportPDF = new System.Windows.Forms.Button();
            this.buttonUpdateSettings = new System.Windows.Forms.Button();
            this.buttonAddSettings = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSettings)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(30, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 33);
            this.label1.TabIndex = 80;
            this.label1.Text = "Settings";
            // 
            // dataGridViewSettings
            // 
            this.dataGridViewSettings.AllowUserToAddRows = false;
            this.dataGridViewSettings.AllowUserToDeleteRows = false;
            this.dataGridViewSettings.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewSettings.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewSettings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSettings.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SettingsID,
            this.SettingsName,
            this.SettingsSelect,
            this.AmountReaders,
            this.AmountAntennas,
            this.StoreName});
            this.dataGridViewSettings.Location = new System.Drawing.Point(36, 69);
            this.dataGridViewSettings.Name = "dataGridViewSettings";
            this.dataGridViewSettings.ReadOnly = true;
            this.dataGridViewSettings.RowHeadersVisible = false;
            this.dataGridViewSettings.Size = new System.Drawing.Size(638, 397);
            this.dataGridViewSettings.TabIndex = 81;
            // 
            // SettingsID
            // 
            this.SettingsID.HeaderText = "Settings ID";
            this.SettingsID.Name = "SettingsID";
            this.SettingsID.ReadOnly = true;
            // 
            // SettingsName
            // 
            this.SettingsName.HeaderText = "Settings Name";
            this.SettingsName.Name = "SettingsName";
            this.SettingsName.ReadOnly = true;
            // 
            // SettingsSelect
            // 
            this.SettingsSelect.HeaderText = "Settings Select";
            this.SettingsSelect.Name = "SettingsSelect";
            this.SettingsSelect.ReadOnly = true;
            // 
            // AmountReaders
            // 
            this.AmountReaders.HeaderText = "Amount of Readers";
            this.AmountReaders.Name = "AmountReaders";
            this.AmountReaders.ReadOnly = true;
            // 
            // AmountAntennas
            // 
            this.AmountAntennas.HeaderText = "Amount of Antennas";
            this.AmountAntennas.Name = "AmountAntennas";
            this.AmountAntennas.ReadOnly = true;
            // 
            // StoreName
            // 
            this.StoreName.HeaderText = "Store Name";
            this.StoreName.Name = "StoreName";
            this.StoreName.ReadOnly = true;
            // 
            // buttonExportPDF
            // 
            this.buttonExportPDF.BackColor = System.Drawing.Color.Silver;
            this.buttonExportPDF.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonExportPDF.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonExportPDF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExportPDF.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExportPDF.ForeColor = System.Drawing.Color.White;
            this.buttonExportPDF.Location = new System.Drawing.Point(852, 19);
            this.buttonExportPDF.Name = "buttonExportPDF";
            this.buttonExportPDF.Size = new System.Drawing.Size(161, 46);
            this.buttonExportPDF.TabIndex = 91;
            this.buttonExportPDF.Text = "Export PDF";
            this.buttonExportPDF.UseVisualStyleBackColor = false;
            this.buttonExportPDF.Click += new System.EventHandler(this.buttonExportPDF_Click);
            // 
            // buttonUpdateSettings
            // 
            this.buttonUpdateSettings.BackColor = System.Drawing.Color.MidnightBlue;
            this.buttonUpdateSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonUpdateSettings.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonUpdateSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonUpdateSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonUpdateSettings.ForeColor = System.Drawing.Color.White;
            this.buttonUpdateSettings.Location = new System.Drawing.Point(852, 219);
            this.buttonUpdateSettings.Name = "buttonUpdateSettings";
            this.buttonUpdateSettings.Size = new System.Drawing.Size(161, 43);
            this.buttonUpdateSettings.TabIndex = 90;
            this.buttonUpdateSettings.Text = "Update Settings";
            this.buttonUpdateSettings.UseVisualStyleBackColor = false;
            this.buttonUpdateSettings.Click += new System.EventHandler(this.buttonUpdateSettings_Click);
            // 
            // buttonAddSettings
            // 
            this.buttonAddSettings.BackColor = System.Drawing.Color.MidnightBlue;
            this.buttonAddSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonAddSettings.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonAddSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAddSettings.ForeColor = System.Drawing.Color.White;
            this.buttonAddSettings.Location = new System.Drawing.Point(852, 152);
            this.buttonAddSettings.Name = "buttonAddSettings";
            this.buttonAddSettings.Size = new System.Drawing.Size(161, 43);
            this.buttonAddSettings.TabIndex = 89;
            this.buttonAddSettings.Text = "Add Settings";
            this.buttonAddSettings.UseVisualStyleBackColor = false;
            this.buttonAddSettings.Click += new System.EventHandler(this.button1_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.MidnightBlue;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(852, 86);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(161, 43);
            this.button1.TabIndex = 92;
            this.button1.Text = "Select Setting";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonExportPDF);
            this.Controls.Add(this.buttonUpdateSettings);
            this.Controls.Add(this.buttonAddSettings);
            this.Controls.Add(this.dataGridViewSettings);
            this.Controls.Add(this.label1);
            this.Name = "Settings";
            this.Size = new System.Drawing.Size(1031, 532);
            this.Load += new System.EventHandler(this.Settings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSettings)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridViewSettings;
        private System.Windows.Forms.Button buttonExportPDF;
        private System.Windows.Forms.Button buttonUpdateSettings;
        private System.Windows.Forms.Button buttonAddSettings;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn SettingsID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SettingsName;
        private System.Windows.Forms.DataGridViewTextBoxColumn SettingsSelect;
        private System.Windows.Forms.DataGridViewTextBoxColumn AmountReaders;
        private System.Windows.Forms.DataGridViewTextBoxColumn AmountAntennas;
        private System.Windows.Forms.DataGridViewTextBoxColumn StoreName;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}
