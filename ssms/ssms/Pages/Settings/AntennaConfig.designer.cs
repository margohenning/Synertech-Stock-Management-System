namespace ssms.Pages.Settings
{
    partial class AntennaConfig
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
            this.tblMain = new System.Windows.Forms.TableLayoutPanel();
            this.nudRX = new System.Windows.Forms.NumericUpDown();
            this.lblPortNumber = new System.Windows.Forms.Label();
            this.cbxEnabled = new System.Windows.Forms.CheckBox();
            this.nudTX = new System.Windows.Forms.NumericUpDown();
            this.tblMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTX)).BeginInit();
            this.SuspendLayout();
            // 
            // tblMain
            // 
            this.tblMain.ColumnCount = 4;
            this.tblMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 108F));
            this.tblMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tblMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tblMain.Controls.Add(this.nudRX, 3, 0);
            this.tblMain.Controls.Add(this.lblPortNumber, 0, 0);
            this.tblMain.Controls.Add(this.cbxEnabled, 1, 0);
            this.tblMain.Controls.Add(this.nudTX, 2, 0);
            this.tblMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblMain.Location = new System.Drawing.Point(0, 0);
            this.tblMain.Name = "tblMain";
            this.tblMain.RowCount = 1;
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.tblMain.Size = new System.Drawing.Size(328, 43);
            this.tblMain.TabIndex = 0;
            // 
            // nudRX
            // 
            this.nudRX.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.nudRX.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudRX.Location = new System.Drawing.Point(244, 11);
            this.nudRX.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            this.nudRX.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.nudRX.Name = "nudRX";
            this.nudRX.Size = new System.Drawing.Size(68, 25);
            this.nudRX.TabIndex = 7;
            this.nudRX.Value = new decimal(new int[] {
            70,
            0,
            0,
            -2147483648});
            // 
            // lblPortNumber
            // 
            this.lblPortNumber.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblPortNumber.AutoSize = true;
            this.lblPortNumber.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPortNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblPortNumber.Location = new System.Drawing.Point(23, 3);
            this.lblPortNumber.Name = "lblPortNumber";
            this.lblPortNumber.Size = new System.Drawing.Size(61, 40);
            this.lblPortNumber.TabIndex = 4;
            this.lblPortNumber.Text = "Antenna Number";
            this.lblPortNumber.Click += new System.EventHandler(this.lblPortNumber_Click);
            // 
            // cbxEnabled
            // 
            this.cbxEnabled.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbxEnabled.AutoSize = true;
            this.cbxEnabled.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxEnabled.Location = new System.Drawing.Point(111, 16);
            this.cbxEnabled.Name = "cbxEnabled";
            this.cbxEnabled.Size = new System.Drawing.Size(14, 14);
            this.cbxEnabled.TabIndex = 5;
            this.cbxEnabled.UseVisualStyleBackColor = true;
            // 
            // nudTX
            // 
            this.nudTX.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.nudTX.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudTX.Location = new System.Drawing.Point(147, 11);
            this.nudTX.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.nudTX.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudTX.Name = "nudTX";
            this.nudTX.Size = new System.Drawing.Size(62, 25);
            this.nudTX.TabIndex = 6;
            this.nudTX.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudTX.ValueChanged += new System.EventHandler(this.nudTX_ValueChanged);
            // 
            // AntennaConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.tblMain);
            this.Name = "AntennaConfig";
            this.Size = new System.Drawing.Size(328, 43);
            this.tblMain.ResumeLayout(false);
            this.tblMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTX)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tblMain;
        public System.Windows.Forms.Label lblPortNumber;
        public System.Windows.Forms.NumericUpDown nudRX;
        public System.Windows.Forms.CheckBox cbxEnabled;
        public System.Windows.Forms.NumericUpDown nudTX;
    }
}
