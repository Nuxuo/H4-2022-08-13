using System.ComponentModel.DataAnnotations;
using DataTransferObject.Base;

namespace DataTransferObject{
    public class StatisticsDto {
        public List<Stats> SensorStats {get; set;} = new List<Stats>();
    }

    public class Stats {
        public string Sensor_Name {get; set;}
        public float latest_value {get; set;}
        public float Max_value {get; set;}
        public float Min_value {get; set;}
        public float Avg_value {get; set;}
        public float latest_value_DateTime {get; set;}
        public float Max_value_DateTime {get; set;}
        public float Min_value_DateTime {get; set;}
        public float Avg_value_DateTime {get; set;}
    }
}   