using System;
using System.Collections.Generic;
using System.Web.Mvc;
using PillDrop.Domain.Contracts.Models;
using PillDrop.Domain.Entities;

namespace PillDropApplication.Models
{
    public class MedicalModel : IPrescriptionModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Volume { get; set; }
        public string Dosage { get; set; }
        public string Weight { get; set; }
        public string Frequency { get; set; }
        public DateTime DateToBeCollected { get; set; }
        public string DateCollected { get; set; }   
        public bool Collected { get; set; } 

        public IList<SelectListItem> Users { get; set; }
        public IList<PrescriptionModel> Prescriptions { get; set; }
        public long UserId { get; set; }
        public string MedicineIds { get; set; }
        
        public MedicalModel()
        {
            
        }

        public MedicalModel(Prescription medicine)
        {
            Name = medicine.Name;
            Volume = medicine.Volume;
            Dosage = medicine.Dosage;
            Weight = medicine.Weight;
            DateToBeCollected = medicine.DateToBeCollected;
            Frequency = medicine.Frequency;
            Collected = medicine.Collected;
        }
    }
}