namespace Turismo_API.Models.Custom
{
    public class ChangePasswordDTO
    {
        public string Email { get; set; }
        public string Code { get; set; }
        public string Password { get; set; }
    }
}
