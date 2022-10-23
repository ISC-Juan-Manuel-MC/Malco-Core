using Microsoft.AspNetCore.Mvc;

using Application.Models;
using Application.Models.Request;
using Application.Models.General;
using Application.Services.UserCases;
using Application.Errors;
using Infrastructure.DataAccess.Contexts;
using Infrastructure.DataAccess.Repositories.General;
using System.Text.Json;
using Application.Models.Security;
using Infrastructure.DataAccess.Repositories.Security;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Infrastructure.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Registration : ControllerBase
    {
        private JWTModel JWT;

        private void GetJWT()
        {
            JWT = JWTModel.GetFakeModel();
        }
        private RegistrationService CreateRegistrationService()
        {
            MCCContext Database = new();
            ActivityLogRepo LogRepo = new(Database);
            ProfileRepo ProfileRepo = new(Database);
            PersonToProfileRepo PersonToProfileRepo = new(Database);
            PersonRepo PersonRepo = new(Database);
            return new RegistrationService(LogRepo, PersonToProfileRepo, PersonRepo, ProfileRepo);
        }

        // POST api/<Registration>
        [HttpPost]
        public ActionResult<GenericResponse<ProfilePublicModel>> Post([FromBody] RegistrationRequestModel request)
        {
            try
            {
                this.GetJWT();

                RegistrationService Service = CreateRegistrationService();
                ProfilePublicModel Profile = Service.Registration(
                    this.JWT,
                    request.email,
                    request.password,
                    request.firstName,
                    request.lastName, 
                    request.cellphone,
                    request.gender,
                    DateOnly.Parse(request.birthday));
                GenericResponse<ProfilePublicModel> Response = new(Profile);
                return Ok(JsonSerializer.Serialize(Response));
            }
            catch (Exception ex)
            {
                if (ex.GetType() == typeof(EntityNotExistError))
                {
                    return NotFound(ex.Message);
                }
                else if (ex.GetType() == typeof(ExistingEntityError))
                {
                    return Conflict(ex.Message);
                }
                else
                {
                    return BadRequest(ex.Message);
                }
            }
        }
    }
}
