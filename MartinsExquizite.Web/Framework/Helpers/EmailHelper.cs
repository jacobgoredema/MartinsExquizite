using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MartinsExquizite.Entities;
using System.IO;
using System.Net.Mail;
using System.Net;

namespace MartinsExquizite.Web.Framework.Helpers
{
    public class EmailHelper
    {
        public static string GetVirtualRoot()
        {
            string root = HttpContext.Current.Request.Url.Scheme + "//" +
                HttpContext.Current.Request.Url.Authority +
                HttpContext.Current.Request.ApplicationPath;

            if(root.EndsWith("/"))
            {
                return root.Substring(0, root.Length - 1);
            }
            else
            {
                return root;
            }
        }

        public static string GetTemplate(string name)
        {
            StreamReader reader = File.OpenText(HttpContext.Current.Server.MapPath("~/htmlTemplates/" + name + ".html"));

            string text = reader.ReadToEnd();
            reader.Close();

            return text;
        }

        public static string SubstituteContactEmail(string template, ContactUsModel model)
        {
            string body = template;

            body=StringHelper.RepaceIgnoringCase(body,"#FIRSTNAME",model.FirstName);
            body=StringHelper.RepaceIgnoringCase(body,"#LASTNAME",model.LastName);
            body=StringHelper.RepaceIgnoringCase(body,"#MOBILE",model.Mobile);
            body=StringHelper.RepaceIgnoringCase(body,"#EMAIL",model.Email);
            body=StringHelper.RepaceIgnoringCase(body,"#COMMENTS",model.Comment);
            body=StringHelper.RepaceIgnoringCase(body,"#DEPARTMENTS",model.Department);

            return body;
        }

        public static bool SendMail(string subject, string to, string body)
        {           
            try
            {
                MailMessage mm = new MailMessage();
                if (Config.EmailTestingOn)
                    to = Config.TestEmailAddress;

                mm.From = new MailAddress(Config.FromAddress, Config.FromName);
                mm.To.Add(to);
                mm.Subject = subject;
                mm.Body = body;
                mm.IsBodyHtml = true;

                SmtpClient client = new SmtpClient();

                if(Config.PickupDirectoryFromIis==false)
                {
                    client.Host = Config.EmailHost;
                    client.UseDefaultCredentials = false;
                    client.EnableSsl = Config.SendEmailWithSsl;
                    client.Timeout = 20000;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.Credentials = new NetworkCredential(Config.EmailUserName, Config.EmailPassword);
                }
                else
                {
                    client.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
                    client.PickupDirectoryLocation = @"C:inetpub\mailroot\Pickup";
                    client.EnableSsl = Config.SendEmailWithSsl;
                }

                client.Send(mm);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}