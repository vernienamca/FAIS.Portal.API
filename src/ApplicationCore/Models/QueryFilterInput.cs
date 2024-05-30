using System.Runtime.Serialization;

namespace FAIS.ApplicationCore.Models
{
    public class QueryFilterInput
    {
        [DataMember(Name = "offset")]
        public int? Offset { get; set; }

        [DataMember(Name = "pageSize")]
        public int PageSize { get; set; }

        [DataMember(Name = "isPaginated")]
        public bool? IsPaginated { get; set; }

        public QueryFilterInput()
        {
            ApplyDefaults();
        }

        public void ApplyDefaults()
        {
            if (PageSize == 0)
                PageSize = 50;
        }
    }
}
