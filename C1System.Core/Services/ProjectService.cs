using C1System.Core.Services.Interface;
using C1System.DataLayar.Context;
using C1System.DataLayar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C1System.Core.Services
{
    public class ProjectService : IProjectService
    {
        private readonly C1SystemContext _context;
        public ProjectService(C1SystemContext context)
        {
            _context = context;
        }
        public bool AddProject(Project project)
        {
            try
            {
                _context.Projects.Add(project);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteProject(Project project)
        {
            if (project != null)
            {
                var Project = project;
                Project.IsDelete = true;
                try
                {
                    _context.Projects.Update(Project);
                    _context.SaveChanges();
                    return true;
                }
                catch (Exception)
                {

                    return false;
                }
            }
            else
                return false;
        }

        public List<Project> GetAllProject()
        {
            return _context.Projects.Where(x => x.IsDelete == false).ToList();
        }

        public Project GetProjectById(Guid id)
        {
            return _context.Projects.Find(id);
        }

        public bool UpdateProject(Project project)
        {
            if (project != null)
            {
                try
                {
                    _context.Projects.Update(project);
                    _context.SaveChanges();
                    return true;
                }
                catch (Exception)
                {

                    throw;
                }
            }
            else
                return false;
        }
    }
}
