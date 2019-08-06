using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TempApi.Models
{
    public class TempItem
    {
        public long Id { get; set; }
        public string SensorName { get; set; }
        public DateTime Timestamp { get; set; }
        public decimal Temperature { get; set; }
        public string HeaterAction { get; set; }
    }

}
