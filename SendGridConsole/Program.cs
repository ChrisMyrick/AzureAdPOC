using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SendGridConsole
{
    class Program
    {
        private static string apiKey = "xxxx";

        static async Task<Response> Execute()
        {
 
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("eric.li.100@gmail.com", "Eric Li"),
                Subject = "Sending with SendGrid is Fun",
                PlainTextContent = "and easy to do anywhere, even with C#",
                HtmlContent = "<strong>and easy to do anywhere, even with C#</strong>"
            };
            msg.AddTo(new EmailAddress("eric@eric-li.com", "Eric Li"));
            var response = await client.SendEmailAsync(msg);
            return response;
        }

        static void Main(string[] args)
        {
            var response = Execute().GetAwaiter().GetResult();
        }
    }
}
