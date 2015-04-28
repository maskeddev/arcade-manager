using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArcadeManager.Models
{
    public class User
    {
        public string Name;
        public string Email;
        public string Password { get; set; }
        public IEnumerable<Game> Games;
    }
}