namespace Entity.Service.User
{
    public class CreateUserRequest
    {
        public string Mail { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string DocumentType { get; set; } = null!;
        public string DocumentNumber { get; set; } = null!;
        public string Names { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Gender { get; set; } = null!;
        public DateTime Birthdate { get; set; }
        public string PhoneNumber { get; set; } = null!;
    }
}
