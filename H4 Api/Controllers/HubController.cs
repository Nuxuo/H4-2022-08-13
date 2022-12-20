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
using Newtonsoft.Json;

namespace Controllers{
    [Route("[Controller]")]
    [ApiController]
    public class HubController : Controller{
        private readonly IHubRepos _repos;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly LinkGenerator _linkGenerator;

        public HubController(IHubRepos reposContext, IMapper mapperContext, ILogger<Hub> loggerContext, LinkGenerator linkContext){
            _repos = reposContext ?? throw new ArgumentNullException(nameof(reposContext));
            _mapper = mapperContext ?? throw new ArgumentNullException(nameof(mapperContext));
            _logger = loggerContext ?? throw new ArgumentNullException(nameof(loggerContext));
            _linkGenerator = linkContext ?? throw new ArgumentNullException(nameof(linkContext));
        }

        [HttpGet("")]
        public IActionResult GetHubs(){
            var _result = _repos.GetHubs();
            var _mapped = _mapper.Map<IEnumerable<HubDto>>(_result);
            _logger.LogDebug("Returned all hubs",DateTime.UtcNow.ToLongTimeString());

            return _result != null ? Ok(_mapped) : NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult GetHub(int id){
            var _result = _repos.GetHubById(id);
            var _mapped = _mapper.Map<Expanded_HubDto>(_result);
            _logger.LogDebug("Returned all hub datapackages",DateTime.UtcNow.ToLongTimeString());

            return _result != null ? Ok(_mapped) : NotFound();
        }
        
        [HttpGet("{id}/Sensors")]
        public IActionResult GetHubSensors(int id){
            var _result = _repos.GetHubSensors(id);
            var _mapped = _mapper.Map<IEnumerable<HubSensorsDto>>(_result);
            _logger.LogDebug("Returned all hub sensors",DateTime.UtcNow.ToLongTimeString());

            return _result != null ? Ok(_mapped) : NotFound();
        }
                
        [HttpGet("{id}/Datapackages")]
        public IActionResult GetHubDatapackages(int id){
            var _result = _repos.GetHubDatapackages(id);
            var _mapped = _mapper.Map<IEnumerable<DataPackageDto>>(_result);
            _logger.LogDebug("Returned all hub datapackages",DateTime.UtcNow.ToLongTimeString());

            return _result != null ? Ok(_mapped) : NotFound();
        }

        [HttpPost("")]
        public ActionResult CreateHub([FromBody] string _input){
            Entry_HubDto _postInput = JsonConvert.DeserializeObject<Entry_HubDto>(_input);

            var _result = _repos.CreateHub(_postInput);
            if(_result == null){return BadRequest();}

            _logger.LogDebug("Created hub : " + _result.Id,DateTime.UtcNow.ToLongTimeString());
            var _mapped = _mapper.Map<HubDto>(_result);

            return CreatedAtAction(nameof(GetHub), new { id = _mapped.Id }, _mapped);
        }

        [HttpPost("HubSensor")]
        public ActionResult CreateHubSensor([FromBody] string _input){
            Entry_HubSensorsDto _postInput = JsonConvert.DeserializeObject<Entry_HubSensorsDto>(_input);
            
            var _result = _repos.CreateHubSensor(_postInput);
            if(_result == null){return BadRequest();}

            _logger.LogDebug("Created hub sensor : " + _result.Id,DateTime.UtcNow.ToLongTimeString());
            var _mapped = _mapper.Map<HubSensors>(_result);

            return CreatedAtAction(nameof(GetHubSensors), new { id = _mapped.HubId }, _mapped);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateSensor(int id, [FromBody] Entry_HubDto _input){
            var _result = _repos.UpdateHub(id,_input);
            if(_result == null){return BadRequest();}

            _logger.LogDebug("Updated hub : " + _result.Id,DateTime.UtcNow.ToLongTimeString());
            var _mapped = _mapper.Map<HubDto>(_result);

            return Accepted(_mapped);
        }
     
        [HttpPut("HubSensor/{id}")]
        public ActionResult UpdateHubSensor(int id, [FromBody] Entry_HubSensorsDto _input){
            var _result = _repos.UpdateHubSensor(id,_input);
            if(_result == null){return BadRequest();}

            _logger.LogDebug("Updated hub sensor : " + _result.Id,DateTime.UtcNow.ToLongTimeString());
            var _mapped = _mapper.Map<HubSensorsDto>(_result);

            return Accepted(_mapped);
        }

        [HttpDelete("Hard/{id}")]
        public ActionResult HardDeleteHub(int id){
            var _result = _repos.HardDeleteHubById(id);
            if(_result == null){return BadRequest();}

            _logger.LogDebug("hard deleted hub : " + _result.Id,DateTime.UtcNow.ToLongTimeString());
            var _mapped = _mapper.Map<HubDto>(_result);

            return NoContent();
        }

        [HttpDelete("Soft/{id}")]
        public ActionResult SoftDeleteHub(int id){
            var _result = _repos.SoftDeleteHubById(id);
            if(_result == null){return BadRequest();}

            _logger.LogDebug("soft deleted hub : " + _result.Id,DateTime.UtcNow.ToLongTimeString());
            var _mapped = _mapper.Map<HubDto>(_result);

            return Ok(_mapped);
        }

        [HttpDelete("HubSensor/{id}")]
        public ActionResult DeleteHubSensor(int id){
            var _result = _repos.DeleteHubSensor(id);
            if(_result == null){return BadRequest();}

            _logger.LogDebug("deleted hub sensor : " + _result.Id,DateTime.UtcNow.ToLongTimeString());
            var _mapped = _mapper.Map<HubSensorsDto>(_result);

            return NoContent();
        }
    }
}