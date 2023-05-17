
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using APIprojectModelStore.Models;
using System.Reflection.PortableExecutable;
using APIModelStore.Models;

namespace APIprojectModelStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        //Chuỗi kết nối đến DB
        private readonly string Conn = "Server=20.231.38.177;Database=ModelStore;User Id=sa;Password=Th@ng04062000;";
        //private readonly string Conn = "Server=DESKTOP-6OJTPAP\\WINDING2K;Database=ModelStore;User Id=sa;Password=123;";
        [HttpGet]
        public async Task<IEnumerable<ProductsModel>> GetAllProducts()
        {
            var ListProducts = new List<ProductsModel>();
            using (SqlConnection connection = new SqlConnection(Conn))
            {
                await connection.OpenAsync();
                using (SqlCommand command = new SqlCommand("getAllProducts", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            ListProducts.Add(new Models.ProductsModel()
                            {
                                ProductID = reader.GetInt32(0),
                                ProductName = reader.IsDBNull(1) ? null : reader.GetString(1),
                                PriceListed = reader.IsDBNull(2) ? null : reader.GetDecimal(2),
                                Sale = reader.IsDBNull(3) ? null : reader.GetInt32(3),
                                Avatar = reader.IsDBNull(4) ? null : reader.GetString(4),
                                Version = reader.IsDBNull(5) ? null : reader.GetInt32(5),
                                Weight = reader.IsDBNull(6) ? null : reader.GetString(6),
                                Height = reader.IsDBNull(7) ? null : reader.GetString(7),
                                Material = reader.IsDBNull(8) ? null : reader.GetString(8),
                                Status = reader.IsDBNull(10) ? null : reader.GetString(10),
                                Description = reader.IsDBNull(11) ? null : reader.GetString(11),
                                CreatedAt = reader.IsDBNull(12) ? null : reader.GetDateTime(12),
                                CreatedBy = reader.IsDBNull(13) ? null : reader.GetInt32(13),
                                LastModifiedAt = reader.IsDBNull(14) ? null : reader.GetDateTime(14),
                                LastModifiedBy = reader.IsDBNull(15) ? null : reader.GetInt32(15),
                                Flag = reader.IsDBNull(16) ? null : reader.GetString(16),
                            });
                        }
                    }
                }
                await connection.CloseAsync();
            }
            return ListProducts;
        }

        [HttpGet("{ProductID}")]
        public async Task<IEnumerable<ProductsModel>> Get(int ProductID)
        {
            var ListProducts = new List<ProductsModel>();

            using (SqlConnection connection = new SqlConnection(Conn))
            {
                await connection.OpenAsync();
                using (SqlCommand command = new SqlCommand("getProductsbyID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ProductID", ProductID);
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            ListProducts.Add(new ProductsModel()
                            {
                                ProductID = reader.GetInt32(0),
                                ProductName = reader.IsDBNull(1) ? null : reader.GetString(1),
                                PriceListed = reader.IsDBNull(2) ? null : reader.GetDecimal(2),
                                Sale = reader.IsDBNull(3) ? null : reader.GetInt32(3),
                                Avatar = reader.IsDBNull(4) ? null : reader.GetString(4),
                                Version = reader.IsDBNull(5) ? null : reader.GetInt32(5),
                                Weight = reader.IsDBNull(6) ? null : reader.GetString(6),
                                Height = reader.IsDBNull(7) ? null : reader.GetString(7),
                                Material = reader.IsDBNull(8) ? null : reader.GetString(8),
                                Status = reader.IsDBNull(10) ? null : reader.GetString(10),
                                Description = reader.IsDBNull(11) ? null : reader.GetString(11),
                                CreatedAt = reader.IsDBNull(12) ? null : reader.GetDateTime(12),
                                CreatedBy = reader.IsDBNull(13) ? null : reader.GetInt32(13),
                                LastModifiedAt = reader.IsDBNull(14) ? null : reader.GetDateTime(14),
                                LastModifiedBy = reader.IsDBNull(15) ? null : reader.GetInt32(15),
                                Flag = reader.IsDBNull(16) ? null : reader.GetString(16),
                            });
                        }
                    }
                }
            }
            return ListProducts;
        }

        [HttpPost]

        public async Task<IActionResult> PostAsync([FromBody] ProductsModel products)
        {
            using(SqlConnection connection = new SqlConnection(Conn))
            {
                await connection.OpenAsync();
                using (SqlCommand command = new SqlCommand("InsertOrUpdateProducts", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@ProductID", products.ProductID);
                    command.Parameters.AddWithValue("@ProductName", products.ProductName != null ? (object)products.ProductName : DBNull.Value);
                    command.Parameters.AddWithValue("@PriceListed", products.PriceListed != null ? (object)products.PriceListed : DBNull.Value);
                    command.Parameters.AddWithValue("@Sale", products.Sale != null ? (object)products.Sale : DBNull.Value);
                    string fileName = "Assets/images/ " + products.Avatar;
                    command.Parameters.AddWithValue("@Avatar", fileName != null ? (object)fileName : DBNull.Value);
                    command.Parameters.AddWithValue("@Version", products.Version != null ? (object)products.Version : DBNull.Value);
                    command.Parameters.AddWithValue("@Weight", products.Weight != null ? (object)products.Weight : DBNull.Value);
                    command.Parameters.AddWithValue("@Height", products.Height != null ? (object)products.Height : DBNull.Value);
                    command.Parameters.AddWithValue("@Material", products.Material != null ? (object)products.Material : DBNull.Value);
                    command.Parameters.AddWithValue("@Status", products.Status != null ? (object)products.Status : DBNull.Value);
                    command.Parameters.AddWithValue("@Description", products.Description != null ? (object)products.Description : DBNull.Value);
                    command.Parameters.AddWithValue("@CreatedAt", products.CreatedAt != null ? (object)products.CreatedAt : DBNull.Value);
                    command.Parameters.AddWithValue("@CreatedBy", products.CreatedBy != null ? (object)products.CreatedBy : DBNull.Value);
                    command.Parameters.AddWithValue("@LastModifiedAt", products.LastModifiedAt != null ? (object)products.LastModifiedAt : DBNull.Value);
                    command.Parameters.AddWithValue("@LastModifiedBy", products.LastModifiedBy != null ? (object)products.LastModifiedBy : DBNull.Value);
                    command.Parameters.AddWithValue("@Flag", products.Flag != null ? (object)products.Flag : DBNull.Value);



                    int resultinsertProducts = await command.ExecuteNonQueryAsync();
                    return resultinsertProducts > 0 ? Ok("Insert Thất Bại :(") : Ok("Insert Thành Công!!!");
                };
            }
        }


        [HttpPut("{ProductID}")]
        public async Task<IActionResult> UpdateAsync(int ProductID, ProductsModel products)
        {
            using (SqlConnection connection = new SqlConnection(Conn))
            {
                await connection.OpenAsync();
                using (SqlCommand command = new SqlCommand("InsertOrUpdateProducts", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@ProductID", ProductID);
                    command.Parameters.AddWithValue("@ProductName", products.ProductName != null ? (object)products.ProductName : DBNull.Value);
                    command.Parameters.AddWithValue("@PriceListed", products.PriceListed != null ? (object)products.PriceListed : DBNull.Value);
                    command.Parameters.AddWithValue("@Sale", products.Sale != null ? (object)products.Sale : DBNull.Value);
                    command.Parameters.AddWithValue("@Avatar", products.Avatar != null ? (object)products.Avatar : DBNull.Value);
                    command.Parameters.AddWithValue("@Version", products.Version != null ? (object)products.Version : DBNull.Value);
                    command.Parameters.AddWithValue("@Weight", products.Weight != null ? (object)products.Weight : DBNull.Value);
                    command.Parameters.AddWithValue("@Height", products.Height != null ? (object)products.Height : DBNull.Value);
                    command.Parameters.AddWithValue("@Material", products.Material != null ? (object)products.Material : DBNull.Value);
                    command.Parameters.AddWithValue("@Status", products.Status != null ? (object)products.Status : DBNull.Value);
                    command.Parameters.AddWithValue("@Description", products.Description != null ? (object)products.Description : DBNull.Value);
                    command.Parameters.AddWithValue("@CreatedAt", products.CreatedAt != null ? (object)products.CreatedAt : DBNull.Value);
                    command.Parameters.AddWithValue("@CreatedBy", products.CreatedBy != null ? (object)products.CreatedBy : DBNull.Value);
                    command.Parameters.AddWithValue("@LastModifiedAt", products.LastModifiedAt != null ? (object)products.LastModifiedAt : DBNull.Value);
                    command.Parameters.AddWithValue("@LastModifiedBy", products.LastModifiedBy != null ? (object)products.LastModifiedBy : DBNull.Value);
                    command.Parameters.AddWithValue("@Flag", products.Flag != null ? (object)products.Flag : DBNull.Value);


                    int result = await command.ExecuteNonQueryAsync();
                    return result > 0 ? Ok("Đã có lỗi xảy ra!") : Ok("Update thành công!!!");

                }
            }
        }

        [HttpDelete("{ProductID}")]

        public async Task<IActionResult> DeleteProduct(int ProductID, ProductsModel products)
        {
            using(SqlConnection connection = new SqlConnection(Conn))
            {
                await connection.OpenAsync();
                using (SqlCommand command = new SqlCommand("DeleteProduct", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ProductID", ProductID);

                    int resultDeleteProduct = await command.ExecuteNonQueryAsync();
                    return resultDeleteProduct > 0 ? Ok("An error has occurred") : Ok("Delete Successfully!");
                }
            }
        }


    }

    public class ProductModels
    {
        public object ProductID { get; internal set; }
    }
}
