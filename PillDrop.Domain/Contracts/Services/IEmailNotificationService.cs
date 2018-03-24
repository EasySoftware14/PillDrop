using PillDrop.Domain.Entities;
using SendGrid;

namespace PillDrop.Domain.Contracts.Services
{
    public interface IEmailNotificationService
    {
        EmailCallResponse Send(SendGridMessage mailMessage);
    }
}