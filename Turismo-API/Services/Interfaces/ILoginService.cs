using Turismo_API.Models;
using Turismo_API.Models.Custom;

namespace Turismo_API.Services.Interfaces
{
    public interface ILoginService
    {
        string GenerateUserName(string Name, string lastName, string Email, string Ci);
        Task<AuthResponse> Login(UserRequest user);
        string EncryptPassword(string password);

        Task<bool> GetCode(string email, string username);

        Task<bool> ChangePassword(ChangePasswordDTO changePassword);
    }
}
