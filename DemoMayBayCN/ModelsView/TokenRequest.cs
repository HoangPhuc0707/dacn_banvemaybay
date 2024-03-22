using System.ComponentModel.DataAnnotations;

namespace DemoMayBayCN.Models
{
    public class TokenRequest
    {
        [Required]
        public string Token { get; set; }
        [Required]
        public string RefeshToken { get; set; }
    }
}
