using PillDrop.Domain.Entities;

namespace PillDropApplication.Models
{
    public class PrescriptionModel
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public PrescriptionModel()
        {
            
        }

        public PrescriptionModel(Prescription prescription)
        {
            Id = prescription.Id;
            Name = prescription.Name;
        }
    }
}