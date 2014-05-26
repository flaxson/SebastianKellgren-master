using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Forum_SM.Models;

namespace Forum_SM.Controllers
{
    public class ThreadController : BaseController
    {
        //
        // GET: /Thread/
        public ActionResult IndexThread()
        {
            var model = OurContext.ThreadPosts.Include(x => x.Comments).Include(x => x.AuthorThread).ToList();

            return View(model);
        }
        
        // public ActionResult AddComment(int postId, Comment comment)
        //{

        //   return RedirectToAction("IndexThread");
        //}

        public ActionResult AddThreadPost()
        {
            return View();
        }
        public ActionResult SaveThreadPost(ThreadPost post)
        {
            if (ViewBag.User != null)
            {
                int tempId = ViewBag.User.id; //Får inte använde viewbag i nedanstående rad, då den är dynamisk, så vi byter ut den till tempId
                var dbUser = OurContext.Users.First(x => x.id == tempId);
                post.AuthorThread = dbUser;
            }

            OurContext.ThreadPosts.Add(post);
            OurContext.SaveChanges();
            return RedirectToAction("IndexThread");
        }
    }
}