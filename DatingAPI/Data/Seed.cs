using DatingAPI.Entities;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace DatingAPI.Data
{
    public class Seed
    {
        public static async Task SeedUsers(DataContext context)
        {
            if (await context.Users.AnyAsync()) return;

            var userData = await File.ReadAllTextAsync("Data/UserSeedData.json");

            //   var options = new JsonSerializerOptions(PropertyNameCaseInsensitive);

            var users = JsonSerializer.Deserialize<List<Appuser>>(userData);

            foreach ( var user in users ) 
            {
                using var hmac = new HMACSHA512();

                user.UserName = user.UserName.ToLower();
                user.PasswordHarsh = hmac.ComputeHash(Encoding.UTF8.GetBytes("passw0rd123"));
                user.PasswordSalt = hmac.Key;

                context.Users.Add(user);

            }
             
            await context.SaveChangesAsync();
        }
    }
}
