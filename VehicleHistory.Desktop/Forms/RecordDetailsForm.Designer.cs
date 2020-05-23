namespace VehicleHistoryDesktop.Forms
{
    partial class RecordDetailsForm
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
            this.lblVin = new System.Windows.Forms.Label();
            this.lblMileage = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblVinValue = new System.Windows.Forms.Label();
            this.lblMileageValue = new System.Windows.Forms.Label();
            this.lblTitleValue = new System.Windows.Forms.Label();
            this.lblTypeValue = new System.Windows.Forms.Label();
            this.lblDescriptionValue = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblVin
            // 
            this.lblVin.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblVin.AutoSize = true;
            this.lblVin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblVin.Location = new System.Drawing.Point(131, 10);
            this.lblVin.Name = "lblVin";
            this.lblVin.Size = new System.Drawing.Size(36, 20);
            this.lblVin.TabIndex = 0;
            this.lblVin.Text = "VIN";
            // 
            // lblMileage
            // 
            this.lblMileage.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblMileage.AutoSize = true;
            this.lblMileage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblMileage.Location = new System.Drawing.Point(63, 51);
            this.lblMileage.Name = "lblMileage";
            this.lblMileage.Size = new System.Drawing.Size(104, 20);
            this.lblMileage.TabIndex = 1;
            this.lblMileage.Text = "Przebieg [km]";
            // 
            // lblType
            // 
            this.lblType.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblType.AutoSize = true;
            this.lblType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblType.Location = new System.Drawing.Point(75, 135);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(92, 20);
            this.lblType.TabIndex = 3;
            this.lblType.Text = "Typ rekordu";
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblTitle.Location = new System.Drawing.Point(124, 92);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(43, 20);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "Tytuł";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblDescription.Location = new System.Drawing.Point(126, 168);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(41, 209);
            this.lblDescription.TabIndex = 4;
            this.lblDescription.Text = "Opis";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.03608F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 77.96392F));
            this.tableLayoutPanel1.Controls.Add(this.lblVinValue, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblMileageValue, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblTitleValue, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblTypeValue, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblVin, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblDescription, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblType, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblTitle, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblMileage, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblDescriptionValue, 1, 4);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.97183F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 54.92958F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(776, 377);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // lblVinValue
            // 
            this.lblVinValue.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblVinValue.AutoSize = true;
            this.lblVinValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblVinValue.Location = new System.Drawing.Point(173, 10);
            this.lblVinValue.Name = "lblVinValue";
            this.lblVinValue.Size = new System.Drawing.Size(36, 20);
            this.lblVinValue.TabIndex = 6;
            this.lblVinValue.Text = "VIN";
            // 
            // lblMileageValue
            // 
            this.lblMileageValue.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblMileageValue.AutoSize = true;
            this.lblMileageValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblMileageValue.Location = new System.Drawing.Point(173, 51);
            this.lblMileageValue.Name = "lblMileageValue";
            this.lblMileageValue.Size = new System.Drawing.Size(92, 20);
            this.lblMileageValue.TabIndex = 9;
            this.lblMileageValue.Text = "Typ rekordu";
            // 
            // lblTitleValue
            // 
            this.lblTitleValue.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTitleValue.AutoSize = true;
            this.lblTitleValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblTitleValue.Location = new System.Drawing.Point(173, 92);
            this.lblTitleValue.Name = "lblTitleValue";
            this.lblTitleValue.Size = new System.Drawing.Size(43, 20);
            this.lblTitleValue.TabIndex = 8;
            this.lblTitleValue.Text = "Tytuł";
            // 
            // lblTypeValue
            // 
            this.lblTypeValue.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTypeValue.AutoSize = true;
            this.lblTypeValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblTypeValue.Location = new System.Drawing.Point(173, 135);
            this.lblTypeValue.Name = "lblTypeValue";
            this.lblTypeValue.Size = new System.Drawing.Size(104, 20);
            this.lblTypeValue.TabIndex = 7;
            this.lblTypeValue.Text = "Przebieg [km]";
            // 
            // lblDescriptionValue
            // 
            this.lblDescriptionValue.AutoSize = true;
            this.lblDescriptionValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblDescriptionValue.Location = new System.Drawing.Point(173, 168);
            this.lblDescriptionValue.Name = "lblDescriptionValue";
            this.lblDescriptionValue.Size = new System.Drawing.Size(104, 20);
            this.lblDescriptionValue.TabIndex = 10;
            this.lblDescriptionValue.Text = "Przebieg [km]";
            // 
            // btnClose
            // 
            this.btnClose.Image = global::VehicleHistoryDesktop.Properties.Resources.cancel;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(362, 395);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(86, 43);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Zamknij";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // RecordDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "RecordDetailsForm";
            this.Text = "Szczegóły rekordu";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RecordDetailsForm_KeyDown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblVin;
        private System.Windows.Forms.Label lblMileage;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblVinValue;
        private System.Windows.Forms.Label lblMileageValue;
        private System.Windows.Forms.Label lblTitleValue;
        private System.Windows.Forms.Label lblTypeValue;
        private System.Windows.Forms.Label lblDescriptionValue;
        private System.Windows.Forms.Button btnClose;
    }
}