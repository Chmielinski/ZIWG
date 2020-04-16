using System.Collections.Generic;
using VehicleHistory.Logic.Models.Database;
using VehicleHistory.Logic.Models.Enums;

namespace VehicleHistory.Logic.Services.Interfaces
{
    public interface IDictionaryService
    {
        List<DictionaryItem> GetAllDictionaryItems();
        List<DictionaryItem> GetItemsByDictionaryType(DictionaryType dictionaryType);
        DictionaryItem GetDictionaryItem(DictionaryType dictionaryType, int itemKey);
    }
}
