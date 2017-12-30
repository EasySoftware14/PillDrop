using PillDrop.Domain;
using PillDrop.Domain.Contracts.Models;

namespace PillDropApplication.Models
{
    public class DemographicsModel : IDemography
    {
        public string StandNumber { get; set; }
        public string Location { get; set; }
        public string Code { get; set; }
        public string Gps { get; set; }

        public DemographicsModel(){}
       
    }
}