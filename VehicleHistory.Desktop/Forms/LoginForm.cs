using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json;
using RestSharp;
using VehicleHistoryDesktop.Models;
using VehicleHistoryDesktop.Utility;

namespace VehicleHistoryDesktop.Forms
{
    public partial class LoginForm : VHFormBase
    {
        public LoginForm()
        {
            InitializeComponent();
            // Just to make repeated app launches less annoying
            tbLogin.Text = "kuba.chmiel2@gmail.com";
            tbPassword.Text = "test";
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            ValidateChildren();
            if (!IncorrectInputs.Any())
            {
                var user = new User
                {
                    Email = tbLogin.Text,
                    Password = tbPassword.Text
                };

                var response = ExecuteRestRequest("users/authenticate", user, Method.POST, lblPasswordError, null);
                if (response.IsSuccessful)
                {
                    var responseUser = JsonConvert.DeserializeObject<User>(response.Content);
                    EnvironmentSettings.CurrentUser = responseUser;
                    Hide();
                    tbLogin.Text = null;
                    tbPassword.Text = null;
                    if (responseUser.PasswordRecoveryActive)
                    {
                        using (var setNewPasswordForm = new SetNewPasswordForm(this))
                        {
                            setNewPasswordForm.ShowDialog();
                        }
                    }

                    if (!EnvironmentSettings.CurrentUser.PasswordRecoveryActive)
                    {
                        using (var dashboardForm = new DashboardForm(this))
                        {
                            dashboardForm.ShowDialog();
                        }
                    }
                }
            }
        }

        private void tbLogin_Validating(object sender, CancelEventArgs e)
        {
            if (!InputValidators.Email(tbLogin.Text, out var errorMessage))
            {
                NoteError(lblEmailError, errorMessage);
            }
            else
            {
                CancelError(lblEmailError);
            }
        }

        private void tbPassword_Validating(object sender, CancelEventArgs e)
        {
            if (!InputValidators.NotEmpty(tbPassword.Text, "Hasło", out var errorMessage))
            {
                NoteError(lblPasswordError, errorMessage);
            }
            else
            {
                CancelError(lblPasswordError);
            }
        }

        private void LoginForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
            if (e.KeyCode == Keys.Return)
            {
                btnLogin_Click(this, EventArgs.Empty);
                e.SuppressKeyPress = true;
            }
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnForgotPassword_Click(object sender, EventArgs e)
        {
            using (var passwordResetForm = new PasswordResetForm(this))
            {
                Hide();
                passwordResetForm.ShowDialog();
            }
        }
    }
}
