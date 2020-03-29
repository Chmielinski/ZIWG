using System;
using System.Collections.Generic;
using RestSharp;
using VehicleHistoryDesktop.Models;

namespace VehicleHistoryDesktop.Forms
{
    public partial class DashboardForm : VHFormBase
    {
        private LoginForm _loginScreen;
        public DashboardForm()
        {
            InitializeComponent();
        }

        public DashboardForm(List<VehicleRecord> records, LoginForm loginScreen, User currentUser) : this()
        {
            _loginScreen = loginScreen;
            CurrentUser = currentUser;
            dgvRecords.DataSource = records;
            if (dgvRecords.Columns["Id"] != null)
            {
                dgvRecords.Columns["Id"].Visible = false;
            }
            if (dgvRecords.Columns["InsertDateStr"] != null)
            {
                dgvRecords.Columns["InsertDateStr"].Visible = false;
            }
            if (dgvRecords.Columns["UpdateDateStr"] != null)
            {
                dgvRecords.Columns["UpdateDateStr"].Visible = false;
            }
            if (dgvRecords.Columns["User"] != null)
            {
                dgvRecords.Columns["User"].Visible = false;
            }
            if (dgvRecords.Columns["RecordTypeId"] != null)
            {
                dgvRecords.Columns["RecordTypeId"].Visible = false;
            }
        }

        private void btnNewRecord_Click(object sender, EventArgs e)
        {

        }

        private void btnShowDetails_Click(object sender, EventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            new ProfileForm(ref CurrentUser).ShowDialog();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            ExecuteRestRequest("users/logout", null, Method.POST, null, CurrentUser.Token);
            _loginScreen.Show();
            Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            ExecuteRestRequest("users/logout", null, Method.POST, null, CurrentUser.Token);
        }
    }
}
