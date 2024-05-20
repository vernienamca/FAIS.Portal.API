using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace FAIS.ApplicationCore.Entities.Structure
{
    public class ProjectProfile : BaseEntity<int>
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string ProjectName { get; set; }

        [DataMember]
        public string Remarks { get; set; }

        [DataMember]
        public string UDF1 { get; set; }

        [DataMember]
        public string UDF2 { get; set; }

        [DataMember]
        public string UDF3 { get; set; }

        [DataMember]
        public int ProjClassSeq { get; set; }

        [DataMember]
        public int ProjStageSeq { get; set; }

        [DataMember]
        public DateTime TpsrMonth { get; set; }

        [DataMember]
        public char IsActive { get; set; }

        [DataMember]
        public DateTime StatusDate { get; set; }

        [DataMember]
        public DateTime CreatedAt { get; set; }

        [DataMember]
        public DateTime? UpdatedAt { get; set; }

        [DataMember]
        public int CreatedBy { get; set; }

        [DataMember]
        public int? UpdatedBy { get; set; }

        [DataMember]
        public IEnumerable<ProjectProfileComponent> ProjectProfileComponents { get; set; }
    }
}