namespace Turismo_API.Services.Interfaces
{
    public interface IPersonRegisterService
    {
        Task RegisterPersonRegister(int personID, int userID);
        Task SendEmail(string username, string emailDestiny);

    }
}
