using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Resources;
using System.Reflection;

namespace UNO_Server.Utilities
{
    public class EmailVerification
    {
        private ResourceManager emailResourceManager = new ResourceManager("Email.es-MX", Assembly.GetExecutingAssembly());
        
        private MailMessage CreateMessage(string playerEmail, string token)
        {
            MailMessage result = null;

            MailMessage email = new MailMessage();
            email.To.Add(playerEmail);
            email.From = new MailAddress("unogame.lis@gmail.com");
            /*
            email.Subject = emailResourceManager.GetString("Subject");
            email.Body = emailResourceManager.GetString("Body") + token;
            */
            email.Subject = "Codigo de verificacion";
            email.Body = "Codigo: " + token;
            email.IsBodyHtml = true;
            email.Priority = MailPriority.Normal;

            result = email;

            return result;
        }

        public bool SendEmail(string playerEmail, string token)
        {
            bool result = false;
            SmtpClient smtp = new Smtp().createClient();
            MailMessage email = CreateMessage(playerEmail, token);

            try
            {
                smtp.Send(email);
                result = true;
            }catch(Exception e)
            {
                throw e;
            }
            finally
            {
                email.Dispose();
            }

            return result;
        }
    }
}
