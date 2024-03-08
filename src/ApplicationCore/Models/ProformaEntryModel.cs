using FAIS.ApplicationCore.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace FAIS.ApplicationCore.Models
{
    public class ProformaEntryModel
    {
        public int Id { get; set; }

        public int TranTypeSeq { get; set; }

        public string Description { get; set; }

        public string IsActive { get; set; }

        public DateTime StatusDate { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public int CreatedBy { get; set; }

        public int? UpdatedBy { get; set; }

        public IEnumerable<ProformaEntryDetailModel> ProformaEntryDetails { get; set; }

    }
}
