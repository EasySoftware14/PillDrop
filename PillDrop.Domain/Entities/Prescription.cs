using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PillDrop.Domain.Contracts.Models;

namespace PillDrop.Domain.Entities
{
    public class Prescription : Entity
    {
        public virtual string Name { get; set; }
        public virtual string Volume { get; set; }
        public virtual string Dosage { get; set; }
        public virtual string Weight { get; set; }
        public virtual string Frequency { get; set; }
        public virtual DateTime DateToBeCollected { get; set; }
        public virtual bool Collected { get; set; }
        
        public virtual void Update(IPrescriptionModel model)
        {
            Name = model.Name;
            Volume = model.Volume;
            Dosage = model.Dosage;
            Weight = model.Weight;
            Frequency = model.Frequency;
            DateToBeCollected = model.DateToBeCollected;
            Collected = model.Collected;
        }
    }
}
