using System;
using System.Linq;
using System.Windows.Forms;
using RestSharp;
using VehicleHistoryDesktop.Models;
using VehicleHistoryDesktop.Utility;

namespace VehicleHistoryDesktop.Forms
{
    public partial class EditRecordForm : VHFormBase
    {
        private string _activeRecordId;

        public EditRecordForm()
        {
            InitializeComponent();
            cbType.DataSource = Dictionaries.GetDictionaries().Where(x => x.DictionaryTypeId == 1).ToList();
            cbType.DisplayMember = "StringValue";
            cbType.ValueMember = "EnumValue";
        }

        public EditRecordForm(VehicleRecord activeRecord) : this()
        {
            tbVin.Text = activeRecord.Vin;
            tbMileage.Text = activeRecord.Mileage.ToString();
            tbTitle.Text = activeRecord.Title;
            var recordType = Dictionaries.GetDictionaries().FirstOrDefault(x => x.DictionaryTypeId == 1 && x.EnumValue == activeRecord.RecordTypeId);
            if (recordType != null)
            {
                foreach (dynamic item in cbType.Items)
                {
                    if (item.Id == recordType.Id)
                    {
                        cbType.SelectedItem = item;
                    }
                }
            }
            tbDescription.Text = activeRecord.Description;
            _activeRecordId = activeRecord.Id;
        }

        private void tbMileage_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void tbVin_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            ValidateChildren();
            if (!IncorrectInputs.Any())
            {
                IRestResponse response;
                var record = new VehicleRecord
                {
                    Vin = tbVin.Text,
                    Title = tbTitle.Text,
                    Mileage = Convert.ToInt32(tbMileage.Text),
                    Description = tbDescription.Text,
                    UserId = EnvironmentSettings.CurrentUser.Id,
                    RecordTypeId = (int)cbType.SelectedValue
                };
                if (string.IsNullOrWhiteSpace(_activeRecordId))
                {
                    response = ExecuteRestRequest("vehiclerecords/add", record, Method.POST, lblGeneralError, EnvironmentSettings.CurrentUser.Token);
                }
                else
                {
                    response = ExecuteRestRequest($"vehiclerecords/{_activeRecordId}", record, Method.PUT, lblGeneralError, EnvironmentSettings.CurrentUser.Token);
                }
                if (response.IsSuccessful)
                {
                    Close();
                }
            }
        }

        private void tbVin_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!InputValidators.Vin(tbVin.Text, "VIN", out var errorMessage))
            {
                NoteError(lblVinError, errorMessage);
            }
            else
            {
                CancelError(lblVinError);
            }
        }

        private void tbMileage_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!InputValidators.DigitsOnly(tbMileage.Text, "Przebieg", out var errorMessage))
            {
                NoteError(lblMileageError, errorMessage);
            }
            else
            {
                CancelError(lblMileageError);
            }
        }

        private void tbTitle_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!InputValidators.NotEmpty(tbTitle.Text, "Tytuł", out var errorMessage))
            {
                NoteError(lblTitleError, errorMessage);
            }
            else
            {
                CancelError(lblTitleError);
            }
        }

        private void EditRecordForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    btnSubmit_Click(this, EventArgs.Empty);
                    e.SuppressKeyPress = true;
                    break;
                case Keys.Escape:
                    btnCancel_Click(this, EventArgs.Empty);
                    break;
            }
        }
    }
}
