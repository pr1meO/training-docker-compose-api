namespace Docker.Compose.API.Contracts
{
    public class CreateUserRequest
    {
        public string Firstname { get; set; } = string.Empty;
        public string Login { get; set; } = string.Empty;
    }
}
