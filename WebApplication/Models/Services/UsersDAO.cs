using System.Data.SqlClient;

namespace WebApplication.Models.Services
{
    public class UsersDAO
    {
        string connectionString = @"Data Source=(localdb)\ProjectModels;Initial Catalog=Test;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        
        public bool FindUserByNameAndPassword(UserViewModel user)
        {
            bool success = false;
            string sqlStatement = "SELECT * FROM Users WHERE USERNAME =@username AND PASSWORD = @password";

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, sqlConnection);
                command.Parameters.Add("@username",System.Data.SqlDbType.VarChar,40).Value =user.UserName;
                command.Parameters.Add("@password", System.Data.SqlDbType.VarChar, 40).Value = user.Password;

                try
                {
                    sqlConnection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if(reader.HasRows)
                    {
                        success = true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);  
                } 
            }

            return success;
        }
    
    }
}
