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
    public class DecorationsCategoryController : ApiController
    {
        [HttpGet]
        [Route("api/decorationscategory/all")]
        public HttpResponseMessage Foods()
        {
            try
            {
                var data = DecorationsCategoryServices.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }

            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);

            }
        }

        [HttpGet]
        [Route("api/decorationscategory/{id}")]

        public HttpResponseMessage FoodsByID(int id)
        {

            try
            {
                var data = DecorationsCategoryServices.Get(id);
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
        [Route("api/decorationscategory/create")]

        public HttpResponseMessage Create(DecorationsCategoryDTO decorationscategory)
        {

            try
            {
                var data = DecorationsCategoryServices.Create(decorationscategory);
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
        [Route("api/decorationscategory/delete/{id}")]

        public HttpResponseMessage Delete(int id)
        {

            try
            {
                var data = DecorationsCategoryServices.Delete(id);
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
        [Route("api/decorationlistbycategory/{id}")]

        public HttpResponseMessage DecorationListByCategory(int id)
        {

            try
            {
                var data = DecorationsCategoryServices.GetDecorationByCategory(id);
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

