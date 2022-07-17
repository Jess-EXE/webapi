using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace webapi
{
    public class LogIn
    {
        // Used in controller to pass result of log in attempt
        public string result { get; set; }
        public int id { get; set; }

        // Accounts are added manually in the API
        public static Dictionary<string, string> accountUsernameAndPassword = new Dictionary<string, string>()
        {
            {"JOtie@testemail.com" , "Arca1234"},
            {"JTerapie@testemail.com" , "Arca4321"},
            {"SusanAnderson@mail.com" , "Parent1234"},
            {"MikeAnthony@mail.com" , "Parent4321"}
        };

        // The lists below authorize accounts to have roles if they pass log in
        public static Dictionary<string, int> therapistAccountsAndIds = new Dictionary<string, int>()
        {
            {"JOtie@testemail.com", 1000},
            {"JTerapie@testemail.com", 1001}
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
            if (therapistAccountsAndIds.ContainsKey(username))
            {
                return "Therapist";
            }
            else
            {
                return "Parent";
            }
        }

        public static int GetTherapistId(string username)
        {
            return therapistAccountsAndIds[username];
        }

    }

}