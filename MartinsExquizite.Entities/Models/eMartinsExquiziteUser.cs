using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Security.Claims;

namespace MartinsExquizite.Entities.Models
{
    public class eMartinsExquiziteUser:IdentityUser
    {
        public string FullName { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<eMartinsExquiziteUser> manager)
        {
            // note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);

            // Add custom user claims here
            userIdentity.AddClaim(new Claim("Email", Email));
            userIdentity.AddClaim(new Claim("Picture", this.Picture != null ? this.Picture.URL : string.Empty));

            return userIdentity;
        }

        public int? PictureId { get; set; }
        public virtual Picture Picture { get; set; }
    }
}
