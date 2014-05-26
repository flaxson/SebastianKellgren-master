using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity; //Användare Entity Framework
using Forum_SM.Models;

namespace Forum_SM.DAL
{
    public class LoginContext : DbContext //Ärver från DBContext
    {
        public DbSet<User> Users { get; set; }//Gör så vi kan använda modellen user
        public DbSet<ThreadPost> ThreadPosts { get; set; } //Gör så vi kan använda modellen threadpost
        public DbSet<Comment> Comments { get; set; }//Gör så vi kan använda modellen comment
    }
}