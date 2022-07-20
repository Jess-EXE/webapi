using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace webapi
{
    public enum Result { success, failure }
    public class Response
    {
        public string result { get; set; }
        public int rowsAffected { get; set; }
        public string message { get; set; }
        public List<Client> clients { get; set; }

        // BELOW: Therapist controller and class commented out, turn on this property if they are un-commented
        // public Therapist therapist { get; set; }

        public List<Message> userDbMessages { get; set; }
    }
}