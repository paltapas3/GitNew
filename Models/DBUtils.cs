using System;
using System.Data.SqlClient;   
using System.Data;    
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPICore.Models;


public class DBUtils
{
   
    public void AddUser(UserAccount user)
    {
        try
        {
            var cb = new SqlConnectionStringBuilder();
            //cb.DataSource = "openshift.database.windows.net";
            //cb.UserID = "user";
             cb.ConnectionString = "Server = tcp:openshift.database.windows.net,1433; Initial Catalog = BankAccountDB; Persist Security Info = False; User ID =user; Password =database@12345; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;";
            //cb.Password = "database@12345";
            //cb.InitialCatalog = "BankAccountDB";

            using (SqlConnection connection = new SqlConnection(cb.ConnectionString))
            {
                
                SqlCommand cmd = new SqlCommand("INSERT INTO UserAccount (U_ID, U_NAME, U_ADDRESS, U_PAN, U_ACCOUNTTYPE, U_BALANCE, U_GENDER, U_EMAIL, U_DOB) VALUES (@Id, @Name, @Address, @Pan, @Account_Type, @Balance, @Gender, @Email, @DOB)",connection);
                cmd.Parameters.AddWithValue("@Id", UserList._userList[0]);                  
                cmd.Parameters.AddWithValue("@Name", UserList._userList[1]);
                cmd.Parameters.AddWithValue("@Address", UserList._userList[2]);
                cmd.Parameters.AddWithValue("@Pan", UserList._userList[3]);
                cmd.Parameters.AddWithValue("@Account_Type", UserList._userList[4]);
                cmd.Parameters.AddWithValue("@Balance", UserList._userList[5]);
                cmd.Parameters.AddWithValue("@Gender", UserList._userList[6]);
                cmd.Parameters.AddWithValue("@Email", UserList._userList[7]);
                cmd.Parameters.AddWithValue("@DOB", UserList._userList[8]);
                connection.Open();


                // SQL_ExecuteReader(connection);

                int result=cmd.ExecuteNonQuery();
                connection.Close();

            }
        }
        catch (SqlException e)
        {
            throw e;
        }
    }

    //static string SQL_Insert()
    //{
    //    return @"

                               
    //    INSERT INTO UserAccount (Id, Name, Address, Pan, Account_Type, Balance, Gender, Email, DOB)
    //     VALUES                    
    //    ('@Id', '@Name', '@Address', '@Pan', '@Account_Type', '@Balance', '@Gender', '@Email', '@DOB');           
        
    //           ";
    //}                           
                                      
    //static string SQL_Select()
    //{
    //    return @"SELECT * from UserAccount"; 
    //}

    //static void SQL_NonQuery(
    //     SqlConnection connection,
    //     string tsqlPurpose,
    //     string tsqlSourceCode,
    //     string parameterName = null,
    //     string parameterValue = null
    //     )
    //{

    //    using (var command = new SqlCommand(tsqlSourceCode, connection))
    //    {
    //        if (parameterName != null)
    //        {
    //            command.Parameters.AddWithValue(
    //               parameterName,
    //               parameterValue);
    //        }
    //        int rowsAffected = command.ExecuteNonQuery();
           
    //    }
    //}

    //static void SQL_ExecuteReader(SqlConnection connection)
    //{

    //    string tsql = SQL_Select();

    //    using (var command = new SqlCommand(tsql, connection))
    //    {
    //        using (SqlDataReader reader = command.ExecuteReader())
    //        {
    //            while (reader.Read())
    //            {
    //                //reader.GetGuid(0),
    //                //   reader.GetString(1),
    //                //   reader.GetInt32(2),
    //                //   (reader.IsDBNull(3)) ? "NULL" : reader.GetString(3),
    //                //   (reader.IsDBNull(4)) ? "NULL" : reader.GetString(4));
    //            }
    //        }
    //    }
    //}
}
