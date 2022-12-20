using Microsoft.EntityFrameworkCore;
using Context;
using Models;
using DataTransferObject;

namespace Repositories{
    public class DataRepos : IDataRepos{
        private readonly DatabaseContext _context;
        public DataRepos(DatabaseContext context){
            _context = context ?? throw new NullReferenceException(nameof(context));
        }
        
        public IEnumerable<DataPackage> GetDataPackages(){
            IEnumerable<DataPackage> data = null;
            try{
                data = _context.DataPackage.ToList();
            }
            catch{
                return null;
            }
            return data;
        } 
        public IEnumerable<DataPackage> GetHubDataPackagesExpanded(int id){
            IEnumerable<DataPackage> data = null;
            try{
                data = _context.DataPackage.Include(x=>x.SensorData).Where(x=>x.HubId == id).ToList();
            }
            catch{
                return null;
            }
            return data;
        }
        public chart_DataPackageDto GetChartData(int id, int? days = null, int? dataPoints = null){      
            chart_DataPackageDto _cd = new chart_DataPackageDto();

            int sensor_index = 0;
            var _sensors = _context.HubSensors.Include(x=>x.Sensor).Where(x=>x.HubId == id).OrderBy(x=>x.SensorId);
            _cd.Sensor = new string[_sensors.Count()];
            foreach (HubSensors _hs in _sensors){
                _cd.Sensor[sensor_index] = _hs.Sensor.Name;
                sensor_index++;
            }

            //var _datapackage = _context.DataPackage.Include(x=>x.SensorData).Where(x=>x.HubId == id && x.CreatedDate > x.CreatedDate.AddDays(-days));

            var _datapackage = _context.DataPackage.Include(x=>x.SensorData).Where(x=>x.HubId == id);
            _cd.SensorData = new List<List<object>>();
            foreach (DataPackage _dp in _datapackage){
                List<Object> Child = new List<Object>();

                Child.Add(_dp.CreatedDate.ToString());
                foreach(SensorData _sd in _dp.SensorData.OrderBy(x=>x.SensorId)){
                    float _value = _sd.Data;

                    if(_sd.SensorId == 3)
                        _value = _value / 10;
                    
                    if(_sd.SensorId == 4)
                        _value = _value / 5;

                    Child.Add(_value);
                }
                _cd.SensorData.Add(Child);
            }


            return _cd;
        }
        public chart_DataPackageDto GetDaysChartData(int id, int days){
            chart_DataPackageDto _cd = new chart_DataPackageDto();

            int sensor_index = 0;
            var _sensors = _context.HubSensors.Include(x=>x.Sensor).Where(x=>x.HubId == id).OrderBy(x=>x.SensorId);
            _cd.Sensor = new string[_sensors.Count()];
            foreach (HubSensors _hs in _sensors){
                _cd.Sensor[sensor_index] = _hs.Sensor.Name;
                sensor_index++;
            }

            var _datapackage = _context.DataPackage.Include(x=>x.SensorData).Where(x=>x.HubId == id && x.CreatedDate > x.CreatedDate.AddDays(-days));
            _cd.SensorData = new List<List<object>>();
            
            foreach (DataPackage _dp in _datapackage){
                List<Object> Child = new List<Object>();

                Child.Add(_dp.CreatedDate.ToString());
                foreach(SensorData _sd in _dp.SensorData.OrderBy(x=>x.SensorId)){
                    float _value = _sd.Data;

                    if(_sd.SensorId == 3)
                        _value = _value / 10;
                    
                    if(_sd.SensorId == 4)
                        _value = _value / 5;

                    Child.Add(_value);
                }
                _cd.SensorData.Add(Child);
            }


            return _cd;
        }
        public async Task<StatisticsDto> GetStatisticsData(int id){
            var _sensors = await _context.HubSensors.Include(x=>x.Sensor).Where(x=>x.HubId == id).OrderBy(x=>x.SensorId).ToListAsync();

            StatisticsDto _package = new StatisticsDto();
            List<SensorData> _HubsensorSensorData = await _context.SensorData.Include(x=>x.DataPackage).Where(x=>x.DataPackage.HubId == id).ToListAsync();

            foreach(HubSensors _s in _sensors){
                Stats _stats = new Stats();
                List<SensorData> _hsd = _HubsensorSensorData.Where(x=>x.SensorId == _s.SensorId).ToList();
                SensorData _first = _hsd.OrderBy(x=>x.DataPackage.CreatedDate).First();

                _package.SensorStats.Add(new Stats{
                    latest_value = _first.Data,
                    Min_value = _hsd.Min(x=>x.Data),
                    Max_value = _hsd.Max(x=>x.Data),
                    Avg_value = _hsd.Average(x=>x.Data),
                    Sensor_Name = _s.Sensor.Name
                });
            }
            return _package;
        }
        public DataPackage GetDataPackage(int id){
            DataPackage data = null;
            try{
                data = _context.DataPackage.Include(x=>x.SensorData).FirstOrDefault(x=>x.Id == id);
            }
            catch{
                return null;
            }
            return data;
        }
        public DataPackage CreateDataPackage(Entry_DataPackageDto _input){
            DataPackage _dp = new DataPackage();
            try{
                _dp.HubId = _input.HubId;
            }
            catch{
                return null;
            }
            
            _context.DataPackage.Add(_dp);
            _context.SaveChanges();

            foreach(Entry_SensorDataDto _esd in _input.SensorData){
                try{
                    _context.SensorData.Add(new SensorData{
                        SensorId = _esd.SensorId,
                        DataPackageId = _dp.Id,
                        Data = _esd.Data
                    });
                }
                catch{
                    return null;
                }
            }
            _context.SaveChanges();




            return _dp;
        }
        public DataPackage DeleteDataPackage(int id){
            DataPackage _dp;
            try{
                _dp = _context.DataPackage.Find(id);
            }
            catch{
                return null;
            }
            if (_dp == null) { 
                return null; 
            }

            _context.DataPackage.Remove(_dp);
            _context.SaveChanges();
            return _dp;
        }
        public DataPackage UpdateDataPackage(int id,Base_Entry_DataPackageDto _input){
            DataPackage _dp;
            try{
                _dp = _context.DataPackage.Find(id);
            }
            catch{
                return null;
            }
            if (_dp == null) { 
                return null; 
            }

            _dp.HubId = _input.HubId;

            _context.SaveChanges();
            return _dp;
        }
        public bool DataPackageExists(int id){
            try{
                return _context.Hub.Find(id) != null ? true : false;
            }
            catch{
                throw new NullReferenceException(nameof(DataPackage));
            }
        }
    }
}