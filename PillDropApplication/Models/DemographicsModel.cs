using PillDrop.Domain.Contracts.Models;
using PillDrop.Domain.Entities;

namespace PillDropApplication.Models
{
    public class DemographicsModel : IDemography
    {
        public string StandNumber { get; set; }
        public string Location { get; set; }
        public string Code { get; set; }
        public string Gps { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }

        public DemographicsModel(){}

        public DemographicsModel(Demography demography)
        {
            StandNumber = demography.StandNumber;
            Code = demography.Code;
            //Gps = demography.Gps;
            Latitude = demography.Latitude;
            Longitude = demography.Longitude;
        }

    }
}