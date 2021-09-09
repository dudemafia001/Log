using Log.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Log.Services
{
    public interface IAuthenticationService
    {
        UserDeatils Authenticate(string username, string pass);
    }
}
