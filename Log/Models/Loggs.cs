using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Log.Models
{
    public class Loggs
    {
        public int id { get; set; }

        public List<LogMessages> LogReadings { get; set; }
    }
}
