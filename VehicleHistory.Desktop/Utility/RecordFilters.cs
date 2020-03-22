using System;
using System.Collections.Generic;
using VehicleHistoryDesktop.Models;

namespace VehicleHistoryDesktop.Utility
{
    public class RecordFilters
    {
        public string Phrase { get; set; }
        public int? MileageFrom { get; set; }
        public int? MileageTo { get; set; }
        public IEnumerable<RecordTypes> RecordTypes { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public RecordFilters()
        {
            Phrase = "";
            MileageFrom = 0;
            MileageTo = 9999999;
            RecordTypes = new List<RecordTypes>();
        }
    }
}
