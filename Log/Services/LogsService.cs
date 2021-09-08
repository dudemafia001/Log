using Log.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Log.Services
{
    public class LogsService :  ILogs
    {
        private List<LogMessages> _log;
        public Dictionary<string, List<LogMessages>> LogReadings { get; set; }
        public LogsService(Dictionary<string, List<LogMessages>> logReadings)
        {
            LogReadings = logReadings;
        }
        public List<LogMessages> GetLogs(int id)
        {
            return LogReadings[id.ToString()];
        }

        public void SetLogs(int id, List<LogMessages> Log)
        {
            if (!LogReadings.ContainsKey(id.ToString()))
            {
                LogReadings.Add(id.ToString(), new List<LogMessages>());
            }
            LogReadings[id.ToString()] = Log;
        }

    }
    
}
