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
    public class DecorationServices
    {
        public static List<DecorationDTO> Get()
        {
            var data = DataAccessFactory.DecorationData().Read();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Decoration, DecorationDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<DecorationDTO>>(data);
            return mapped;
        }

        public static DecorationDTO Get(int id)
        {
            var data = DataAccessFactory.DecorationData().Read(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Decoration, DecorationDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<DecorationDTO>(data);
            return mapped;

        }

        public static bool Create(DecorationDTO decoration)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<DecorationDTO, Decoration>();
            });
            var mapper = new Mapper(cfg);
            var data = mapper.Map<Decoration>(decoration);
            return DataAccessFactory.DecorationData().Create(data);
        }

        public static bool Update(DecorationDTO decoration)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<DecorationDTO, Decoration>();
            });
            var mapper = new Mapper(cfg);
            var data = mapper.Map<Decoration>(decoration);
            return DataAccessFactory.DecorationData().Update(data);
        }

        public static bool Delete(int decorationId)
        {
            return DataAccessFactory.DecorationData().Delete(decorationId);
        }
    }
}
