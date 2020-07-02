using System;
using System.IO;
using System.Xml.Serialization;

namespace TP3_Web_Identity.Models
{
    [Serializable]
    public class ModelLogin
    {
        string username;
        string password;
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }

        public ModelLogin(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        public ModelLogin()
        {
            this.username = "1";
            this.password = "1";
        }


        public static bool Login(ModelLogin login)
        {
            string[] logins = File.ReadAllLines(AppDomain.CurrentDomain.BaseDirectory + "/Models/logins.txt");
            foreach (string s in logins)
            {
                if (s.Equals(login.username + ":" + login.password))
                    return true;
            }

            return false;
        }

        public static void Inscription(ModelLogin login)
        {
            string data = "\r\n" + login.username + ":" + login.password;
            using (StreamWriter file =
            new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "/Models/logins.txt", true))
            {
                file.WriteLine(data);
            }

        }


        public static bool Existant(string username)
        {
            string[] logins = File.ReadAllLines(AppDomain.CurrentDomain.BaseDirectory + "/Models/logins.txt");
            foreach (string s in logins)
            {
                if (s.StartsWith(username + ":"))
                    return true;
            }

            return false;

        }

        override
        public string ToString()
        {
            return this.username;
        }




    }
}