using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PillDrop.Domain.Contracts.Models;
using PillDrop.Domain.Entities;

namespace PillDropApplication.Models
{
    public class PillDropperModel : IPillDropperModel
    {
        public string LicenceNumber { get; set; }
        public string LicencePlateNumber { get; set; }
        public bool VetteCertificate { get; set; }

        public PillDropperModel()
        {
            
        }

        public PillDropperModel(PillDropper model)
        {
            LicencePlateNumber = model.LicencePlateNumber;
            LicenceNumber = model.LicenceNumber;
            VetteCertificate = model.VetteCertificate;
        }
    }
}