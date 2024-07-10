using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace FAIS.ApplicationCore.Models
{
    public class Amr100BatchStatHistoryModel
    {
        public int Id { get; set; }
        public int Amr100BatchSeq { get; set; }
        public int StatusCodeLto { get; set; }
        public DateTime StatusDate { get; set; }
        public string StatusRemarks { get; set; }
        public int CreatedBy { get; set; }
        public string UserName { get; set;}
     
    }
}
