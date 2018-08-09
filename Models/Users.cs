using System;

namespace WebAPICore.Models
{
    public class Users
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public Users() { }

        public Users(string id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
    }
}