namespace Entity.AppSettings
{
    public class JwtSettings
    {
        public string Key { get; set; }
        public string KeySettings { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int TokenExpiryDays { get; set; }
        public int RefreshTokenExpiryDays { get; set; }
    }
}
