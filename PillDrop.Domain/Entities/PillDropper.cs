using PillDrop.Domain.Contracts.Models;

namespace PillDrop.Domain.Entities
{
    public class PillDropper : Entity
    {
        public virtual User User { get; set; }
        public virtual string LicenceNumber { get; set; }
        public virtual string LicencePlateNumber { get; set; }
        public virtual bool VetteCertificate { get; set; }
        public virtual string Latitude { get; set; }
        public virtual string Longitude { get; set; }

        public PillDropper()
        {}

        public virtual void Update(IPillDropperModel model)
        {
            LicenceNumber = model.LicenceNumber;
            LicencePlateNumber = model.LicencePlateNumber;
            VetteCertificate = model.VetteCertificate;
            Latitude = model.Latitude;
            Longitude = model.Longitude;
        }
    }
}
