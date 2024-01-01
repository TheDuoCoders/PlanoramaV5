using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Planorama.Controllers
{
    public class FoodsCategoryController : ApiController
    {
        [HttpGet]
        [Route("api/foodscategory/all")]
        public HttpResponseMessage FoodsCategories()
        {
            try
            {
                var data = FoodsCategoryService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }

            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);

            }
        }

        [HttpGet]
        [Route("api/foodscategory/{id}")]

        public HttpResponseMessage FoodsCategoriesByID(int Id)
        {
          
            try
            {
                var data = FoodsCategoryService.Get(Id);
                if (data == null)
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
