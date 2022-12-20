using System;
using Models;
using AutoMapper;
using Repositories;
using DataTransferObject;
using DataTransferObject.Base;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Controllers{
    [Route("[Controller]")]
    [ApiController]
    public class LocationController : Controller{
        private readonly ILocationRepos _repos;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly LinkGenerator _linkGenerator;

        public LocationController(ILocationRepos reposContext, IMapper mapperContext, ILogger<Hub> loggerContext, LinkGenerator linkContext){
            _repos = reposContext ?? throw new ArgumentNullException(nameof(reposContext));
            _mapper = mapperContext ?? throw new ArgumentNullException(nameof(mapperContext));
            _logger = loggerContext ?? throw new ArgumentNullException(nameof(loggerContext));
            _linkGenerator = linkContext ?? throw new ArgumentNullException(nameof(linkContext));
        }


        [HttpGet("Rooms")]
        public IActionResult GetRooms(){
            var _result = _repos.GetRooms();
            var _mapped = _mapper.Map<IEnumerable<RoomDto>>(_result);
            _logger.LogDebug("Returned all rooms",DateTime.UtcNow.ToLongTimeString());

            return _result != null ? Ok(_mapped) : NotFound();
        }

        [HttpGet("Buildings")]
        public IActionResult GetBuildings(){
            var _result = _repos.GetBuildings();
            var _mapped = _mapper.Map<IEnumerable<BuildingDto>>(_result);
            _logger.LogDebug("Returned all buildings",DateTime.UtcNow.ToLongTimeString());

            return _result != null ? Ok(_mapped) : NotFound();
        }
        
        [HttpGet("Building/{id}/Rooms")]
        public IActionResult GetBuildingsRooms(int id){
            var _result = _repos.GetBuildingRooms(id);
            var _mapped = _mapper.Map<IEnumerable<RoomDto>>(_result);
            _logger.LogDebug("Returned all buildings rooms",DateTime.UtcNow.ToLongTimeString());

            return _result != null ? Ok(_mapped) : NotFound();
        }

        [HttpGet("Building/{id}/Hubs")]
        public IActionResult GetBuildingsHubs(int id){
            var _result = _repos.GetBuildingHubs(id);
            var _mapped = _mapper.Map<IEnumerable<HubDto>>(_result);
            _logger.LogDebug("Returned all buildings hubs",DateTime.UtcNow.ToLongTimeString());

            return _result != null ? Ok(_mapped) : NotFound();
        }

        [HttpGet("Room/{id}/Hubs")]
        public IActionResult GetRoomHubs(int id){
            var _result = _repos.GetRoomHubs(id);
            var _mapped = _mapper.Map<IEnumerable<HubDto>>(_result);
            _logger.LogDebug("Returned all room hubs",DateTime.UtcNow.ToLongTimeString());

            return _result != null ? Ok(_mapped) : NotFound();
        }

        [HttpGet("Room/{id}/Datapackages")]
        public IActionResult GetRoomDatapackages(int id){
            var _result = _repos.GetRoomDataPackages(id);
            var _mapped = _mapper.Map<IEnumerable<DataPackageDto>>(_result);
            _logger.LogDebug("Returned all room data",DateTime.UtcNow.ToLongTimeString());

            return _result != null ? Ok(_mapped) : NotFound();
        }

        [HttpGet("Building/{id}/Datapackages")]
        public IActionResult GetBuildingDatapackages(int id){
            var _result = _repos.GetBuildingDataPackages(id);
            var _mapped = _mapper.Map<IEnumerable<DataPackageDto>>(_result);
            _logger.LogDebug("Returned all room data",DateTime.UtcNow.ToLongTimeString());

            return _result != null ? Ok(_mapped) : NotFound();
        }


        [HttpPost("Building")]
        public ActionResult CreateBuilding([FromBody] Entry_BuildingDto _input){
            var _result = _repos.CreateBuilding(_input);
            if(_result == null){return BadRequest();}

            _logger.LogDebug("Created Building : " + _result.Id,DateTime.UtcNow.ToLongTimeString());
            var _mapped = _mapper.Map<BuildingDto>(_result);

            return CreatedAtAction(nameof(_mapped), new { id = _mapped.Id }, _mapped);
        }

        [HttpPost("Room")]
        public ActionResult CreateRoom([FromBody] Entry_RoomDto _input){
            var _result = _repos.CreateRoom(_input);
            if(_result == null){return BadRequest();}

            _logger.LogDebug("Created room : " + _result.Id,DateTime.UtcNow.ToLongTimeString());
            var _mapped = _mapper.Map<RoomDto>(_result);

            return CreatedAtAction(nameof(_mapped), new { id = _mapped.Id }, _mapped);
        }

        [HttpPut("Room/{id}")]
        public ActionResult UpdateRoom(int id, [FromBody] Entry_RoomDto _input){
            var _result = _repos.UpdateRoom(id,_input);
            if(_result == null){return BadRequest();}

            _logger.LogDebug("Updated room : " + _result.Id,DateTime.UtcNow.ToLongTimeString());
            var _mapped = _mapper.Map<RoomDto>(_result);

            return Accepted(_mapped);
        }

        [HttpPut("Building/{id}")]
        public ActionResult UpdateBuilding(int id, [FromBody] Entry_BuildingDto _input){
            var _result = _repos.UpdateBuilding(id,_input);
            if(_result == null){return BadRequest();}

            _logger.LogDebug("Updated building : " + _result.Id,DateTime.UtcNow.ToLongTimeString());
            var _mapped = _mapper.Map<BuildingDto>(_result);

            return Accepted(_mapped);
        }

        [HttpDelete("Building/{id}")]
        public ActionResult DeleteBuilding(int id){
            var _result = _repos.DeleteBuilding(id);
            if(_result == null){return BadRequest();}

            _logger.LogDebug("deleted building : " + _result.Id,DateTime.UtcNow.ToLongTimeString());
            var _mapped = _mapper.Map<BuildingDto>(_result);

            return NoContent();
        }

        [HttpDelete("Room/{id}")]
        public ActionResult DeleteRoom(int id){
            var _result = _repos.DeleteRoom(id);
            if(_result == null){return BadRequest();}

            _logger.LogInformation("deleted building : " + _result.Id,DateTime.UtcNow.ToLongTimeString());
            var _mapped = _mapper.Map<RoomDto>(_result);

            return NoContent();
        }
    }
}