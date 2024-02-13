using FAIS.ApplicationCore.Entities.Security;
using FAIS.ApplicationCore.Enumeration;
using FAIS.ApplicationCore.Helpers;
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
        public EntityEntry Entry { get; set; }
        public string ModuleName { get; set; }
        public Dictionary<string, object> OldValues { get; } = new Dictionary<string, object>();
        public Dictionary<string, object> NewValues { get; } = new Dictionary<string, object>();
        public string State { get; set; }
        public int? UserId { get; set; }
        
        public AuditEntry(EntityEntry entry, int? userId)
        {
            Entry = entry;
            ModuleName = entry.Metadata.GetTableName();
            State = entry.State.ToString();
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
                            if(property.IsModified)
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
            var module = Enum.GetValues(typeof(ModuleEnum)).Cast<ModuleEnum>()
                                .FirstOrDefault(v => EnumHelper.StringValueOf(v) == ModuleName);

            AuditLog audit = new AuditLog();
            audit.OldValues = OldValues.Count == 0 ? null : JsonConvert.SerializeObject(OldValues);
            audit.NewValues = NewValues.Count == 0 ? null : JsonConvert.SerializeObject(NewValues);
            audit.IpAddress = GeoLocationHelpers.GetClientIpAddress();
            audit.ModuleSeq = (int)module;
            audit.Activity = State;
            audit.CreatedAt = DateTime.UtcNow;
            audit.CreatedBy = UserId == 0 ? 1 : UserId.Value;

            return audit;
        }
    }
}
