using APIprojectModelStore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace APIprojectModelStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly string Conn = "Server=20.231.38.177;Database=ModelStore;User Id=sa;Password=Th@ng04062000;";
        [HttpPost]
            public async Task<IActionResult> PostAsync([FromBody] TestModel test)
            {
                using (SqlConnection connection = new SqlConnection(Conn))
                {
                    await connection.OpenAsync();
                    using (SqlCommand command = new SqlCommand("INSERT INTO Test ([ProductName],[PriceListed],[Sale],[Avatar],[Version],[Weight],[Height],[Material]) VALUES (@ProductName,@PriceListed,@Sale,@Avatar,@Version,@Weight,@Height,@Material)", connection))
                    {

                        command.Parameters.AddWithValue("@ProductID", test.ProductID);
                        command.Parameters.AddWithValue("@ProductName", test.ProductName != null ? (object)test.ProductName : DBNull.Value);
                        command.Parameters.AddWithValue("@PriceListed", test.PriceListed != null ? (object)test.PriceListed : DBNull.Value);
                        command.Parameters.AddWithValue("@Sale", test.Sale != null ? (object)test.Sale : DBNull.Value);
                        command.Parameters.AddWithValue("@Avatar", test.Avatar != null ? (object)test.Avatar : DBNull.Value);
                        command.Parameters.AddWithValue("@Version", test.Version != null ? (object)test.Version : DBNull.Value);
                        command.Parameters.AddWithValue("@Weight", test.Weight != null ? (object)test.Weight : DBNull.Value);
                        command.Parameters.AddWithValue("@Height", test.Height != null ? (object)test.Height : DBNull.Value);
                        command.Parameters.AddWithValue("@Material", test.Material != null ? (object)test.Material : DBNull.Value);




                    int resultinsertProducts = await command.ExecuteNonQueryAsync();
                        return resultinsertProducts > 0 ? Ok("Insert Thất Bại :(") : Ok("Insert Thành Công!!!");
                    };
                }
            }
        }
    }
