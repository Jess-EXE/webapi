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

            string sql = "SELECT ClientId, FirstName, LastName, DateOfBirth FROM client;";

            using (SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection))
            {
                sqlCommand.CommandType = System.Data.CommandType.Text;

                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                {
                    while (sqlDataReader.Read())
                    {
                        Client client = new Client();

                        client.ClientId = Convert.ToInt32(sqlDataReader["ClientId"]);
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

                sqlCommand.Parameters["@FirstName"].Value = firstName;
                sqlCommand.Parameters["@LastName"].Value = lastName;
                sqlCommand.Parameters["@DateOfBirth"].Value = dateOfBirth;

                int rowsAffected = sqlCommand.ExecuteNonQuery();
                return rowsAffected;
            }
        }

        public static int UpdateClient(int clientId, string firstName, string lastName, string dateOfBirth, SqlConnection sqlConnection)
        {
            string sql = "update Client set FirstName = @FirstName, LastName = @LastName, DateOfBirth = @DateOfBirth where ClientId = @ClientId;";

            using (SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection))
            {
                sqlCommand.CommandType = System.Data.CommandType.Text;

                sqlCommand.Parameters.Add("@ClientId", System.Data.SqlDbType.Int);
                sqlCommand.Parameters.Add("@FirstName", System.Data.SqlDbType.VarChar);
                sqlCommand.Parameters.Add("@LastName", System.Data.SqlDbType.VarChar);
                sqlCommand.Parameters.Add("@DateOfBirth", System.Data.SqlDbType.Date);

                sqlCommand.Parameters["@ClientId"].Value = clientId;
                sqlCommand.Parameters["@FirstName"].Value = firstName;
                sqlCommand.Parameters["@LastName"].Value = lastName;
                sqlCommand.Parameters["@DateOfBirth"].Value = dateOfBirth;

                int rowsAffected = sqlCommand.ExecuteNonQuery();
                return rowsAffected;
            }
        }

        public static int DeleteClient(int clientId, SqlConnection sqlConnection)
        {
            string sql = "delete from Client where ClientId = @ClientId;";

            using (SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection))
            {
                sqlCommand.CommandType = System.Data.CommandType.Text;

                sqlCommand.Parameters.Add("@ClientId", System.Data.SqlDbType.Int);

                sqlCommand.Parameters["@ClientId"].Value = clientId;

                int rowsAffected = sqlCommand.ExecuteNonQuery();
                return rowsAffected;
            }
        }

        public static Client LoadClientProfile(int clientId, SqlConnection sqlConnection)
        {
            Client client = new Client();

            string sql = "SELECT clientid, firstname, lastname, dateofbirth FROM client WHERE clientid = @ClientId;";

            using (SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection))
            {
                sqlCommand.CommandType = System.Data.CommandType.Text;
                sqlCommand.Parameters.Add("@ClientId", System.Data.SqlDbType.Int);

                sqlCommand.Parameters["@ClientId"].Value = clientId;

                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                {
                    while (sqlDataReader.Read())
                    {
                        client.ClientId = Convert.ToInt32(sqlDataReader["ClientId"]);
                        client.FirstName = sqlDataReader["FirstName"].ToString();
                        client.LastName = sqlDataReader["LastName"].ToString();
                        client.DateOfBirth = Convert.ToDateTime(sqlDataReader["DateOfBirth"]).ToShortDateString();
                    }
                }
            }
            return client;
        }

    }

}