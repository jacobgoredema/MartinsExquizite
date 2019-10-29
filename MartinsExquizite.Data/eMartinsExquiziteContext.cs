using MartinsExquizite.Entities.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartinsExquizite.Data
{
    public class eMartinsExquiziteContext:IdentityDbContext<eMartinsExquiziteUser>
    {
        public eMartinsExquiziteContext(): base("name=eMartinsExquiziteConnectionString")
        {

        }

        public DbSet<Category>  Categories { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<ProjectPicture> ProjectPictures { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Configuration> Configurations { get; set; }

        public static eMartinsExquiziteContext Create()
        {
            return new eMartinsExquiziteContext();
        }
    }
}
