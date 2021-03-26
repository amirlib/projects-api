using ProjectsApi.Entities;

namespace ProjectsApi.Services
{
    public interface IUserService
    {
        User Authenticate(string email, string password);
        User GetById(string id);
    }
}
