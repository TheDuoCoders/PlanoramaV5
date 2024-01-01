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
    public class FoodsCategoryService
    {
        public static List<FoodsCategoryDTO> Get()
        {
            var data = DataAccessFactory.FoodsCategoryData().Read();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<FoodsCategory, FoodsCategoryDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<FoodsCategoryDTO>>(data);
            return mapped;
        }

        public static FoodsCategoryDTO Get(int id)
        {
            var data = DataAccessFactory.FoodsCategoryData().Read(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<FoodsCategory, FoodsCategoryDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<FoodsCategoryDTO>(data);
            return mapped;

        }

        public static bool Create(FoodsCategoryDTO foodsCategory)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<FoodsCategoryDTO, FoodsCategory>();
            });
            var mapper = new Mapper(cfg);
            var data = mapper.Map<FoodsCategory>(foodsCategory);
            return DataAccessFactory.FoodsCategoryData().Create(data);
        }

        public static bool Update(FoodsCategoryDTO foodsCategory)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<FoodsCategoryDTO, FoodsCategory>();
            });
            var mapper = new Mapper(cfg);
            var data = mapper.Map<FoodsCategory>(foodsCategory);
            return DataAccessFactory.FoodsCategoryData().Update(data);
        }

        public static bool Delete(int foodsCategoryId)
        {
            return DataAccessFactory.FoodsCategoryData().Delete(foodsCategoryId);
        }


    }
}
