using System.Collections.Generic;
using System.Net.Mail;
using SendGrid;

namespace PillDrop.Implementation.Implementation.Helpers
{
    public class EmailMessage
    {
        public static SendGridMessage CreateInstance(MailAddress fromEmail, string toEmail, string subject, string body)
        {
            var message = new SendGridMessage { From = fromEmail };
            message.AddTo(toEmail);
            message.Subject = subject;
            message.Html = body;
            return message;
        }

        public static SendGridMessage CreateInstance(MailAddress fromEmail, string toEmail, IList<string> ccEmail, string subject, string body, bool isHtml)
        {
            var message = new SendGridMessage { From = fromEmail };
            message.AddTo(toEmail);
            message.AddTo(ccEmail);
            message.Subject = subject;
            message.Html = body;
            return message;
        }
    }
}