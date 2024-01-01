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
    public class BookingService
    {
        public static List<BookingDTO> Get()
        {
            var data = DataAccessFactory.BookingData().Read();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Booking, BookingDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<BookingDTO>>(data);
            return mapped;
        }

        public static BookingDTO Get(int id)
        {
            var data = DataAccessFactory.BookingData().Read(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Booking, BookingDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<BookingDTO>(data);
            return mapped;
        }

        public static bool Create(BookingDTO booking)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<BookingDTO, Booking>();
            });
            var mapper = new Mapper(cfg);
            var data = mapper.Map<Booking>(booking);
            return DataAccessFactory.BookingData().Create(data);
        }

        public static bool Update(BookingDTO booking)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<BookingDTO, Booking>();
            });
            var mapper = new Mapper(cfg);
            var data = mapper.Map<Booking>(booking);
            return DataAccessFactory.BookingData().Update(data);
        }

        public static bool Delete(int bookingId)
        {
            return DataAccessFactory.BookingData().Delete(bookingId);
        }
    }
}
