using Microsoft.EntityFrameworkCore;
using Context;
using Models;
using DataTransferObject;

namespace Repositories{
    public class HubRepos : IHubRepos{
        private readonly DatabaseContext _context;

        public HubRepos(DatabaseContext context){
            _context = context ?? throw new NullReferenceException(nameof(context));
        }

        public IEnumerable<Hub> GetHubs(){
            return _context.Hub.Include(x=>x.Room).ThenInclude(x=>x.Building).Include(x=>x.HubSensors).ThenInclude(x=>x.Sensor).ThenInclude(x=>x.portType).Where(x=>x.SoftDeleted == false).ToList();
        }
        public IEnumerable<HubSensors> GetHubSensors(int id){
            return _context.HubSensors.Include(x=>x.Sensor).ThenInclude(x=>x.portType).Where(x=>x.HubId == id && !x.Disabled).ToList();
        } 
        public IEnumerable<DataPackage> GetHubDatapackages(int id){
            return _context.DataPackage.Where(x=>x.HubId == id).ToList();
        } 
        public DataPackage GetHubDatapackage(int id){
            return _context.DataPackage.Include(x=>x.SensorData).FirstOrDefault(x=>x.Id == id);
        }
        public Hub GetHubById(int id){
            return _context.Hub.FirstOrDefault(x => x.Id == id);
        }
        public Hub SoftDeleteHubById(int id){
            if(HubExists(id)){
                var _Hub = _context.Hub.Find(id);
                _Hub.SoftDeleted = true;
                _context.SaveChanges();
                return _Hub;
            }
            else{
                return null;
            }
        }
        public Hub HardDeleteHubById(int id){ //NOT WORKING
            var _Hub = _context.Hub.Find(id);
            if (_Hub == null) { return null; }

            _context.Hub.Remove(_Hub);
            _context.SaveChanges();
            return _Hub;
        }
        public Hub CreateHub(Entry_HubDto _input){
            if(_context.Room.Find(_input.RoomId) == null)
                return null;

            Hub _Hub = new Hub{
                RoomId = _input.RoomId
            };
            
            _context.Hub.Add(_Hub);
            _context.SaveChanges();

            if(_input.Sensors != null){
                foreach(Entry_HubSensorsDto _ehs in _input.Sensors){
                    if(_context.Sensor.Find(_ehs.SensorId)== null){
                        _context.Hub.Remove(_Hub);
                        _context.SaveChanges();
                        return null;
                    }

                    _context.HubSensors.Add(new HubSensors{
                        HubId = _Hub.Id,
                        SensorId = _ehs.SensorId,
                        Disabled = _ehs.Disabled,
                        Port = _ehs.Port
                    });

                    _context.SaveChanges();
                }
            }
            
            return _Hub;
        }        
        public Hub UpdateHub(int id, Entry_HubDto _input){
            var _Hub = _context.Hub.Find(id);

            _Hub.RoomId = _input.RoomId;
                   
            _context.SaveChanges();
            return _Hub;
        }

        public HubSensors CreateHubSensor(Entry_HubSensorsDto _input){
            HubSensors _hs = new HubSensors{
                HubId = _input.HubId,
                SensorId = _input.SensorId,
                Port = _input.Port
            };
            _context.HubSensors.Add(_hs);
            _context.SaveChanges();

            return _hs;
        }
        public HubSensors UpdateHubSensor(int id, Entry_HubSensorsDto _input){
            var _hs = _context.HubSensors.Find(id);
            if (_hs == null) { return null; }

            _hs.HubId = _input.HubId;
            _hs.SensorId = _input.SensorId;
            _hs.Port = _input.Port;

            _context.SaveChanges();
            return _hs;
        }
        public HubSensors DeleteHubSensor(int id){
            var _hs = _context.HubSensors.Find(id);
            if (_hs == null) { return null; }

            _context.HubSensors.Remove(_hs);
            _context.SaveChanges();
            return _hs;
        }

        public bool HubExists(int id){
            return _context.Hub.Find(id) != null ? true : false;
        }
    }
}