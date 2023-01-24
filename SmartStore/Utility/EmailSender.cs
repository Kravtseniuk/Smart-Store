using Mailjet.Client;
using Mailjet.Client.Resources;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace SmartStore.Utility
{
    public class EmailSender : IEmailSender
    {
        private readonly IConfiguration _configuration;

        private MailJetSettings _mailjetSettings { get; set; }

        public EmailSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            return Excute(email, subject, htmlMessage);
        }

        public async Task Excute(string email, string subject, string body)
        {
            _mailjetSettings = _configuration.GetSection("MailJet").Get<MailJetSettings>();

            MailjetClient client = new MailjetClient(_mailjetSettings.ApiKey, _mailjetSettings.SecretKey)
            {
                Version = ApiVersion.V3_1,
            };
            MailjetRequest request = new MailjetRequest
            {
                Resource = Send.Resource,
            }
             .Property(Send.Messages, new JArray {
                new JObject {
                {
                    "From",
                new JObject {
                    {"Email", "kravtseniuk@gmail.com"},
                    {"Name", "Ihor"}
                }
                }, {
                    "To",
                new JArray {
                    new JObject
                    {
                        {
                        "Email",
                        email
                        },
                        {
                        "Name",
                        "DotNetMastery"
                        }
                    }
                }
                    }, {
                    "Subject",
                    subject
                },
                {
                "HTMLPart",
                body
                },
                }
             });
            await client.PostAsync(request);
        }
    }
}
