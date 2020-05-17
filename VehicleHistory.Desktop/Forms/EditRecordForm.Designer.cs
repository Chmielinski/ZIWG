using System.Windows.Forms;

namespace VehicleHistoryDesktop.Forms
{
    partial class EditRecordForm
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
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.tbTitle = new System.Windows.Forms.TextBox();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.lblVin = new System.Windows.Forms.Label();
            this.lblMileage = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.tbVin = new System.Windows.Forms.TextBox();
            this.tbMileage = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.lblVinError = new System.Windows.Forms.Label();
            this.lblMileageError = new System.Windows.Forms.Label();
            this.lblTitleError = new System.Windows.Forms.Label();
            this.lblGeneralError = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbDescription
            // 
            this.tbDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbDescription.Location = new System.Drawing.Point(214, 248);
            this.tbDescription.MaxLength = 1000;
            this.tbDescription.Multiline = true;
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.Size = new System.Drawing.Size(448, 104);
            this.tbDescription.TabIndex = 4;
            // 
            // tbTitle
            // 
            this.tbTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbTitle.Location = new System.Drawing.Point(214, 146);
            this.tbTitle.Name = "tbTitle";
            this.tbTitle.Size = new System.Drawing.Size(283, 26);
            this.tbTitle.TabIndex = 2;
            this.tbTitle.Validating += new System.ComponentModel.CancelEventHandler(this.tbTitle_Validating);
            // 
            // cbType
            // 
            this.cbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cbType.FormattingEnabled = true;
            this.cbType.Location = new System.Drawing.Point(214, 199);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(283, 28);
            this.cbType.TabIndex = 3;
            // 
            // lblVin
            // 
            this.lblVin.AutoSize = true;
            this.lblVin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblVin.Location = new System.Drawing.Point(149, 50);
            this.lblVin.Name = "lblVin";
            this.lblVin.Size = new System.Drawing.Size(36, 20);
            this.lblVin.TabIndex = 5;
            this.lblVin.Text = "VIN";
            // 
            // lblMileage
            // 
            this.lblMileage.AutoSize = true;
            this.lblMileage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblMileage.Location = new System.Drawing.Point(50, 99);
            this.lblMileage.Name = "lblMileage";
            this.lblMileage.Size = new System.Drawing.Size(135, 20);
            this.lblMileage.TabIndex = 6;
            this.lblMileage.Text = "Aktualny przebieg";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblTitle.Location = new System.Drawing.Point(142, 149);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(43, 20);
            this.lblTitle.TabIndex = 7;
            this.lblTitle.Text = "Tytuł";
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblType.Location = new System.Drawing.Point(93, 202);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(92, 20);
            this.lblType.TabIndex = 8;
            this.lblType.Text = "Typ rekordu";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblDescription.Location = new System.Drawing.Point(144, 251);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(41, 20);
            this.lblDescription.TabIndex = 9;
            this.lblDescription.Text = "Opis";
            // 
            // tbVin
            // 
            this.tbVin.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbVin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbVin.Location = new System.Drawing.Point(214, 47);
            this.tbVin.MaxLength = 17;
            this.tbVin.Name = "tbVin";
            this.tbVin.Size = new System.Drawing.Size(283, 26);
            this.tbVin.TabIndex = 0;
            this.tbVin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbVin_KeyPress);
            this.tbVin.Validating += new System.ComponentModel.CancelEventHandler(this.tbVin_Validating);
            // 
            // tbMileage
            // 
            this.tbMileage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbMileage.Location = new System.Drawing.Point(214, 96);
            this.tbMileage.MaxLength = 7;
            this.tbMileage.Name = "tbMileage";
            this.tbMileage.Size = new System.Drawing.Size(283, 26);
            this.tbMileage.TabIndex = 1;
            this.tbMileage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbMileage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbMileage_KeyPress);
            this.tbMileage.Validating += new System.ComponentModel.CancelEventHandler(this.tbMileage_Validating);
            // 
            // btnCancel
            // 
            this.btnCancel.Image = global::VehicleHistoryDesktop.Properties.Resources.cancel;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(376, 383);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(95, 44);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "Anuluj";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Image = global::VehicleHistoryDesktop.Properties.Resources.check;
            this.btnSubmit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSubmit.Location = new System.Drawing.Point(214, 383);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(101, 44);
            this.btnSubmit.TabIndex = 12;
            this.btnSubmit.TabStop = false;
            this.btnSubmit.Text = "Zatwierdź";
            this.btnSubmit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // lblVinError
            // 
            this.lblVinError.AutoSize = true;
            this.lblVinError.ForeColor = System.Drawing.Color.Red;
            this.lblVinError.Location = new System.Drawing.Point(211, 76);
            this.lblVinError.Name = "lblVinError";
            this.lblVinError.Size = new System.Drawing.Size(28, 13);
            this.lblVinError.TabIndex = 14;
            this.lblVinError.Text = "error";
            this.lblVinError.Visible = false;
            // 
            // lblMileageError
            // 
            this.lblMileageError.AutoSize = true;
            this.lblMileageError.ForeColor = System.Drawing.Color.Red;
            this.lblMileageError.Location = new System.Drawing.Point(211, 125);
            this.lblMileageError.Name = "lblMileageError";
            this.lblMileageError.Size = new System.Drawing.Size(28, 13);
            this.lblMileageError.TabIndex = 15;
            this.lblMileageError.Text = "error";
            this.lblMileageError.Visible = false;
            // 
            // lblTitleError
            // 
            this.lblTitleError.AutoSize = true;
            this.lblTitleError.ForeColor = System.Drawing.Color.Red;
            this.lblTitleError.Location = new System.Drawing.Point(211, 175);
            this.lblTitleError.Name = "lblTitleError";
            this.lblTitleError.Size = new System.Drawing.Size(28, 13);
            this.lblTitleError.TabIndex = 16;
            this.lblTitleError.Text = "error";
            this.lblTitleError.Visible = false;
            // 
            // lblGeneralError
            // 
            this.lblGeneralError.AutoSize = true;
            this.lblGeneralError.ForeColor = System.Drawing.Color.Red;
            this.lblGeneralError.Location = new System.Drawing.Point(211, 355);
            this.lblGeneralError.Name = "lblGeneralError";
            this.lblGeneralError.Size = new System.Drawing.Size(28, 13);
            this.lblGeneralError.TabIndex = 17;
            this.lblGeneralError.Text = "error";
            this.lblGeneralError.Visible = false;
            // 
            // EditRecordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 450);
            this.Controls.Add(this.lblGeneralError);
            this.Controls.Add(this.lblTitleError);
            this.Controls.Add(this.lblMileageError);
            this.Controls.Add(this.lblVinError);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.tbMileage);
            this.Controls.Add(this.tbVin);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblMileage);
            this.Controls.Add(this.lblVin);
            this.Controls.Add(this.cbType);
            this.Controls.Add(this.tbTitle);
            this.Controls.Add(this.tbDescription);
            this.Name = "EditRecordForm";
            this.Text = "Rekord";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EditRecordForm_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.TextBox tbTitle;
        private System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.Label lblVin;
        private System.Windows.Forms.Label lblMileage;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox tbVin;
        private System.Windows.Forms.TextBox tbMileage;
        private Button btnCancel;
        private Button btnSubmit;
        private Label lblVinError;
        private Label lblMileageError;
        private Label lblTitleError;
        private Label lblGeneralError;
    }
}