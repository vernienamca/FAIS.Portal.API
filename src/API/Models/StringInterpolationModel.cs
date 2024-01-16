﻿using System.Runtime.Serialization;
using System;

namespace FAIS.Portal.API.Models
{
    public class StringInterpolationModel
    {
        public int Id { get; set; }
        public string TransactionCode { get; set; }
        public string TransactionDescription { get; set; }
        public char IsActive { get; set; }
        public DateTime StatusDate { get; set; }
        public string NotificationType { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
