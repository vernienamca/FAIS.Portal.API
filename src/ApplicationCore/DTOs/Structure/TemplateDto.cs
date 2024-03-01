using System.Runtime.Serialization;
using System;

namespace FAIS.ApplicationCore.DTOs
{
    public class TemplateDto
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public int Receiver { get; set; }
        public int? NotificationType { get; set; }
        public char IsActive { get; set; }
        public DateTime StatusDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
