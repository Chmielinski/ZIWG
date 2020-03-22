using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using RestSharp;
using VehicleHistoryDesktop.Models;
using VehicleHistoryDesktop.Utility;

namespace VehicleHistoryDesktop.Forms
{
    public partial class SetNewPasswordForm : VHFormBase
    {
        private LoginForm _loginScreen;

        public SetNewPasswordForm()
        {
            InitializeComponent();
        }

        public SetNewPasswordForm(LoginForm loginForm) : this()
        {
            _loginScreen = loginForm;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            ValidateChildren();
            if (!IncorrectInputs.Any())
            {
                var user = new User
                {
                    Id = EnvironmentSettings.CurrentUser.Id,
                    Email = EnvironmentSettings.CurrentUser.Email,
                    Password = tbNewPassword.Text,
                    FirstName = EnvironmentSettings.CurrentUser.FirstName,
                    LastName = EnvironmentSettings.CurrentUser.LastName,
                    LocationId = EnvironmentSettings.CurrentUser.LocationId
                };
                var response = ExecuteRestRequest($"users/{user.Id}", user, Method.PUT, lblConfirmPasswordError, EnvironmentSettings.CurrentUser.Token);
                if (response.IsSuccessful)
                {
                    EnvironmentSettings.CurrentUser.PasswordRecoveryActive = false;
                    var confirmationDialog = MessageBox.Show("Hasło zostało pomyślnie zmienione.", "Ustawianie nowego hasła", MessageBoxButtons.OK);
                    if (confirmationDialog == DialogResult.OK)
                    {
                        Close();
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _loginScreen.Show();
            Close();
        }

        private void tbNewPassword_Validating(object sender, CancelEventArgs e)
        {
            if (!InputValidators.NewPasswordConfirm(tbNewPassword.Text, tbConfirmNewPassword.Text, out var errorMessage))
            {
                NoteError(lblNewPasswordError, errorMessage);
            }
            else
            {
                CancelError(lblNewPasswordError);
            }
        }

        private void tbConfirmNewPassword_Validating(object sender, CancelEventArgs e)
        {
            if (!InputValidators.NewPasswordConfirm(tbConfirmNewPassword.Text, tbNewPassword.Text, out var errorMessage))
            {
                NoteError(lblConfirmPasswordError, errorMessage);
            }
            else
            {
                CancelError(lblConfirmPasswordError);
            }
        }

        private void SetNewPasswordForm_KeyDown(object sender, KeyEventArgs e)
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
