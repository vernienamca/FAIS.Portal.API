using FAIS.ApplicationCore.Entities.Security;
using FAIS.ApplicationCore.Enumeration;
using FAIS.ApplicationCore.Helpers;
using FAIS.ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FAIS.ApplicationCore.AuditTrail
{
    public class AuditEntry
    {
        private readonly IUserRepository _userRepository;

        public EntityEntry Entry { get; set; }
        public string ModuleName { get; set; }
        public Dictionary<string, object> OldValues { get; } = new Dictionary<string, object>();
        public Dictionary<string, object> NewValues { get; } = new Dictionary<string, object>();
        public string State { get; set; }
        public int? UserId { get; set; }

        public AuditEntry(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public AuditEntry(EntityEntry entry, int? userId)
        {
            if (entry.State.ToString() != "Modified")
                return;

            string tableName = entry.Metadata.GetTableName().Remove(entry.Metadata.GetTableName().Length - 1);

            Entry = entry;
            ModuleName = entry.Metadata.GetTableName();
            State = string.Format("Updated {0} data", tableName.ToLower());
            UserId = userId.GetValueOrDefault();

            foreach(PropertyEntry property in entry.Properties)
            {
                if(property.IsAuditable())
                {
                    string propertyName = property.Metadata.Name;
                    switch(entry.State)
                    {
                        case EntityState.Added:
                            NewValues[propertyName] = property.CurrentValue;
                            break;
                        case EntityState.Deleted:
                            OldValues[propertyName] = property.OriginalValue;
                            break;
                        case EntityState.Modified:
                            if (property.IsModified)
                            {
                                OldValues[propertyName] = property.OriginalValue;
                                NewValues[propertyName] = property.CurrentValue;
                            }
                            break;
                    }
                }
            }
        }

        public AuditLog ToAuditLog()
        {
            var module = Enum.GetValues(typeof(ModuleEnum)).Cast<ModuleEnum>().FirstOrDefault(v => EnumHelper.StringValueOf(v) == ModuleName);

            AuditLog audit = new AuditLog
            {
                OldValues = OldValues.Count == 0 ? null : JsonConvert.SerializeObject(OldValues),
                NewValues = NewValues.Count == 0 ? null : JsonConvert.SerializeObject(NewValues),
                IpAddress = GeoLocationHelpers.GetClientIpAddress(),
                ModuleSeq = (int)module,
                Activity = State,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = UserId == 0 ? 1 : UserId.Value
            };

            return audit;
        }
    }
}
