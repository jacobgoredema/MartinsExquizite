using MartinsExquizite.Entities.Models;
using MartinsExquizite.Service;
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
        public ActionResult Index()
        {
            // TODO
            return View();
        }

        [HttpGet]
        public ActionResult Action(int? Id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Action(CategoryActionVm model)
        {
            if (model.Id>0)
            {
                var category = CategoriesService.Instance.GetCategoryById(model.Id);
                if (category == null)
                    return HttpNotFound();

                if (model.ParentCategoryID>0)
                {
                    category.ParentCategoryID = model.ParentCategoryID;
                }
                else
                {
                    category.ParentCategoryID = null;
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
                if (model.ParentCategoryID>0)
                {
                    category.ParentCategoryID = model.ParentCategoryID;
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