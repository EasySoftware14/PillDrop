namespace PillDrop.Domain.Entities
{
    public class RoleSubModule
    {
        public virtual Role Role { get; set; }
        public virtual Module SubModule { get; set; }
        public virtual Module ParentModule { get; set; }
    }
}
