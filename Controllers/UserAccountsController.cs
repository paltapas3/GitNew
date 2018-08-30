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
        private readonly UserDBContext _context;

        public UserAccountsController(UserDBContext context)
        {
            _context = context;

            if (_context.TodoItems.Count() == 0)
            {
                // Create a new TodoItem if collection is empty,
                // which means you can't delete all TodoItems.
                _context.TodoItems.Add(new TodoItem { Name = "Item1" });
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public ActionResult<List<UserAccount>> GetAll()
        {
                return UserList._userList;
        }

       
        [HttpPost]
        public ActionResult<List<UserAccount>> Create(UserAccount userAccount)
        {
            UserList._userList.Add(userAccount);

            _context.TodoItems.Add(UserList._userList);
            _context.SaveChanges();

            return   UserList._userList;
        }
    }
}