namespace PillDrop.Domain.Entities
{
    public class EmailArchive : Entity
    {
        public virtual string Recipients { get; set; }
        public virtual bool IsSent { get; set; }
        public virtual int RetryCount { get; set; }
        public virtual string FailureReason { get; set; }
        public virtual string Handler { get; set; }
        public virtual string Culture { get; set; }
        public virtual string Timezone { get; set; }
        public virtual long ObjectId { get; set; }

        public virtual void SetFailureReason(string reason)
        {
            FailureReason = reason;
        }

        public virtual void EmailSent()
        {
            IsSent = true;
        }
    }
}