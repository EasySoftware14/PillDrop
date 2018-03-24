using System;

namespace PillDrop.Domain.Entities
{
    public class EmailCallResponse
    {
        public bool IsSuccess
        {
            get
            {
                return CallResult.StartsWith("Sent.");
            }
        }

        public bool IsCallFailure
        {
            get { return !CallResult.StartsWith("Sent."); }
        }

        public Exception LastException { get; set; }
        public string CallResult { get; set; }
    }
}