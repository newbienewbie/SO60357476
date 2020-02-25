using System.Threading.Tasks;
using App1.Models;
using JsonApiDotNetCore.Configuration;
using JsonApiDotNetCore.Controllers;
using JsonApiDotNetCore.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

public class PeopleController : JsonApiController<Person>
{
    public PeopleController(
        IJsonApiOptions jsonApiOptions,
        IResourceService<Person> resourceService,
        ILoggerFactory loggerFactory) 
    : base(jsonApiOptions, resourceService, loggerFactory)
    { }

    [HttpPost("/users/login")]
    public async Task<IActionResult> LoginAsync([FromBody] Login objLogin)
    {
        return new JsonResult(objLogin);
    }

}