// using System;
// using System.Collections.Generic;
// using System.Data.SqlClient;

// namespace webapi
// {
//     public class Therapist
//     {

//         public int TherapistId { get; set; }
//         public int TitleId { get; set; }
//         public int OfficeId { get; set; }
//         public string FirstName { get; set; }
//         public string LastName { get; set; }
//         public string EmailAddress { get; set; }

//         public static Therapist SelectTherapist(int therapistId, SqlConnection sqlConnection)
//         {
//             Therapist therapist = new Therapist();

//             string sql = "SELECT t.TherapistId, t.FirstName, t.LastName, c.TitleName, o.OfficeName, c.TitleName FROM Therapist t JOIN Office o ON t.OfficeId = o.OfficeId JOIN Title c ON t.TitleId = c.TitleId WHERE t.TherapistId = @TherapistId;";

//             using (SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection))
//             {
//                 sqlCommand.CommandType = System.Data.CommandType.Text;

//                 using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
//                 {
//                     sqlCommand.Parameters.Add("@TherapistId", System.Data.SqlDbType.Int);

//                     sqlCommand.Parameters["@TherapistId"].Value = therapistId;

//                     while (sqlDataReader.Read())
//                     {
//                         therapist.TherapistId = Convert.ToInt32(sqlDataReader["@TherapistId"]);
//                         therapist.FirstName = sqlDataReader["FirstName"].ToString();
//                         therapist.LastName = sqlDataReader["LastName"].ToString();
//                         therapist.TitleId = Convert.ToInt32(sqlDataReader["TitleId"]);
//                         therapist.OfficeId = Convert.ToInt32(sqlDataReader["OfficeId"]);

//                         // therapist.Add(therapist);
//                     }
//                 }
//             }
//             return therapist;
//         }
//         // public static int InsertTherapist(int titleId, int officeId, string firstName, string lastName, string emailAddress, SqlConnection sqlConnection)
//         // {
//         //     string sql = "INSERT INTO Therapist (TitleId, OfficeId, FirstName, LastName, EmailAddress) VALUES (@TitleId, @OfficeId, @FirstName, @LastName, @EmailAddress, @TherapistPassword);";

//         //     using (SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection))
//         //     {
//         //         sqlCommand.CommandType = System.Data.CommandType.Text;

//         //         sqlCommand.Parameters.Add("@TitleId", System.Data.SqlDbType.Int);
//         //         sqlCommand.Parameters.Add("@OfficeId", System.Data.SqlDbType.Int);
//         //         sqlCommand.Parameters.Add("@FirstName", System.Data.SqlDbType.VarChar);
//         //         sqlCommand.Parameters.Add("@LastName", System.Data.SqlDbType.VarChar);
//         //         sqlCommand.Parameters.Add("@LastName", System.Data.SqlDbType.VarChar);
//         //         sqlCommand.Parameters.Add("@EmailAddress", System.Data.SqlDbType.VarChar);

//         //         sqlCommand.Parameters["@TitleId"].Value = titleId;
//         //         sqlCommand.Parameters["@OfficeId"].Value = officeId;
//         //         sqlCommand.Parameters["@FirstName"].Value = firstName;
//         //         sqlCommand.Parameters["@LastName"].Value = lastName;
//         //         sqlCommand.Parameters["@EmailAddress"].Value = emailAddress;

//         //         int rowsAffected = sqlCommand.ExecuteNonQuery();
//         //         return rowsAffected;
//         //     }
//         // }

//         // public static int UpdateTherapist(int therapistId, int titleId, int officeId, string firstName, string lastName, string emailAddress, SqlConnection sqlConnection)
//         // {
//         //     string sql = "UPDATE Therapist SET TitleId = @TitleId, OfficeId = @OfficeId, FirstName = @FirstName, LastName = @LastName, EmailAddress = @EmailAddress WHERE TherapistId = @TherapistId;";

//         //     using (SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection))
//         //     {
//         //         sqlCommand.CommandType = System.Data.CommandType.Text;

//         //         sqlCommand.Parameters.Add("@TherapistId", System.Data.SqlDbType.Int);
//         //         sqlCommand.Parameters.Add("@TitleId", System.Data.SqlDbType.Int);
//         //         sqlCommand.Parameters.Add("@OfficeId", System.Data.SqlDbType.Int);
//         //         sqlCommand.Parameters.Add("@FirstName", System.Data.SqlDbType.VarChar);
//         //         sqlCommand.Parameters.Add("@LastName", System.Data.SqlDbType.VarChar);
//         //         sqlCommand.Parameters.Add("@EmailAddress", System.Data.SqlDbType.VarChar);

//         //         sqlCommand.Parameters["@TherapistId"].Value = therapistId;
//         //         sqlCommand.Parameters["@TitleId"].Value = titleId;
//         //         sqlCommand.Parameters["@OfficeId"].Value = officeId;
//         //         sqlCommand.Parameters["@FirstName"].Value = firstName;
//         //         sqlCommand.Parameters["@LastName"].Value = lastName;
//         //         sqlCommand.Parameters["@EmailAddress"].Value = emailAddress;

//         //         int rowsAffected = sqlCommand.ExecuteNonQuery();
//         //         return rowsAffected;
//         //     }
//         // }

//         // public static int DeleteTherapist(int therapistId, SqlConnection sqlConnection)
//         // {
//         //     string sql = "DELETE FROM Therapist WHERE TherapistId = @TherapistId;";

//         //     using (SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection))
//         //     {
//         //         sqlCommand.CommandType = System.Data.CommandType.Text;

//         //         sqlCommand.Parameters.Add("@TherapistId", System.Data.SqlDbType.Int);

//         //         sqlCommand.Parameters["@TherapisttId"].Value = therapistId;

//         //         int rowsAffected = sqlCommand.ExecuteNonQuery();
//         //         return rowsAffected;
//         //     }
//         // }

//     }

// }