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
        public ActionResult<List<UserAccount>> GetAll()
        {
            return UserList._userList;
        }

      [HttpPost]
        public ActionResult<List<UserAccount>> CreateAccount(UserAccount account)
        {
             UserList._userList.Add(account);
         return "success";
        }
    }
}