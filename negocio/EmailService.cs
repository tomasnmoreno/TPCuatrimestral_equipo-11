using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class EmailService
    {
        private MailMessage Mail;
        private SmtpClient Server;

        public EmailService()
        {
            Server = new SmtpClient();
            Server.Credentials = new NetworkCredential("clinicasanbenito60@gmail.com", "cloz ohbl taaq wlxu");
            Server.EnableSsl = true;
            ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors) { return true; };
            Server.Port = 25;
            Server.Host = "smtp.gmail.com";
        }

        public void ArmarCorreo(string EmailDestino, string Contraseña)
        {
            Mail = new MailMessage();
            Mail.From = new MailAddress("clinicasanbenito60@gmail.com");
            Mail.To.Add(EmailDestino);
            Mail.Subject = "Olvide mi contraseña.";
            Mail.IsBodyHtml = true;
            Mail.Priority = MailPriority.High;
            Mail.Body = "<h1> Usted ha solicitado su contraseña. </h1 <br> Su contraseña es " + Contraseña + "</br>";


        }

        public void EnviarMail()
        {
            try
            {
                Server.Send(Mail);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
