using MartinsExquizite.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MartinsExquizite.Web.ViewModels
{



    public class CategoryActionVm:PageVm
    {
        public int ParentCategoryID { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsFeatured { get; set; }

        public List<Project> Projects { get; set; }
        public List<Category> Categories { get; set; }
    }
}