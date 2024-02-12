using DocumentFormat.OpenXml;
using FAIS.ApplicationCore.Entities.Security;
using FAIS.ApplicationCore.Enumeration;
using FAIS.ApplicationCore.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.OpenApi.Extensions;
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
        public string LoggedUser { get; set; }
        public List<PropertyEntry> TemporaryProperties { get; } = new List<PropertyEntry>();
        public bool HasTemporaryProperties => TemporaryProperties.Any();

        public AuditEntry(EntityEntry entry)
        {
            Entry = entry;
            ModuleName = entry.Metadata.GetTableName();
            State = entry.State.ToString();
            LoggedUser = "Admin"; //todo: retrieve user

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

        public void Update()
        {
            foreach(var prop in TemporaryProperties)
            {
                NewValues[prop.Metadata.Name] = prop.CurrentValue;
            }
        }

        public AuditLog ToAuditLog()
        {
            var module = Enum.GetValues(typeof(ModuleEnum)).Cast<ModuleEnum>()
                                .FirstOrDefault(v => EnumHelper.StringValueOf(v) == ModuleName);
            AuditLog audit = new AuditLog();
            audit.OldValues = OldValues.Count == 0 ? null : JsonConvert.SerializeObject(OldValues);
            audit.NewValues = NewValues.Count == 0 ? null : JsonConvert.SerializeObject(NewValues);
            audit.IpAddress = "192.16.8.1.108";
            audit.ModuleSeq = (int)module;
            audit.Activity = State;
            audit.CreatedAt = DateTime.UtcNow;
            audit.CreatedBy = 1;

            return audit;
        }

      
    }
}
