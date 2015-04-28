using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArcadeManager.Models
{
    public class SessionManager
    {
        public void SaveSession(User user)
        {
            HttpContext.Current.Session["User"] = user;
        }

        public User GetSession()
        {
            return HttpContext.Current.Session["User"] as User;
        }

        public void RemoveSession()
        {
            HttpContext.Current.Session["User"] = null;
        }


        public bool Exists()
        {
            return (HttpContext.Current.Session["User"] != null);
        }
    }
}