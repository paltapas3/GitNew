using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebAPICore.Models
{
    public class Users

    {

        public string ID { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Acc_no { get; set; }

        public string password { get; set; }

    }
}