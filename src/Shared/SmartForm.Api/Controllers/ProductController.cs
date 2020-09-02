using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartForm.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IConfiguration _configuration;
        public ProductsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        // GET: api/<ProductController>
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            using (var connection = new SqlConnection(_configuration.GetValue<string>("connectionString:SQLConnection")))
            {
                try
                {
                    string getProduct = "select * from Products";
                    var orderDetails = connection.Query<Product>(getProduct).ToList();
                    //var orderDetail = connection.QueryFirstOrDefault<Product>(sqlOrderDetail, new { Username = "ali123" });
                    //var affectedRows = connection.Execute(sqlCustomerInsert, new { Username = "Mark", Password = "123456" });

                    Console.WriteLine(orderDetails.Count);
                    //Console.WriteLine(affectedRows);
                    return orderDetails;

                }
                catch (Exception ex)
                {
                    connection.Dispose();
                    throw ex;
                }
                finally
                {

                    connection.Dispose();
                }
            }
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public Product Get(int id)
        {
            using (var connection = new SqlConnection(_configuration.GetValue<string>("connectionString:SQLConnection")))
            {
                try
                {
                    connection.Open();
                    string sqlOrderDetail = "SELECT * FROM  [EShop].[dbo].[Products] WHERE Title = @Title;";
                    // var orderDetails = connection.Query<Product>(getProduct).ToList();
                    var orderDetail = connection.QueryFirstOrDefault<Product>(sqlOrderDetail, new { Title = "ali123" });
                    //var affectedRows = connection.Execute(sqlCustomerInsert, new { Username = "Mark", Password = "123456" });

                    Console.WriteLine(orderDetail);
                    //Console.WriteLine(affectedRows);
                    return orderDetail;

                }
                catch (Exception ex)
                {
                    connection.Dispose();
                    throw ex;
                }
                finally
                {

                    connection.Dispose();
                }
            }
        }

        // POST api/<ProductController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }

    public class Product
    {
        public long Id { get; set; }
        public long CategoryId { get; set; }
        public int Status { get; set; }
        public string Title { get; set; }
        public bool Deleted{ get; set; }
    }
}
