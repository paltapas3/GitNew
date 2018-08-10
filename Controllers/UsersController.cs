
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
    [Route("api/Users")]
    [ApiController]
    public class UsersController : ControllerBase
    {     
        [HttpGet]
        public ActionResult<List<Users>> GetAll()
        {
          
            List<Users> userlist = new List<Users>();
            userlist.Add(new Users {Id = "17", Name ="Rishav" });
            //read json file
            return userlist;
        }
    
    }
}