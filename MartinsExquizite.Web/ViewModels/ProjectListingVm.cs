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
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool isFeatured { get; set; }
        public string ProjectPictures { get; set; }
        public int ThumbnailPicture { get; set; }

        public List<ProjectPicture> ProjectPicturesList { get; set; }
        public List<Category> Categories { get; set; }
    }
}