using System;
using System.Data.SqlClient;   
using System.Data;    
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPICore.Models;


public class DBUtils
{
   
    public UserAccount AddUser(UserAccount user)
    {
        List<string> error = new List<string>();
      //  UserAccount userC = new List<UserAccount>();
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

          //  throw new Exception(e.StackTrace);


        }
        catch (Exception e)
        {
            val = e.StackTrace;
            error.Add("exception");
            error.Add(e.StackTrace);
            error.Add(e.Message);
           // throw new Exception(e.StackTrace);

        }

        return user;
       
    }

    public List<UserAccount> getUsers()
    {
        List<string> error = new List<string>();
        List<UserAccount> userList = new List<UserAccount>();
        UserAccount user;
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
                        user = new UserAccount();
                        user.Id = result["U_ID"].ToString();
                        user.Name = result["U_NAME"].ToString();
                        user.Address = result["U_ADDRESS"].ToString();
                        user.Pan = result["U_PAN"].ToString();
                        user.Account_Type = result["U_ACCOUNTTYPE"].ToString();
                        user.Balance = result["U_BALANCE"].ToString();
                        user.Gender = result["U_GENDER"].ToString();
                        user.Email = result["U_EMAIL"].ToString();
                        user.DOB = result["U_DOB"].ToString();
                        userList.Add(user);

                        //error.Add(result["U_ID"].ToString()+","+ result["U_NAME"].ToString()+","+ result["U_ADDRESS"].ToString()+","+ result["U_PAN"].ToString()+","+ result["U_ACCOUNTTYPE"].ToString()+","+ result["U_BALANCE"].ToString()+","+ result["U_GENDER"].ToString()+","+ result["U_EMAIL"].ToString()+","+ result["U_DOB"].ToString());

                    }
                   

                    connection.Close();
                }
            }
        }
        catch (SqlException e)
        {
            string errormsg = string.Empty;
            for (int i = 0; i < e.Errors.Count; i++)
            {
                errormsg = errormsg + e.Errors[i].ToString();
            }
            userList.Add(new UserAccount { Name= errormsg });


        }
        catch (Exception e)
        {
            userList.Add(new UserAccount { Name = e.StackTrace });

        }

        return userList;
    }
}
