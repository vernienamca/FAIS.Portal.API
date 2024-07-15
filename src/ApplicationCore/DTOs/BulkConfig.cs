using System;
using System.Collections.Generic;
using System.Text;

namespace FAIS.ApplicationCore.DTOs
{
    public class BulkConfig
    {
        public int BatchSize { get; set; }
        public int? BulkCopyTimeout { get; set; }
    }
}
