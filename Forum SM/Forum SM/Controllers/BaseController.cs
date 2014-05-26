using Forum_SM.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Forum_SM.Models;
namespace Forum_SM.Controllers
{
    public class BaseController : Controller // Gör en controller som alla andra controller kan ärva ifrån
    {
        private LoginContext _ourContext = new LoginContext(); //Skapar en privat context som vi döper till OurContext
        public LoginContext OurContext 
        {
            get { return _ourContext; }
        }
        public BaseController()
        {
            var Session = System.Web.HttpContext.Current.Session;
            if (Session["LoginSession"] != null)
            {
                User user = Session["LoginSession"] as User; // Hämtar ut session objektet som typen user
                ViewBag.User = user;
            }
        }
        public ActionResult AddComment(int postId, Comment comment)
        {

            return RedirectToAction("IndexThread");
        }
        
	}
}