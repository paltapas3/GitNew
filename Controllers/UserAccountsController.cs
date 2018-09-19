using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Xml.Linq;
using WebAPICore.Models;

namespace WebAPICore.Controllers
{
    [Route("api/UserAccounts")]
    [ApiController]
    public class UserAccountsController : ControllerBase
    {

        [HttpGet]
        public ActionResult<string> GetAll()
        {
            DBUtils du = new DBUtils();
            return du.connectDb();
        }

       
        [HttpPost]
        public ActionResult<string> Create(UserAccount userAccount)
        {
            
            DBUtils du = new DBUtils();


            //  UserList._userList.Add(userAccount);

            return du.AddUser(userAccount);
        }
    }
}