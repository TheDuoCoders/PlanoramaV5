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
    public class PackageService
    {
        public static List<PackageDTO> Get()
        {
            var data = DataAccessFactory.PackageData().Read();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Package, PackageDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<PackageDTO>>(data);
            return mapped;
        }

        public static PackageDTO Get(int id)
        {
            var data = DataAccessFactory.PackageData().Read(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Package, PackageDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<PackageDTO>(data);
            return mapped;
        }

        public static bool Create(PackageDTO package)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<PackageDTO, Package>();
            });
            var mapper = new Mapper(cfg);
            var data = mapper.Map<Package>(package);
            return DataAccessFactory.PackageData().Create(data);
        }

        public static bool Update(PackageDTO package)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<PackageDTO, Package>();
            });
            var mapper = new Mapper(cfg);
            var data = mapper.Map<Package>(package);
            return DataAccessFactory.PackageData().Update(data);
        }

        public static bool Delete(int packageId)
        {
            return DataAccessFactory.PackageData().Delete(packageId);
        }

        public static bool CreateCustomPackage(CustomPackageFullDTO custom)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<CustomPackageFullDTO, Package>();
            });
            var mapper = new Mapper(cfg);
            var data = mapper.Map<Package>(custom);
            data.Price = data.Decoration.Price + data.Location.Price + (data.GuestAmount * data.Food.Price);
            return DataAccessFactory.PackageData().Create(data);
        }

        public static CustomPackageFullDTO GetCustomPackage(int id)
        {
            var data = DataAccessFactory.PackageData().Read(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Package, CustomPackageFullDTO>();
                c.CreateMap<Food, FoodDTO>();
                c.CreateMap<Decoration, DecorationDTO>();
                c.CreateMap<Location, LocationDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<CustomPackageFullDTO>(data);
            return mapped;
        }
    }
}
