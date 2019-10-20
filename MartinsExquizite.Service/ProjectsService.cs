using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MartinsExquizite.Entities.Models;
using MartinsExquizite.Data;

namespace MartinsExquizite.Service
{
    public class ProjectsService
    {
        eMartinsExquiziteContext context = new eMartinsExquiziteContext();

        private static ProjectsService _Instance;

        public static ProjectsService Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new ProjectsService();
                }

                return (_Instance);
            }
        }

        public List<Project> SearchProjects(List<int> CategoryIds, string searchTerm, int? pageNo, int pageSize)
        {
            var Projects = context.Projects.AsQueryable();

            if (CategoryIds!=null && CategoryIds.Count>0)
            {
                Projects = Projects.Where(x => CategoryIds.Contains(x.CategoryId));
            }

            if (!string.IsNullOrEmpty(searchTerm))
            {
                Projects = Projects.Where(x => x.Name.ToLower().Contains(searchTerm.ToLower()));
            }

            pageNo = pageNo ?? 1;
            var skipCount = (pageNo.Value - 1) * pageSize;

            return Projects.OrderByDescending(x => x.ModifiedOn).Skip(skipCount).Take(pageSize).ToList();
        }

        public int GetProjectCount(List<int> CategoryIds, string searchTerm)
        {
            var Projects = context.Projects.AsQueryable();

            if (CategoryIds!=null&&CategoryIds.Count>0)
            {
                Projects = Projects.Where(x => CategoryIds.Contains(x.CategoryId));
            }

            if (!string.IsNullOrEmpty(searchTerm))
            {
                Projects = Projects.Where(x => x.Name.ToLower().Contains(searchTerm.ToLower()));
            }

            return Projects.Count();
        }
    }
}
