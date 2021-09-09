using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Log.Models;
using Log.Services;

namespace Log.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private IAuthenticationService _authenticationService;
        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }
        [HttpPost]
        public IActionResult Post([FromBody]UserDeatils model)
        {
            var user = _authenticationService.Authenticate(model.Name, model.Password);
            if(user == null)
            {
                return BadRequest(new { message = "Incorrect Username or Password" });
            }

            return Ok(user);
        }
    }
}
