using System;

namespace PillDrop.Domain.Contracts.Models
{
    public interface IPrescriptionModel
    {
         
        string Name { get; set; }
        string Volume { get; set; }
        string Dosage { get; set; }
        string Weight { get; set; }
        string Frequency { get; set; }
        DateTime DateToBeCollected { get; set; }
        bool Collected { get; set; }
    }
}