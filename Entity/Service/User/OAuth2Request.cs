namespace Entity.Service.User
{
    public class OAuth2Request
    {
        public string Username { get; set; }
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
    }
}
