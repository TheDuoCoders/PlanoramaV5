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
    public class UserController : ApiController
    {
        [HttpGet]
        [Route("api/user/all")]
        public HttpResponseMessage Users()
        {
            try
            {
                var data = UserService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }

            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);

            }
        }

        [HttpGet]
        [Route("api/user/{uname}")]

        public HttpResponseMessage UsersByID(string uname)
        {

            try
            {
                var data = UserService.Get(uname);
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
        [Route("api/user/create")]

        public HttpResponseMessage Create(UserDTO user)
        {

            try
            {
                var data = UserService.Create(user);
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
        [Route("api/user/delete/{uname}")]

        public HttpResponseMessage Delete(string uname)
        {

            try
            {
                var data = UserService.Delete(uname);
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

        [HttpPost]
        [Route("api/authenticate/{id}/{pass}")]

        public HttpResponseMessage DecorationListByCategory(string id, string pass)
        {

            try
            {
                var data = AuthService.Authenticate(id, pass);
                if (data)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Successful!" });
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
