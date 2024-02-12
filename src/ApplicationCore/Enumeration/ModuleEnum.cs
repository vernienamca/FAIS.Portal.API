using System.ComponentModel;

namespace FAIS.ApplicationCore.Enumeration
{
    public enum ModuleEnum
    {
        None = 0,
        [Description("ANALYTICS")]
        Analytics = 1,
        [Description("MODULES")]
        Modules = 2,
        [Description("ROLES")]
        Roles = 3,
        [Description("USERS")]
        Users = 4,
        [Description("SETTINGS")]
        SystemSettings = 5,
        [Description("TEMPLATES")]
        NotificationTemplates = 6,
        [Description("STRING_INTERPOLATIONS")]
        StringInterpolations = 7,
        [Description("AUDIT_LOGS")]
        AuditLogs = 8,
        [Description("LIBRARY_TYPES")]
        LibraryTypes = 9,
        [Description("LIBRARY_TYPES_OPTIONS")]
        LibraryTypeOptions = 10,
        [Description("CHART_OF_ACCOUNTS_H")]
        ChartOfAccounts = 11,
        [Description("PROFORMA_ENTRIES")]
        ProformaEntities = 12,
        [Description("COST_CENTER")]
        CostCenters = 13,
        [Description("ASSET_PROFILES")]
        AssetProfile = 14,
        [Description("METERING_PROFILES")]
        MeteringProfile = 15,
        [Description("TRANS_LINE_PROFILES")]
        TransmissionLineProfile = 16,
        [Description("PLANT_INFORMATION")]
        PlantInformation = 17
    }
}
