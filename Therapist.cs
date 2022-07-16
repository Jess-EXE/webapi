using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace webapi
{
    public class Therapist
    {

        public int TherapistId { get; set; }
        public int TitleId { get; set; }
        public int OfficeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }

}