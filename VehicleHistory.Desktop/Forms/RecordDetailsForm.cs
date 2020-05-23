using System;
using System.Windows.Forms;
using VehicleHistoryDesktop.Models;

namespace VehicleHistoryDesktop.Forms
{
    public partial class RecordDetailsForm : Form
    {
        public RecordDetailsForm()
        {
            InitializeComponent();
        }

        public RecordDetailsForm(VehicleRecord record) : this()
        {
            lblVinValue.Text = record.Vin;
            lblMileageValue.Text = record.Mileage.ToString("G");
            lblTitleValue.Text = record.Title;
            lblTypeValue.Text = record.RecordTypeStr;
            lblDescriptionValue.Text = record.Description ?? "Brak opisu";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void RecordDetailsForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    btnClose_Click(this, EventArgs.Empty);
                    break;
            }
        }
    }
}
