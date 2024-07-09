using System;
using System.Runtime.Serialization;

namespace FAIS.ApplicationCore.DTOs
{
    public class AmrDTO
    {
        public int Id { get; set; }
        public DateTime AmrYm { get; set; }
        public DateTime DateReceivedTransco { get; set; }
        public DateTime DateReceivedArmPmd { get; set; }
        public DateTime? DateSentEncoding { get; set; }
        public DateTime? DateEndorsed { get; set; }
        public int NoOfBinders { get; set; }
        public string UDF1 { get; set; }
        public string UDF2 { get; set; }
        public string UDF3 { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
    public class AddAmrDTO
    {
        public DateTime AmrYm { get; set; }
        public DateTime DateReceivedTransco { get; set; }
        public DateTime DateReceivedArmPmd { get; set; }
        public DateTime? DateSentEncoding { get; set; }
        public int NoOfBinders { get; set; }
        public string UDF1 { get; set; }
        public string UDF2 { get; set; }
        public string UDF3 { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
    public class UpdateAmrDTO
    {
        public int Id { get; set; }
        public DateTime AmrYm { get; set; }
        public DateTime DateReceivedTransco { get; set; }
        public DateTime DateReceivedArmPmd { get; set; }
        public DateTime? DateSentEncoding { get; set; }
        public int NoOfBinders { get; set; }
        public string UDF1 { get; set; }
        public string UDF2 { get; set; }
        public string UDF3 { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
