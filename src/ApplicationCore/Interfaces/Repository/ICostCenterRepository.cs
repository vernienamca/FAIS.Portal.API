﻿using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Models;
using System.Collections.Generic;

namespace FAIS.ApplicationCore.Interfaces
{
    public interface ICostCenterRepository
    {
        IReadOnlyCollection<CostCenterModel> Get();
    }
}
