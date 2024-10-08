﻿using System.ComponentModel;

namespace FAIS.ApplicationCore.Enumeration
{
    public enum RoleEnum
    {
        [Description("ARMD Librarian")]
        ARMDLibrarian = 12,
        [Description("PAD Librarian")]
        PADLibrarian =  8,
        [Description("Administrator")]
        Administrator = 1,
        [Description("Metering Librarian")]
        MeteringLibrarian = 13,
        [Description("ARMD Analyst")]
        ARMDAnalyst = 14
    }
}
