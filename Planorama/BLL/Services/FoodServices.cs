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
    public class FoodServices
    {
        public static List<FoodDTO> Get()
        {
            var data = DataAccessFactory.FoodData().Read();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap< Food , FoodDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<FoodDTO>>(data);
            return mapped;
        }

        public static FoodDTO Get(int id)
        {
            var data = DataAccessFactory.FoodsCategoryData().Read(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Food, FoodDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<FoodDTO>(data);
            return mapped;

        }

        public static bool Create(FoodDTO food)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<FoodDTO, Food>();
            });
            var mapper = new Mapper(cfg);
            var data = mapper.Map<Food>(food);
            return DataAccessFactory.FoodData().Create(data);
        }

        public static bool Update(FoodDTO food)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<FoodDTO, Food>();
            });
            var mapper = new Mapper(cfg);
            var data = mapper.Map<Food>(food);
            return DataAccessFactory.FoodData().Update(data);
        }

        public static bool Delete(int foodId)
        {
            return DataAccessFactory.FoodData().Delete(foodId);
        }
    }
}
