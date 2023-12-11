using FAIS.ApplicationCore.DTOs;

namespace FAIS.ApplicationCore.Interfaces
{
    public interface IEmailService
    {
        void SendEmail(EmailDTO request);
    }
}
