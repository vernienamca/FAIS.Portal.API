using System.ComponentModel.DataAnnotations;

namespace FAIS.ApplicationCore.DTOs
{
    public class ChangePasswordDTO
    {
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
