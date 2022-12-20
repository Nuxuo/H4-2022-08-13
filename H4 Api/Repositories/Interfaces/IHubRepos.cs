using Models;
using DataTransferObject;

namespace Repositories{
    public interface IHubRepos{
        public IEnumerable<Hub> GetHubs(); 
        public Hub GetHubById(int id);
        public IEnumerable<HubSensors> GetHubSensors(int id); 
        public IEnumerable<DataPackage> GetHubDatapackages(int id); 
        public DataPackage GetHubDatapackage(int id); 
        public Hub CreateHub(Entry_HubDto _input);
        public HubSensors CreateHubSensor(Entry_HubSensorsDto _input);
        public Hub UpdateHub(int id, Entry_HubDto _input);
        public HubSensors UpdateHubSensor(int id, Entry_HubSensorsDto _input);
        public Hub SoftDeleteHubById(int id);
        public Hub HardDeleteHubById(int id);
        public HubSensors DeleteHubSensor(int id);
        public bool HubExists(int id);
    }
}