using System;

namespace WebAPICore.Models
{
    public class UserAccount
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Pan { get; set; }
        public string Account_Type { get; set; }
        public int Balance { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string DOB { get; set; }
        public int AccountNumber { get; set; }
    }
}