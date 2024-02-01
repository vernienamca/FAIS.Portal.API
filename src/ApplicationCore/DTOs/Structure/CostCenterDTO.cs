using System;

namespace FAIS.ApplicationCore.DTOs
{
    public class CostCenterDTO
    {
        public int Id { get; set; }
        public string FGCode { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
