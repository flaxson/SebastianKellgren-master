using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Forum_SM.DAL;
using Forum_SM.Models; //Gör så att vi kan använda modellerna
using System.Security.Cryptography;
using System.Text;


namespace Forum_SM.Controllers
{
    public class LoginController : BaseController 
    {
        //
        // GET: /Login/
        public ActionResult LoginPage()
        {

            return View(new User()); //Vyn förväntar sig en user
        }

        public ActionResult Login(User user) //Får in User och döper om det till user med litet "u", kollar ifall användaren finns i databasen
        {

            MD5 encoder = new MD5Cng();
            string encodedPassword = Encoding.Unicode.GetString(encoder.ComputeHash(Encoding.Unicode.GetBytes(user.Password)));

            var myUser = OurContext.Users.Where(x => x.UserName == user.UserName && x.Password == encodedPassword).SingleOrDefault(); //Jämför användarnamnet och lösenordet med det som finns i databasen (Allt detta sker md5 kodat), SingleOrDefault fixar så att man får tillbaka en användare eller null 
            
            if(myUser == null)
            {
                ModelState.AddModelError("LoginError", "Inloggningen misslyckades!"); //Misslyckas man med inloggningen kommer det att stå "Inloggningen misslyckades" i login rutan
                Session["LoginSession"] = null; // Ifall man är inloggad och försöker logga in, så  tömms den
                return View("LoginPage", user); //Om man misslyckas skickas man till loginpage med det usernamet man skrev in
            }
            else
            {
                Session["LoginSession"] = myUser; // Sparas till sessionen när man lyckas logga in
                return RedirectToAction("../Thread/IndexThread"); //Om man lyckas med inloggningen kommer man tillbaka till startsidan
            }
        }

        public ActionResult Logout()
        {
            Session["LoginSession"] = null;
            return RedirectToAction("LoginPage");
        }
            
        public ActionResult CreateAdmin() //En metod för att skapa en admin
        {

            User newUser = new User();
            newUser.UserName = "Sebastian";//Skapar en ny användare med användarnamnet Sebastian

            MD5 encoder = new MD5Cng();
            newUser.Password = Encoding.Unicode.GetString(encoder.ComputeHash(Encoding.Unicode.GetBytes("4yf95sk2"))); //Och lösenordet 4yf95sk2 krypterat med md5

            OurContext.Users.Add(newUser);
            OurContext.SaveChanges();

            return RedirectToAction("../Thread/IndexThread"); //När användaren har skapats så skickas man till index
        }
	}
}