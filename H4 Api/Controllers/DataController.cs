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
    public class DataController : Controller{
        private readonly IDataRepos _repos;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly LinkGenerator _linkGenerator;

        public DataController(IDataRepos reposContext, IMapper mapperContext, ILogger<Hub> loggerContext, LinkGenerator linkContext){
            _repos = reposContext ?? throw new ArgumentNullException(nameof(reposContext));
            _mapper = mapperContext ?? throw new ArgumentNullException(nameof(mapperContext));
            _logger = loggerContext ?? throw new ArgumentNullException(nameof(loggerContext));
            _linkGenerator = linkContext ?? throw new ArgumentNullException(nameof(linkContext));
        }

        [HttpGet("")]
        public IActionResult GetDatapackages(){
            var _result = _repos.GetDataPackages();
            var _mapped = _mapper.Map<IEnumerable<DataPackageDto>>(_result);
            _logger.LogDebug("Returned all datapackages",DateTime.UtcNow.ToLongTimeString());

            return _result != null ? Ok(_mapped) : NotFound();
        }

        [HttpGet("{id}/SensorData")]
        public IActionResult GetHubDatapackagesExpanded(int id){
            var _result = _repos.GetHubDataPackagesExpanded(id);
            var _mapped = _mapper.Map<IEnumerable<Expanded_DataPackageDto>>(_result);
            _logger.LogDebug("Returned all datapackages",DateTime.UtcNow.ToLongTimeString());

            return _result != null ? Ok(_mapped) : NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult GetDatapackage(int id){
            var _result = _repos.GetDataPackage(id);
            var _mapped = _mapper.Map<Id_Expanded_DataPackageDto>(_result);
            _logger.LogDebug("Returned datapackages",DateTime.UtcNow.ToLongTimeString());

            return _result != null ? Ok(_mapped) : NotFound();
        }

        [HttpGet("{id}/Chart")]
        public IActionResult GetChartDatapackage(int id){
            var _result = _repos.GetChartData(id);
            _logger.LogDebug("Returned chart datapackages",DateTime.UtcNow.ToLongTimeString());

            return _result != null ? Ok(_result) : NotFound();
        }

        [HttpGet("{id}/Chart/Days/{days}")]
        public IActionResult GetChartDatapackage(int id,int days){
            var _result = _repos.GetDaysChartData(id,days);
            _logger.LogDebug("Returned chart datapackages",DateTime.UtcNow.ToLongTimeString());

            return _result != null ? Ok(_result) : NotFound();
        }

        [HttpGet("{id}/Statistics")]
        public async Task<IActionResult> GetDataStatistics(int id){
            var _result = await _repos.GetStatisticsData(id);
            if(_result == null){return BadRequest();}

            _logger.LogDebug("Returned Statistics for " + id,DateTime.UtcNow.ToLongTimeString());
            Console.WriteLine(_result.SensorStats);
            return _result != null ? Ok(_result) : NotFound();
        }

        [HttpPost("")]
        public IActionResult CreateDatapackage([FromBody] Entry_DataPackageDto _input){
            var _result = _repos.CreateDataPackage(_input);
            if(_result == null){return BadRequest();}

            _logger.LogDebug("Created data package & sensor data : " + _result.Id,DateTime.UtcNow.ToLongTimeString());
            var _mapped = _mapper.Map<DataPackageDto>(_result);

            return CreatedAtAction(nameof(GetDatapackage), new { id = _mapped.Id }, _mapped);

        }

        [HttpPut("{id}")]
        public ActionResult UpdateDatapackage(int id, [FromBody] Base_Entry_DataPackageDto _input){
            var _result = _repos.UpdateDataPackage(id,_input);
            if(_result == null){return BadRequest();}

            _logger.LogDebug("Updated data package : " + _result.Id,DateTime.UtcNow.ToLongTimeString());
            var _mapped = _mapper.Map<RoomDto>(_result);

            return Accepted(_mapped);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteDatapackage(int id){
            var _result = _repos.DeleteDataPackage(id);
            if(_result == null){return BadRequest();}

            _logger.LogDebug("deleted datapackage & sensor data : " + _result.Id,DateTime.UtcNow.ToLongTimeString());
            var _mapped = _mapper.Map<DataPackageDto>(_result);

            return NoContent();
        }
    }
}