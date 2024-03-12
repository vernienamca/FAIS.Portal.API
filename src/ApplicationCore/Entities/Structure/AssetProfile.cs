﻿using System;
using System.Runtime.Serialization;

namespace FAIS.ApplicationCore.Entities.Structure
{
    public class AssetProfile : BaseEntity<int>
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int AssetCategoryId { get; set; }
        [DataMember]
        public int? AssetClassId { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public int RcaGLId { get; set; }
        [DataMember]
        public int RcaSLId { get; set; }
        [DataMember]
        public int CostCenter { get; set; }
        [DataMember]
        public string EconomicLife { get; set; }
        [DataMember] 
        public string ResidualLife { get; set; }
        [DataMember]
        public string IsActive { get; set; }
        [DataMember]
        public DateTime StatusDate { get; set; }
        [DataMember]
        public int CreatedBy { get; set; }
        [DataMember]
        public DateTime CreatedAt { get; set; }
        [DataMember]
        public int? UpdatedBy { get; set; }
        [DataMember]
        public DateTime? UpdatedAt { get; set; }
    }
}
