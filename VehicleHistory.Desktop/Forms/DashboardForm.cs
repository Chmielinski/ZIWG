using System;
using System.Collections.Generic;
using RestSharp;
using VehicleHistoryDesktop.Models;

namespace VehicleHistoryDesktop.Forms
{
    public partial class DashboardForm : VHFormBase
    {
        private LoginForm _loginScreen;
        private RecordFilters _filters;
        private List<VehicleRecord> _allRecords;
        public DashboardForm()
        {
            InitializeComponent();
            GetRecords(false);

            _filters = new RecordFilters();
            _filters.DateFrom = _allRecords.Any() ? _allRecords.Min(x => x.Timestamp) : DateTime.Now.AddDays(-1);
            _filters.DateTo = DateTime.Now.AddDays(1);
            FilterItems();
			
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
            if (dgvRecords.Columns["UserId"] != null)
            {
                dgvRecords.Columns["UserId"].Visible = false;
            }
            if (dgvRecords.Columns["RecordTypeId"] != null)
            {
                dgvRecords.Columns["RecordTypeId"].Visible = false;
            }
        }

        public DashboardForm(LoginForm loginScreen) : this()
        {
            _loginScreen = loginScreen;
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
            using (var filtersForm = new FilterRecordsForm(_filters))
            {
                filtersForm.ShowDialog();
                _filters = filtersForm.FiltersResult;
                FilterItems();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            new ProfileForm().ShowDialog();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            var confirmationDialog = MessageBox.Show("Czy jesteś pewien, że chcesz się wylogować?", "Wyloguj", MessageBoxButtons.YesNo);
            if (confirmationDialog == DialogResult.Yes)
            {
                Close();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            var confirmationDialog = MessageBox.Show("Czy jesteś pewien, że chcesz zamknąć aplikację?", "Zamykanie aplikacji", MessageBoxButtons.YesNo);
            if (confirmationDialog == DialogResult.Yes)
            {
                ExecuteRestRequest("users/logout", null, Method.POST, null, EnvironmentSettings.CurrentUser.Token);
                EnvironmentSettings.CurrentUser = null;
                Application.Exit();
            }
        }

        private void DashboardForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (EnvironmentSettings.CurrentUser != null)
            {
                ExecuteRestRequest("users/logout", null, Method.POST, null, EnvironmentSettings.CurrentUser.Token);
                EnvironmentSettings.CurrentUser = null;
                _loginScreen.Show();
            }
            Dispose();
        }

        private void GetRecords(bool filter = true)
        {
            var response = ExecuteRestRequest("vehiclerecords/byuser", null, Method.GET, null, EnvironmentSettings.CurrentUser.Token);
            if (response.IsSuccessful)
            {
                _allRecords = JsonConvert.DeserializeObject<List<VehicleRecord>>(response.Content);
                if (filter)
                {
                    FilterItems();
                }
            }
        }

        private void FilterItems()
        {
            dgvRecords.DataSource = _allRecords
                .Where(x => x.Mileage >= _filters.MileageFrom && x.Mileage <= _filters.MileageTo)
                .Where(x => _filters.RecordTypes.Contains((RecordTypes) x.RecordTypeId) || !_filters.RecordTypes.Any())
                .Where(x => x.Description.Contains(_filters.Phrase) || x.Title.Contains(_filters.Phrase) || x.Vin.Contains(_filters.Phrase))
                .Where(x => x.Timestamp >= _filters.DateFrom && x.Timestamp <= _filters.DateTo)
                .ToList();
        }
    }
}
