using AutoMapper;
using Models;
using DataTransferObject;

namespace Profiles{
    public class HubProfiles : Profile
        {
            public HubProfiles()
            {
                // CreateMap<Hub, Expanded_HubDto>();
                // CreateMap<Hub, HubDto>()            
                //     .ForMember(dest => dest.RoomName,opt => opt.MapFrom(src => src.Room.Name))             
                //     .ForMember(dest => dest.BuildingName,opt => opt.MapFrom(src => src.Room.Building.Name)); 

                // CreateMap<HubSensors, HubSensorsDto>()            
                //     .ForMember(dest => dest.Name,opt => opt.MapFrom(src => src.Sensor.Name))             
                //     .ForMember(dest => dest.DataType,opt => opt.MapFrom(src => src.Sensor.DataType));


                // CreateMap<SensorData, SensorDataDto>();
                // CreateMap<DataPackage, Expanded_DataPackageDto>();
                // CreateMap<DataPackage, DataPackageDto>();

                CreateMap<Hub, HubDto>()
                    .ForMember(dest => dest.Room,opt => opt.MapFrom(src => src.Room.Name));
                CreateMap<HubSensors, HubSensorsDto>()        
                    .ForMember(dest => dest.Name,opt => opt.MapFrom(src => src.Sensor.Name));           

                CreateMap<Room, RoomDto>();
                CreateMap<SensorData, SensorDataDto>();
                CreateMap<DataPackage, DataPackageDto>();
                CreateMap<Building, BuildingDto>();

                CreateMap<HubSensors, HubSensorsDto>()
                    .ForMember(dest => dest.Name,opt => opt.MapFrom(src => src.Sensor.Name))
                    .ForMember(dest => dest.PortTypeId,opt => opt.MapFrom(src => src.Sensor.portType.Id));

                CreateMap<Hub, Expanded_HubDto>();
                CreateMap<DataPackage, Expanded_DataPackageDto>();
                CreateMap<HubSensors, Expanded_HubSensorsDto>() 
                    .ForMember(dest => dest.Name,opt => opt.MapFrom(src => src.Sensor.Name))             
                    .ForMember(dest => dest.PortType,opt => opt.MapFrom(src => src.Sensor.portType.Id))             
                    .ForMember(dest => dest.DataType,opt => opt.MapFrom(src => src.Sensor.DataType));
          
            }
        }

}