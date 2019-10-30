using MartinsExquizite.Data;
using MartinsExquizite.Entities.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System;

namespace MartinsExquizite.Service
{
    public class ProjectsService
    {
        eMartinsExquiziteContext context = new eMartinsExquiziteContext();
        #region Define as Singleton
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

        public ProjectsService()
        {

        }
        #endregion

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

        public Project GetProjectById(int Id)
        {
            return context.Projects.Find(Id);
        }

        public bool DeleteProject(int Id)
        {
            var project = context.Projects.Find(Id);
            context.Projects.Remove(project);

            return context.SaveChanges() > 0;
        }

        public void UpdateProject(Project project)
        {
            var existingProject = context.Projects.Find(project.Id);
            context.ProjectPictures.RemoveRange(existingProject.ProjectPictures);
            context.Entry(existingProject).CurrentValues.SetValues(project);
            context.ProjectPictures.AddRange(project.ProjectPictures);

            context.SaveChanges();
        }

        public void SaveProject(Project project)
        {
            context.Projects.Add(project);

            context.SaveChanges();
        }
    }
}
