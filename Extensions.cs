using WashFua.Dtos;
using WashFua.Entities;

namespace WashFua
{
    public static class Extensions
    {
        public static UserDto AsDto(this User user)
        {
            return new UserDto
            {
                Id = user.Id,
                firstName = user.firstName,
                lastName = user.lastName,
                email = user.email,
                username = user.username,
                password = user.password,
                dateCreated = user.dateCreated
            };
        }

        public static MamaFuaDto AsDto(this MamaFua mamaFua)
        {
            return new MamaFuaDto
            {
                Id = mamaFua.Id,
                firstName = mamaFua.firstName,
                lastName = mamaFua.lastName,
                email = mamaFua.email,
                username = mamaFua.username,
                password = mamaFua.password,
                dateCreated = mamaFua.dateCreated
            };
        }
    }
}