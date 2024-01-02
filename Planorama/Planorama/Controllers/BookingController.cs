using BLL.DTO;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Planorama.Controllers
{
    public class BookingController : ApiController
    {
        [HttpGet]
        [Route("api/booking/all")]
        public HttpResponseMessage Bookings()
        {
            try
            {
                var data = BookingService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }

            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);

            }
        }

        [HttpGet]
        [Route("api/booking/{id}")]

        public HttpResponseMessage BookingsByID(int id)
        {

            try
            {
                var data = BookingService.Get(id);
                if (data != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Not data faound" });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);

            }

        }

        [HttpPost]
        [Route("api/booking/create")]

        public HttpResponseMessage Create(BookingDTO booking)
        {

            try
            {
                var data = BookingService.Create(booking);
                if (data)
                {
                    return Request.CreateResponse(HttpStatusCode.Created, new { Msg = "Created" });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { Msg = "Not Created!" });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);

            }

        }

        [HttpPost]
        [Route("api/booking/delete/{id}")]

        public HttpResponseMessage Delete(int id)
        {

            try
            {
                var data = BookingService.Delete(id);
                if (data)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Deleted" });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { Msg = "Not Deleted!" });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);

            }

        }

        [HttpGet]
        [Route("api/bookingwithuserpackage/{id}")]

        public HttpResponseMessage DecorationListByCategory(int id)
        {
            try
            {
                var data = BookingService.BookingUserPackageDetails(id);
                if (data != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Msg = "Not Found!" });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

        }

        [HttpGet]
        [Route("api/custombooking/{id}")]

        public HttpResponseMessage CustomBookings(int id)
        {
            try
            {
                var data = BookingCustomPackageService.GetBookingCustomPackage(id);
                if (data != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Not data faound" });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);

            }

        }

        [HttpPost]
        [Route("api/custombooking/create")]

        public HttpResponseMessage CustomBookingCreate(BookingCustomPackageDTO package)
        {
            try
            {
                var data = BookingCustomPackageService.Create(package);
                if (data)
                {
                    return Request.CreateResponse(HttpStatusCode.Created, new { Msg = "Created!" });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { Msg = "Not Created" });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
