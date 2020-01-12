using RESTAPI.Model;

namespace RESTAPI.Business
{
    public interface IUserBusiness
    {
        object FindByLogin(User user);
    }
}
