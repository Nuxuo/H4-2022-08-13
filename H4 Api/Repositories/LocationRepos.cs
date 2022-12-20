using Microsoft.EntityFrameworkCore;
using Context;
using Models;
using DataTransferObject;

namespace Repositories{
    public class LocationRepos : ILocationRepos{
        private readonly DatabaseContext _context;
        public LocationRepos(DatabaseContext context){
            _context = context ?? throw new NullReferenceException(nameof(context));
        }

        public IEnumerable<Room> GetRooms(){
            return _context.Room.ToList();
        } 
        public IEnumerable<Building> GetBuildings(){
            return _context.Building.ToList();
        } 
        public IEnumerable<Room> GetBuildingRooms(int id){
            return _context.Room.Where(x=>x.BuildingId == id).ToList();
        } 
        public IEnumerable<Hub> GetBuildingHubs(int id){
            return _context.Hub.Include(x=>x.Room).ThenInclude(x=>x.Building).Where(x=>x.Room.BuildingId == id).ToList();
        } 
        public IEnumerable<Hub> GetRoomHubs(int id){
            return _context.Hub.Where(x=>x.RoomId == id).ToList();
        } 
        public IEnumerable<DataPackage> GetRoomDataPackages(int id){
            return _context.DataPackage.Include(x=>x.Hub).ThenInclude(x=>x.Room).ThenInclude(x=>x.Building).Where(x=>x.Hub.RoomId == id).ToList();
        } 
        public IEnumerable<DataPackage> GetBuildingDataPackages(int id){
            return _context.DataPackage.Include(x=>x.Hub).ThenInclude(x=>x.Room).ThenInclude(x=>x.Building).Where(x=>x.Hub.Room.BuildingId == id).ToList();
        } 

        public Room DeleteRoom(int id){
            var _room = _context.Room.Find(id);
            if (_room == null) { return null; }

            _context.Room.Remove(_room);
            _context.SaveChanges();
            return _room;
        }
        public Building DeleteBuilding(int id){
            var _building = _context.Building.Find(id);
            if (_building == null) { return null; }

            _context.Building.Remove(_building);
            _context.SaveChanges();
            return _building;
        }


        public Building CreateBuilding(Entry_BuildingDto _input){
            Building _building = new Building{
                Address = _input.Address,
                Name = _input.Name
            };
            _context.Building.Add(_building);
            _context.SaveChanges();

            return _building;
        }
        public Building UpdateBuilding(int id,Entry_BuildingDto _input){
            var _building = _context.Building.Find(id);
            if (_building == null) { return null; }

            _building.Address = _input.Address;
            _building.Name = _input.Name;

            _context.SaveChanges();
            return _building;
        }
        public Room CreateRoom(Entry_RoomDto _input){
            Room _room = new Room{
                BuildingId = _input.BuildingId,
                Name = _input.Name
            };
            _context.Room.Add(_room);
            _context.SaveChanges();

            return _room;
        }
        public Room UpdateRoom(int id,Entry_RoomDto _input){
            var _room = _context.Room.Find(id);
            if (_room == null) { return null; }

            _room.BuildingId = _input.BuildingId;
            _room.Name = _input.Name;

            _context.SaveChanges();
            return _room;
        }
        
        public bool RoomExists(int id){
            return _context.Room.Find(id) != null ? true : false;
        }
        public bool BuildingExists(int id){
            return _context.Building.Find(id) != null ? true : false;
        }
    }
}