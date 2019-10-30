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
using MartinsExquizite.Entities.Models;

namespace MartinsExquizite.Web.Areas.Admin.Controllers
{
    public class ProjectsController : Controller
    {
        // GET: Admin/Projects
        public ActionResult Index(int? categoryId, string searchTerm, int? pageNo)
        {
            var pageSize = ConfigurationsHelper.DashboardRecordsSizePerPage;
            ProjectListingVm model = new ProjectListingVm();
            model.PageTitle = "Projects";
            model.PageDescription = "Project Listing Page";
            model.SearchTerm = searchTerm;
            model.Categories = CategoriesService.Instance.GetAllCategories();

            List<int> selectedCategoryIds = null;

            if (categoryId.HasValue && categoryId.Value > 0)
            {
                var selectedCategory = CategoriesService.Instance.GetCategoryById(categoryId.Value);

                if (selectedCategory == null) return HttpNotFound();
                else
                {
                    model.CategoryId = selectedCategory.Id;

                    var searchCategories = Methods.GetAllCategoryChildrens(selectedCategory, model.Categories);
                    selectedCategoryIds = searchCategories != null ? searchCategories.Select(x => x.Id).ToList() : null;
                }
            }

            model.Projects = ProjectsService.Instance.SearchProjects(selectedCategoryIds, searchTerm, pageNo, pageSize);
            var totalProjects = ProjectsService.Instance.GetProjectCount(selectedCategoryIds, searchTerm);

            model.Pager = new Pager(totalProjects, pageNo, pageSize);

            return View(model);
        }

        [HttpGet]
        public ActionResult Action(int? Id)
        {
            ProjectActionVm model = new ProjectActionVm();

            if (Id.HasValue)
            {
                var project = ProjectsService.Instance.GetProjectById(Id.Value);
                if (project == null)
                    return HttpNotFound();

                model.PageTitle = "Edit Project";
                model.PageDescription = string.Format("Edit Ptoject {0}.", project.Name);
                model.Id = project.Id;
                model.CategoryId = project.CategoryId;
                model.Name = project.Name;
                model.Summary = project.Summary;
                model.Description = project.Description;
                model.Price = project.Price;
                model.isFeatured = project.isFeatured;
                model.ProjectPicturesList = project.ProjectPictures;
                model.ThumbnailPicture = project.ThumbnailPictureId;
            }
            else
            {
                model.PageTitle = "Create Project";
                model.PageDescription = "Create new Project";
            }

            model.Categories = CategoriesService.Instance.GetAllCategories();

            return View(model);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Action(ProjectActionVm model)
        {
            if (model.Id>0)
            {
                var project = ProjectsService.Instance.GetProjectById(model.Id);
                if (project == null)
                    return HttpNotFound();

                project.Id = model.Id;
                project.Name = model.Name;
                project.CategoryId = model.CategoryId;
                project.Summary = model.Summary;
                project.Description = model.Description;
                project.Price = model.Price;
                project.isFeatured = model.isFeatured;
                project.ModifiedOn = DateTime.Now;

                if (!string.IsNullOrEmpty(model.ProjectPictures))
                {
                    var pictureIds = model.ProjectPictures
                        .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(ID => int.Parse(ID)).ToList();

                    if (pictureIds.Count>0)
                    {
                        project.ProjectPictures.Clear();
                        project.ProjectPictures.AddRange(pictureIds.Select(x => new ProjectPicture()
                        {
                            PictureId = project.Id,
                            ProjectId = x
                        }).ToList());

                        project.ThumbnailPictureId = model.ThumbnailPicture != 0 ? model.ThumbnailPicture : pictureIds.First();
                    }                    
                }

                ProjectsService.Instance.UpdateProject(project);                
            }

            else
            {
                Project project = new Project();
                project.Id = model.Id;
                project.Name = model.Name;
                project.CategoryId = model.CategoryId;
                project.Summary = model.Summary;
                project.Description = model.Summary;
                project.Price = model.Price;
                project.isFeatured = model.isFeatured;
                project.ModifiedOn = DateTime.Now;

                if (!string.IsNullOrEmpty(model.ProjectPictures))
                {
                    var pictureIds = model.ProjectPictures
                        .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(Id => int.Parse(Id)).ToList();

                    if (pictureIds.Count>0)
                    {
                        project.ProjectPictures = new List<ProjectPicture>();
                        project.ProjectPictures.AddRange(pictureIds.Select(x => new ProjectPicture()
                        {
                            ProjectId = project.Id,
                            PictureId = x
                        }).ToList());

                        project.ThumbnailPictureId = model.ThumbnailPicture != 0 ? model.ThumbnailPicture : pictureIds.First();
                    }
                }

                ProjectsService.Instance.SaveProject(project);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult Delete(int Id)
        {
            JsonResult result = new JsonResult();

            try
            {
                var operation = ProjectsService.Instance.DeleteProject(Id);

                result.Data = new
                {
                    Success = operation,
                    Message = operation ? string.Empty : "Can not delete product."
                };
            }
            catch (Exception ex)
            {
                result.Data = new
                {
                    Success = false,
                    Message = string.Format("{0}", ex.Message)
                };
            }

            return result;
        }
    }
}