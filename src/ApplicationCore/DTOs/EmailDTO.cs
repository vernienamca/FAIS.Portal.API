using System;
using System.Collections.Generic;
using System.Text;

namespace FAIS.ApplicationCore.DTOs
{
    public class EmailDTO
    {
        //public string To { get; set; } = string.Empty;

        public IReadOnlyCollection<string> ToRecipient { get; set; }
        public IReadOnlyCollection<string> CcRecipient { get; set; }
        public int settings { get; set; }
    }
}
