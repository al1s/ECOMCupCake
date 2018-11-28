using ECOMCupCake.Models;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ECOMCupCake.Services
{
    public class EmailSender : IEmailSender
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EmailSender"/> class.
        /// </summary>
        /// <param name="optionsAccessor">The options accessor.</param>
        public EmailSender(IOptions<AuthMessageSenderOptions> optionsAccessor)
        {
            Options = optionsAccessor.Value;
        }

        /// <summary>
        /// Gets the options.
        /// </summary>
        /// <value>
        /// The options.
        /// </value>
        public AuthMessageSenderOptions Options { get; }

        /// <summary>
        /// Sends the email asynchronous.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="subject">The subject.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public Task SendEmailAsync(string email, string subject, string message)
        {
            return Execute(Options.SendGridKey, subject, message, email);
        }

       
        /// <summary>
        /// Executes the specified API key.
        /// </summary>
        /// <param name="apiKey">The API key.</param>
        /// <param name="subject">The subject.</param>
        /// <param name="message">The message.</param>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        public Task Execute(string apiKey, string subject, string message, string email, string templateID = null)
        {
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("no-reply@ecomcupcake.azurewebsites.net", "ECOMCupcake"),
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = message
           
            };
            msg.AddTo(new EmailAddress(email));

            if (templateID != null)
            {
                msg.SetTemplateId(templateID);
            }
            // Disable click tracking.
            // See https://sendgrid.com/docs/User_Guide/Settings/tracking.html
            msg.SetClickTracking(false, false);

            return client.SendEmailAsync(msg);
        }
    }
}
