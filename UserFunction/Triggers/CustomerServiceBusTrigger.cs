using System;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using SendGrid;
using SendGrid.Helpers.Mail;
using SharedProject.Models.EventMsg;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using UserFunction.Options;

namespace UserFunction.Triggers
{
    public class CustomerServiceBusTrigger
    {
        private readonly ILogger<CustomerServiceBusTrigger> _logger;

        private SendGridClient _sendgridClient;

        public CustomerServiceBusTrigger(

            ILogger<CustomerServiceBusTrigger> log,
            IOptionsSnapshot<SendgridOption> sendgridOption,
            IOptionsSnapshot<TwilioOption> twilioOption
            )
        {
            _logger = log;
            _sendgridClient = sendgridOption.Value != null ? new SendGridClient(sendgridOption.Value.ApiKey) : null;

            if (twilioOption != null)
            {
                TwilioClient.Init(twilioOption.Value.AccountId, twilioOption.Value.ApiKey);
            }

        }

        [FunctionName("SendEmailTrigger")]
        public async Task SendEmail([ServiceBusTrigger("Customer", "SendEmail", Connection = "ConnectionStrings:ServiceBus")] string payload)
        {
            _logger.LogInformation($"C# ServiceBus topic trigger function processed message: {payload}");

            var data = JsonConvert.DeserializeObject<SendCreateCustomerMsg>(payload);

            var from_email = new EmailAddress("leejgdh@hotmail.com", "leejgdh");
            var subject = "회원가입 되었습니다.";

            var to_email = new EmailAddress(data.Email, data.Name);

            var plainTextContent = "압도적 감사";
            var htmlContent = "<strong>압도적 감사</strong>";

            var msg = MailHelper.CreateSingleEmail(from_email, to_email, subject, plainTextContent, htmlContent);


            //var response = await _sendgridClient.SendEmailAsync(msg);
        }

        [FunctionName("SendSMSTrigger")]
        public async Task SendSMS([ServiceBusTrigger("Customer", "SendSMS", Connection = "ConnectionStrings:ServiceBus")] string payload)
        {
            _logger.LogInformation($"C# ServiceBus topic trigger function processed message: {payload}");

            var data = JsonConvert.DeserializeObject<SendCreateCustomerMsg>(payload);

            if (!string.IsNullOrWhiteSpace(data.Tel))
            {
                try
                {

                    //var message = await MessageResource.CreateAsync(
                    //    body: "CRM 회원가입 축하함당 전번은 근데 고정임",
                    //    from: new Twilio.Types.PhoneNumber("+15092859280"), // fix from number
                    //    to: new Twilio.Types.PhoneNumber($"+82{data.Tel}")
                    //);

                    //var sid = message.Sid;
                }
                catch (Exception ex)
                {


                }
            }


        }
    }
}
