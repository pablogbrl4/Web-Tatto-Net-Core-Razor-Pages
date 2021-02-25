namespace ProjectTemplate.Domain.Entities
{
    public class User : BaseModel
    {
        public string Login { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Role { get; set; }
    }
}
