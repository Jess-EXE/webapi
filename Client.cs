using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace webapi
{
    public class Client
    {

        public int ClientId { get; set; }
        public int TherapistId { get; set; }
        public int PrimaryContactId { get; set; }
        public string PrimaryContactFirstName { get; set; }
        public string PrimaryContactLastName { get; set; }
        // public string Address { get; set; }
        // public string City { get; set; }
        public string StateId { get; set; }
        // public int Zipcode { get; set; }
        public string Phone { get; set; }
        public string EmailAddress { get; set; }
        // public string PrimaryContactPassword { get; set; }
        //public int TeacherId { get; set; }
        public string ClientFirstName { get; set; }
        public string ClientLastName { get; set; }
        public string ClientDateOfBirth { get; set; }

        public int CurrentPrimaryContactId { get; set; }

        public static List<Client> SelectClients(SqlConnection sqlConnection)
        {
            List<Client> clients = new List<Client>();

            string sql = "SELECT c.ClientId, c.ClientFirstName, c.ClientLastName, c.ClientDateOfBirth, p.PrimaryContactId, p.PrimaryContactFirstName, p.PrimaryContactLastName, p.Phone, p.EmailAddress FROM Client c JOIN PrimaryContact p ON c.PrimaryContactId = p.PrimaryContactId;";

            using (SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection))
            {
                sqlCommand.CommandType = System.Data.CommandType.Text;

                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                {
                    while (sqlDataReader.Read())
                    {
                        Client client = new Client();

                        client.PrimaryContactId = Convert.ToInt32(sqlDataReader["PrimaryContactId"]);
                        client.PrimaryContactFirstName = sqlDataReader["PrimaryContactFirstName"].ToString();
                        client.PrimaryContactLastName = sqlDataReader["PrimaryContactLastName"].ToString();
                        client.Phone = sqlDataReader["Phone"].ToString();
                        client.EmailAddress = sqlDataReader["EmailAddress"].ToString();
                        client.ClientId = Convert.ToInt32(sqlDataReader["ClientId"]);
                        client.ClientFirstName = sqlDataReader["ClientFirstName"].ToString();
                        client.ClientLastName = sqlDataReader["ClientLastName"].ToString();
                        client.ClientDateOfBirth = Convert.ToDateTime(sqlDataReader["ClientDateOfBirth"]).ToShortDateString();
                        clients.Add(client);
                    }
                }
            }
            return clients;
        }

        public static int InsertClient(int primaryContactId, int therapistId, string primaryContactFirstName, string primaryContactLastName, string address, string city, string stateId, int zipCode, string phone, string emailAddress, string clientFirstName, string clientLastName, string clientDateOfBirth, SqlConnection sqlConnection)
        {
            string sql = "INSERT INTO PrimaryContact (PrimaryContactId, PrimaryContactFirstName, PrimaryContactLastName, [Address], City, StateId, ZipCode, Phone, EmailAddress)VALUES (@PrimaryContactId, @PrimaryContactFirstName, @PrimaryContactLastName, @Address, @City, @StateId, @ZipCode, @Phone, @EmailAddress); INSERT INTO Client (PrimaryContactId, TherapistId, ClientFirstName, ClientLastName, ClientDateOfBirth) VALUES (@PrimaryContactId, @TherapistId, @ClientFirstName, @ClientLastName, @ClientDateOfBirth);";

            using (SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection))
            {
                sqlCommand.CommandType = System.Data.CommandType.Text;
                sqlCommand.Parameters.Add("@PrimaryContactId", System.Data.SqlDbType.Int);
                sqlCommand.Parameters.Add("@TherapistId", System.Data.SqlDbType.Int);
                sqlCommand.Parameters.Add("@PrimaryContactFirstName", System.Data.SqlDbType.VarChar);
                sqlCommand.Parameters.Add("@PrimaryContactLastName", System.Data.SqlDbType.VarChar);
                sqlCommand.Parameters.Add("@Address", System.Data.SqlDbType.VarChar);
                sqlCommand.Parameters.Add("@City", System.Data.SqlDbType.VarChar);
                sqlCommand.Parameters.Add("@StateId", System.Data.SqlDbType.Char);
                sqlCommand.Parameters.Add("@ZipCode", System.Data.SqlDbType.Int);
                sqlCommand.Parameters.Add("@Phone", System.Data.SqlDbType.VarChar);
                sqlCommand.Parameters.Add("@EmailAddress", System.Data.SqlDbType.VarChar);
                sqlCommand.Parameters.Add("@ClientFirstName", System.Data.SqlDbType.VarChar);
                sqlCommand.Parameters.Add("@ClientLastName", System.Data.SqlDbType.VarChar);
                sqlCommand.Parameters.Add("@ClientDateOfBirth", System.Data.SqlDbType.DateTime);

                sqlCommand.Parameters["@PrimaryContactId"].Value = primaryContactId;
                sqlCommand.Parameters["@TherapistId"].Value = therapistId;
                sqlCommand.Parameters["@PrimaryContactFirstName"].Value = primaryContactFirstName;
                sqlCommand.Parameters["@PrimaryContactLastName"].Value = primaryContactLastName;
                sqlCommand.Parameters["@Address"].Value = address;
                sqlCommand.Parameters["@City"].Value = city;
                sqlCommand.Parameters["@StateId"].Value = stateId;
                sqlCommand.Parameters["@ZipCode"].Value = zipCode;
                sqlCommand.Parameters["@Phone"].Value = phone;
                sqlCommand.Parameters["@EmailAddress"].Value = emailAddress;
                sqlCommand.Parameters["@ClientFirstName"].Value = clientFirstName;
                sqlCommand.Parameters["@ClientLastName"].Value = clientLastName;
                sqlCommand.Parameters["@ClientDateOfBirth"].Value = clientDateOfBirth;

                int rowsAffected = sqlCommand.ExecuteNonQuery();
                return rowsAffected;
            }
        }

        public static int UpdateClient(int primaryContactId, string primaryContactFirstName, string primaryContactLastName, string address, string city, string stateId, string zipCode, string phone, string emailAddress, int clientId, string clientFirstName, string clientLastName, string clientDateOfBirth, SqlConnection sqlConnection)
        {
            string sql = "UPDATE PrimaryContact SET PrimaryContactFirstName = @PrimaryContactFirstName, PrimaryContactLastName = @PrimaryContactLastName, [Address] = @Address, City = @City, StateId = @StateId, ZipCode = @ZipCode, Phone = @Phone, EmailAddress = @EmailAddress  WHERE PrimaryContactId = @PrimaryContactId;; UPDATE Client SET ClientFirstName = @ClientFirstName, ClientLastName = @ClientLastName, ClientDateOfBirth = @ClientDateOfBirth WHERE ClientId = @ClientId;";

            using (SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection))
            {
                sqlCommand.CommandType = System.Data.CommandType.Text;

                sqlCommand.Parameters.Add("@PrimaryContactId", System.Data.SqlDbType.Int);
                sqlCommand.Parameters.Add("@PrimaryContactFirstName", System.Data.SqlDbType.VarChar);
                sqlCommand.Parameters.Add("@PrimaryContactLastName", System.Data.SqlDbType.VarChar);
                sqlCommand.Parameters.Add("@Address", System.Data.SqlDbType.VarChar);
                sqlCommand.Parameters.Add("@City", System.Data.SqlDbType.VarChar);
                sqlCommand.Parameters.Add("@StateId", System.Data.SqlDbType.Char);
                sqlCommand.Parameters.Add("@ZipCode", System.Data.SqlDbType.Int);
                sqlCommand.Parameters.Add("@Phone", System.Data.SqlDbType.VarChar);
                sqlCommand.Parameters.Add("@EmailAddress", System.Data.SqlDbType.VarChar);
                sqlCommand.Parameters.Add("@ClientId", System.Data.SqlDbType.Int);
                sqlCommand.Parameters.Add("@ClientFirstName", System.Data.SqlDbType.VarChar);
                sqlCommand.Parameters.Add("@ClientLastName", System.Data.SqlDbType.VarChar);
                sqlCommand.Parameters.Add("@ClientDateOfBirth", System.Data.SqlDbType.DateTime);

                sqlCommand.Parameters["@PrimaryContactId"].Value = primaryContactId;
                sqlCommand.Parameters["@PrimaryContactFirstName"].Value = primaryContactFirstName;
                sqlCommand.Parameters["@PrimaryContactLastName"].Value = primaryContactLastName;
                sqlCommand.Parameters["@Address"].Value = address;
                sqlCommand.Parameters["@City"].Value = city;
                sqlCommand.Parameters["@StateId"].Value = stateId;
                sqlCommand.Parameters["@ZipCode"].Value = zipCode;
                sqlCommand.Parameters["@Phone"].Value = phone;
                sqlCommand.Parameters["@EmailAddress"].Value = emailAddress;
                sqlCommand.Parameters["@ClientId"].Value = clientId;
                sqlCommand.Parameters["@ClientFirstName"].Value = clientFirstName;
                sqlCommand.Parameters["@ClientLastName"].Value = clientLastName;
                sqlCommand.Parameters["@ClientDateOfBirth"].Value = clientDateOfBirth;

                int rowsAffected = sqlCommand.ExecuteNonQuery();
                return rowsAffected;
            }
        }

        public static int DeleteClient(int clientId, SqlConnection sqlConnection)
        {
            string sql = "DELETE FROM Client WHERE ClientId = @ClientId;";

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
                        client.ClientFirstName = sqlDataReader["FirstName"].ToString();
                        client.ClientLastName = sqlDataReader["LastName"].ToString();
                        client.ClientDateOfBirth = Convert.ToDateTime(sqlDataReader["DateOfBirth"]).ToShortDateString();
                    }
                }
            }
            return client;
        }

        public static int GetCurretPrimaryContactIdNumber(SqlConnection sqlConnection)
        {

            Client client = new Client();

            string sql = "SELECT MAX(PrimaryContactId) FROM PrimaryContact";

            using (SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection))
            {
                sqlCommand.CommandType = System.Data.CommandType.Text;

                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                {
                    while (sqlDataReader.Read())
                    {
                        client.CurrentPrimaryContactId = Convert.ToInt32(sqlDataReader["PrimaryContactId"]);
                        client.CurrentPrimaryContactId++;
                    }
                }
            }
            return client.CurrentPrimaryContactId;
        }

    }
}