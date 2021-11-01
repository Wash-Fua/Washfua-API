using System;
using System.Collections.Generic;
using System.Linq;
using WashFua.Entities;

namespace WashFua.Repositories
{
   
    public class InMemUsersRepository : IUsersRepository
    {
        private readonly List<User> users = new()
        {
            new User
            {
                Id = Guid.NewGuid(), firstName = "Billy", lastName = "Okeyo", email = "billycartel360@gmail.com",
                username = "billy", password = "BillyOkeyo", userType = "Client", dateCreated = DateTime.UtcNow
            },
            new User
            {
                Id = Guid.NewGuid(), firstName = "Bryson", lastName = "Minodi", email = "bryson@gmail.com",
                username = "bryson", password = "BrysonM", userType = "Client", dateCreated = DateTime.UtcNow
            },
            new User
            {
                Id = Guid.NewGuid(), firstName = "Daniel", lastName = "Dennis", email = "dan@gmail.com",
                username = "dan", password = "DanieDennis", userType = "Washer", dateCreated = DateTime.UtcNow
            },
            new User
            {
                Id = Guid.NewGuid(), firstName = "Kandy", lastName = "Said", email = "kandy@gmail.com",
                username = "kandy", password = "KandySaid", userType = "Washer", dateCreated = DateTime.UtcNow
            }
        };

        public IEnumerable<User> GetUsers()
        {
            return users;
        }

        public User GetUser(Guid id)
        {
            return users.Where(user => user.Id == id).SingleOrDefault();
        }

        public void CreateUser(User user)
        {
            users.Add(user);
        }

        public void UpdateUser(User user)
        {
            var index = users.FindIndex(existingUser => existingUser.Id == user.Id);
            users[index] = user;
        }

        public void DeleteUser(Guid id)
        {
            var index = users.FindIndex(existingUser => existingUser.Id == id);
            users.RemoveAt(index);
        }
    }
}