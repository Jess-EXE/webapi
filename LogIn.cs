using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace webapi
{
    public class LogIn
    {
        // Used in controller to pass result of log in attempt
        public string result { get; set; }

        // Accounts are added manually in the API
        public static Dictionary<string, string> accountUsernameAndPassword = new Dictionary<string, string>()
        {
            {"JesseChase@mail.com" , "Arca1234"},
            {"MattGwartney@mail.com" , "Arca4321"},
            {"SusanAnderson@mail.com" , "Parent1234"},
            {"MikeAnthony@mail.com" , "Parent4321"}
        };

        // The lists below authorize accounts to have roles if they pass log in
        public static List<string> therapistAccounts = new List<string>()
        {
            "JesseChase@mail.com",
            "MattGwartney@mail.com"
        };

        public static List<string> parentAccounts = new List<string>()
        {
            "SusanAnderson@mail.com",
            "MikeAnthony@mail.com"
        };

        // Authenticate username and password
        public static bool Authenticate(string username, string password)
        {
            if (accountUsernameAndPassword.ContainsKey(username))
            {
                if (accountUsernameAndPassword[username].Equals(password))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        // Authorize role of account if they enter a correct username and password
        public static string Authorize(string username)
        {
            if (therapistAccounts.Contains(username))
            {
                return "Therapist";
            }
            else
            {
                return "Parent";
            }
        }

    }

}