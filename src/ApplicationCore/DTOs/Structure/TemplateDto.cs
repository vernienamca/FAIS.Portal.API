using System.Runtime.Serialization;
using System;
using DocumentFormat.OpenXml.InkML;
using DocumentFormat.OpenXml.Packaging;

namespace FAIS.ApplicationCore.DTOs
{
    public class TemplateDTO
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public int Receiver { get; set; }
        public string Users { get; set; }
        public string Roles { get; set; }
        public string Icon { get; set; }
        public string IconColor { get; set; }
        public int? NotificationType { get; set; }
        public DateTime? StartDate { get; set; }
        public string StartTime { get; set; }
        public DateTime? EndDate { get; set; }
        public string EndTime { get; set; }
        public string Target { get; set; }
        public char IsActive { get; set; }
        public DateTime StatusDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }

    public class AddTemplateDTO
    {
        public string Subject { get; set; }
        public string Content { get; set; }
        public int Receiver { get; set; }
        public string Users { get; set; }
        public string Roles { get; set; }
        public string Icon { get; set; }
        public string IconColor { get; set; }
        public int? NotificationType { get; set; }
        public DateTime? StartDate { get; set; }
        public string StartTime { get; set; }
        public DateTime? EndDate { get; set; }
        public string EndTime { get; set; }
        public string Target { get; set; }
        public char IsActive { get; set; }
        public DateTime StatusDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; } = DateTime.Now;
    }

    public class UpdateTemplateDTO
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public int Receiver { get; set; }
        public string Users { get; set; }
        public string Roles { get; set; }
        public string Icon { get; set; }
        public string IconColor { get; set; }
        public int? NotificationType { get; set; }
        public DateTime? StartDate { get; set; }
        public string StartTime { get; set; }
        public DateTime? EndDate { get; set; }
        public string EndTime { get; set; }
        public string Target { get; set; }
        public char IsActive { get; set; }
        public DateTime StatusDate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
