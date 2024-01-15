using System.Runtime.Serialization;
using System;

namespace FAIS.ApplicationCore.DTOs
{
    public class AlertsDTO
    {
        
        public decimal Id { get; set; }
        
        public string Subject { get; set; }
        
        public string Content { get; set; }
        
        public string Receiver { get; set; }
        
        public string NotificationType { get; set; }
        
        public char IsActive { get; set; }
        
        public DateTime StatusDate { get; set; }
        
        public decimal CreatedBy { get; set; }
        
        public DateTime? CreatedAt { get; set; }
        
        public decimal? UpdatedBy { get; set; }
        
        public DateTime? UpdatedAt { get; set; }
    }
}
