using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forum_SM.Models
{
    public class User
    {
        public int id { get; set; }
        public string UserName { get; set; } //En sträng för att man skall logga in med sitt användarnamn och t.ex. inte e-post
        public string Password { get; set; } //Om man skall logga in, krävs det ett lösenord
        public string Token { get; set; } // Säkerthet, komma ihåg en inloggning
        public bool IsAdmin { get; set; } //Detta kollar om användaren är admin, vilket vi först tänkte implimera men sket i det.
    }
}