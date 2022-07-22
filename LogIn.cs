using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace webapi
{
    public class LogIn
    {

        public static bool therapistLoggedIn;
        // Used in controller to pass result of log in attempt
        public string result { get; set; }
        public int id { get; set; }

        public string name { get; set; }

        public static int loggedInId;

        // Accounts are added manually in the API
        public static Dictionary<string, string> accountUsernameAndPassword = new Dictionary<string, string>()
        {
            {"JOtie@arcatherapy.com" , "Arca1234"},
            {"JTerapie@arcatherapy.com" , "Arca1234"},
            {"PBrennan@mail.com", "Parent1234"},
            {"SHenderson@mail.com", "Parent1234"},
            {"JNoble@mail.com", "Parent1234"},
            {"YRamsey@mail.com", "Parent1234"},
            {"BSharp@mail.com", "Parent1234"},
            {"SSabbath@arcatherapy.com", "Arca1234"}
        };

        // The lists below authorize accounts to have roles if they pass log in
        public static Dictionary<string, int> therapistAccountsAndIds = new Dictionary<string, int>()
        {
            {"JOtie@arcatherapy.com", 1001},
            {"SSabbath@arcatherapy.com", 1002}
        };

        public static Dictionary<string, int> parentAccountsAndIds = new Dictionary<string, int>()
        {
            {"PBrennan@mail.com", 1001},
            {"SHenderson@mail.com", 1005},
            {"JNoble@mail.com", 1006},
            {"YRamsey@mail.com", 1007},
            {"BSharp@mail.com", 1003}
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
                therapistLoggedIn = true;
                return "Therapist";
            }
            else
            {
                therapistLoggedIn = false;
                return "Parent";
            }
        }

        public static int GetTherapistId(string username)
        {
            return therapistAccountsAndIds[username];
        }

        public static int GetParentId(string username)
        {
            return parentAccountsAndIds[username];
        }

    }

}