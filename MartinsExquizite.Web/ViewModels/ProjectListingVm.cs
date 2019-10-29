using MartinsExquizite.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MartinsExquizite.Web.ViewModels
{
    public class ProjectListingVm:PageVm
    {
        public List<Project> Projects { get; set; }
        public List<Category> Categories { get; internal set; }

        public int? CategoryId { get; set; }
        public string SearchTerm { get; internal set; }

        public Pager Pager { get; set; }
    }

    public class ProjectActionVm:PageVm
    {



        public List<ProjectPicture> ProjectPicturesList { get; set; }
        public List<Category> Categories { get; set; }
    }
}