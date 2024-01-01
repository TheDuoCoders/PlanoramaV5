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
    public class CustomPackageService
    {
        public static List<CustomPackageDTO> Get()
        {
            var data = DataAccessFactory.CustomPackageData().Read();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<CustomPackage, CustomPackageDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<CustomPackageDTO>>(data);
            return mapped;
        }

        public static CustomPackageDTO Get(int id)
        {
            var data = DataAccessFactory.CustomPackageData().Read(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<CustomPackage, CustomPackageDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<CustomPackageDTO>(data);
            return mapped;
        }

        public static bool Create(CustomPackageDTO customPackage)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<CustomPackageDTO, CustomPackage>();
            });
            var mapper = new Mapper(cfg);
            var data = mapper.Map<CustomPackage>(customPackage);
            return DataAccessFactory.CustomPackageData().Create(data);
        }

        public static bool Update(CustomPackageDTO customPackage)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<CustomPackageDTO, CustomPackage>();
            });
            var mapper = new Mapper(cfg);
            var data = mapper.Map<CustomPackage>(customPackage);
            return DataAccessFactory.CustomPackageData().Update(data);
        }

        public static bool Delete(int customPackageId)
        {
            return DataAccessFactory.CustomPackageData().Delete(customPackageId);
        }
    }
}
