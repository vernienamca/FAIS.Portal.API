﻿namespace FAIS.ApplicationCore.Models
{
    public class PermissionModel
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int ModuleId { get; set; }
        public string ModuleName { get; set; }
        public string Url { get; set; }
        public string Icon { get; set; }
        public string GroupName { get; set; }
        public bool IsCreate { get; set; }
        public bool IsRead { get; set; }
        public bool IsUpdate { get; set; }
    }
}
