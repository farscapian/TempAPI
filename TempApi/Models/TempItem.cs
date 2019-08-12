using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace TempApi.Models
{
    public class TempItem
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string SensorName { get; set; }
        public DateTime Timestamp { get; set; }
        public decimal Temperature { get; set; }
        public string HeaterAction { get; set; }
    }

}
