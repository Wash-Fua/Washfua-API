using System;
using System.Collections.Generic;
using WashFua.Entities;

namespace WashFua.Repositories
{

    public interface IUsersRepository
    {
        IEnumerable<User> GetUsers();
        User GetUser(Guid id);

        void CreateUser(User user);

        void UpdateUser(User user);

        void DeleteUser(Guid id);
    }
}