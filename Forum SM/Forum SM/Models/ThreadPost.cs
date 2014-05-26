using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forum_SM.Models
{
    public class ThreadPost
    {
        public int id { get; set; }
        public string ThreadText { get; set; }
        public User AuthorThread { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}