using Microsoft.Azure.KeyVault;
using Microsoft.Azure.KeyVault.Models;
using Microsoft.Identity.Client;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
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
            string authority = $"https://login.microsoftonline.com/{Tenant}";
            _clientApp = new PublicClientApplication(ClientId, authority, TokenCacheHelper.GetUserCache());
        }

        private static string ClientId = ConfigurationManager.AppSettings["ClientId"];
        private static string Tenant = ConfigurationManager.AppSettings["TenantId"];
        public static string SecretIdentifier = ConfigurationManager.AppSettings["KeyVaultSecretIdentifier"];

        private static PublicClientApplication _clientApp;

        // PublicClientApp should be a singleton.
        public static PublicClientApplication PublicClientApp { get { return _clientApp; } }


        private async Task<Response> Send()
        {
            Response response;
            var pandaPath = Environment.CurrentDirectory + @"\Assets\panda.jpg";

            var client = new SendGridClient(txtAPIKey.Text.Trim());
            var msg = new SendGridMessage()
            {
                From = new EmailAddress(ConfigurationManager.AppSettings["FromAddress"], ConfigurationManager.AppSettings["FromName"]),
                Subject = "SendGrid POC: Enjoy Panda",
                PlainTextContent = "Test message in plain text format.",
                HtmlContent = "Panda! <h3>Panda!</h3> <h1>Panda!<h1>"
            };

            using (var panda1 = new FileStream(pandaPath, FileMode.Open))
            {
                await msg.AddAttachmentAsync("panda1.jpg", panda1, "image/jpeg", "attachment", "panda1");
            }


            msg.AddTo(new EmailAddress(txtToAddress.Text.Trim(), "Test Account"));
            response = await client.SendEmailAsync(msg);


            return response;
        }

        private void SetStatus(string status)
        {
            txtBoxStatus.Text = status + Environment.NewLine + txtBoxStatus.Text;
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

        private async void btnSignIn_Click(object sender, EventArgs e)
        {
            SecretBundle sec = null;
            var kv = new KeyVaultClient(new KeyVaultClient.AuthenticationCallback(GetToken));

            sec = await kv.GetSecretAsync("https://svmic.vault.azure.net/secrets/SendGrid-API-Key/4b2359314a5042b3a5e3bc86fc111db5");

            this.Invoke(new System.Action(() =>
                {
                    btnSignOut.Visible = true;
                    txtBoxStatus.Text = "API Key: " + sec.Value + Environment.NewLine + txtBoxStatus.Text;
                    txtAPIKey.Text = sec.Value;
                }
            ));

        }

        private async Task<string> GetToken(string authority, string resource, string scope)
        {
            string[] keyVaultScopes = new string[] { $"{resource}/.default" };
            AuthenticationResult authResult = null;

            var app = Main.PublicClientApp;
            var accounts = await app.GetAccountsAsync();

            try
            {
                authResult = await app.AcquireTokenSilentAsync(keyVaultScopes, accounts.FirstOrDefault());
                this.Invoke(new System.Action(() =>
                    {
                        txtBoxStatus.Text = "AccessToken: " + Environment.NewLine + authResult.AccessToken;
                    }
                ));
            }
            catch (MsalUiRequiredException ex)
            {
                // A MsalUiRequiredException happened on AcquireTokenSilentAsync. 
                // This indicates you need to call AcquireTokenAsync to acquire a token
                //System.Diagnostics.Debug.WriteLine($"MsalUiRequiredException: {ex.Message}");

                try
                {
                    authResult = await app.AcquireTokenAsync(keyVaultScopes);
                    this.Invoke(new System.Action(() =>
                        {
                            txtBoxStatus.Text = "AccessToken: " + Environment.NewLine + authResult.AccessToken;
                        }
                    ));

                }
                catch (MsalException msalex)
                {
                    
                    this.Invoke(new System.Action(() =>
                    {
                        txtBoxStatus.Text = $"Error Acquiring Token:{System.Environment.NewLine}{msalex}";
                    }
                    ));
                }
            }


            return authResult.AccessToken;

        }

        private async void btnSignOut_Click(object sender, EventArgs e)
        {
            var accounts = await Main.PublicClientApp.GetAccountsAsync();
            if (accounts.Any())
            {
                try
                {
                    await Main.PublicClientApp.RemoveAsync(accounts.FirstOrDefault());
                    this.txtBoxStatus.Text = "User Signed Out" + Environment.NewLine + txtBoxStatus.Text;

                    this.btnSignOut.Visible = false;
                }
                catch (MsalException ex)
                {
                    this.txtBoxStatus.Text = $"Error signing-out user: {ex.Message}" + Environment.NewLine + txtBoxStatus.Text;
                }
            }
        }
    }
}
