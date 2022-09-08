using Microsoft.AspNetCore.Mvc;

using Application.Models;
using Application.Models.Request;
using Application.Models.General;
using Application.Services.UserCases;
using Application.Errors;
using Infrastructure.DataAccess.Contexts;
using Infrastructure.DataAccess.Repositories.General;
using System.Text.Json;
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
        public ActionResult<GenericResponse<ProfilePublicModel>> Post([FromBody] GenericRequest<LoginRequestModel> Request)
        {
            try
            {
                LoginService Service = CreateLoginService();
                ProfilePublicModel Profile = Service.Login(Request.Data.Email, Request.Data.Password);
                GenericResponse<ProfilePublicModel> Response = new(Profile);
                return Ok(JsonSerializer.Serialize(Response));
            }
            catch (Exception ex)
            {
                if(ex.GetType() == typeof(EntityNotExistError))
                {
                    return NotFound(ex.Message);
                }
                else
                {
                    return BadRequest(ex.Message);
                }
            }
        }

    }
}
