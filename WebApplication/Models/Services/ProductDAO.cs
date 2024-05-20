using System.Data.SqlClient;
using WebApplication.Models.Products;

namespace WebApplication.Models.Services
{
    public class ProductDAO : IProductDataService
    {

        string connectionString = @"Data Source=(localdb)\ProjectModels;Initial Catalog=Test;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public int Delete(ProductViewModel product)
        {
            int newIdNumber = -1;

            List<ProductViewModel> foundProducts = new List<ProductViewModel>();
            string sqlStatement = "DELETE FROM Product WHERE Id = @Id";

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, sqlConnection);
                command.Parameters.AddWithValue("@Id", product.Id);

                try
                {
                    sqlConnection.Open();
                    newIdNumber = Convert.ToInt32(command.ExecuteScalar());

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return newIdNumber;
        }

        public List<ProductViewModel> GetAllProducts()
        {
            List<ProductViewModel> foundProducts = new List<ProductViewModel>();
            string sqlStatement = "SELECT * FROM Product";

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, sqlConnection);

                try
                {
                    sqlConnection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        foundProducts.Add(new ProductViewModel
                        {
                            Id = (int)reader[0],
                            Name = (string)reader[1],
                            Price = (decimal)reader[2],
                            Description = (string)reader[3]
                        });
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return foundProducts;

        }

        public ProductViewModel GetProductById(int id)
        {
            ProductViewModel foundProducts = null;
            string sqlStatement = "SELECT * FROM Product where Id = @Id";

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, sqlConnection);
                command.Parameters.AddWithValue("@Id", id);
                try
                {
                    sqlConnection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        foundProducts = new ProductViewModel
                        {
                            Id = (int)reader[0],
                            Name = (string)reader[1],
                            Price = (decimal)reader[2],
                            Description = (string)reader[3]
                        };
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return foundProducts;
        }

        public int Insert(ProductViewModel product)
        {
            int newIdNumber = -1;

            List<ProductViewModel> foundProducts = new List<ProductViewModel>();
            string sqlStatement = "INSERT INTO Product (Name ,Price, Description) VALUES (@Name, @Price, @Description)";

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, sqlConnection);
                command.Parameters.AddWithValue("@Name", product.Name);
                command.Parameters.AddWithValue("@Price", product.Price);
                command.Parameters.AddWithValue("@Description", product.Description);                

                try
                {
                    sqlConnection.Open();
                    newIdNumber = Convert.ToInt32(command.ExecuteScalar());

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return newIdNumber;
        }

        public List<ProductViewModel> SearchProducts(string searchTerm)
        {
            List<ProductViewModel> foundProducts = new List<ProductViewModel>();
            string sqlStatement = "SELECT * FROM Product WHERE Name LIKE @Name";

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, sqlConnection);
                command.Parameters.AddWithValue("@Name", '%' + searchTerm + '%');

                try
                {
                    sqlConnection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        foundProducts.Add(new ProductViewModel
                        {
                            Id = (int)reader[0],
                            Name = (string)reader[1],
                            Price = (decimal)reader[2],
                            Description = (string)reader[3]
                        });
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return foundProducts;
        }

        public int Update(ProductViewModel product)
        {

            int newIdNumber = -1;

            List<ProductViewModel> foundProducts = new List<ProductViewModel>();
            string sqlStatement = "UPDATE Product SET Name = @Name, Price = @Price, Description=@Description WHERE Id = @Id";

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, sqlConnection);
                command.Parameters.AddWithValue("@Name", product.Name);
                command.Parameters.AddWithValue("@Price", product.Price);
                command.Parameters.AddWithValue("@Description", product.Description);
                command.Parameters.AddWithValue("@Id", product.Id);

                try
                {
                    sqlConnection.Open();
                    newIdNumber =Convert.ToInt32(command.ExecuteScalar());

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return newIdNumber;
        }
    }
}
