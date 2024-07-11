using System;
using System.Collections.Generic;
using System.Text;

namespace FAIS.ApplicationCore.DTOs.Structure
{
    public class Amr100BatchStatHistoryDTO
    {
        public int Id { get; set; }
        public int BatchSeq { get; set; }
        public int StatusCode { get; set; }
        public DateTime StatusDate { get; set; }
        public string Remarks { get; set; }
        public int CreatedBy { get; set; }
    }
}
