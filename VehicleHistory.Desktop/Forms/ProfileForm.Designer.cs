using VehicleHistoryDesktop.Utility;

namespace VehicleHistoryDesktop.Forms
{
    partial class ProfileForm
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
            this.lblFirstName = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblLastName = new System.Windows.Forms.Label();
            this.lblConfirmPassword = new System.Windows.Forms.Label();
            this.lblCurrentPassword = new System.Windows.Forms.Label();
            this.lblNewPassword = new System.Windows.Forms.Label();
            this.tbFirstName = new System.Windows.Forms.TextBox();
            this.tbNewPassword = new System.Windows.Forms.TextBox();
            this.tbConfirmNewPassword = new System.Windows.Forms.TextBox();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.tbLastName = new System.Windows.Forms.TextBox();
            this.tbCurrentPassword = new System.Windows.Forms.TextBox();
            this.lblFirstNameError = new System.Windows.Forms.Label();
            this.lblCurrentPasswordError = new System.Windows.Forms.Label();
            this.lblConfirmPasswordError = new System.Windows.Forms.Label();
            this.lblNewPasswordError = new System.Windows.Forms.Label();
            this.lblEmailError = new System.Windows.Forms.Label();
            this.lblLastNameError = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblFirstName.Location = new System.Drawing.Point(157, 51);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(39, 20);
            this.lblFirstName.TabIndex = 0;
            this.lblFirstName.Text = "Imię";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblEmail.Location = new System.Drawing.Point(143, 143);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(53, 20);
            this.lblEmail.TabIndex = 3;
            this.lblEmail.Text = "E-Mail";
            this.lblEmail.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblLastName.Location = new System.Drawing.Point(120, 97);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(76, 20);
            this.lblLastName.TabIndex = 4;
            this.lblLastName.Text = "Nazwisko";
            // 
            // lblConfirmPassword
            // 
            this.lblConfirmPassword.AutoSize = true;
            this.lblConfirmPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblConfirmPassword.Location = new System.Drawing.Point(33, 235);
            this.lblConfirmPassword.Name = "lblConfirmPassword";
            this.lblConfirmPassword.Size = new System.Drawing.Size(163, 20);
            this.lblConfirmPassword.TabIndex = 7;
            this.lblConfirmPassword.Text = "Potwierdź nowe hasło";
            // 
            // lblCurrentPassword
            // 
            this.lblCurrentPassword.AutoSize = true;
            this.lblCurrentPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblCurrentPassword.Location = new System.Drawing.Point(88, 281);
            this.lblCurrentPassword.Name = "lblCurrentPassword";
            this.lblCurrentPassword.Size = new System.Drawing.Size(108, 20);
            this.lblCurrentPassword.TabIndex = 6;
            this.lblCurrentPassword.Text = "Obence hasło";
            this.lblCurrentPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblNewPassword
            // 
            this.lblNewPassword.AutoSize = true;
            this.lblNewPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblNewPassword.Location = new System.Drawing.Point(104, 189);
            this.lblNewPassword.Name = "lblNewPassword";
            this.lblNewPassword.Size = new System.Drawing.Size(92, 20);
            this.lblNewPassword.TabIndex = 5;
            this.lblNewPassword.Text = "Nowe hasło";
            // 
            // tbFirstName
            // 
            this.tbFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbFirstName.Location = new System.Drawing.Point(217, 45);
            this.tbFirstName.MaxLength = 150;
            this.tbFirstName.Name = "tbFirstName";
            this.tbFirstName.Size = new System.Drawing.Size(244, 26);
            this.tbFirstName.TabIndex = 8;
            this.tbFirstName.Validating += new System.ComponentModel.CancelEventHandler(this.tbFirstName_Validating);
            // 
            // tbNewPassword
            // 
            this.tbNewPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbNewPassword.Location = new System.Drawing.Point(217, 186);
            this.tbNewPassword.MaxLength = 64;
            this.tbNewPassword.Name = "tbNewPassword";
            this.tbNewPassword.Size = new System.Drawing.Size(244, 26);
            this.tbNewPassword.TabIndex = 9;
            this.tbNewPassword.Validating += new System.ComponentModel.CancelEventHandler(this.tbNewPassword_Validating);
            // 
            // tbConfirmNewPassword
            // 
            this.tbConfirmNewPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbConfirmNewPassword.Location = new System.Drawing.Point(217, 232);
            this.tbConfirmNewPassword.MaxLength = 64;
            this.tbConfirmNewPassword.Name = "tbConfirmNewPassword";
            this.tbConfirmNewPassword.Size = new System.Drawing.Size(244, 26);
            this.tbConfirmNewPassword.TabIndex = 10;
            this.tbConfirmNewPassword.Validating += new System.ComponentModel.CancelEventHandler(this.tbConfirmNewPassword_Validating);
            // 
            // tbEmail
            // 
            this.tbEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbEmail.Location = new System.Drawing.Point(217, 140);
            this.tbEmail.MaxLength = 150;
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(244, 26);
            this.tbEmail.TabIndex = 11;
            this.tbEmail.Validating += new System.ComponentModel.CancelEventHandler(this.tbEmail_Validating);
            // 
            // tbLastName
            // 
            this.tbLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbLastName.Location = new System.Drawing.Point(217, 94);
            this.tbLastName.MaxLength = 150;
            this.tbLastName.Name = "tbLastName";
            this.tbLastName.Size = new System.Drawing.Size(244, 26);
            this.tbLastName.TabIndex = 12;
            this.tbLastName.Validating += new System.ComponentModel.CancelEventHandler(this.tbLastName_Validating);
            // 
            // tbCurrentPassword
            // 
            this.tbCurrentPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbCurrentPassword.Location = new System.Drawing.Point(217, 278);
            this.tbCurrentPassword.Name = "tbCurrentPassword";
            this.tbCurrentPassword.Size = new System.Drawing.Size(244, 26);
            this.tbCurrentPassword.TabIndex = 13;
            this.tbCurrentPassword.Validating += new System.ComponentModel.CancelEventHandler(this.tbCurrentPassword_Validating);
            // 
            // lblFirstNameError
            // 
            this.lblFirstNameError.AutoSize = true;
            this.lblFirstNameError.ForeColor = System.Drawing.Color.Red;
            this.lblFirstNameError.Location = new System.Drawing.Point(214, 74);
            this.lblFirstNameError.Name = "lblFirstNameError";
            this.lblFirstNameError.Size = new System.Drawing.Size(28, 13);
            this.lblFirstNameError.TabIndex = 14;
            this.lblFirstNameError.Text = "error";
            // 
            // lblCurrentPasswordError
            // 
            this.lblCurrentPasswordError.AutoSize = true;
            this.lblCurrentPasswordError.ForeColor = System.Drawing.Color.Red;
            this.lblCurrentPasswordError.Location = new System.Drawing.Point(214, 307);
            this.lblCurrentPasswordError.Name = "lblCurrentPasswordError";
            this.lblCurrentPasswordError.Size = new System.Drawing.Size(28, 13);
            this.lblCurrentPasswordError.TabIndex = 15;
            this.lblCurrentPasswordError.Text = "error";
            // 
            // lblConfirmPasswordError
            // 
            this.lblConfirmPasswordError.AutoSize = true;
            this.lblConfirmPasswordError.ForeColor = System.Drawing.Color.Red;
            this.lblConfirmPasswordError.Location = new System.Drawing.Point(214, 261);
            this.lblConfirmPasswordError.Name = "lblConfirmPasswordError";
            this.lblConfirmPasswordError.Size = new System.Drawing.Size(28, 13);
            this.lblConfirmPasswordError.TabIndex = 16;
            this.lblConfirmPasswordError.Text = "error";
            // 
            // lblNewPasswordError
            // 
            this.lblNewPasswordError.AutoSize = true;
            this.lblNewPasswordError.ForeColor = System.Drawing.Color.Red;
            this.lblNewPasswordError.Location = new System.Drawing.Point(214, 216);
            this.lblNewPasswordError.Name = "lblNewPasswordError";
            this.lblNewPasswordError.Size = new System.Drawing.Size(28, 13);
            this.lblNewPasswordError.TabIndex = 17;
            this.lblNewPasswordError.Text = "error";
            // 
            // lblEmailError
            // 
            this.lblEmailError.AutoSize = true;
            this.lblEmailError.ForeColor = System.Drawing.Color.Red;
            this.lblEmailError.Location = new System.Drawing.Point(214, 170);
            this.lblEmailError.Name = "lblEmailError";
            this.lblEmailError.Size = new System.Drawing.Size(28, 13);
            this.lblEmailError.TabIndex = 18;
            this.lblEmailError.Text = "error";
            // 
            // lblLastNameError
            // 
            this.lblLastNameError.AutoSize = true;
            this.lblLastNameError.ForeColor = System.Drawing.Color.Red;
            this.lblLastNameError.Location = new System.Drawing.Point(214, 124);
            this.lblLastNameError.Name = "lblLastNameError";
            this.lblLastNameError.Size = new System.Drawing.Size(28, 13);
            this.lblLastNameError.TabIndex = 19;
            this.lblLastNameError.Text = "error";
            // 
            // btnCancel
            // 
            this.btnCancel.Image = global::VehicleHistoryDesktop.Properties.Resources.cancel;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(323, 347);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(95, 44);
            this.btnCancel.TabIndex = 21;
            this.btnCancel.Text = "Anuluj";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Image = global::VehicleHistoryDesktop.Properties.Resources.check;
            this.btnSubmit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSubmit.Location = new System.Drawing.Point(161, 347);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(101, 44);
            this.btnSubmit.TabIndex = 20;
            this.btnSubmit.Text = "Zatwierdź";
            this.btnSubmit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // ProfileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 424);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.lblLastNameError);
            this.Controls.Add(this.lblEmailError);
            this.Controls.Add(this.lblNewPasswordError);
            this.Controls.Add(this.lblConfirmPasswordError);
            this.Controls.Add(this.lblCurrentPasswordError);
            this.Controls.Add(this.lblFirstNameError);
            this.Controls.Add(this.tbCurrentPassword);
            this.Controls.Add(this.tbLastName);
            this.Controls.Add(this.tbEmail);
            this.Controls.Add(this.tbConfirmNewPassword);
            this.Controls.Add(this.tbNewPassword);
            this.Controls.Add(this.tbFirstName);
            this.Controls.Add(this.lblConfirmPassword);
            this.Controls.Add(this.lblCurrentPassword);
            this.Controls.Add(this.lblNewPassword);
            this.Controls.Add(this.lblLastName);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblFirstName);
            this.Name = "ProfileForm";
            this.Text = "ProfileForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.Label lblConfirmPassword;
        private System.Windows.Forms.Label lblCurrentPassword;
        private System.Windows.Forms.Label lblNewPassword;
        private System.Windows.Forms.TextBox tbFirstName;
        private System.Windows.Forms.TextBox tbNewPassword;
        private System.Windows.Forms.TextBox tbConfirmNewPassword;
        private System.Windows.Forms.TextBox tbEmail;
        private System.Windows.Forms.TextBox tbLastName;
        private System.Windows.Forms.TextBox tbCurrentPassword;
        private System.Windows.Forms.Label lblFirstNameError;
        private System.Windows.Forms.Label lblCurrentPasswordError;
        private System.Windows.Forms.Label lblConfirmPasswordError;
        private System.Windows.Forms.Label lblNewPasswordError;
        private System.Windows.Forms.Label lblEmailError;
        private System.Windows.Forms.Label lblLastNameError;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnCancel;
    }
}