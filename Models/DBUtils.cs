using System;
using System.Data.SqlClient;   
using System.Data;    
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPICore.Models;


public class DBUtils
{
   
    public List<string> AddUser(UserAccount user)
    {
        List<string> error = new List<string>();
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

                int result=cmd.ExecuteNonQuery();
                connection.Close();

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
                
                

                using (SqlCommand command = new SqlCommand("select * from UserAccount", connection))
                {
                    connection.Open();
                    SqlDataReader result = command.ExecuteReader();
                    while (result.Read())
                    {
                        error.Add(result["U_ID"].ToString()+" "+ result["U_NAME"].ToString());
                        error.Add(result["U_NAME"].ToString());
                        error.Add(result["U_ADDRESS"].ToString());
                        error.Add(result["U_PAN"].ToString());
                        error.Add(result["U_ACCOUNTTYPE"].ToString());
                        error.Add(result["U_BALANCE"].ToString());
                        error.Add(result["U_GENDER"].ToString());
                        error.Add(result["U_EMAIL"].ToString());
                        error.Add(result["U_DOB"].ToString());

                    }
                   

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
}
