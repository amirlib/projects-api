using ProjectsApi.Entities;

namespace ProjectsApi.Services
{
    public interface IProjectService
    {
        Project GetByUserId(string id);
    }
}
