﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace FAIS.ApplicationCore.Entities.Structure
{
    public class ProformaEntries : BaseEntity<int>
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string FaisRefNo { get; set; }

        [DataMember]
        public int TranTypeSeq { get; set; }

        [DataMember]
        public string CostCenter { get; set; }

        [DataMember]
        public int? GlNo { get; set; }

        [DataMember]
        public int RcaGl { get; set; }

        [DataMember]
        public string Prefix { get; set; }

        [DataMember]
        public int? Sl { get; set; }

        [DataMember]
        public string OtherCode { get; set; }

        [DataMember]
        public string Dce { get; set; }

        [DataMember]
        public string PlantCode { get; set; }

        [DataMember]
        public string Wo { get; set; }

        [DataMember]
        public string RefBillNo { get; set; }

        [DataMember]
        public string Source { get; set; }

        [DataMember]
        public string Nature { get; set; }

        [DataMember]
        public string AYyyy { get; set; }

        [DataMember]
        public string Fg { get; set; }

        [DataMember]
        public string Debit { get; set; }

        [DataMember]
        public string Credit { get; set; }

        [DataMember]
        public string TranDate { get; set; }

        [DataMember]
        public string YmPosted { get; set; }

        [DataMember]
        public int? Sort { get; set; }

        [DataMember]
        public string Udf1 { get; set; }

        [DataMember]
        public string Udf2 { get; set; }

        [DataMember]
        public DateTime CreatedAt { get; set; }

        [DataMember]
        public DateTime? UpdatedAt { get; set; }

        [DataMember]
        public DateTime? DeletedAt { get; set; }

        [DataMember]
        public int CreatedBy { get; set; }

        [DataMember]
        public int? UpdatedBy { get; set; }

        //public virtual PlantInformation PlantCodeNavigation { get; set; }
        //public virtual TransactionTypes TranTypeSeqNavigation { get; set; }
    }
}
