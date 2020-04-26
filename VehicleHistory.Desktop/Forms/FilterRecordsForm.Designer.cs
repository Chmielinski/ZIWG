namespace VehicleHistoryDesktop.Forms
{
    partial class FilterRecordsForm
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
            this.nudFrom = new System.Windows.Forms.NumericUpDown();
            this.nudTo = new System.Windows.Forms.NumericUpDown();
            this.tbPhrase = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbAllTypes = new System.Windows.Forms.CheckBox();
            this.clbTypesOptions = new System.Windows.Forms.CheckedListBox();
            this.lblTypes = new System.Windows.Forms.Label();
            this.lblPhrase = new System.Windows.Forms.Label();
            this.lblMileageFrom = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.lblTo = new System.Windows.Forms.Label();
            this.lblRangeError = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.lblDateFrom = new System.Windows.Forms.Label();
            this.lblDatesError = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTo)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // nudFrom
            // 
            this.nudFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.nudFrom.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudFrom.Location = new System.Drawing.Point(111, 50);
            this.nudFrom.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.nudFrom.Name = "nudFrom";
            this.nudFrom.Size = new System.Drawing.Size(114, 26);
            this.nudFrom.TabIndex = 0;
            this.nudFrom.ValueChanged += new System.EventHandler(this.MileageRangeChanged);
            // 
            // nudTo
            // 
            this.nudTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.nudTo.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudTo.Location = new System.Drawing.Point(264, 50);
            this.nudTo.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.nudTo.Name = "nudTo";
            this.nudTo.Size = new System.Drawing.Size(120, 26);
            this.nudTo.TabIndex = 1;
            this.nudTo.Value = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.nudTo.ValueChanged += new System.EventHandler(this.MileageRangeChanged);
            // 
            // tbPhrase
            // 
            this.tbPhrase.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbPhrase.Location = new System.Drawing.Point(68, 11);
            this.tbPhrase.Name = "tbPhrase";
            this.tbPhrase.Size = new System.Drawing.Size(316, 26);
            this.tbPhrase.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbAllTypes);
            this.panel1.Controls.Add(this.clbTypesOptions);
            this.panel1.Controls.Add(this.lblTypes);
            this.panel1.Location = new System.Drawing.Point(12, 160);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(372, 134);
            this.panel1.TabIndex = 3;
            // 
            // cbAllTypes
            // 
            this.cbAllTypes.AutoSize = true;
            this.cbAllTypes.Location = new System.Drawing.Point(6, 16);
            this.cbAllTypes.Name = "cbAllTypes";
            this.cbAllTypes.Size = new System.Drawing.Size(74, 17);
            this.cbAllTypes.TabIndex = 16;
            this.cbAllTypes.Text = "Wszystkie";
            this.cbAllTypes.UseVisualStyleBackColor = true;
            this.cbAllTypes.CheckedChanged += new System.EventHandler(this.cbAllTypes_CheckedChanged);
            // 
            // clbTypesOptions
            // 
            this.clbTypesOptions.BackColor = System.Drawing.SystemColors.Control;
            this.clbTypesOptions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.clbTypesOptions.CheckOnClick = true;
            this.clbTypesOptions.FormattingEnabled = true;
            this.clbTypesOptions.Location = new System.Drawing.Point(99, 16);
            this.clbTypesOptions.Name = "clbTypesOptions";
            this.clbTypesOptions.Size = new System.Drawing.Size(270, 120);
            this.clbTypesOptions.TabIndex = 1;
            this.clbTypesOptions.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clbTypesOptions_ItemCheck);
            // 
            // lblTypes
            // 
            this.lblTypes.AutoSize = true;
            this.lblTypes.Location = new System.Drawing.Point(3, 0);
            this.lblTypes.Name = "lblTypes";
            this.lblTypes.Size = new System.Drawing.Size(77, 13);
            this.lblTypes.TabIndex = 0;
            this.lblTypes.Text = "Typy rekordów";
            // 
            // lblPhrase
            // 
            this.lblPhrase.AutoSize = true;
            this.lblPhrase.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblPhrase.Location = new System.Drawing.Point(12, 14);
            this.lblPhrase.Name = "lblPhrase";
            this.lblPhrase.Size = new System.Drawing.Size(50, 20);
            this.lblPhrase.TabIndex = 4;
            this.lblPhrase.Text = "Fraza";
            // 
            // lblMileageFrom
            // 
            this.lblMileageFrom.AutoSize = true;
            this.lblMileageFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblMileageFrom.Location = new System.Drawing.Point(12, 52);
            this.lblMileageFrom.Name = "lblMileageFrom";
            this.lblMileageFrom.Size = new System.Drawing.Size(93, 20);
            this.lblMileageFrom.TabIndex = 5;
            this.lblMileageFrom.Text = "Przebieg od";
            // 
            // btnCancel
            // 
            this.btnCancel.Image = global::VehicleHistoryDesktop.Properties.Resources.cancel;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(235, 308);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(95, 44);
            this.btnCancel.TabIndex = 15;
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
            this.btnSubmit.Location = new System.Drawing.Point(68, 308);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(101, 44);
            this.btnSubmit.TabIndex = 14;
            this.btnSubmit.TabStop = false;
            this.btnSubmit.Text = "Zatwierdź";
            this.btnSubmit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblTo.Location = new System.Drawing.Point(231, 52);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(27, 20);
            this.lblTo.TabIndex = 0;
            this.lblTo.Text = "do";
            // 
            // lblRangeError
            // 
            this.lblRangeError.AutoSize = true;
            this.lblRangeError.ForeColor = System.Drawing.Color.Red;
            this.lblRangeError.Location = new System.Drawing.Point(108, 79);
            this.lblRangeError.Name = "lblRangeError";
            this.lblRangeError.Size = new System.Drawing.Size(28, 13);
            this.lblRangeError.TabIndex = 16;
            this.lblRangeError.Text = "error";
            this.lblRangeError.Visible = false;
            // 
            // dtpFrom
            // 
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(111, 104);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(114, 20);
            this.dtpFrom.TabIndex = 17;
            this.dtpFrom.ValueChanged += new System.EventHandler(this.DateRangeChanged);
            // 
            // dtpTo
            // 
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(264, 104);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(120, 20);
            this.dtpTo.TabIndex = 18;
            this.dtpTo.ValueChanged += new System.EventHandler(this.DateRangeChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(231, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 20);
            this.label1.TabIndex = 19;
            this.label1.Text = "do";
            // 
            // lblDateFrom
            // 
            this.lblDateFrom.AutoSize = true;
            this.lblDateFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblDateFrom.Location = new System.Drawing.Point(14, 105);
            this.lblDateFrom.Name = "lblDateFrom";
            this.lblDateFrom.Size = new System.Drawing.Size(66, 20);
            this.lblDateFrom.TabIndex = 20;
            this.lblDateFrom.Text = "Data od";
            // 
            // lblDatesError
            // 
            this.lblDatesError.AutoSize = true;
            this.lblDatesError.ForeColor = System.Drawing.Color.Red;
            this.lblDatesError.Location = new System.Drawing.Point(108, 127);
            this.lblDatesError.Name = "lblDatesError";
            this.lblDatesError.Size = new System.Drawing.Size(28, 13);
            this.lblDatesError.TabIndex = 21;
            this.lblDatesError.Text = "error";
            this.lblDatesError.Visible = false;
            // 
            // FilterRecordsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(405, 364);
            this.Controls.Add(this.lblDatesError);
            this.Controls.Add(this.lblDateFrom);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpTo);
            this.Controls.Add(this.dtpFrom);
            this.Controls.Add(this.lblRangeError);
            this.Controls.Add(this.lblTo);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.lblMileageFrom);
            this.Controls.Add(this.lblPhrase);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tbPhrase);
            this.Controls.Add(this.nudTo);
            this.Controls.Add(this.nudFrom);
            this.Name = "FilterRecordsForm";
            this.Text = "Filtruj";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FilterRecordsForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.nudFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTo)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nudFrom;
        private System.Windows.Forms.NumericUpDown nudTo;
        private System.Windows.Forms.TextBox tbPhrase;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblPhrase;
        private System.Windows.Forms.Label lblMileageFrom;
        private System.Windows.Forms.CheckBox cbAllTypes;
        private System.Windows.Forms.CheckedListBox clbTypesOptions;
        private System.Windows.Forms.Label lblTypes;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Label lblRangeError;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblDateFrom;
        private System.Windows.Forms.Label lblDatesError;
    }
}
