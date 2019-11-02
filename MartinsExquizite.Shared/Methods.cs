using MartinsExquizite.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartinsExquizite.Shared
{
    public class Methods
    {
        public static List<Category> GetAllCategoryChildrens(Category category, List<Category> allCategories)
        {
            if (category!=null&&allCategories!=null&&allCategories.Count>0)
            {
                var categories = new List<Category>() { category };
                var childCategories = GeCategoryChildren(category.Id, allCategories);

                foreach (var childCategory in childCategories)
                {
                    categories.Add(childCategory);
                    GetAllCategoryChildrens(childCategory, allCategories);
                }

                return categories;
            }

            return null;
        }

        private static List<Category> GeCategoryChildren(int parentCategoryId, List<Category> allCategories)
        {
            return allCategories.Where(x => x.ParentCategoryId == parentCategoryId).ToList();
        }
    }
}
