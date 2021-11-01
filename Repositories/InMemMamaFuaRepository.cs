using System;
using System.Collections.Generic;
using System.Linq;
using WashFua.Entities;

namespace WashFua.Repositories
{
    public class InMemMamaFuaRepository : IMamaFuaRepository
    {
        private readonly List<MamaFua> mamas = new()
        {
            new MamaFua
            {
                Id = Guid.NewGuid(), firstName = "Billy", lastName = "Okeyo", email = "billycartel360@gmail.com",
                username = "billy", password = "BillyOkeyo", dateCreated = DateTime.UtcNow
            },
            new MamaFua
            {
                Id = Guid.NewGuid(), firstName = "Bryson", lastName = "Minodi", email = "bryson@gmail.com",
                username = "bryson", password = "BrysonM", dateCreated = DateTime.UtcNow
            },
            new MamaFua
            {
                Id = Guid.NewGuid(), firstName = "Daniel", lastName = "Dennis", email = "dan@gmail.com",
                username = "dan", password = "DanieDennis", dateCreated = DateTime.UtcNow
            },
            new MamaFua
            {
                Id = Guid.NewGuid(), firstName = "Kandy", lastName = "Said", email = "kandy@gmail.com",
                username = "kandy", password = "KandySaid", dateCreated = DateTime.UtcNow
            }
        };

        public IEnumerable<MamaFua> GetMamaFuas()
        {
            return mamas;
        }

        public MamaFua GetMamaFua(Guid id)
        {
            return mamas.Where(mamafua => mamafua.Id == id).SingleOrDefault();
        }

        public void CreateMamaFua(MamaFua mamafua)
        {
            mamas.Add(mamafua);
        }

        public void UpdateMamaFua(MamaFua mamafua)
        {
            var index = mamas.FindIndex(existingUser => existingUser.Id == mamafua.Id);
            mamas[index] = mamafua;
        }

        public void DeleteMamaFua(Guid id)
        {
            var index = mamas.FindIndex(existingUser => existingUser.Id == id);
            mamas.RemoveAt(index);
        }
    }
}