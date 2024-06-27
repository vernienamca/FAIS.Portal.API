using System;
using System.Collections.Generic;
using System.Text;

namespace FAIS.ApplicationCore.Models
{
    public class EmailModel
    {
        public IReadOnlyCollection<string> ToRecipient { get; set; }
        public IReadOnlyCollection<string> CcRecipient { get; set; } = new List<string>();
    }
}
