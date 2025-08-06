namespace Docker.Compose.API.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Firstname { get; set; } = string.Empty;
        public string Login { get; set; } = string.Empty;
    }
}