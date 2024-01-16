using FAIS.ApplicationCore.DTOs;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Interfaces
{
    public interface IEmailService
    {
        bool SendEmail(string emailAddress, string subject, string content);
    }
}
