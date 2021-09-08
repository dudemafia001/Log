using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Log.Models;

namespace Log.Services
{
    public interface ILogs
    {
        List<LogMessages> GetLogs(int id);

        void SetLogs(int id, List<LogMessages> Log);
    }
}
