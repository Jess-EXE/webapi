using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace webapi
{
    public class Message
    {

        //public int ClientId { get; set; }
        //public int PrimaryContactId { get; set; }
        //public int TherapistId { get; set; }
        public string MessageText { get; set; }
        public string FromUser { get; set; }

        public DateTime TimeSent { get; set; }
        public int MessageId { get; set; }

        public string FromTherapist { get; set; }
        //public List<string> recievedMessages = new List<string>();

        // public static Message SelectMessages(int clientId, int therapistId, SqlConnection sqlConnection)
        // {
        //     Message message = new Message();

        //     string sql = "SELECT MessageText, TherapistId, ClientId FROM [Message] WHERE ClientId = @ClientId AND TherapistId = @TherapistId";

        //     using (SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection))
        //     {
        //         sqlCommand.CommandType = System.Data.CommandType.Text;

        //         sqlCommand.Parameters.Add("@ClientId", System.Data.SqlDbType.Int);
        //         //sqlCommand.Parameters.Add("@PrimaryContactId", System.Data.SqlDbType.Int);
        //         sqlCommand.Parameters.Add("@TherapistId", System.Data.SqlDbType.Int);

        //         sqlCommand.Parameters["@ClientId"].Value = clientId;
        //         //sqlCommand.Parameters["@PrimaryContactId"].Value = primaryContactId;
        //         sqlCommand.Parameters["@TherapistId"].Value = therapistId;

        //         using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
        //         {


        //             while (sqlDataReader.Read())
        //             {

        //                 message.ClientId = Convert.ToInt32(sqlDataReader["ClientId"]);
        //                 // message.PrimaryContactId = Convert.ToInt32(sqlDataReader["PrimaryContactId"]);
        //                 message.TherapistId = Convert.ToInt32(sqlDataReader["TherapistId"]);
        //                 message.MessageText = sqlDataReader["MessageText"].ToString();

        //                 message.recievedMessages.Add(message.MessageText);
        //             }
        //         }
        //     }
        //     return message;
        // }


        public static List<Message> SelectMessages(int clientId, SqlConnection sqlConnection)
        {
            List<Message> userMessages = new List<Message>();

            string sql = "SELECT MessageId, MessageText, FromUser, TimeSent, FromTherapist FROM [Message] WHERE ClientId = @ClientId ORDER BY TimeSent;";

            using (SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection))
            {
                sqlCommand.CommandType = System.Data.CommandType.Text;

                sqlCommand.Parameters.Add("@ClientId", System.Data.SqlDbType.Int);
                //sqlCommand.Parameters.Add("@PrimaryContactId", System.Data.SqlDbType.Int);
                //sqlCommand.Parameters.Add("@TherapistId", System.Data.SqlDbType.Int);

                sqlCommand.Parameters["@ClientId"].Value = clientId;
                //sqlCommand.Parameters["@PrimaryContactId"].Value = primaryContactId;
                //sqlCommand.Parameters["@TherapistId"].Value = therapistId;

                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                {


                    while (sqlDataReader.Read())
                    {
                        Message message = new Message();

                        //message.ClientId = Convert.ToInt32(sqlDataReader["ClientId"]);
                        // message.PrimaryContactId = Convert.ToInt32(sqlDataReader["PrimaryContactId"]);
                        //message.TherapistId = Convert.ToInt32(sqlDataReader["TherapistId"]);
                        message.MessageId = Convert.ToInt32(sqlDataReader["MessageId"]);
                        message.MessageText = sqlDataReader["MessageText"].ToString();
                        message.FromUser = sqlDataReader["FromUser"].ToString();
                        message.TimeSent = Convert.ToDateTime(sqlDataReader["TimeSent"]);
                        message.FromTherapist = sqlDataReader["FromTherapist"].ToString();

                        userMessages.Add(message);
                    }
                }
            }
            return userMessages;
        }

        public static int InsertMessage(int clientId, int sentFromId, string messageText, string fromTherapist, SqlConnection sqlConnection)
        {
            string sql;
            if (LogIn.therapistLoggedIn)
            {
                sql = "INSERT INTO [Message] (ClientId, MessageText, TimeSent, FromUser, FromTherapist) VALUES (@ClientId, @MessageText, CURRENT_TIMESTAMP, (SELECT (FirstName + ' ' + LastName) AS FullName FROM Therapist WHERE TherapistId = @SentFromId), @FromTherapist);";
            }
            else
            {
                sql = "INSERT INTO [Message] (ClientId, MessageText, TimeSent, FromUser, FromTherapist) VALUES (@ClientId, @MessageText, CURRENT_TIMESTAMP, (SELECT (PrimaryContactFirstName + ' ' + PrimaryContactLastName) AS FullName FROM PrimaryContact WHERE PrimaryContactId = @SentFromId), @FromTherapist);";
            }

            using (SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection))
            {
                sqlCommand.CommandType = System.Data.CommandType.Text;

                sqlCommand.Parameters.Add("@ClientId", System.Data.SqlDbType.Int);
                //sqlCommand.Parameters.Add("@TimeSent", System.Data.SqlDbType.DateTime);
                //sqlCommand.Parameters.Add("@PrimaryContactId", System.Data.SqlDbType.Int);
                //sqlCommand.Parameters.Add("@TherapistId", System.Data.SqlDbType.Int);
                sqlCommand.Parameters.Add("@MessageText", System.Data.SqlDbType.Text);
                //sqlCommand.Parameters.Add("@CurrentTimestamp", System.Data.SqlDbType.DateTime);
                sqlCommand.Parameters.Add("@SentFromId", System.Data.SqlDbType.Int);
                sqlCommand.Parameters.Add("@FromTherapist", System.Data.SqlDbType.Text);

                sqlCommand.Parameters["@ClientId"].Value = clientId;
                //sqlCommand.Parameters.Add["@TimeSent"].Value = timeSent;
                //sqlCommand.Parameters.Add["@PrimaryContactId"].Value = primaryContactId;
                //sqlCommand.Parameters.Add["@TherapistId"].Value = therapistId;
                //sqlCommand.Parameters["@CurrentTimestamp"].Value = CurrentTimestamp;
                sqlCommand.Parameters["@MessageText"].Value = messageText;
                sqlCommand.Parameters["@SentFromId"].Value = sentFromId;
                sqlCommand.Parameters["@FromTherapist"].Value = fromTherapist;

                int rowsAffected = sqlCommand.ExecuteNonQuery();
                return rowsAffected;
            }
        }

        // public static int UpdateMessage(int clientId, int primaryContactId, int therapistId, string messageText, SqlConnection sqlConnection)
        // {
        //     string sql = "UPDATE [Message] SET MessageText = @MessageText WHERE ClientId = @ClientId AND PrimaryContactId = @PrimaryContactId AND TherapistId = @TherapistId";

        //     using (SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection))
        //     {
        //         sqlCommand.CommandType = System.Data.CommandType.Text;

        //         sqlCommand.Parameters.Add("@ClientId", System.Data.SqlDbType.Int);
        //         sqlCommand.Parameters.Add("@PrimaryContactId", System.Data.SqlDbType.Int);
        //         sqlCommand.Parameters.Add("@TherapistId", System.Data.SqlDbType.Int);
        //         sqlCommand.Parameters.Add("@MessageText", System.Data.SqlDbType.Text);

        //         sqlCommand.Parameters.Add["@ClientId"].Value = clientId;
        //         sqlCommand.Parameters.Add["@PrimaryContactId"].Value = primaryContactId;
        //         sqlCommand.Parameters.Add["@TherapistId"].Value = therapistId;
        //         sqlCommand.Parameters.Add["@MessageText"].Value = messageText;

        //         int rowsAffected = sqlCommand.ExecuteNonQuery();
        //         return rowsAffected;
        //     }
        // }

        public static int DeleteMessage(int messageId, SqlConnection sqlConnection)
        {
            string sql = "DELETE FROM [Message] WHERE MessageId = @MessageId";

            using (SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection))
            {
                sqlCommand.CommandType = System.Data.CommandType.Text;

                sqlCommand.Parameters.Add("@MessageId", System.Data.SqlDbType.Int);

                sqlCommand.Parameters["@MessageId"].Value = messageId;

                int rowsAffected = sqlCommand.ExecuteNonQuery();
                return rowsAffected;
            }
        }

    }
}