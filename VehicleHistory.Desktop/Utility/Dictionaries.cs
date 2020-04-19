using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;
using VehicleHistoryDesktop.Models;

namespace VehicleHistoryDesktop.Utility
{
    public class Dictionaries
    {
        private static List<DictionaryItem> _dictionaryItems;

        private Dictionaries()
        {

        }

        public static List<DictionaryItem> GetDictionaries()
        {
            if (_dictionaryItems == null)
            {
                var request = new RestRequest("dictionaries", Method.GET);

                EnvironmentSettings.RestClient.Execute(request);
                var response = EnvironmentSettings.RestClient.Execute(request);
                if (response.IsSuccessful)
                {
                    _dictionaryItems = JsonConvert.DeserializeObject<List<DictionaryItem>>(response.Content);
                }
                if (!response.IsSuccessful)
                {
                    throw new Exception("Błąd przy pobieraniu konfiguracji.");
                }
            }

            return _dictionaryItems;
        }
    }
}
