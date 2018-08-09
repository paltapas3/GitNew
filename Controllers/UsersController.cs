
using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using WebAPICore.Models;

namespace WebAPICore.Controllers
{
    [Route("api/Users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public UsersController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        public ActionResult<List<Users>> GetAll()
        {
             //read from xml
            List<Users> userlist = new List<Users>();
            


            string contentRootPath = _hostingEnvironment.ContentRootPath;
            var JSON = System.IO.File.ReadAllText(contentRootPath + "/UserData.json");
            userlist=JsonConvert.DeserializeObject(JSON);

            return userlist;
        }
    
    }
}