using JacWebShopAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
//using System.Web.Mvc;

namespace JacWebShopAPI.Controllers
{
    [RoutePrefix("api/ProductsManagement")]
    public class ProductsManagementController : ApiController
    {

        [HttpGet]
        [Route("GetAllProductsBasic")]
        public List<uspGetAllProducts_Result> GetAllProductsBasic()
        {
            try
            {           
                using (var DB = new JacShopDBEntities())
                {
                    List<uspGetAllProducts_Result> getAllProductsList = new List<uspGetAllProducts_Result>();
                    getAllProductsList = DB.uspGetAllProducts().ToList();
                    return getAllProductsList;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpGet]
        [Route("GetAllProducts")]
        public IHttpActionResult GetAllProducts()
        {
            try
            {
                using (var DB = new JacShopDBEntities())
                {
                    List<uspGetAllProducts_Result> getAllProductsList = new List<uspGetAllProducts_Result>();
                    getAllProductsList = DB.uspGetAllProducts().ToList();
                    return Ok(getAllProductsList);
                }
            }

            catch (Exception ex)
            {
                return BadRequest("Error");
            }
        }

        [HttpPost]
        [Route("CreateNewProduct")]
        public IHttpActionResult CreateNewProduct([FromBody] uspGetAllProducts_Result product)
        {
            try
            {
                using (var DB = new JacShopDBEntities())
                {
                    product.TimeStamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                   
                    if (product != null && ModelState.IsValid)
                    {
                        DB.uspInsertNewProduct(
                             product.Category,
                             product.ProductName,
                             product.ProductCode,
                             product.Price,
                             product.Description);
                        DB.SaveChanges();
                    }
                }

                return Ok("Los datos se guardaron correctamente");
            }

            catch (Exception ex)
            {
                return BadRequest("Error");
            }
        }

    }
}
