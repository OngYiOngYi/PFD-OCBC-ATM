using Microsoft.AspNetCore.Mvc;

using System.Configuration;

using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

using Twilio.TwiML;
using Twilio.AspNet.Mvc;
using Twilio.Rest.Microvisor.V1;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Twilio.Exceptions;


namespace WebApplication1.Controllers
{
    public class SmsController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly IConfiguration _configuration;

        public SmsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public ActionResult SendSms()
        {
            var accountSid = _configuration["Twilio:AccountSid"];
            var authToken = _configuration["Twilio:AuthToken"];
            TwilioClient.Init(accountSid, authToken);

            var to = new PhoneNumber(_configuration["Twilio:MyPhoneNumber"]);
            var from = new PhoneNumber("+");

            var currentDate = DateTime.Now.ToString("yyyy-MM-dd");
            var messageBody = $"You have withdrawn money from OCBC on {currentDate}. If this is not you, please contact OCBC.";

            var message = MessageResource.Create(
                to: to,
                from: from,
                body: messageBody);

            return RedirectToAction("Feedback" ,"Home");
        }
    }
}