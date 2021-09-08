using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Log.Models;

namespace Log.Generator
{
    public class LogsGenerator
    {
        public LogsGenerator()
        {

        }
        public List<LogMessages> Generate(int number)
        {
            var readings = new List<LogMessages>();
            var random = new Random();
            for (int i = 0; i < number; i++)
            {
                var log = new LogMessages
                {
                    id = i,
                    Message = "Test "+i.ToString(),
                    Summary = "Summary "+i.ToString(),
                    ReceivedAt = DateTime.Now
                };
                readings.Add(log);
            }
            return readings;
        }
    }
}
