using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.Script.Serialization;

namespace ArcadeManager.Models
{
    public class DataManager
    {
        public User Login(string username, string password)
        {
            var user = GetUser(username);
            return user != null && user.Password == password ? user : null;
        }

        public string CreateUser(User user)
        {            
            try
            {
                var filename = HttpContext.Current.Server.MapPath(@"\Data\") + user.Email + ".txt";

                if (File.Exists(filename))
                    return "User already exists";                

                File.WriteAllText(filename, SerializeJson(user));
            }
            catch
            {
                return "Error creating user";
            }

            return string.Empty;
        }

        private static User GetUser(string username)
        {
            try
            {
                var fileText = File.ReadAllText(HttpContext.Current.Server.MapPath(@"\Data\") + username + ".txt");
                return DeserializeJson<User>(fileText);
            }
            catch
            {
                return null;
            }
        }

        private static string SerializeJson(object myObject)
        {
            var serializer = new JavaScriptSerializer();
            return serializer.Serialize(myObject);
        }

        private static T DeserializeJson<T>(string myString)
        {
            var serializer = new JavaScriptSerializer();
            return serializer.Deserialize<T>(myString);
        }
    }
}