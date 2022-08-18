using DAL.Entities;
using System.Net;
using System.Net.Mail;

namespace PL.Helper
{
    public static class EmailSettings
    {

        public static void SendEmail(Email email)
        {

            var client = new SmtpClient("smtp.titan.email", 587);

           client.EnableSsl = true;

            client.Credentials = new NetworkCredential("yosof@joo.digital", "yosof2001@Joo");

            client.Send("yosof@joo.digital", email.To, email.Title, email.Body); 

        }
    }
}
  