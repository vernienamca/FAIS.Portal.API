using System;

namespace FAIS.ApplicationCore.Models
{
    public class VersionModel
    {
        public int Id { get; set; }
        public string VersionNo { get; set; }
        public DateTime VersionDate { get; set; }
        public string Amendment { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
