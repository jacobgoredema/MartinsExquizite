using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartinsExquizite.Entities
{
    public class ContactUsModel
    {
        [Required(ErrorMessage ="First name is required.")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        [Display(Name ="First Name:")]
        public string FirstName { get; set; }

        [Required(ErrorMessage ="Last name is required")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        [Display(Name ="Last Name:")]
        public string LastName { get; set; }

        [Display(Name = "Phone:")]
        [Required(ErrorMessage ="Phone is required")]
        public string Mobile { get; set; }

        [Display(Name = "Email:")]
        [Required(ErrorMessage ="Email is required")]
        [DataType(DataType.EmailAddress,ErrorMessage ="Invlid email address")]
        public string Email { get; set; }

        [Display(Name = "Message:")]
        [Required(ErrorMessage ="Comment is required")]
        [DataType(DataType.MultilineText)]
        public string Comment { get; set; }

        [Display(Name = "Department:")]
        public string Department { get; set; }

        public Dictionary<string,string> Departments { get; set; }

        public ContactUsModel()
        {
            Departments = new Dictionary<string, string>();
            Departments.Add("", "Select");
            Departments.Add("General Request", "General Request");
            Departments.Add("Request A Quote", "Request A Quote");
        }
    }
}
