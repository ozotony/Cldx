using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Script.Serialization;

namespace cld.Handlers
{
    /// <summary>
    /// Summary description for AddEmail2
    /// </summary>
    public class AddEmail2 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            var pp = context.Request["vid"];

            var pp2 = context.Request["vid2"];
            var pp4 = context.Request["vid3"];
            var pp5 = context.Request["vid4"];
          //  pp5 = "ozotony@yahoo.com";

            this.SendEmailAsync(pp5, pp4, pp);
            context.Response.ContentType = "text/plain";
            context.Response.Write("Hello World");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
     
        public void   SendEmailAsync(string email, string subject, string message)
        {
            MailMessage mMessage = new MailMessage();

            mMessage.To.Add(email);
            mMessage.Subject = subject;
            mMessage.From = new MailAddress($"IPO Nigeria <{"einaosolution2016@gmail.com"}>");
            mMessage.Body = message;
            mMessage.Priority = MailPriority.High;
            mMessage.IsBodyHtml = true;

            using (SmtpClient smtpMail = new SmtpClient())
            {
                smtpMail.Host = "smtp.gmail.com";
                smtpMail.Port = Convert.ToInt32("587");
                smtpMail.EnableSsl = true;
                smtpMail.Credentials = new NetworkCredential("einaosolution2016@gmail.com", "Einao2015");
                smtpMail.Send(mMessage);

               

            }


        }
    }
}