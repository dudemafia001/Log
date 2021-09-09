using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Log.Services;
using Log.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Log.Controllers
{
    [Route("Logs")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ILogs _log;
        public HomeController(ILogs log)
        {
            _log = log;
        }
        // GET api/values
        [HttpGet("getLogs/{id}")]
        public ObjectResult GetLogs(int id,int ? maxRecords = null)
        {
            List<LogMessages> logs = _log.GetLogs(id);
            if (maxRecords.HasValue)
            {
                return new OkObjectResult(logs.Take(maxRecords.Value));
            }
            return new OkObjectResult(logs);

        }

        // GET api/values/5
        [HttpPost("Store")]
        public ObjectResult SetLogs([FromBody]Loggs logs)
        {
            _log.SetLogs(logs.id, logs.LogReadings);
            return new OkObjectResult("{}");
        }

    }
}
