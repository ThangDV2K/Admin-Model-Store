using System.Data.SqlClient;

namespace APIprojectModelStore.Models
{
    public class TestModel
    {
        public int ProductID { get; set; }

        public string ProductName { get; set; }

        public decimal PriceListed { get; set; }
        public int Sale { get; set;}

        public string Avatar { get; set;}

        public int Version { get; set; } 

        public string Weight { get; set; }
        public string Height { get; set; }
        public string Material { get; set; }


    }
}
