using Models;
using DataTransferObject;

namespace Repositories{
    public interface ILocationRepos{
        public IEnumerable<Room> GetRooms(); 
        public IEnumerable<Building> GetBuildings(); 
        public IEnumerable<Room> GetBuildingRooms(int id); 
        public IEnumerable<Hub> GetBuildingHubs(int id); 
        public IEnumerable<Hub> GetRoomHubs(int id); 
        public IEnumerable<DataPackage> GetRoomDataPackages(int id); 
        public IEnumerable<DataPackage> GetBuildingDataPackages(int id); 

        public Building CreateBuilding(Entry_BuildingDto _input);
        public Room CreateRoom(Entry_RoomDto _input);
        public Building UpdateBuilding(int id,Entry_BuildingDto _input);
        public Room UpdateRoom(int id,Entry_RoomDto _input);
        public Room DeleteRoom(int id);
        public Building DeleteBuilding(int id);



        public bool RoomExists(int id);
        public bool BuildingExists(int id);

    }
}