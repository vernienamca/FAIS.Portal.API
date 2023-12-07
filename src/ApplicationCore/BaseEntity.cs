using System.Runtime.Serialization;

namespace FAIS.ApplicationCore
{
    [DataContract]
    public class BaseEntity<IdType>
    {
        /*[DataMember(IsRequired = false)]
        public IdType Id { get; set; }*/
    }
}
