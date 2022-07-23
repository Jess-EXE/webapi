using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Data.SqlClient;

namespace webapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessageController : ControllerBase
    {

        private readonly ILogger<MessageController> _logger;

        public MessageController(ILogger<MessageController> logger)
        {
            _logger = logger;
        }

        static string serverName = @"GWART-PC\SQLEXPRESS"; //Change to the "Server Name" you see when you launch SQL Server Management Studio.
        static string databaseName = "OTeam"; //Change to the database where you created your Employee table.
        string connectionString = $"data source={serverName}; database={databaseName}; Integrated Security=true;";

        // [HttpGet]
        // [Route("/SelectMessages")]
        // public List<string> SelectMessages(int clientId, int therapistId)
        // {
        //     Message message = new Message();

        //     using (SqlConnection sqlConnection = new SqlConnection(connectionString))
        //     {
        //         sqlConnection.Open();
        //         message = Message.SelectMessages(clientId, therapistId, sqlConnection);
        //     }

        //     return message.recievedMessages;
        // }

        [HttpGet]
        [Route("/SelectMessages")]
        public Response SelectMessages(int clientId)
        {
            Response response = new Response();
            List<Message> userMessages = new List<Message>();

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();
                    userMessages = Message.SelectMessages(clientId, sqlConnection);
                    response.result = Result.success.ToString();
                    response.rowsAffected = 0;
                }
            }
            catch (Exception ex)
            {
                response.result = Result.failure.ToString();
                response.message = ex.Message;
            }

            response.userDbMessages = userMessages;

            return response;
        }

        [HttpGet]
        [Route("/InsertMessage")]
        public Response InsertMessage(int clientId, int sentFromId, string messageText, string fromTherapist)
        {

            Response response = new Response();
            List<Message> userMessages = new List<Message>();
            // Message userMessage = new Message();
            int rowsAffected = 0;
            string result = Result.failure.ToString();
            string message = "";

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                try
                {
                    sqlConnection.Open();
                    rowsAffected = Message.InsertMessage(clientId, sentFromId, messageText, fromTherapist, sqlConnection);
                    userMessages = Message.SelectMessages(clientId, sqlConnection);
                    result = Result.success.ToString();
                }
                catch (Exception ex)
                {
                    message = ex.Message;
                }
            }

            response.result = result;
            response.rowsAffected = rowsAffected;
            response.message = message;
            response.userDbMessages = userMessages;

            return response;
        }

        [HttpGet]
        [Route("/DeleteMessage")]
        public Response DeleteMessage(int clientId, int messageId)
        {
            Response response = new Response();
            List<Message> userMessages = new List<Message>();
            int rowsAffected = 0;
            string result = Result.failure.ToString();
            string message = "";

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                try
                {
                    sqlConnection.Open();
                    rowsAffected = Message.DeleteMessage(messageId, sqlConnection);
                    result = Result.success.ToString();
                    userMessages = Message.SelectMessages(clientId, sqlConnection);
                }
                catch (Exception ex)
                {
                    message = ex.Message;
                }
            }

            response.result = result;
            response.rowsAffected = rowsAffected;
            response.message = message;
            response.userDbMessages = userMessages;

            return response;
        }

        // [HttpGet]
        // [Route("/UpdateTherapist")]
        // public Response UpdateTherapist(int therapistId, int titleId, int officeId, string firstName, string lastName, string emailAddress)
        // {
        //     Response response = new Response();
        //     Therapist therapist = new Therapist();
        //     int rowsAffected = 0;
        //     string result = Result.failure.ToString();
        //     string message = "";

        //     using (SqlConnection sqlConnection = new SqlConnection(connectionString))
        //     {
        //         try
        //         {
        //             sqlConnection.Open();
        //             rowsAffected = Therapist.UpdateTherapist(therapistId, titleId, officeId, firstName, lastName, emailAddress, sqlConnection);
        //             result = Result.success.ToString();
        //             // therapist = Therapist.SelectTherapist(therapistId, sqlConnection);
        //         }
        //         catch (Exception ex)
        //         {
        //             message = ex.Message;
        //         }
        //     }

        //     response.result = result;
        //     response.rowsAffected = rowsAffected;
        //     response.message = message;
        //     response.therapist = therapist;

        //     return response;
        // }

        // [HttpGet]
        // [Route("/DeleteTherapist")]
        // public Response DeleteTherapist(int therapistId)
        // {
        //     Response response = new Response();
        //     Therapist therapist = new Therapist();
        //     int rowsAffected = 0;
        //     string result = Result.failure.ToString();
        //     string message = "";

        //     using (SqlConnection sqlConnection = new SqlConnection(connectionString))
        //     {
        //         try
        //         {
        //             sqlConnection.Open();
        //             rowsAffected = Therapist.DeleteTherapist(therapistId, sqlConnection);
        //             result = Result.success.ToString();
        //             // therapist = Therapist.SelectTherapist(therapistId, sqlConnection);
        //         }
        //         catch (Exception ex)
        //         {
        //             message = ex.Message;
        //         }
        //     }

        //     response.result = result;
        //     response.rowsAffected = rowsAffected;
        //     response.message = message;
        //     response.therapist = therapist;

        //     return response;
        // }
    }
}