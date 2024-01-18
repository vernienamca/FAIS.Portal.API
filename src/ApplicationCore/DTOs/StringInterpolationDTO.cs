﻿using System.Runtime.Serialization;
using System;

namespace FAIS.ApplicationCore.DTOs
{
    public class StringInterpolationDTO
    {
        public int Id { get; set; }
        public string TransactionCode { get; set; }
        public string TransactionDescription { get; set; }
        public char IsActive { get; set; }
        public DateTime StatusDate { get; set; }
        public string NotificationType { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
