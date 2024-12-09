using SystemSchool.Server.Models;

namespace SystemSchool.Server.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(Users users);
    }
}
