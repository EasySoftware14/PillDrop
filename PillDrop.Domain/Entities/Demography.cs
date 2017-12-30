using PillDrop.Domain.Contracts;
using PillDrop.Domain.Contracts.Models;

namespace PillDrop.Domain.Entities
{
    public class Demography : Entity
    {
        public virtual string StandNumber { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual string Location { get; set; }
        public virtual string Code { get; set; }
        public virtual string Gps { get; set; }

        public Demography(){}

        public virtual void Update(IDemography model)
        {
            StandNumber = model.StandNumber;
            Location = model.Location;
            Code = model.Code;
            Gps = model.Gps;
        }
    }

    
}