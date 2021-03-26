namespace ProjectsApi.Services
{
    public interface IJwtService
    {
        string DecodeSecurityToken(string authorizationValue);
        string GenerateSecurityToken(string id);
    }
}
