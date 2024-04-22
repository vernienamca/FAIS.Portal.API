using System;

namespace FAIS.ApplicationCore.DTOs
{
    public class LibraryTypeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public char IsActive { get; set; }
        public DateTime StatusDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
    public class AddLibraryTypeDTO
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public char IsActive { get; set; }
        public DateTime StatusDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; } = DateTime.Now;
    }

    public class UpdateLibraryTypeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public char IsActive { get; set; }
        public DateTime StatusDate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
    }
}
