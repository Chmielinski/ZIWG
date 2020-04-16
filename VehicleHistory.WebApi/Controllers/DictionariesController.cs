using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VehicleHistory.Logic.Models.Dtos;
using VehicleHistory.Logic.Models.Enums;
using VehicleHistory.Logic.Services.Interfaces;

namespace VehicleHistory.WebApi.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class DictionariesController : ControllerBase
    {
        private IDictionaryService _dictionaryService;

        private IMapper _mapper;

        public DictionariesController(IDictionaryService dictionaryService, IMapper mapper)
        {
            _dictionaryService = dictionaryService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetAll()
        {
            var dictionaryItems = _dictionaryService.GetAllDictionaryItems();
            var dictionaryItemsDto = _mapper.Map<IList<DictionaryItemDto>>(dictionaryItems);
            return Ok(dictionaryItemsDto);
        }

        [AllowAnonymous]
        [HttpGet("{dictionaryType}")]
        public IActionResult GetItemsByType(int dictionaryType)
        {
            var dictionaryItems = _dictionaryService.GetItemsByDictionaryType((DictionaryType)dictionaryType);
            var dictionaryItemsDto = _mapper.Map<IList<DictionaryItemDto>>(dictionaryItems);
            return Ok(dictionaryItemsDto);
        }

        [AllowAnonymous]
        [HttpGet("{dictionaryType}/{itemKey}")]
        public IActionResult GetItem(int dictionaryType, int itemKey)
        {
            var dictionaryItem = _dictionaryService.GetDictionaryItem((DictionaryType)dictionaryType, itemKey);
            var dictionaryItemDto = _mapper.Map<DictionaryItemDto>(dictionaryItem);
            return Ok(dictionaryItemDto);
        }
    }
}
