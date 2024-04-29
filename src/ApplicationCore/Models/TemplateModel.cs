using System;

namespace FAIS.ApplicationCore.Models
{
    public class TemplateModel
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public int Receiver { get; set; }
        public string ReceiverName { get; set; }
        public int? NotificationType { get; set; }
        public string NotificationTypeName { get; set; }
        public string Users { get; set; }
        public string Roles { get; set; }
        public string Icon { get; set; }
        public int? IconColor { get; set; }
        public DateTime? StartDate { get; set; }
        public string StartTime { get; set; }
        public DateTime? EndDate { get; set; }
        public int Target { get; set; }
        public string Url { get; set; }
        public string EndTime { get; set; }
        public char IsActive { get; set; }
        public DateTime StatusDate { get; set; }
        public int CreatedBy { get; set; }
        public string CreatedByName { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public string UpdatedByName { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
