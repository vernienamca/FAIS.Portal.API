using System;

namespace FAIS.ApplicationCore.Models
{
    public class AuditLogModel
    {
        public int Id { get; set; }
        public string ModuleName { get; set; }
        public string Activity { get; set; }
        public string OldValues { get; set; }
        public string NewValues { get; set; }
        public string IpAddress { get; set; }
        public int UserId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
