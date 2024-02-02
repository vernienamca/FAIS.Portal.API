using System;

namespace FAIS.ApplicationCore.Models
{
    public class VersionModel
    {
        public int Id { get; set; }
        public string VersionNo { get; set; }
        public DateTime VersionDate { get; set; }
        public string Amendment { get; set; }
        public string CreatedByName { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
