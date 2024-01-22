using System;
using System.Collections.Generic;
using System.Text;

namespace FAIS.ApplicationCore.Models
{
    public class SettingModel
    {
        public int Id { get; set; }
        public string SMTPFromEmail { get; set; }

        public string SMTPPassword { get; set; }

        public string SMTPServerName { get; set; }

        public int? SMTPPort { get; set; }

        public char? SMTPEnableSSL { get; set; }

        public string SMTPDisplayName { get; set; }
    }
}
