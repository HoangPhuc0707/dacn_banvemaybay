namespace DemoMayBayCN.Configurations
{
    public class JwtConfig
    {
        public string? Secret { get; set; }
        public TimeSpan ExpireTimeFrame { get; set; }
    }
}
