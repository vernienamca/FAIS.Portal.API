﻿using System;
using System.Runtime.Serialization;

namespace FAIS.ApplicationCore.Entities.Security
{
    public class RolePermission : BaseEntity<int>
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int RoleId { get; set; }

        [DataMember]
        public int ModuleId { get; set; }

        [DataMember]
        public char IsCreate { get; set; }

        [DataMember]
        public char IsRead { get; set; }

        [DataMember]
        public char IsUpdate { get; set; }

        [DataMember]
        public DateTime? DateRemoved { get; set; }

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
