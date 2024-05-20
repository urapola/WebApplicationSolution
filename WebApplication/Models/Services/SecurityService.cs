namespace WebApplication.Models.Services
{
    public class SecurityService
    {
       
        UsersDAO usersDAO = new UsersDAO();
        public SecurityService()
        {
          
        }

        public bool IsValid(UserViewModel user)
        {
            return usersDAO.FindUserByNameAndPassword(user);
        }
    }

}
