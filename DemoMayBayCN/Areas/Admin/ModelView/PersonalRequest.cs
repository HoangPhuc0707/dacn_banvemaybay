using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace DemoMayBayCN.Areas.Admin.ModelView
{
    public class PersonalRequest
    {
        public string FullName {get; set; }
        public string Gender { get; set; }
        public string Address { get; set; } 
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
