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
    public class BookingCustomPackageService
    {
        public static bool Create(BookingCustomPackageDTO decorationsCategory)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<BookingCustomPackageDTO, Booking>();
            });
            var mapper = new Mapper(cfg);
            var data = mapper.Map<Booking>(decorationsCategory);
            return DataAccessFactory.BookingData().Create(data);
        }

        public static BookingCustomPackageDTO GetBookingCustomPackage(int id)
        {
            var data = DataAccessFactory.BookingData().Read(id)
        ;
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Booking, BookingCustomPackageDTO>();
                c.CreateMap<Package, CustomPackageDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<BookingCustomPackageDTO>(data);
            return mapped;
        }
    }
}
