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
    public class Registration : ControllerBase
    {

        private RegistrationService CreateRegistrationService()
        {
            MCCContext Database = new();
            ProfileRepo ProfileRepo = new(Database);
            PersonToProfileRepo PersonToProfileRepo = new(Database);
            PersonRepo PersonRepo = new(Database);
            return new RegistrationService(PersonToProfileRepo, PersonRepo, ProfileRepo);
        }

        // POST api/<Registration>
        [HttpPost]
        public ActionResult<GenericResponse<ProfilePublicModel>> Post([FromBody] RegistrationRequestModel request)
        {
            try
            {
                RegistrationService Service = CreateRegistrationService();
                ProfilePublicModel Profile = Service.Registration(
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
                else
                {
                    return BadRequest(ex.Message);
                }
            }
        }
    }
}
