namespace SILVER_E
{
    partial class frm_acceso
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
            this.cboEmpresa = new System.Windows.Forms.ComboBox();
            this.btn_cancel = new DevExpress.XtraEditors.SimpleButton();
            this.btn_access = new DevExpress.XtraEditors.SimpleButton();
            this.txt_password = new DevExpress.XtraEditors.TextEdit();
            this.txt_username = new DevExpress.XtraEditors.TextEdit();
            this.LabelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.LabelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.txt_password.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_username.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // cboEmpresa
            // 
            this.cboEmpresa.FormattingEnabled = true;
            this.cboEmpresa.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cboEmpresa.Location = new System.Drawing.Point(77, 230);
            this.cboEmpresa.Margin = new System.Windows.Forms.Padding(2);
            this.cboEmpresa.Name = "cboEmpresa";
            this.cboEmpresa.Size = new System.Drawing.Size(272, 21);
            this.cboEmpresa.TabIndex = 56;
            // 
            // btn_cancel
            // 
            this.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_cancel.Location = new System.Drawing.Point(252, 395);
            this.btn_cancel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(97, 41);
            this.btn_cancel.TabIndex = 55;
            this.btn_cancel.Text = "&SALIR";
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_access
            // 
            this.btn_access.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_access.Location = new System.Drawing.Point(77, 395);
            this.btn_access.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btn_access.Name = "btn_access";
            this.btn_access.Size = new System.Drawing.Size(97, 41);
            this.btn_access.TabIndex = 54;
            this.btn_access.Text = "&ENTRAR";
            this.btn_access.Click += new System.EventHandler(this.btn_access_Click);
            // 
            // txt_password
            // 
            this.txt_password.Location = new System.Drawing.Point(77, 347);
            this.txt_password.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txt_password.Name = "txt_password";
            this.txt_password.Properties.Appearance.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_password.Properties.Appearance.Options.UseFont = true;
            this.txt_password.Properties.UseSystemPasswordChar = true;
            this.txt_password.Size = new System.Drawing.Size(272, 26);
            this.txt_password.TabIndex = 53;
            // 
            // txt_username
            // 
            this.txt_username.Location = new System.Drawing.Point(77, 286);
            this.txt_username.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txt_username.Name = "txt_username";
            this.txt_username.Properties.Appearance.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_username.Properties.Appearance.Options.UseFont = true;
            this.txt_username.Size = new System.Drawing.Size(272, 26);
            this.txt_username.TabIndex = 52;
            // 
            // LabelControl2
            // 
            this.LabelControl2.Appearance.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelControl2.Appearance.ForeColor = System.Drawing.Color.White;
            this.LabelControl2.Appearance.Options.UseFont = true;
            this.LabelControl2.Appearance.Options.UseForeColor = true;
            this.LabelControl2.Location = new System.Drawing.Point(77, 317);
            this.LabelControl2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.LabelControl2.Name = "LabelControl2";
            this.LabelControl2.Size = new System.Drawing.Size(83, 19);
            this.LabelControl2.TabIndex = 51;
            this.LabelControl2.Text = "Contraseña:";
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureEdit1.EditValue = global::SILVER_E.Properties.Resources.logo_login;
            this.pictureEdit1.Location = new System.Drawing.Point(77, 18);
            this.pictureEdit1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pictureEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.pictureEdit1.Size = new System.Drawing.Size(272, 176);
            this.pictureEdit1.TabIndex = 57;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Appearance.Options.UseForeColor = true;
            this.labelControl3.Location = new System.Drawing.Point(77, 210);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(63, 19);
            this.labelControl3.TabIndex = 59;
            this.labelControl3.Text = "Empresa:";
            // 
            // LabelControl1
            // 
            this.LabelControl1.Appearance.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelControl1.Appearance.ForeColor = System.Drawing.Color.White;
            this.LabelControl1.Appearance.Options.UseFont = true;
            this.LabelControl1.Appearance.Options.UseForeColor = true;
            this.LabelControl1.Location = new System.Drawing.Point(77, 260);
            this.LabelControl1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.LabelControl1.Name = "LabelControl1";
            this.LabelControl1.Size = new System.Drawing.Size(57, 19);
            this.LabelControl1.TabIndex = 58;
            this.LabelControl1.Text = "Usuario:";
            // 
            // frm_acceso
            // 
            this.AcceptButton = this.btn_access;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.CancelButton = this.btn_cancel;
            this.ClientSize = new System.Drawing.Size(426, 454);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.LabelControl1);
            this.Controls.Add(this.pictureEdit1);
            this.Controls.Add(this.cboEmpresa);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_access);
            this.Controls.Add(this.txt_password);
            this.Controls.Add(this.txt_username);
            this.Controls.Add(this.LabelControl2);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "frm_acceso";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_acceso";
            this.Load += new System.EventHandler(this.frm_acceso_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txt_password.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_username.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private System.Windows.Forms.ComboBox cboEmpresa;
        internal DevExpress.XtraEditors.SimpleButton btn_cancel;
        internal DevExpress.XtraEditors.SimpleButton btn_access;
        internal DevExpress.XtraEditors.TextEdit txt_password;
        internal DevExpress.XtraEditors.LabelControl LabelControl2;
        internal DevExpress.XtraEditors.LabelControl labelControl3;
        internal DevExpress.XtraEditors.LabelControl LabelControl1;
        public DevExpress.XtraEditors.TextEdit txt_username;
    }
}