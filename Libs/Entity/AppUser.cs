using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libs.Entity
{
    public class AppUser:IdentityUser
    {
        public string Gender { get; set; }
        public string Address { get; set; }
        public string FullName { get; set; }
        public virtual ICollection<Flights> Flights { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }
}
