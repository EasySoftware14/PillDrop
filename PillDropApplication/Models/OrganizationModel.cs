using PillDrop.Domain;
using PillDrop.Domain.Contracts.Models;

namespace PillDropApplication.Models
{
    public class OrganizationModel : IOrganizationModel
    {
        public string Name { get; set; }
        public EntityStatus Status { get; set; }
    }
}