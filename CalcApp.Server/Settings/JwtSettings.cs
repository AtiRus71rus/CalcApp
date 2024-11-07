namespace CalcApp.Server.Settings
{
    //настройки JWT-токена
    public class JwtSettings
    {
        public TimeSpan Expires { get; set; }
        public string SecretKey { get; set; }
    }
}
