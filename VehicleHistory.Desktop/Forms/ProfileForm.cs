using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using RestSharp;
using VehicleHistoryDesktop.Models;
using VehicleHistoryDesktop.Utility;

namespace VehicleHistoryDesktop.Forms
{
    public partial class ProfileForm : VHFormBase
    {
        public ProfileForm()
        {
            InitializeComponent();
        }

        public ProfileForm(ref User currentUser) : this()
        {
            CurrentUser = currentUser;
            tbEmail.Text = CurrentUser.Email;
            tbFirstName.Text = CurrentUser.FirstName;
            tbLastName.Text = CurrentUser.LastName;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            ValidateChildren();
            if (!IncorrectInputs.Any() && IsCurrentPasswordValid())
            {
                var user = new User
                {
                    Id = CurrentUser.Id,
                    Email = tbEmail.Text,
                    Password = tbNewPassword.Text,
                    FirstName = tbFirstName.Text,
                    LastName = tbLastName.Text,
                    LocationId = CurrentUser.LocationId
                };
                var response = ExecuteRestRequest($"users/{CurrentUser.Id}", user, Method.PUT, lblCurrentPasswordError, CurrentUser.Token);
                if (response.IsSuccessful)
                {
                    var responseUser = JsonConvert.DeserializeObject<User>(response.Content);
                    CurrentUser = responseUser;
                    Close();
                }
            }
        }

        private bool IsCurrentPasswordValid()
        {
            var user = new User
            {
                Email = CurrentUser.Email,
                Password = tbCurrentPassword.Text
            };
            var response = ExecuteRestRequest("/users/validate-password", user, Method.POST, lblCurrentPasswordError, CurrentUser.Token);
            return response.IsSuccessful;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void tbFirstName_Validating(object sender, CancelEventArgs e)
        {
            if (!InputValidators.NotEmpty(tbFirstName.Text, "Imię", out var errorMessage))
            {
                NoteError(lblFirstNameError, errorMessage);
            }
            else
            {
                CancelError(lblFirstNameError);
            }
        }

        private void tbLastName_Validating(object sender, CancelEventArgs e)
        {
            if (!InputValidators.NotEmpty(tbLastName.Text, "Nazwisko", out var errorMessage))
            {
                NoteError(lblLastNameError, errorMessage);
            }
            else
            {
                CancelError(lblLastNameError);
            }
        }

        private void tbEmail_Validating(object sender, CancelEventArgs e)
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

        private void tbCurrentPassword_Validating(object sender, CancelEventArgs e)
        {
            if (!InputValidators.NotEmpty(tbCurrentPassword.Text, "Obecne hasło", out var errorMessage))
            {
                NoteError(lblCurrentPasswordError, errorMessage);
            }
            else
            {
                CancelError(lblCurrentPasswordError);
            }
        }
    }
}
