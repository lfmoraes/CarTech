using CarTech.Domain.Models.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarTech.Data.Interface
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsuariosAsync();
        Task<User> GetUsuarioByIdAsync(string userId);

        void UpdateUser(User user);
    }
}
