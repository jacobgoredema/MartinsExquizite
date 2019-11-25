using MartinsExquizite.Entities.Models;
using MartinsExquizite.Service;
using MartinsExquizite.Web.Framework.Extensions;
using MartinsExquizite.Web.Framework.Helpers;
using MartinsExquizite.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MartinsExquizite.Web.Areas.Admin.Controllers
{
    public class CategoriesController : Controller
    {
        // GET: Admin/Categories
        public ActionResult Index(int? parentCategoryId, string searchTerm, int? pageNo)
        {
            var pageSize = ConfigurationsHelper.DashboardRecordsSizePerPage;
            CategoriesListingVm model = new CategoriesListingVm();

            model.PageTitle = "Categories";
            model.PageDescription = "Categories Listing Page";
            model.ParentCategoryId = parentCategoryId;
            model.SearchTerm = searchTerm;
            model.ParentCategory = CategoriesService.Instance.GetAllParentCategories();
            model.Categories = CategoriesService.Instance.SearchCategories(parentCategoryId, searchTerm, pageNo, pageSize);

            var totalCategories = CategoriesService.Instance.GetCategoriesCount(parentCategoryId, searchTerm);

            //model.Pager = new Pager(totalCategories, pageNo, pageSize);
            return View(model);
        }

        [HttpGet]
        public ActionResult Action(int? Id)
        {
            CategoryActionVm model = new CategoryActionVm();
            if (Id.HasValue)
            {
                var category = CategoriesService.Instance.GetCategoryById(Id.Value);

                if (category == null)
                    return HttpNotFound();

                model.PageTitle = "Edit Category";
                model.PageDescription = string.Format("Edit Category {0}.", category.Name);
                model.ParentCategoryID = category.ParentCategoryId.HasValue ? category.ParentCategoryId.Value : 0;
                model.Id = category.Id;
                model.Name = category.Name;
                model.Description = category.Description;
                model.IsFeatured = category.isFeatured;
            }
            else
            {
                model.PageTitle = "Create Category";
                model.PageDescription = "Create New Category";
            }

            model.Categories = CategoriesService.Instance.GetAllCategories();

            return View(model);
        }

        [HttpPost]
        public ActionResult Action(CategoryActionVm model)
        {
            if (model.Id > 0)
            {
                var category = CategoriesService.Instance.GetCategoryById(model.Id);
                if (category == null)
                    return HttpNotFound();

                if (model.ParentCategoryID > 0)
                {
                    category.ParentCategoryId = model.ParentCategoryID;
                }
                else
                {
                    category.ParentCategoryId = null;
                    category.ParentCategory = null;
                }

                category.Name = model.Name;
                category.SanitizedName = model.Name.SanitizeLowerString();
                category.Description = model.Description;
                category.isFeatured = model.IsFeatured;
                category.DisplaySeqNo = 1;

                CategoriesService.Instance.UpdateCategory(category);
            }
            else
            {
                Category category = new Category();
                if (model.ParentCategoryID > 0)
                {
                    category.ParentCategoryId = model.ParentCategoryID;
                }

                category.Name = model.Name;
                category.SanitizedName = model.Name.SanitizeLowerString();
                category.Description = model.Description;
                category.isFeatured = model.IsFeatured;
                category.DisplaySeqNo = 1;

                CategoriesService.Instance.SaveCategory(category);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult Delete(int Id)
        {
            JsonResult result = new JsonResult();
            try
            {
                var operation = CategoriesService.Instance.DeleteCategory(Id);
                result.Data = new
                {
                    Success = operation,
                    Message = operation ? string.Empty : "Cannot delete category."
                };
            }
            catch (Exception ex)
            {
                result.Data = new
                {
                    Success = false,
                    Message = string.Format("{0", ex.Message)
                };
            }

            return result;
        }
    }
}