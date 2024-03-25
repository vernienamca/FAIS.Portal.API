using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace FAIS.ApplicationCore.Entities.Structure
{
    public class PlantInformation : BaseEntity<int>
    {
        [DataMember]
        public string PlantCode { get; set; }

        [DataMember]
        public string SubstationName { get; set; }

        [DataMember]
        public string SubstationNameOld { get; set; }

        [DataMember]
        public int Class { get; set; }

        [DataMember]
        public int TransGrid { get; set; }

        [DataMember]
        public int District { get; set; }

        [DataMember]
        public int Mtd { get; set; }

        [DataMember]
        public string GmapCoord { get; set; }

        [DataMember]
        public int Region { get; set; }

        [DataMember]
        public int Prov { get; set; }

        [DataMember]
        public int Mun { get; set; }

        [DataMember]
        public int Brgy { get; set; }

        [DataMember]
        public char IsActive { get; set; }

        [DataMember]
        public DateTime StatusDate { get; set; }

        [DataMember]
        public string CreatedBy { get; set; }

        [DataMember]
        public DateTime CreatedAt { get; set; }

        [DataMember]
        public string UpdatedBy { get; set; }

        [DataMember]
        public DateTime? UpdatedAt { get; set; }
    }
}
