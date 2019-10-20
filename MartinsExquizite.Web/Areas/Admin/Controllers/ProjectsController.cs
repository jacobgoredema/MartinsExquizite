using MartinsExquizite.Service;
using MartinsExquizite.Web.Framework.Helpers;
using MartinsExquizite.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MartinsExquizite.Entities;
using MartinsExquizite.Shared;

namespace MartinsExquizite.Web.Areas.Admin.Controllers
{
    public class ProjectsController : Controller
    {
        // GET: Admin/Projects
        public ActionResult Index(int? categoryId,string searchTerm, int?pageNo)
        {
            var pageSize = ConfigurationsHelper.DashboardRecordingSizePerPage;
            ProjectListingVm model = new ProjectListingVm();
            model.PageTitle = "Projects";
            model.PageDescription = "Project Listing Page";
            model.SearchTerm = searchTerm;
            model.Categories = CategoriesService.Instance.GetAllCategories();

            List<int> selectedCategoryIds = null;

            if (categoryId.HasValue&& categoryId.Value>0)
            {
                var selectedCategory = CategoriesService.Instance.GetCategoryById(categoryId.Value);

                if (selectedCategory == null) return HttpNotFound();
                else
                {
                    model.CategoryId = selectedCategory.Id;

                    var searchCategories = Methods.GetAllCategoryChildrens(selectedCategory, model.Categories);
                    selectedCategoryIds = searchCategories != null ? searchCategories.Select(x => x.Id).ToList() : null;
                }

                model.Projects = ProjectsService.Instance.SearchProjects(selectedCategoryIds, searchTerm, pageNo, pageSize);
                var totalProjects = ProjectsService.Instance.GetProjectCount(selectedCategoryIds, searchTerm);

                model.Pager = new Pager(totalProjects, pageNo, pageSize);

                return View(model);
            }

            return View();
        }
    }
}