using MartinsExquizite.Data;
using MartinsExquizite.Entities.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartinsExquizite.Service
{
    public class CategoriesService
    {
        eMartinsExquiziteContext context = new eMartinsExquiziteContext();

        private static CategoriesService _Instance;

        public static CategoriesService Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new CategoriesService();
                }

                return (_Instance);
            }
        }

        public CategoriesService()
        {

        }

        public bool DeleteCategory(int Id)
        {
            var category = context.Categories.Find(Id);
            context.Categories.Remove(category);

            return context.SaveChanges() > 0;
        }

        public List<Category> GetAllParentCategories()
        {
            return context.Categories.Where(x => !x.ParentCategoryId.HasValue).OrderBy(x => x.DisplaySeqNo).ToList();
        }

        public int GetCategoriesCount(int? parentCategoryId, string searchTerm)
        {
            var categories = context.Categories.AsQueryable();

            if (parentCategoryId.HasValue && parentCategoryId.Value > 0)
            {
                categories = categories.Where(x => x.ParentCategoryId == parentCategoryId.Value);
            }

            if (!string.IsNullOrEmpty(searchTerm))
            {
                categories = categories.Where(x => x.Name.ToLower().Contains(searchTerm.ToLower()));
            }

            return categories.Count();
        }

        public List<Category> SearchCategories(int? parentCategoryId, string searchTerm, int? pageNo, int pageSize)
        {
            var categories = context.Categories.AsQueryable();

            if (parentCategoryId.HasValue && parentCategoryId.Value > 0)
            {
                categories = categories.Where(x => x.ParentCategoryId == parentCategoryId.Value);
            }

            if (!string.IsNullOrEmpty(searchTerm))
            {
                categories = categories.Where(x => x.Name.ToLower().Contains(searchTerm.ToLower()));
            }

            pageNo = pageNo ?? 1;
            var skipCount = (pageNo.Value - 1) * pageSize;

            return categories.OrderBy(x => x.DisplaySeqNo).Skip(skipCount).Take(pageSize).ToList();
        }

        public List<Category> GetAllCategories()
        {
            return context.Categories.OrderBy(x => x.DisplaySeqNo).ToList();
        }

        public Category GetCategoryById(int Id)
        {
            return context.Categories.Find(Id);
        }

        public void SaveCategory(Category category)
        {
            context.Categories.Add(category);
            context.SaveChanges();
        }

        public void UpdateCategory(Category category)
        {
            context.Entry(category).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
