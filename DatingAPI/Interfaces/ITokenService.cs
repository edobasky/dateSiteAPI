using DatingAPI.Entities;

namespace DatingAPI.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(Appuser user);
    }
}
