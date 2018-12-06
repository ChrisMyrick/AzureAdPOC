using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SendGridPOC
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }


        private async Task<Response> Send()
        {
            Response response;
            var pandaPath = Environment.CurrentDirectory + @"\Assets\panda.jpg";
            
                var client = new SendGridClient(txtAPIKey.Text.Trim());
                var msg = new SendGridMessage()
                {
                    From = new EmailAddress("eric.li@provisionsgroup.com", "Eric Li"),
                    Subject = "SendGrid POC: Enjoy Panda",
                    PlainTextContent = "Test message in plain text format.",
                    HtmlContent = "Panda! <h3>Panda!</h3> <h1>Panda!<h1>"
                };

                using (var panda1 = new FileStream(pandaPath, FileMode.Open))
                {
                    await msg.AddAttachmentAsync("panda1.jpg", panda1, "image/jpeg", "attachment", "panda1");
                }

                //using (var panda2 = new FileStream(pandaPath, FileMode.Open))
                //{
                //    await msg.AddAttachmentAsync("panda2.jpg", panda2, "image/jpeg", "inline", "panda2");
                //}
           
                msg.AddTo(new EmailAddress(txtToAddress.Text.Trim(), "Eric Li"));
                response = await client.SendEmailAsync(msg);


            return response;
        }

        private void SetStatus(string status)
        {
            txtBoxStatus.Text += status + Environment.NewLine;
        }

        private async void btnSendMail_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtAPIKey.Text))
            {
                MessageBox.Show("Please enter an API key. \r\n You know where to find it.");
                return;

            }

            var stopWatch = new Stopwatch();
            stopWatch.Start();

            SetStatus("Sending...");

            var response = await Send();

            stopWatch.Stop();
            SetStatus($"Status: {response.StatusCode.ToString()}");
            SetStatus($"Done. Time taken in ms: {stopWatch.ElapsedMilliseconds}");
        }
    }
}
