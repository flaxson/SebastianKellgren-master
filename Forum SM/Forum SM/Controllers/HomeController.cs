using Forum_SM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Forum_SM.Controllers
{
    public class HomeController : BaseController
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddThreadPost()
        {
            return View();
        }
        public ActionResult SaveThreadPost(ThreadPost post)
        {
            if(ViewBag.User != null)
            {
                int tempId = ViewBag.User.id; //Får inte använde viewbag i nedanstående rad, då den är dynamisk, så vi byter ut den till tempId
                var dbUser = OurContext.Users.First(x => x.id == tempId);
                post.AuthorThread = dbUser;
            }

            OurContext.ThreadPosts.Add(post);
            OurContext.SaveChanges();
            return RedirectToAction("Index");
        }
	}
}