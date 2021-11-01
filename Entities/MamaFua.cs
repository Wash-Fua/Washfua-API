using System;

namespace WashFua.Entities
{
    public record MamaFua
    {
        public Guid  Id { get; init; }
        public string firstName { get; init; }
        public string lastName { get; init; }
        public string email { get; init; }
        public string username { get; init; }
        public string password { get; init; }
        public DateTime dateCreated { get; init; }
    }
}