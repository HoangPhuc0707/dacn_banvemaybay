using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libs.Entity
{
    public class Post
    {
        public int PostID { get; set; }
        public int TopicID { get; set; }
        public string title { get; set; }
        public string slug { get; set; }
        public string detail { get; set; }
        public string img { get; set; }
        public string type { get; set; }
        public DateTime? created_at { get; set; }
        public string created_by { get; set; }
        public virtual Topic Topic { get; set; }
        public virtual AppUser AspNetUser { get; set; }
    }
}
