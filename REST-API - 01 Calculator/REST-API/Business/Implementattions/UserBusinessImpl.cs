using RESTAPI.Model;
using RESTAPI.Repository;

namespace RESTAPI.Business.Implementattions
{
    public class UserBusinessImpl : IUserBusiness
    {
        private IUserRepository _userRepository;
        public UserBusinessImpl(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public object FindByLogin(User user)
        {
            throw new System.NotImplementedException();
        }
    }
}
