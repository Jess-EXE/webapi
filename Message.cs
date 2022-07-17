using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace webapi
{
    public class Message
    {

        public int ClientId { get; set; }
        public int PrimaryContactId { get; set; }
        public int TherapistId { get; set; }
        public string MessageText { get; set; }

        public static List<Message> SelectMessages(SqlConnection sqlConnection)
        {
            List<Message> messages = new List<Message>();

            string sql = "SELECT MessageText FROM [Message] WHERE ClientId = @ClientId AND PrimaryContactId = @PrimaryContactId AND TherapistId = @TherapistId";

            using (SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection))
            {
                sqlCommand.CommandType = System.Data.CommandType.Text;

                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                {
                    while (sqlDataReader.Read())
                    {
                        Message messsage = new Message();

                        messsage.ClientId = Convert.ToInt32(sqlDataReader["ClientId"]);
                        messsage.PrimaryContactId = Convert.ToInt32(sqlDataReader["PrimaryContactId"]);
                        messsage.TherapistId = Convert.ToInt32(sqlDataReader["TherapistId"]);
                        messages.MessageText = sqlDataReader["MessageText"].ToString();

                        messages.Add(message);
                    }
                }
            }
            return clients;
        }

        public static int InsertMessage(int clientId, int primaryContactId, int therapistId, string messageText, SqlConnection sqlConnection)
        {
            string sql = "INSERT INTO [Message] (ClientId, PrimaryContactId, TherapistID, MessageText) VALUES (@ClientId, @PrimaryContactId, @TherapistId, @MessageText);";

            using (SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection))
            {
                sqlCommand.CommandType = System.Data.CommandType.Text;

                sqlCommand.Parameters.Add("@ClientId", System.Data.SqlDbType.Int);
                sqlCommand.Parameters.Add("@PrimaryContactId", System.Data.SqlDbType.Int);
                sqlCommand.Parameters.Add("@TherapistId", System.Data.SqlDbType.Int);
                sqlCommand.Parameters.Add("@MessageText", System.Data.SqlDbType.Text);

                sqlCommand.Parameters.Add["@ClientId"].Value = clientId;
                sqlCommand.Parameters.Add["@PrimaryContactId"].Value = primaryContactId;
                sqlCommand.Parameters.Add["@TherapistId"].Value = therapistId;
                sqlCommand.Parameters.Add["@MessageText"].Value = messageText;

                int rowsAffected = sqlCommand.ExecuteNonQuery();
                return rowsAffected;
            }
        }

        public static int UpdateMessage(int clientId, int primaryContactId, int therapistId, string messageText, SqlConnection sqlConnection)
        {
            string sql = "UPDATE [Message] SET MessageText = @MessageText WHERE ClientId = @ClientId AND PrimaryContactId = @PrimaryContactId AND TherapistId = @TherapistId";

            using (SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection))
            {
                sqlCommand.CommandType = System.Data.CommandType.Text;

                sqlCommand.Parameters.Add("@ClientId", System.Data.SqlDbType.Int);
                sqlCommand.Parameters.Add("@PrimaryContactId", System.Data.SqlDbType.Int);
                sqlCommand.Parameters.Add("@TherapistId", System.Data.SqlDbType.Int);
                sqlCommand.Parameters.Add("@MessageText", System.Data.SqlDbType.Text);

                sqlCommand.Parameters.Add["@ClientId"].Value = clientId;
                sqlCommand.Parameters.Add["@PrimaryContactId"].Value = primaryContactId;
                sqlCommand.Parameters.Add["@TherapistId"].Value = therapistId;
                sqlCommand.Parameters.Add["@MessageText"].Value = messageText;

                int rowsAffected = sqlCommand.ExecuteNonQuery();
                return rowsAffected;
            }
        }

        public static int DeleteMessage(int clientId, int primaryContactId, int therapistId, SqlConnection sqlConnection)
        {
            string sql = "DELETE FROM Client WHERE ClientId = @ClientId AND PrimaryContactId = @PrimaryContactId AND TherapistId = @TherapistId;";

            using (SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection))
            {
                sqlCommand.CommandType = System.Data.CommandType.Text;

                sqlCommand.Parameters.Add("@ClientId", System.Data.SqlDbType.Int);
                qlCommand.Parameters.Add("@PrimaryContactId", System.Data.SqlDbType.Int);
                qlCommand.Parameters.Add("@TherapistId", System.Data.SqlDbType.Int);

                sqlCommand.Parameters["@ClientId"].Value = clientId;
                sqlCommand.Parameters["@PrimaryContactId"].Value = primaryContactId;
                sqlCommand.Parameters["@TherapistId"].Value = therapistId;

                int rowsAffected = sqlCommand.ExecuteNonQuery();
                return rowsAffected;
            }
        }

    }
}