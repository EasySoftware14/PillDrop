using PillDrop.Domain.Contracts;
using PillDrop.Domain.Contracts.Models;

namespace PillDrop.Domain.Entities
{
    public class Demography : Entity
    {
        public virtual string StandNumber { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual string Code { get; set; }
        public virtual string Gps { get; set; }
        public virtual string Latitude { get; set; }
        public virtual string Longitude { get; set; }

        public Demography(){}
        
        public virtual void Update(IDemography model)
        {
            StandNumber = model.StandNumber;
            Code = model.Code;
            Gps = model.Gps;
            Latitude = model.Latitude;
            Longitude = model.Longitude;
        }
    }

    
}