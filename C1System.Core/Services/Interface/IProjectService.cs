using C1System.DataLayar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C1System.Core.Services.Interface
{
    public interface IProjectService
    {
        List<Project> GetAllProject();
        Project GetProjectById(Guid id);
        bool AddProject(Project project);
        bool DeleteProject(Project project);
        bool UpdateProject(Project project);
    }
}
