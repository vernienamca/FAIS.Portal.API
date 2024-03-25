using System;

namespace FAIS.ApplicationCore.Models
{
    public class PlantInformationModel
    {
        public string PlantCode { get; set; }
        public string SubstationName { get; set; }
        public string SubstationNameOld { get; set; }
        public int Class { get; set; }
        public int TransGrid { get; set; }
        public int District { get; set; }
        public int Mtd { get; set;}
        public string GmapCoord { get; set; }
        public int Region { get; set; }
        public int Prov { get; set; }
        public int Mun { get; set; }
        public int Brgy { get; set; }
        public char IsActive { get; set; }
        public DateTime StatusDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
