using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json;
using RestSharp;
using VehicleHistoryDesktop.Models;
using VehicleHistoryDesktop.Properties;
using VehicleHistoryDesktop.Utility;

namespace VehicleHistoryDesktop.Forms
{
    public partial class VHFormBase : Form, IErrorLabelDriver
    {
        protected readonly List<Label> IncorrectInputs = new List<Label>();
        protected Uri WebApiUrl { get; }

        protected VHFormBase()
        {
            var environmentSettings = EnvironmentSettings.CreateWithUrl(Settings.Default["WebApiUrl" + Environment.GetEnvironmentVariable("runenv")].ToString());
            WebApiUrl = environmentSettings.WebApiUrl;
            InitializeComponent();
            KeyPreview = true;
        }
        public void NoteError(Label targetLabel, string errorMessage)
        {
            targetLabel.Text = errorMessage;
            targetLabel.Visible = true;
            if (IncorrectInputs.All(label => label != targetLabel))
            {
                IncorrectInputs.Add(targetLabel);
            }
        }

        public void CancelError(Label targetLabel)
        {
            targetLabel.Visible = false;
            if (IncorrectInputs.Any(label => label == targetLabel))
            {
                IncorrectInputs.Remove(targetLabel);
            }
        }

        public IRestResponse ExecuteRestRequest(string path, object requestParams, Method method, Label errorTargetLabel, string token)
        {
            var request = new RestRequest(path, method);
            if (requestParams != null)
            {
                request.AddJsonBody(requestParams);
            }

            if (token != null)
            {
                request.AddHeader("Authorization", $"Bearer {token}");
            }
            var response = EnvironmentSettings.RestClient.Execute(request);
            if (!response.IsSuccessful)
            {
                var message = JsonConvert.DeserializeObject<BadResponse>(response.Content).Message;
                if (errorTargetLabel != null)
                {
                    NoteError(errorTargetLabel, message);
                }
            }

            return response;
        }
    }
}
