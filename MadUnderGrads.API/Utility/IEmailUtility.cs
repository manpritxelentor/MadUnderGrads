using log4net;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace MadUnderGrads.API.Utility
{
    public interface IEmailUtility
    {
        bool SendMail(string email, string subject, string body);
    }

    public class EmailUtility : IEmailUtility
    {
        private readonly IConfigurationUtility configurationUtility;
        public EmailUtility(IConfigurationUtility configurationUtility)
        {
            this.configurationUtility = configurationUtility;
        }

        public bool SendMail(string email, string subject, string body)
        {
            MailMessage mail = new MailMessage();
            SmtpClient client = new SmtpClient(ConfigurationManager.AppSettings["SmtpHost"]);

            mail.From = new MailAddress(ConfigurationManager.AppSettings["EmailFrom"]);
            if (configurationUtility.IsDevelopmentMode)
                mail.To.Add("hardik0207@gmail.com");
            else
                mail.To.Add(email);
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;
            client.Port = Convert.ToInt32(ConfigurationManager.AppSettings["SmtpPort"]);
            client.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["EmailUser"], ConfigurationManager.AppSettings["EmailPassword"]);

            if (client.Host.Contains("gmail"))
                client.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["SmtpEnableSsl"]);

            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Send(mail);
            return true;
        }
    }
}