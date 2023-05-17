using APIModelStore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace APIModelStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly string Conn = "Server=20.231.38.177;Database=ModelStore;User Id=sa;Password=Th@ng04062000;";
        //private readonly string Conn = "Server=DESKTOP-6OJTPAP\\WINDING2K;Database=ModelStore;User Id=sa;Password=123;";
        [HttpGet]
        public async Task<IEnumerable<CategoryModel>> GetAllCategory()
        {
            var ListCategory = new List<CategoryModel>();

            using (SqlConnection connection = new SqlConnection(Conn))
            {
                await connection.OpenAsync();
                using (SqlCommand command = new SqlCommand("getAllCategory", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            ListCategory.Add(new CategoryModel()
                            {
                                CategoryID = reader.GetInt32(0),
                                CategoryName = reader.IsDBNull(1) ? null : reader.GetString(1),
                                ParentID = reader.IsDBNull(2) ? null : reader.GetInt32(2),
                                Description = reader.IsDBNull(3) ? null : reader.GetString(3),
                                CreatedAt = reader.IsDBNull(4) ? null : reader.GetDateTime(4),
                                CreatedBy = reader.IsDBNull(5) ? null : reader.GetInt32(5),
                                LastModifiedAt = reader.IsDBNull(6) ? null : reader.GetDateTime(6),
                                LastModifiedBy = reader.IsDBNull(7) ? null : reader.GetInt32(7),
                                Flag = reader.IsDBNull(8) ? null : reader.GetString(8),
                            });
                        }
                    }
                }
                await connection.CloseAsync();
            }
            return ListCategory;
        }

        [HttpGet("{CategoryID}")]
        public async Task<IEnumerable<CategoryModel>> Get(int CategoryID)
        {
            var ListCategory = new List<CategoryModel>();

            using (SqlConnection connection = new SqlConnection(Conn))
            {
                await connection.OpenAsync();
                using (SqlCommand command = new SqlCommand("SELECT * FROM Category WHERE CategoryID = @CategoryID", connection))
                {
                    command.Parameters.AddWithValue("@CategoryID", CategoryID);
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            ListCategory.Add(new CategoryModel()
                            {
                                CategoryID = reader.GetInt32(0),
                                CategoryName = reader.IsDBNull(1) ? null : reader.GetString(1),
                                ParentID = reader.IsDBNull(2) ? null : reader.GetInt32(2),
                                Description = reader.IsDBNull(3) ? null : reader.GetString(3),
                                CreatedAt = reader.IsDBNull(4) ? null : reader.GetDateTime(4),
                                CreatedBy = reader.IsDBNull(5) ? null : reader.GetInt32(5),
                                LastModifiedAt = reader.IsDBNull(6) ? null : reader.GetDateTime(6),
                                LastModifiedBy = reader.IsDBNull(7) ? null : reader.GetInt32(7),
                                Flag = reader.IsDBNull(8) ? null : reader.GetString(8),
                            });
                        }
                    }
                }
            }
            return ListCategory;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(CategoryModel categorys)
        {
            using (SqlConnection connection = new SqlConnection(Conn))
            {
                await connection.OpenAsync();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO Category ([CategoryName],[ParentID],[Description],[CreatedAt],[CreatedBy],[LastModifiedAt],[LastModifiedBy],[Flag]) VALUES(@CategoryName,@ParentID,@Description,@CreatedAt,@CreatedBy,@LastModifiedAt,@LastModifiedBy,@Flag)";
                    command.Parameters.AddWithValue("@CategoryName", categorys.CategoryName);
                    command.Parameters.AddWithValue("@ParentID", categorys.ParentID);
                    command.Parameters.AddWithValue("@Description", categorys.Description);
                    command.Parameters.AddWithValue("@CreatedAt", categorys.CreatedAt);
                    command.Parameters.AddWithValue("@CreatedBy", categorys.CreatedBy);
                    command.Parameters.AddWithValue("@LastModifiedAt", categorys.LastModifiedAt);
                    command.Parameters.AddWithValue("@LastModifiedBy", categorys.LastModifiedBy);
                    command.Parameters.AddWithValue("@Flag", categorys.Flag != null ? (object)categorys.Flag : DBNull.Value);


                    int result = await command.ExecuteNonQueryAsync();
                    if (result > 0)
                    {
                        return Ok("Insert data successed!");
                    }
                    else
                    {
                        return Ok("Insert data faild");
                    }

                }
            }
        }

        [HttpPut("{CategoryID}")]
        public async Task<IActionResult> UpdateAsync(int CategoryID, CategoryModel category)
        {
            using (SqlConnection connection = new SqlConnection(Conn))
            {
                await connection.OpenAsync();
                using (SqlCommand command = new SqlCommand("InsertOrUpdateCategory", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CategoryID", CategoryID);
                    command.Parameters.AddWithValue("@CategoryName", category.CategoryName);
                    command.Parameters.AddWithValue("@ParentID", category.ParentID);
                    command.Parameters.AddWithValue("@Description", category.Description);
                    command.Parameters.AddWithValue("@CreatedAt", category.CreatedAt);
                    command.Parameters.AddWithValue("@CreatedBy", category.CreatedBy);
                    command.Parameters.AddWithValue("@LastModifiedAt", category.LastModifiedAt);
                    command.Parameters.AddWithValue("@LastModifiedBy", category.LastModifiedBy);
                    command.Parameters.AddWithValue("@Flag", category.Flag != null ? (object)category.Flag : DBNull.Value);


                    int result = await command.ExecuteNonQueryAsync();
                    return Ok("Success!");

                }
            }
        }

        [HttpDelete("{CategoryID}")]

        public async Task<IActionResult> DeleteCategory(int CategoryID, CategoryModel category)
        {
            using (SqlConnection connection = new SqlConnection(Conn))
            {
                await connection.OpenAsync();
                using(SqlCommand command = new SqlCommand("DeleteCategory",connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CategoryID", CategoryID);

                    int resultDeleteCategory = await command.ExecuteNonQueryAsync();
                    return resultDeleteCategory > 0 ? Ok("Delete Faild!") : Ok("Delete Successfully");
                }
            }
        }
    }
}
