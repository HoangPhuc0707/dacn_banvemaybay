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
    public class Topic
    {
        public int TopicID { get; set; }
        public string name { get; set; }

        public string slug { get; set; }
        public DateTime? NgayViet { get; set; }
        public int? created_by { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }
}
