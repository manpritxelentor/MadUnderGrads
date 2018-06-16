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
        private readonly ILog _logger;
        public EmailUtility()
        {
            _logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        }

        public bool SendMail(string email, string subject, string body)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient client = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress(ConfigurationManager.AppSettings["EmailFrom"]);
                mail.To.Add(email);
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = true;
                client.Port = Convert.ToInt32(ConfigurationManager.AppSettings["SmtpPort"]);
                client.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["EmailUser"], ConfigurationManager.AppSettings["EmailPassword"]);
                client.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["SmtpEnableSsl"]);
                client.Send(mail);
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error("Email Error", ex);
                return false;
            }
        }
    }
}