using RESTAPI.Model;
using System.Collections.Generic;

namespace RESTAPI.Repository
{
    public interface IUserRepository
    {
        User FindByLogin(string login);
    }
}
