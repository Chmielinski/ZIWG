using System;
using System.Net.Http;
using RestSharp;
using VehicleHistoryDesktop.Models;

namespace VehicleHistoryDesktop.Utility
{
    public class EnvironmentSettings
    {
        private static EnvironmentSettings _currentEnvironmentSettings;
        public Uri WebApiUrl { get; }
        public static User CurrentUser { get; set; }

        public static HttpClient HttpClient = new HttpClient();

        public static RestClient RestClient = new RestClient();


        private EnvironmentSettings()
        {

        }

        private EnvironmentSettings(string url)
        {
            WebApiUrl = new Uri(url);
            RestClient.BaseUrl = WebApiUrl;
            HttpClient.BaseAddress = WebApiUrl;
        }

        public static EnvironmentSettings Create()
        {
            if (_currentEnvironmentSettings == null)
            {
                _currentEnvironmentSettings = new EnvironmentSettings();
            }

            return _currentEnvironmentSettings;
        }

        public static EnvironmentSettings CreateWithUrl(string url)
        {
            if (_currentEnvironmentSettings == null)
            {
                _currentEnvironmentSettings = new EnvironmentSettings(url);
            }

            return _currentEnvironmentSettings;
        }
    }
}
