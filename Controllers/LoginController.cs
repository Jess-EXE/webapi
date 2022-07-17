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
    public class LoginController : ControllerBase
    {

        private readonly ILogger<ClientController> _logger;

        public LoginController(ILogger<ClientController> logger)
        {
            _logger = logger;
        }

        static string serverName = @"DESKTOP-E3CTJCH\SQLEXPRESS"; //Change to the "Server Name" you see when you launch SQL Server Management Studio.
        static string databaseName = "OTeam"; //Change to the database where you created your Employee table.
        string connectionString = $"data source={serverName}; database={databaseName}; Integrated Security=true;";

        // The result of this api call is passed back to JavaScript to verify or fail the log in
        [HttpGet]
        [Route("/AttemptLogIn")]
        public LogIn AuthenticateUser(string username, string password)
        {
            LogIn logIn = new LogIn();

            if (LogIn.Authenticate(username, password))
            {
                logIn.result = LogIn.Authorize(username);
                if (logIn.result == "Therapist")
                {
                    logIn.id = LogIn.GetTherapistId(username);
                }
                return logIn;
            }
            else
            {
                logIn.result = "Fail";
                return logIn;
            }
        }
    }
}