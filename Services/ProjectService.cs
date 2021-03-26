using ProjectsApi.Entities;
using ProjectsApi.Helpers;

namespace ProjectsApi.Services
{
    public class ProjectService : IProjectService
    {
        public ProjectService(DataContext context)
        {
            _context = context;
        }

        #region Fields
        private DataContext _context;
        #endregion

        #region Public Methods
        public Project GetByUserId(string id)
        {
            return _context.Projects.Find(id);
        } 
        #endregion
    }
}
