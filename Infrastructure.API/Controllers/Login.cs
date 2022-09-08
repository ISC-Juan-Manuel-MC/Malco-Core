using Microsoft.AspNetCore.Mvc;

using Application.Models;
using Application.Models.Request;
using Application.Models.General;
using Application.Services.UserCases;
using Infrastructure.DataAccess.Contexts;
using Infrastructure.DataAccess.Repositories.General;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Infrastructure.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Login : ControllerBase
    {

        private LoginService CreateLoginService()
        {
            MCCContext Database = new();
            ProfileRepo ProfileRepo = new(Database);
            PersonToProfileRepo PersonToProfileRepo = new(Database);
            PersonRepo PersonRepo = new(Database);
            return new LoginService(ProfileRepo, PersonToProfileRepo, PersonRepo);
        }

        // POST api/<Login>
        [HttpPost]
        public ActionResult<ProfilePublicModel> Post([FromBody] GenericRequest<LoginRequestModel> entity)
        {
            LoginService Service = CreateLoginService();
            ProfilePublicModel Response = Service.Login(entity.Data.Email, entity.Data.Password);
            return Ok(Response);
        }

    }
}
