using System.Net;
using PillDrop.Domain.Contracts;
using PillDrop.Domain.Contracts.Services;
using PillDrop.Domain.Entities;
using SendGrid;

namespace PillDrop.Implementation.Implementation.Services
{
    public class EmailNotificationService: IEmailNotificationService
    {
        private readonly IApplicationConfiguration _applicationConfiguration;

        public EmailNotificationService(IApplicationConfiguration applicationConfiguration)
        {
            _applicationConfiguration = applicationConfiguration;
        }
        public EmailCallResponse Send(SendGridMessage mailMessage)
        {
            var username = _applicationConfiguration.GetSetting("sendgrid_username");
            var password = _applicationConfiguration.GetSetting("sendgrid_key");
            var credentials = new NetworkCredential(username, password);
            var transporter = new Web(credentials);

            transporter.Deliver(mailMessage);
            return new EmailCallResponse { CallResult = "Sent." };
        }
    }
}