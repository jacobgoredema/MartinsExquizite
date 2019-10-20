using MartinsExquizite.Data;
using MartinsExquizite.Entities.Models;
using System;
using System.Collections.Generic;
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

        public List<Category> GetAllCategories()
        {
            return context.Categories.OrderBy(x => x.DisplaySeqNo).ToList();
        }

        public Category GetCategoryById(int Id)
        {
            return context.Categories.Find(Id);
        }
    }
}
