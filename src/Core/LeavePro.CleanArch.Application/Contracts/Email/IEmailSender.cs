using LeavePro.CleanArch.Application.Models.Email;

namespace LeavePro.CleanArch.Application.Contracts.Email;

public interface IEmailSender
{
    Task<bool> SendEmail(EmailMessage email);
}
