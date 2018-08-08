
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
             //read from xml
            List<Users> userlist = new List<Users>();    
            XDocument doc = XDocument.Load("D:\\Gitold\\WebAPICore\\UserData.xml");
            foreach (XElement element in doc.Descendants("DocumentElement")
                .Descendants("UserData"))
            {
                Users user = new Users();
                user.Id = element.Element("Id").Value;
                user.Name = element.Element("Name").Value;

                userlist.Add(user);   
            }
            return userlist;
        }
    
    }
}