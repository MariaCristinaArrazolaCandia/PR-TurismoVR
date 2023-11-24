namespace Turismo_API.Models.Custom
{
    public class PersonDTO : Person
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public int UserID { get; set; }
        public PersonDTO(int personId, string name, string firstName, string lastName, string ci, int phone, string address, DateTime birthDate, string gender, byte state, string email, string password, int userID) : base(personId, name, firstName, lastName, ci, phone, address, birthDate, gender, state)
        {
            UserID = userID;
            Email = email;
            Password = password;
        }
    }
}
