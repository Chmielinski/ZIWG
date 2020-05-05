using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VehicleHistory.Logic.Services.Interfaces;
using AutoMapper;
using Microsoft.Extensions.Options;
using VehicleHistory.Logic.Models.Database;
using VehicleHistory.Logic.Models.Dtos;
using VehicleHistory.Logic.Models.Utility;

namespace VehicleHistory.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private ILocationsService _locationsService;

        private IMapper _mapper;

        private AppSettings _appSettings;

        public LocationsController(ILocationsService locationsService, IMapper mapper, IOptions<AppSettings> appSettings)
        {
            _locationsService = locationsService;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var locations = _locationsService.GetAllLocations();
            var locationsDto = _mapper.Map<IList<LocationDto>>(locations);
            foreach (var location in locationsDto)
            {
                location.Operators = _mapper.Map<IList<UserDto>>(_locationsService.GetLocationOperators(location));
            }
            return Ok(locationsDto);
        }

        [HttpGet("{id}")]
        public IActionResult GetLocationById(string id)
        {
            var location = _locationsService.GetLocationById(id);
            var locationDto = _mapper.Map<LocationDto>(location);
            return Ok(locationDto);
        }

        [AllowAnonymous]
        [HttpPost("add")]
        public IActionResult AddLocation([FromBody] LocationApplicationDto applicationDto)
        {
            var application = new LocationApplication();
            application = _mapper.Map(applicationDto, application);
            try
            {
                _locationsService.Create(application);
                return Ok();
            }
            catch (AppException ex)
            {
                return BadRequest(new {message = ex.Message});
            }
        }

        [HttpPut("accept/{id}")]
        public IActionResult AcceptApplication(string id)
        {
            try
            {
                _locationsService.HandleApplication(true, id, _appSettings);
                return GetActiveApplications();
            }
            catch (AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("reject/{id}")]
        public IActionResult RejectApplication(string id)
        {
            try
            {
                _locationsService.HandleApplication(false, id, _appSettings);
                return GetActiveApplications();
            }
            catch (AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("applications")]
        public IActionResult GetActiveApplications()
        {
            try
            {
                var applications = _locationsService.GetActiveApplications();
                var applicationsDto = _mapper.Map<IList<LocationApplicationDto>>(applications);
                return Ok(applicationsDto);
            }
            catch (AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

    }
}
