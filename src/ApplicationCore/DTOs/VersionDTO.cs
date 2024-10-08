﻿using System;

namespace FAIS.ApplicationCore.DTOs
{
    public class VersionDTO
    {
        public int Id { get; set; }
        public string VersionNo { get; set; }
        public DateTime VersionDate { get; set; }
        public string Amendment { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class AddVersionDTO
    {
        public string VersionNo { get; set; }
        public DateTime VersionDate { get; set; }
        public string Amendment { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
