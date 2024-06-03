using System;

namespace FAIS.ApplicationCore.DTOs.Structure
{
    public class LibraryOptionAddDto
    {
        public int LibraryTypeId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string Remarks { get; set; }
        public int Ranking { get; set; }
        public string UDF1 { get; set; }
        public string UDF2 { get; set; }
        public string UDF3 { get; set; }
        public char IsActive { get; set; }
        public DateTime StatusDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }

    public class LibraryOptionUpdateDto
    {
        public int Id { get; set; }
        public int LibraryTypeId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string Remark { get; set; }
        public int Ranking { get; set; }
        public string UDF1 { get; set; }
        public string UDF2 { get; set; }
        public string UDF3 { get; set; }
        public char IsActive { get; set; }
        public DateTime StatusDate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}