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
    public class LocationsCategoryController : ApiController
    {
        [HttpGet]
        [Route("api/locationscategory/all")]
        public HttpResponseMessage Foods()
        {
            try
            {
                var data = LocationsCategoryServices.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }

            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);

            }
        }

        [HttpGet]
        [Route("api/locationscategory/{id}")]

        public HttpResponseMessage FoodsByID(int id)
        {

            try
            {
                var data = LocationsCategoryServices.Get(id);
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
        [Route("api/locationscategory/create")]

        public HttpResponseMessage Create(LocationsCategoryDTO locationscategory)
        {

            try
            {
                var data = LocationsCategoryServices.Create(locationscategory);
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
        [Route("api/locationscategory/delete/{id}")]

        public HttpResponseMessage Delete(int id)
        {

            try
            {
                var data = LocationsCategoryServices.Delete(id);
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
        [Route("api/locationlistbycategory/{id}")]

        public HttpResponseMessage LocationListByCategory(int id)
        {

            try
            {
                var data = LocationsCategoryServices.GetLocationByCategory(id)
        ;
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
    }
}
