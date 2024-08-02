using FAIS.ApplicationCore.Enumeration;
using System;
using System.Collections.Generic;

namespace FAIS.ApplicationCore.DTOs
{
    public class StepContainerDTO
    {
        //public StepContainerDTO() {
        //    StepContainerChild = new List<StepContainerDTO>();
        //}
        public int Id { get; set; }
        public int DefinedMethodId { get; set; }
        public int ParentId { get; set; }     
        public int SortOrder { get; set; }   
        public StepTypeEnum StepType { get; set; }     
        public int FieldDictionaryId { get; set; }      
        public char IsElse { get; set; }      
        public string Value { get; set; }     
        public string Comments { get; set; }      
        public DateTime CreatedAt { get; set; }    
        public DateTime? UpdatedAt { get; set; }       
        public int CreatedBy { get; set; } 
        public int? UpdatedBy { get; set; }
        public DateTime? RemovedAt { get; set; }
        //@TODO: Add a child property of its own for parent/child relation
        //public List<StepContainerDTO> StepContainerChild { get; set; } 
    }
}
