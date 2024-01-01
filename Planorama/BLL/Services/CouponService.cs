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
    public class CouponService
    {
        public static List<CouponDTO> Get()
        {
            var data = DataAccessFactory.CouponData().Read();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Coupon, BookingDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<CouponDTO>>(data);
            return mapped;
        }

        public static CouponDTO Get(int id)
        {
            var data = DataAccessFactory.CouponData().Read(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Coupon, CouponDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<CouponDTO>(data);
            return mapped;
        }

        public static bool Create(CouponDTO coupon)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<CouponDTO, Coupon>();
            });
            var mapper = new Mapper(cfg);
            var data = mapper.Map<Coupon>(coupon);
            return DataAccessFactory.CouponData().Create(data);
        }

        public static bool Update(CouponDTO coupon)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<CouponDTO, Coupon>();
            });
            var mapper = new Mapper(cfg);
            var data = mapper.Map<Coupon>(coupon);
            return DataAccessFactory.CouponData().Update(data);
        }

        public static bool Delete(int couponId)
        {
            return DataAccessFactory.CouponData().Delete(couponId);
        }


    }
}
