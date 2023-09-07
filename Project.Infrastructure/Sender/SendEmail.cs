using System.Net.Mail;
namespace Project.Infrastructure.Sender
{
    public class SendEmail
    {
        public static bool UseDefaultCredentials { get; private set; }

        public static void Send(string To, string Subject, string Body)
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            mail.From = new MailAddress("pars@gmail.com", "درخواست جدید ");
            //mail.To.Add(To);
            mail.Subject = Subject;
            mail.Body = Body;
            mail.IsBodyHtml = true;

            //SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("pars@gmail.com", "1234");
            SmtpServer.EnableSsl = true;
            //SmtpServer.Send(mail);

        }
    }
}
