// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.Extensions.Logging;
// using System.Data.SqlClient;

// namespace webapi.Controllers
// {
//     [ApiController]
//     [Route("[controller]")]
//     public class TherapistController : ControllerBase
//     {

//         private readonly ILogger<TherapistController> _logger;

//         public TherapistController(ILogger<TherapistController> logger)
//         {
//             _logger = logger;
//         }

//         static string serverName = @"GWART-PC\SQLEXPRESS"; //Change to the "Server Name" you see when you launch SQL Server Management Studio.
//         static string databaseName = "OTeam"; //Change to the database where you created your Employee table.
//         string connectionString = $"data source={serverName}; database={databaseName}; Integrated Security=true;";

//         [HttpGet]
//         [Route("/SelectTherapist")]
//         public Response SelectTherapist(int therapistId)
//         {
//             Response response = new Response();
//             Therapist therapist = new Therapist();

//             try
//             {
//                 using (SqlConnection sqlConnection = new SqlConnection(connectionString))
//                 {
//                     sqlConnection.Open();
//                     therapist = Therapist.SelectTherapist(therapistId, sqlConnection);
//                     response.result = Result.success.ToString();
//                     response.rowsAffected = 0;
//                 }
//             }
//             catch (Exception ex)
//             {
//                 response.result = Result.failure.ToString();
//                 response.message = ex.Message;
//             }

//             response.therapist = therapist;

//             return response;
//         }

//         // [HttpGet]
//         // [Route("/InsertTherapist")]
//         // public Response InsertTherapist(int titleId, int officeId, string firstName, string lastName, string emailAddress, string therapistPassword)
//         // {
//         //     Response response = new Response();
//         //     Therapist therapist = new Therapist();
//         //     int rowsAffected = 0;
//         //     string result = Result.failure.ToString();
//         //     string message = "";

//         //     using (SqlConnection sqlConnection = new SqlConnection(connectionString))
//         //     {
//         //         try
//         //         {
//         //             sqlConnection.Open();
//         //             rowsAffected = Therapist.InsertTherapist(titleId, officeId, firstName, lastName, emailAddress, sqlConnection);
//         //             result = Result.success.ToString();
//         //             // therapist = Therapist.SelectTherapist(therapistId, sqlConnection);
//         //         }
//         //         catch (Exception ex)
//         //         {
//         //             message = ex.Message;
//         //         }
//         //     }

//         //     response.result = result;
//         //     response.rowsAffected = rowsAffected;
//         //     response.message = message;
//         //     response.therapist = therapist;

//         //     return response;
//         // }

//         // [HttpGet]
//         // [Route("/UpdateTherapist")]
//         // public Response UpdateTherapist(int therapistId, int titleId, int officeId, string firstName, string lastName, string emailAddress)
//         // {
//         //     Response response = new Response();
//         //     Therapist therapist = new Therapist();
//         //     int rowsAffected = 0;
//         //     string result = Result.failure.ToString();
//         //     string message = "";

//         //     using (SqlConnection sqlConnection = new SqlConnection(connectionString))
//         //     {
//         //         try
//         //         {
//         //             sqlConnection.Open();
//         //             rowsAffected = Therapist.UpdateTherapist(therapistId, titleId, officeId, firstName, lastName, emailAddress, sqlConnection);
//         //             result = Result.success.ToString();
//         //             // therapist = Therapist.SelectTherapist(therapistId, sqlConnection);
//         //         }
//         //         catch (Exception ex)
//         //         {
//         //             message = ex.Message;
//         //         }
//         //     }

//         //     response.result = result;
//         //     response.rowsAffected = rowsAffected;
//         //     response.message = message;
//         //     response.therapist = therapist;

//         //     return response;
//         // }

//         // [HttpGet]
//         // [Route("/DeleteTherapist")]
//         // public Response DeleteTherapist(int therapistId)
//         // {
//         //     Response response = new Response();
//         //     Therapist therapist = new Therapist();
//         //     int rowsAffected = 0;
//         //     string result = Result.failure.ToString();
//         //     string message = "";

//         //     using (SqlConnection sqlConnection = new SqlConnection(connectionString))
//         //     {
//         //         try
//         //         {
//         //             sqlConnection.Open();
//         //             rowsAffected = Therapist.DeleteTherapist(therapistId, sqlConnection);
//         //             result = Result.success.ToString();
//         //             // therapist = Therapist.SelectTherapist(therapistId, sqlConnection);
//         //         }
//         //         catch (Exception ex)
//         //         {
//         //             message = ex.Message;
//         //         }
//         //     }

//         //     response.result = result;
//         //     response.rowsAffected = rowsAffected;
//         //     response.message = message;
//         //     response.therapist = therapist;

//         //     return response;
//         // }
//     }
// }