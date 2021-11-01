using System;

namespace WashFua.Entities
{
    public record  User
    {
        public Guid  Id { get; init; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string userType { get; set; }
        public DateTime dateCreated { get; set; }
    }
}