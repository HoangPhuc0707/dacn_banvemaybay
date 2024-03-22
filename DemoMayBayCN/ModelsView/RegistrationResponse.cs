namespace DemoMayBayCN.Models
{
    public class RegistrationResponse
    {
        public string Token { get; set; }
        public string RefeshToken { get; set; }
        public bool Success { get; set; }
        public List<string> Errors { get; set; }
    }
}
