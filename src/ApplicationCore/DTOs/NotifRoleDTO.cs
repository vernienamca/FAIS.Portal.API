using System.Collections.Generic;

namespace FAIS.ApplicationCore.DTOs
{
    public class NotifRoleDTO
    {
        public List <int> RoleIds { get; set; }
        public int? Id { get; set; }
        public string AssetName { get; set; }
        public bool EditMode { get; set; }
        public bool isAdmin { get; set; }
    }
}
