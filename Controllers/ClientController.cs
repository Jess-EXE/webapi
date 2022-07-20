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
    public class ClientController : ControllerBase
    {

        private readonly ILogger<ClientController> _logger;

        public ClientController(ILogger<ClientController> logger)
        {
            _logger = logger;
        }

        static string serverName = @"DESKTOP-E3CTJCH\SQLEXPRESS"; //Change to the "Server Name" you see when you launch SQL Server Management Studio.
        static string databaseName = "OTeam"; //Change to the database where you created your Employee table.
        string connectionString = $"data source={serverName}; database={databaseName}; Integrated Security=true;";

        [HttpGet]
        [Route("/SelectClients")]
        public Response SelectClients(int currentLoggedInId)
        {
            Response response = new Response();
            List<Client> clients = new List<Client>();

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();
                    clients = Client.SelectClients(currentLoggedInId, sqlConnection);
                    response.result = Result.success.ToString();
                    response.rowsAffected = 0;
                }
            }
            catch (Exception ex)
            {
                response.result = Result.failure.ToString();
                response.message = ex.Message;
            }

            response.clients = clients;

            return response;
        }

        [HttpGet]
        [Route("/InsertClient")]
        public Response InsertClient(int primaryContactId, int therapistId, string primaryContactFirstName, string primaryContactLastName, string address, string city, string stateId, int zipCode, string phone, string emailAddress, string clientFirstName, string clientLastName, string clientDateOfBirth)
        {
            Response response = new Response();
            List<Client> clients = new List<Client>();
            int rowsAffected = 0;
            string result = Result.failure.ToString();
            string message = "";

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                //int primaryContactId = Client.GetCurretPrimaryContactIdNumber(sqlConnection);

                try
                {
                    sqlConnection.Open();
                    rowsAffected = Client.InsertClient(primaryContactId, therapistId, primaryContactFirstName, primaryContactLastName, address, city, stateId, zipCode, phone, emailAddress, clientFirstName, clientLastName, clientDateOfBirth, sqlConnection);
                    result = Result.success.ToString();
                    clients = Client.SelectClients(LogIn.loggedInId, sqlConnection);
                }
                catch (Exception ex)
                {
                    message = ex.Message;
                }
            }

            response.result = result;
            response.rowsAffected = rowsAffected;
            response.message = message;
            response.clients = clients;

            return response;
        }

        [HttpGet]
        [Route("/UpdateClient")]
        public Response UpdateClient(int primaryContactId, string primaryContactFirstName, string primaryContactLastName, string address, string city, string stateId, string zipCode, string phone, string emailAddress, int clientId, string clientFirstName, string clientLastName, string clientDateOfBirth)
        {
            Response response = new Response();
            List<Client> clients = new List<Client>();
            int rowsAffected = 0;
            string result = Result.failure.ToString();
            string message = "";

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                try
                {
                    sqlConnection.Open();
                    rowsAffected = Client.UpdateClient(primaryContactId, primaryContactFirstName, primaryContactLastName, address, city, stateId, zipCode, phone, emailAddress, clientId, clientFirstName, clientLastName, clientDateOfBirth, sqlConnection);
                    result = Result.success.ToString();
                    clients = Client.SelectClients(LogIn.loggedInId, sqlConnection);
                }
                catch (Exception ex)
                {
                    message = ex.Message;
                }
            }

            response.result = result;
            response.rowsAffected = rowsAffected;
            response.message = message;
            response.clients = clients;

            return response;
        }

        [HttpGet]
        [Route("/DeleteClient")]
        public Response DeleteClient(int clientId)
        {
            Response response = new Response();
            List<Client> clients = new List<Client>();
            int rowsAffected = 0;
            string result = Result.failure.ToString();
            string message = "";

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                try
                {
                    sqlConnection.Open();
                    rowsAffected = Client.DeleteClient(clientId, sqlConnection);
                    result = Result.success.ToString();
                    clients = Client.SelectClients(LogIn.loggedInId, sqlConnection);
                }
                catch (Exception ex)
                {
                    message = ex.Message;
                }
            }

            response.result = result;
            response.rowsAffected = rowsAffected;
            response.message = message;
            response.clients = clients;

            return response;
        }

        [HttpGet]
        [Route("/LoadClientProfile")]
        public Client LoadClientProfilePage(int clientId)
        {

            Client client = new Client();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                client = Client.LoadClientProfile(clientId, sqlConnection);
            }

            return client;
        }

        [HttpGet]
        [Route("/CurrentPrimaryContactIdNumber")]
        public Client GetCurrentPrimaryContactIdNumber()
        {
            Client client = new Client();

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                client = Client.GetCurretPrimaryContactIdNumber(sqlConnection);
            }

            return client;
        }
    }
}