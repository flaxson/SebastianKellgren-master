using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forum_SM.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public User Author { get; set; }
        public string CommentText { get; set; }
    }
}