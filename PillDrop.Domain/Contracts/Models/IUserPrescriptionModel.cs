using System;
using PillDrop.Domain.Entities;

namespace PillDrop.Domain.Contracts.Models
{
    public interface IUserPrescriptionModel
    {
        string Prescription { get; set; }
        User AssignedBy { get; set; }
        User User { get; set; }
        DateTime DateOfCollection { get; set; }
        bool Collected { get; set; }
    }
}