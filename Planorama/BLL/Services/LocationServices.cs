using AutoMapper;
using BLL.DTO;
using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class LocationServices
    {
        public static List<LocationDTO> Get()
        {
            var data = DataAccessFactory.LocationData().Read();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Location, LocationDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<LocationDTO>>(data);
            return mapped;
        }

        public static LocationDTO Get(int id)
        {
            var data = DataAccessFactory.LocationData().Read(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Location, LocationDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<LocationDTO>(data);
            return mapped;

        }

        public static bool Create(LocationDTO location)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<LocationDTO, Location>();
            });
            var mapper = new Mapper(cfg);
            var data = mapper.Map<Location>(location);
            return DataAccessFactory.LocationData().Create(data);
        }

        public static bool Update(LocationDTO location)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<LocationDTO, Location>();
            });
            var mapper = new Mapper(cfg);
            var data = mapper.Map<Location>(location);
            return DataAccessFactory.LocationData().Update(data);
        }

        public static bool Delete(int locationId)
        {
            return DataAccessFactory.LocationData().Delete(locationId);
        }
    }
}
