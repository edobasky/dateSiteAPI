using AutoMapper;
using AutoMapper.QueryableExtensions;
using DatingAPI.Dtos;
using DatingAPI.Entities;
using DatingAPI.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DatingAPI.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public UserRepository( DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<membersDto> GetMemberAsync(string username)
        {
            return await _context.Users
                .Where(x => x.UserName == username)
                .ProjectTo<membersDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
        }

        public Task<IEnumerable<membersDto>> GetMembersAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Appuser> GetUserByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<Appuser> GetUserByUsernameAsync(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.UserName.Equals(username));
        }

        public async Task<IEnumerable<Appuser>> GetUsersAsync()
        {
             return await _context.Users
                .Include(p => p.Photos)
                .ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update(Appuser user)
        {
            _context.Entry(user).State = EntityState.Modified;
        }
    }
}
