using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Log.Models
{
    public class LogMessages
    {
        public int id { get; set; }

        public string Summary { get; set; }

        public string Message { get; set; }

        public DateTime ReceivedAt { get; set; }
    }
}
