using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace webapi
{
    public class Client
    {

        public int ClientId { get; set; }
        //public int TherapistId { get; set; }
        //public int PrimaryContactId { get; set; }
        //public int TeacherId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }

        public static List<Client> SelectClients(SqlConnection sqlConnection)
        {
            List<Client> clients = new List<Client>();

            string sql = "SELECT FirstName, LastName, DateOfBirth FROM client;";

            using (SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection))
            {
                sqlCommand.CommandType = System.Data.CommandType.Text;

                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                {
                    while (sqlDataReader.Read())
                    {
                        Client client = new Client();

                        client.FirstName = sqlDataReader["FirstName"].ToString();
                        client.LastName = sqlDataReader["LastName"].ToString();
                        client.DateOfBirth = Convert.ToDateTime(sqlDataReader["DateOfBirth"]).ToShortDateString();
                        clients.Add(client);
                    }
                }
            }
            return clients;
        }

        public static int InsertClient(string firstName, string lastName, string dateOfBirth, SqlConnection sqlConnection)
        {
            string sql = "insert into Client (FirstName, LastName, DateOfBirth) values (@FirstName, @LastName, @DateOfBirth);";

            using (SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection))
            {
                sqlCommand.CommandType = System.Data.CommandType.Text;

                sqlCommand.Parameters.Add("@FirstName", System.Data.SqlDbType.VarChar);
                sqlCommand.Parameters.Add("@LastName", System.Data.SqlDbType.VarChar);
                sqlCommand.Parameters.Add("@DateOfBirth", System.Data.SqlDbType.Date);

                sqlCommand.Parameters["@FirstName"].Value = lastName;
                sqlCommand.Parameters["@LastName"].Value = firstName;
                sqlCommand.Parameters["@DateOfBirth"].Value = dateOfBirth;

                int rowsAffected = sqlCommand.ExecuteNonQuery();
                return rowsAffected;
            }
        }

    }

}