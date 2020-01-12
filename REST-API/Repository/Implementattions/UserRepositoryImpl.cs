using RESTAPI.Model;
using RESTAPI.Model.Context;
using System.Linq;

namespace RESTAPI.Repository.Implementattions
{
    public class UserRepositoryImpl : IUserRepository
    {
        private MySQLContext _mySQLContext;

        public UserRepositoryImpl(MySQLContext mySQLContext)
        {
            _mySQLContext = mySQLContext;
        }
                
        public User FindByLogin(string login)
        {
            return _mySQLContext.Users.SingleOrDefault(u => u.Login.Equals(login));
        }
    }
}
