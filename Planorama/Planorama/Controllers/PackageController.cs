using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Planorama.Controllers
{
    public class PackageController : ApiController
    {
        [HttpGet]
        [Route("api/package/all")]
        public HttpResponseMessage Packages()
        {
            try
            {
                var data = PackageService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }

            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);

            }
        }

        [HttpGet]
        [Route("api/package/{id}")]

        public HttpResponseMessage PackagesByID(int id)
        {

            try
            {
                var data = PackageService.Get(id);
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
    }
}
