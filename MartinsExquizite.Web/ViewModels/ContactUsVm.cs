using MartinsExquizite.Entities;
using MartinsExquizite.Web.Framework;
using MartinsExquizite.Web.Framework.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MartinsExquizite.Web.ViewModels
{
    public class ContactUsVm
    {
        public ContactUsModel Item { get; set; }
        public string Message { get; set; }
        List<string> cc = new List<string>();

        public ContactUsVm()
        {
            Item = new ContactUsModel();
        }

        public void SendMail()
        {
            cc.Add(Item.Email);
            string body = EmailHelper.GetTemplate("Contact");
            body = EmailHelper.SubstituteContactEmail(body, Item);

            try
            {
                if (Item.Department.ToString()=="General Request")
                {
                    EmailHelper.SendMail("Contact Us Form", body, Config.ContactFormRecipientGeneral);
                }
                else if(Item.Department.ToString()== "Request A Quote")
                {
                    EmailHelper.SendMail("Contact Us Form", body, Config.ContactFormRecipientGetQuote);
                }

                Message = "Information Sent";
            }
            catch (Exception ex)
            {
                Message = "There is a problem with sending a mail, please try again later.";
            }

        }
    }
}