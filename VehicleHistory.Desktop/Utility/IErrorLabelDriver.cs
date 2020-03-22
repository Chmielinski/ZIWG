using System.Windows.Forms;

namespace VehicleHistoryDesktop.Utility
{
    interface IErrorLabelDriver
    {
        void NoteError(Label targetLabel, string errorMessage);

        void CancelError(Label targetLabel);
    }
}
