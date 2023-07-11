using DatingAPI.Dtos;
using DatingAPI.Entities;

namespace DatingAPI.Interfaces
{
    public interface IUserRepository
    {
        void Update(Appuser user);
        Task<bool> SaveAllAsync();
        Task<IEnumerable<Appuser>> GetUsersAsync();
        Task<Appuser> GetUserByIdAsync(int id);
        Task<Appuser> GetUserByUsernameAsync(string username);
        Task<IEnumerable<membersDto>> GetMembersAsync();
        Task<membersDto> GetMemberAsync(string username);
    }
}
