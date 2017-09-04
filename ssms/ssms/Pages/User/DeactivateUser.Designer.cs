namespace ssms.Pages
{
    partial class DeactivateUser
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
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.btnlogin = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.UserID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserIDentityNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserSurname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserAdmin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserActivated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(741, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 16);
            this.label3.TabIndex = 255;
            this.label3.Text = "Identity Number:";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(741, 71);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(162, 26);
            this.textBox1.TabIndex = 254;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(629, 405);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 25);
            this.label5.TabIndex = 253;
            this.label5.Text = "Deactivate";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(18, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(223, 33);
            this.label1.TabIndex = 232;
            this.label1.Text = "Deactivate User";
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button2.Image = global::ssms.Properties.Resources.search;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button2.Location = new System.Drawing.Point(918, 42);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(56, 56);
            this.button2.TabIndex = 256;
            this.button2.Text = "Search";
            this.button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // btnlogin
            // 
            this.btnlogin.BackgroundImage = global::ssms.Properties.Resources.rubbish_bin__1_;
            this.btnlogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnlogin.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnlogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnlogin.Location = new System.Drawing.Point(644, 341);
            this.btnlogin.Name = "btnlogin";
            this.btnlogin.Size = new System.Drawing.Size(80, 61);
            this.btnlogin.TabIndex = 252;
            this.btnlogin.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::ssms.Properties.Resources.reply__1_;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button1.Location = new System.Drawing.Point(967, 416);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(61, 113);
            this.button1.TabIndex = 199;
            this.button1.Text = "Back";
            this.button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.UserID,
            this.UserIDentityNumber,
            this.UserName,
            this.UserSurname,
            this.UserEmail,
            this.UserAdmin,
            this.UserActivated});
            this.dataGridView2.Location = new System.Drawing.Point(24, 52);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.Size = new System.Drawing.Size(711, 274);
            this.dataGridView2.TabIndex = 257;
            // 
            // UserID
            // 
            this.UserID.HeaderText = "User ID";
            this.UserID.Name = "UserID";
            this.UserID.ReadOnly = true;
            // 
            // UserIDentityNumber
            // 
            this.UserIDentityNumber.HeaderText = "Identity Number";
            this.UserIDentityNumber.Name = "UserIDentityNumber";
            this.UserIDentityNumber.ReadOnly = true;
            // 
            // UserName
            // 
            this.UserName.HeaderText = "Name";
            this.UserName.Name = "UserName";
            this.UserName.ReadOnly = true;
            // 
            // UserSurname
            // 
            this.UserSurname.HeaderText = "Surname";
            this.UserSurname.Name = "UserSurname";
            this.UserSurname.ReadOnly = true;
            // 
            // UserEmail
            // 
            this.UserEmail.HeaderText = "Email";
            this.UserEmail.Name = "UserEmail";
            this.UserEmail.ReadOnly = true;
            // 
            // UserAdmin
            // 
            this.UserAdmin.HeaderText = "Admin";
            this.UserAdmin.Name = "UserAdmin";
            this.UserAdmin.ReadOnly = true;
            // 
            // UserActivated
            // 
            this.UserActivated.HeaderText = "Activated";
            this.UserActivated.Name = "UserActivated";
            this.UserActivated.ReadOnly = true;
            // 
            // DeactivateUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnlogin);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "DeactivateUser";
            this.Size = new System.Drawing.Size(1031, 532);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnlogin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserID;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserIDentityNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserSurname;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserAdmin;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserActivated;
    }
}
