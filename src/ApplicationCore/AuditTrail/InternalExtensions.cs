using FAIS.ApplicationCore.Entities.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Reflection;

namespace FAIS.ApplicationCore.AuditTrail
{
    public static class InternalExtensions
    {
        public static bool ShouldBeAudited(this EntityEntry entry)
        {
            return entry.State != EntityState.Detached && entry.State != EntityState.Unchanged &&
                !(entry.Entity is AuditLog) && entry.IsAuditable();
        }

        internal static bool IsAuditable(this EntityEntry entry) 
        {
            AuditableAttribute enableAuditAttribute = (AuditableAttribute)Attribute.GetCustomAttribute(entry.Entity.GetType(), typeof(AuditableAttribute));
            return enableAuditAttribute != null;
        }

        internal static bool IsAuditable(this PropertyEntry propertyEntry)
        {
            Type entityType = propertyEntry.EntityEntry.Entity.GetType();
            PropertyInfo propertyInfo = entityType.GetProperty(propertyEntry.Metadata.Name);
            bool disableAuditAttribute = Attribute.IsDefined(propertyInfo, typeof(AuditableAttribute));

            return IsAuditable(propertyEntry.EntityEntry) && !disableAuditAttribute;
        }
    }
}
