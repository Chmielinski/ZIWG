using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VehicleHistory.Logic.Services.Interfaces;
using AutoMapper;
using VehicleHistory.Logic.Models.Database;
using VehicleHistory.Logic.Models.Dtos;
using VehicleHistory.Logic.Models.Enums;
using VehicleHistory.Logic.Models.Utility;

namespace VehicleHistory.WebApi.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class VehicleRecordsController : ControllerBase
    {
        private IVehicleRecordsService _vehicleRecordsService;

        private IMapper _mapper;

        private IDictionaryService _dictionaryService;

        public VehicleRecordsController(IVehicleRecordsService vehicleRecordsService, IMapper mapper, IDictionaryService dictionaryService)
        {
            _vehicleRecordsService = vehicleRecordsService;
            _mapper = mapper;
            _dictionaryService = dictionaryService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var records = _vehicleRecordsService.GetAllRecords();
            var recordsDto = _mapper.Map<IList<VehicleRecordDto>>(records);
            return Ok(recordsDto);
        }

        [HttpGet("{id}")]
        public IActionResult GetRecordById(string id)
        {
            var record = _vehicleRecordsService.GetRecordById(id);
            var recordDto = _mapper.Map<VehicleRecordDto>(record);
            return Ok(recordDto);
        }

        [HttpGet("byuser")]
        public IActionResult GetRecordsForCurrentUser()
        {
            try
            {
                var userId = HttpContext.User.Identity.Name;
                var records = _vehicleRecordsService.GetRecordsByUser(userId);
                var recordsDto = _mapper.Map<IList<VehicleRecordDto>>(records);
                foreach (var record in recordsDto)
                {
                    record.RecordTypeStr = _dictionaryService.GetDictionaryItem(DictionaryType.RecordTypes, record.RecordTypeId).StringValue;
                }
                return Ok(recordsDto);
            }
            catch (Exception ex)
            {
                return BadRequest(new {message = ex.Message});
            }
        }

        [AllowAnonymous]
        [HttpGet("byvin/{vin}")]
        public IActionResult GetRecordsForVin(string vin)
        {
            try
            {
                var records = _vehicleRecordsService.GetAllRecordsByVin(vin);
                var recordsDto = _mapper.Map<IList<VehicleRecordDto>>(records);
                foreach (var record in recordsDto)
                {
                    record.RecordTypeStr = _dictionaryService.GetDictionaryItem(DictionaryType.RecordTypes, record.RecordTypeId).StringValue;
                }
                return Ok(recordsDto);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
