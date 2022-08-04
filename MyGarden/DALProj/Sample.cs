using MongoDB.Driver;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALProj
{
    public class Sample
    {
        public string _id { get; set; }
        public int id { get; set; }
        public DateTime datetime_of_sample { get; set; }
        public double light_sensor_data { get; set; }
        public double first_moist_sensor { get; set; }
        public double second_moist_sensor { get; set; }
        public double third_moist_sensor { get; set; }
        public double first_atmosphere_sensor_data { get; set; }
        public double second_atmosphere_sensor_data { get; set; }
        public double temperature_sensor_data { get; set; }
        public bool is_raining { get; set; }

        public Sample()
        {
            datetime_of_sample = DateTime.Now;
            light_sensor_data = 0;
            first_moist_sensor = 0;
            second_moist_sensor = 0;
            third_moist_sensor = 0;
            first_atmosphere_sensor_data = 0;
            second_atmosphere_sensor_data = 0;
            is_raining = false;
        }
    }
}
