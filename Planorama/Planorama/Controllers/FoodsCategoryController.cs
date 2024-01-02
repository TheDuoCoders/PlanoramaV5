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
        [Route("api/foodscategory/create")]

        public HttpResponseMessage Create(FoodsCategoryDTO foodscategory)
        {

            try
            {
                var data = FoodsCategoryService.Create(foodscategory);
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
        [Route("api/foodscategory/delete/{id}")]

        public HttpResponseMessage Delete(int id)
        {

            try
            {
                var data = FoodsCategoryService.Delete(id);
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
        [Route("api/foodlistbycategory/{id}")]

        public HttpResponseMessage FoodListByCategory(int id)
        {

            try
            {
                var data = FoodsCategoryService.GetFoodByCategory(id)
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
