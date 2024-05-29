﻿using System;
using System.Collections.Generic;

namespace FAIS.ApplicationCore.Models
{
    public class LibraryOptionModel
    {
        
        public int Id { get; set; }
        public int LibraryTypeId { get; set; }
        public string LibraryTypeName { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string Remark { get; set; }
        public char IsActive { get; set; }
        public DateTime StatusDate { get; set; }
        public int CreatedBy { get; set; }
        public string CreatedByName { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public string UpdatedByName { get; set; } = string.Empty;
        public DateTime? UpdatedAt { get; set; }
        public string ParentValue { get; set; }
        public int ParentId { get; set; }
        public List<ChildValueModel> ChildValues { get; set; }
      
    }

    public class ChildValueModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }
}
