using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RESTAPI.Business;
using RESTAPI.Model;

namespace RESTAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        //Declaração do serviço usado
        private IUserBusiness _userBusiness;

        public LoginController(IUserBusiness userBusiness)
        {
            _userBusiness = userBusiness;
        }

        // POST api/books
        [AllowAnonymous]
        [HttpPost]
        public object Post([FromBody]User user)
        {
            if (user == null) return BadRequest();
            return _userBusiness.FindByLogin(user);
        }
    }
}
