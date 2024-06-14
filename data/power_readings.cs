namespace TestEnergyProject.data
{
    public class power_readings
    {
        public int id { get; set; }
        public string device_id { get; set; }
        public double watts { get; set; }
        public double amperage { get; set; }

        public double voltaje { get; set; }

        public double frecuency { get; set; }

        public DateTime creation_timestamp { get; set; }

        public DateTime reading_timestamp { get; set; }




    }
}