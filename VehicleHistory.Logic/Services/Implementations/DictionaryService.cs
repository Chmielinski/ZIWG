using System.Collections.Generic;
using System.Linq;
using VehicleHistory.Logic.DB;
using VehicleHistory.Logic.Models.Database;
using VehicleHistory.Logic.Models.Enums;
using VehicleHistory.Logic.Services.Interfaces;

namespace VehicleHistory.Logic.Services.Implementations
{
    public class DictionaryService : IDictionaryService
    {
        private List<DictionaryItem> AllItems { get; set; }

        public DictionaryService(VehicleHistoryContext context)
        {
            AllItems = context.DictionaryItems.ToList();
        }
        public List<DictionaryItem> GetAllDictionaryItems()
        {
            return AllItems;
        }

        public List<DictionaryItem> GetItemsByDictionaryType(DictionaryType dictionaryType)
        {
            return AllItems.Where(x => x.DictionaryType == dictionaryType).ToList();
        }

        public DictionaryItem GetDictionaryItem(DictionaryType dictionaryType, int itemKey)
        {
            return AllItems.FirstOrDefault(x => x.DictionaryType == dictionaryType && x.EnumValue == itemKey);
        }
    }
}
