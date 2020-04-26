using System;
using System.Linq;
using System.Windows.Forms;
using VehicleHistoryDesktop.Models;
using VehicleHistoryDesktop.Utility;

namespace VehicleHistoryDesktop.Forms
{
    public partial class FilterRecordsForm : VHFormBase
    {
        public RecordFilters FiltersResult { get; set; }
        public FilterRecordsForm()
        {
            InitializeComponent();
            clbTypesOptions.DataSource = Dictionaries.GetDictionaries().Where(x => x.DictionaryTypeId == 1).ToList();
            clbTypesOptions.DisplayMember = "StringValue";
            clbTypesOptions.ValueMember = "EnumValue";
        }

        public FilterRecordsForm(RecordFilters currentFilters) : this()
        {
            tbPhrase.Text = currentFilters.Phrase;
            nudFrom.Value = currentFilters.MileageFrom ?? 0;
            nudTo.Value = currentFilters.MileageTo ?? nudTo.Maximum;
            cbAllTypes.Checked = currentFilters.RecordTypes == null || currentFilters.RecordTypes.Count() == 0;
            if (currentFilters.RecordTypes != null)
            {
                for (var i = 0; i < clbTypesOptions.Items.Count; i++)
                {
                    var item = clbTypesOptions.Items[i] as DictionaryItem;
                    if (item == null)
                    {
                        continue;
                    }
                    if (currentFilters.RecordTypes.Contains((RecordTypes) item.EnumValue))
                    {
                        clbTypesOptions.SetItemChecked(i, true);
                    }
                }
            }
            dtpFrom.Value = currentFilters.DateFrom;
            dtpTo.Value = currentFilters.DateTo;

            FiltersResult = currentFilters;
        }


        private void cbAllTypes_CheckedChanged(object sender, EventArgs e)
        {
            if (cbAllTypes.Focused)
            {
                for (var i = 0 ; i < clbTypesOptions.Items.Count; i++)
                {
                    clbTypesOptions.SetItemChecked(i, false);
                }
            }

            cbAllTypes.Enabled = !cbAllTypes.Checked;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!IncorrectInputs.Any())
            {
                FiltersResult.Phrase = tbPhrase.Text;
                FiltersResult.MileageFrom = Convert.ToInt32(nudFrom.Value);
                FiltersResult.MileageTo = Convert.ToInt32(nudTo.Value);
                FiltersResult.RecordTypes = clbTypesOptions.CheckedItems.OfType<DictionaryItem>().Select(x => (RecordTypes)x.EnumValue).ToList();
                FiltersResult.DateFrom = dtpFrom.Value;
                FiltersResult.DateTo = dtpTo.Value;
                Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void clbTypesOptions_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (clbTypesOptions.CheckedItems.Count == 0 && e.NewValue == CheckState.Checked)
            {
                cbAllTypes.Checked = false;
            }
            else if (clbTypesOptions.CheckedItems.Count == 1 && e.NewValue == CheckState.Unchecked)
            {
                cbAllTypes.Checked = true;
            }
            else
            {
                cbAllTypes.Checked = clbTypesOptions.CheckedItems.Count == 0;
            }
        }

        private void MileageRangeChanged(object sender, EventArgs e)
        {
            if (!InputValidators.Range(nudFrom.Value, nudTo.Value, out var errorMessage))
            {
                NoteError(lblRangeError, errorMessage);
            }
            else
            {
                CancelError(lblRangeError);
            }
        }

        private void DateRangeChanged(object sender, EventArgs e)
        {
            if (!InputValidators.Range(dtpFrom.Value, dtpTo.Value, out var errorMessage))
            {
                NoteError(lblDatesError, errorMessage);
            }
            else
            {
                CancelError(lblDatesError);
            }
        }

        private void FilterRecordsForm_KeyDown(object sender, KeyEventArgs e)
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
