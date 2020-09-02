using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SmartForm.Common.Repository;
using System;
using System.Data.SqlClient;
using System.Linq;

namespace SmartForm.Api.Controllers

    [Route("")]
    public class HomeController : Controller
    {
        IConfiguration _configuration;
        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("")]
        public IActionResult Get()
        {
            return Content("Hello from Actio API!");
        }
        [HttpGet("test")]
        public IActionResult GetTest()
        {
            var dapper = new DapperRepository("Server=192.168.105.55\\exp17;Database=EShop; User ID=ma;password=123;MultipleActiveResultSets=True");
            var query = dapper.Query("select *  FROM [EShop].[dbo].[Users]");
            return Ok(query);
        }
        [HttpGet("ts2")]
        public dynamic GetTs2()
        {
            //using (SqlConnection conn = new SqlConnection(_configuration.GetValue<string>("connectionString:SQLConnection")))
            //{
            //    try
            //    {

            //        DBParam p0 = new DBParam();
            //        p0.Name = "@refId";
            //        p0.Value = "af70eb19-dc7e-7bb9-05a9-fc544ebc7fb2";

            //        DBParam p1 = new DBParam();
            //        p1.Name = "@date";
            //        p1.Value = "1953 - 01 - 15 07:39:52.470";

            //        DBParam p2 = new DBParam();
            //        p2.Name = "@note";
            //        p2.Value = "data.Note";

            //        DBParam p3 = new DBParam();
            //        p3.Name = "@userId";
            //        p3.Value = null;
            //        p3.IsNullable = true;

            //        var tes = conn.ExecuteReader(sql: "select * FROM [EShop].[dbo].[Users]", commandType: System.Data.CommandType.Text);

            //    var identity = conn.Insert(new User { Kind = InvoiceKind.WebInvoice, Code = "Insert_Single_1" });
            //    var sql = "SELECT *,overall_count = COUNT(*) OVER()  FROM (SELECT [ETIM_ID] AS [EntityImportID],[ETIM_NAME] AS [EntityImportName],[ETFD_NAME] AS [EntityFieldName],[ENTT_NAME] AS [EntityName],[ENTT_SOURCE] AS [EntitySource],[EIFD_EXCEL_COL_NAME] AS [EntityImportFieldExcelColName],[EIFD_FGNK] AS [IsForeginKey],[EIFD_COLM_IND] AS [ColumnIndex],[ETIM_SPBASE] AS [SPName] FROM ADM.ADM_VW_IMPORT) T";

            //        var tes1 = conn.Query<dynamic>(sql);
            //        //var tes2 = conn.Query<dynamic>(tes);

            //        var res = new
            //        {
            //            Items = tes1,
            //            TotalCount = 32
            //        };
            //        conn.Dispose();
            //        return res;
            //    }
            string sqlOrderDetails = "SELECT TOP 5 * FROM  [EShop].[dbo].[Users];";
            string sqlOrderDetail = "SELECT * FROM  [EShop].[dbo].[Users] WHERE Username = @Username;";
            string sqlCustomerInsert = "INSERT INTO  [EShop].[dbo].[Users] (Username,Password) Values (@Username,@Password);";

            using (var connection = new SqlConnection(_configuration.GetValue<string>("connectionString:SQLConnection")))
            {
                try
                {
                    var orderDetails = connection.Query<User>(sqlOrderDetails).ToList();
                    var orderDetail = connection.QueryFirstOrDefault<User>(sqlOrderDetail, new { Username = "ali123" });
                    var affectedRows = connection.Execute(sqlCustomerInsert, new { Username = "Mark", Password = "123456" });

                    Console.WriteLine(orderDetails.Count);
                    Console.WriteLine(affectedRows);
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



        class User
        {
            public long Id { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }
            public bool Deleted { get; set; }
        }
    }
}
