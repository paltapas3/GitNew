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
            cb.DataSource = "openshift.database.windows.net";
            cb.UserID = "user";
            cb.Password = "database@12345";
            cb.InitialCatalog = "BankAccountDB";

            using (var connection = new SqlConnection(cb.ConnectionString))
            {
                connection.Open();

                SQL_NonQuery(connection, "Inserts",
                   SQL_Insert());

                // SQL_ExecuteReader(connection);

                connection.SQL_NonQuery();
                connection.Close();
                
            }
        }
        catch (SqlException e)
        {
            throw e;
        }
    }

    static string SQL_Insert()
    {
        return @"

                               
        INSERT INTO UserAccount (Id, Name, Address, Pan, Account_Type, Balance, Gender, Email, DOB)
         VALUES                    
        ('@Id', '@Name', '@Address', '@Pan', '@Account_Type', '@Balance', '@Gender', '@Email', '@DOB');           
        
               ";
    }                           
                                      
    //static string SQL_Select()
    //{
    //    return @"SELECT * from UserAccount"; 
    //}

    static void SQL_NonQuery(
         SqlConnection connection,
         string tsqlPurpose,
         string tsqlSourceCode,
         string parameterName = null,
         string parameterValue = null
         )
    {

        using (var command = new SqlCommand(tsqlSourceCode, connection))
        {
            if (parameterName != null)
            {
                command.Parameters.AddWithValue(
                   parameterName,
                   parameterValue);
            }
            int rowsAffected = command.ExecuteNonQuery();
           
        }
    }

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
