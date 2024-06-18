using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace FAIS.ApplicationCore.Models
{
    public class PlantInformationDetailModel
    {
        public int Id { get; set; }
        public string PlantCode { get; set; }
        public int CostCenterType { get; set; }
        public string CostCenterNo { get; set; }
        public string CreatedByName { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UpdatedByName { get; set; } 
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? RemovedAt { get; set; }
    }
}
