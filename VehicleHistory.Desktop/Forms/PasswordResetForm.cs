using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using RestSharp;
using VehicleHistoryDesktop.Utility;

namespace VehicleHistoryDesktop.Forms
{
    public partial class PasswordResetForm : VHFormBase
    {
        private LoginForm _loginForm;

        public PasswordResetForm()
        {
            InitializeComponent();
        }

        public PasswordResetForm(LoginForm loginForm) : this()
        {
            _loginForm = loginForm;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            ValidateChildren();
            if (!IncorrectInputs.Any())
            {
                var response = ExecuteRestRequest("users/reset-password", tbEmail.Text, Method.POST, lblEmailError, null);
                if (response.IsSuccessful)
                {
                    var confirmationDialog = MessageBox.Show("Hasło zostało pomyślnie zresetowane. Wysłano wiadomość E-Mail", "Resetowanie hasła", MessageBoxButtons.OK);
                    if (confirmationDialog == DialogResult.OK)
                    {
                        Close();
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tbLogin_Validating(object sender, CancelEventArgs e)
        {
            if (!InputValidators.Email(tbEmail.Text, out var errorMessage))
            {
                NoteError(lblEmailError, errorMessage);
            }
            else
            {
                CancelError(lblEmailError);
            }
        }

        private void PasswordResetForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _loginForm.Show();
        }

        private void PasswordResetForm_KeyDown(object sender, KeyEventArgs e)
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
