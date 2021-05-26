using System;
using System.Collections.Generic;
using System.Text;

namespace EvaluacionTecnica.Repository.Historical
{
    public class HistoricalDto
    {
        public int HistoricalID { get; set; }
        public int CityID { get; set; }
        public decimal Temperature { get; set; }
        public decimal ThermalSensation { get; set; }

    }

    public class HistoricalInfo
    {
        public string CityName { get; set; }
        public string CountryName { get; set; }
        public decimal Temperature { get; set; }
        public decimal ThermalSensation { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
