using System;
using System.Data.SqlClient;   
using System.Data;    
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPICore.Models;


public class DBUtils
{
   
    public string AddUser(UserAccount user)
    {
        string val = "";
        try
        {
            var cb = new SqlConnectionStringBuilder();
            //cb.DataSource = "openshift.database.windows.net";
            //cb.UserID = "user";
            cb.ConnectionString = "Data Source=openshift.database.windows.net;Initial Catalog=BankAccountDB;User ID=user;Password=database@12345";
            //cb.Password = "database@12345";
            //cb.InitialCatalog = "BankAccountDB";

            using (SqlConnection connection = new SqlConnection(cb.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO UserAccount VALUES (@Id, @Name, @Address, @Pan, @Account_Type, @Balance, @Gender, @Email, @DOB)", connection);
                cmd.Parameters.AddWithValue("@Id", user.Id);                  
                cmd.Parameters.AddWithValue("@Name",user.Name);
                cmd.Parameters.AddWithValue("@Address",user.Address);
                cmd.Parameters.AddWithValue("@Pan",user.Pan);
                cmd.Parameters.AddWithValue("@Account_Type",user.Account_Type);
                cmd.Parameters.AddWithValue("@Balance",user.Balance);
                cmd.Parameters.AddWithValue("@Gender",user.Gender);
                cmd.Parameters.AddWithValue("@Email",user.Email);
                cmd.Parameters.AddWithValue("@DOB",user.DOB);
                connection.Open();


                // SQL_ExecuteReader(connection);

                int result=cmd.ExecuteNonQuery();
                connection.Close();

            }
        }
        catch (Exception e)
        {
            val= e.StackTrace;
        }
        return val;
    }

    public List<string> connectDb()
    {
        List<string> error = new List<string>();
        string val = "";
        try
        {
            var cb = new SqlConnectionStringBuilder();
            cb.ConnectionString = "Data Source=openshift.database.windows.net;Initial Catalog=BankAccountDB;User ID=user;Password=database@12345";
            
            using (SqlConnection connection = new SqlConnection("Data Source=openshift.database.windows.net;Initial Catalog=BankAccountDB;User ID=user;Password=database@12345"))
            {
                
                

                using (SqlCommand command = new SqlCommand("insert into test values('Rabi1')", connection))
                {
                    connection.Open();
                    int result = command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }
        catch (SqlException e)
        {
            val = e.StackTrace;
            error.Add("SqlException");
            error.Add(e.Number.ToString());
            for (int i = 0; i < e.Errors.Count; i++)
            {
                error.Add(e.Errors[i].ToString());
            }
            

        }
        catch (Exception e)
        {
            val = e.StackTrace;
            error.Add("exception");
            error.Add(e.StackTrace);
            error.Add(e.Message);

        }

        return error;
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
