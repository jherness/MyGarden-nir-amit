using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Database
{
    public class AvgSample
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }
        public int id { get; set; }
        public DateTime datetime_of_sample { get; set; }
        public double temperature_sensor_data { get; set; }
        public double light_sensor_data { get; set; }
        public double atmosphere_sensors_data { get; set; }
        public double moist_sensors_data { get; set; }
        public bool is_raining { get; set; }

    }
}
