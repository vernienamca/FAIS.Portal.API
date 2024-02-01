﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FAIS.ApplicationCore.Models
{
    public class ProformaEntriesModel
    {
        public int Id { get; set; }
        public string FaisRefNo { get; set; }
        public int TranTypeSeq { get; set; }
        public string CostCenter { get; set; }
        public int? GlNo { get; set; }
        public int RcaGl { get; set; }
        public string Prefix { get; set; }
        public int? Sl { get; set; }
        public string OtherCode { get; set; }
        public string Dce { get; set; }
        public string PlantCode { get; set; }
        public string Wo { get; set; }
        public string RefBillNo { get; set; }
        public string Source { get; set; }
        public string Nature { get; set; }
        public string AYyyy { get; set; }
        public string Fg { get; set; }
        public string Debit { get; set; }
        public string Credit { get; set; }
        public string TranDate { get; set; }
        public string YmPosted { get; set; }
        public int? Sort { get; set; }
        public string Udf1 { get; set; }
        public string Udf2 { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public int CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
    }
}
