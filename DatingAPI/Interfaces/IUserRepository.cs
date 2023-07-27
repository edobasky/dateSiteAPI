using DatingAPI.Dtos;
using DatingAPI.Entities;
using DatingAPI.Helpers;

namespace DatingAPI.Interfaces
{
    public interface IUserRepository
    {
        void Update(Appuser user);
        Task<bool> SaveAllAsync();
        Task<IEnumerable<Appuser>> GetUsersAsync();
        Task<Appuser> GetUserByIdAsync(int id);
        Task<Appuser> GetUserByUsernameAsync(string username);
        Task<PagedList<membersDto>> GetMembersAsync(UserParams userParams);
        Task<membersDto> GetMemberAsync(string username);
    }
}
