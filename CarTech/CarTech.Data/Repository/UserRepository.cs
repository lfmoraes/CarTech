using CarTech.Data.Context;
using CarTech.Data.Interface;
using CarTech.Data.Repository.Base;
using CarTech.Domain.Models.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarTech.Data.Repository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(CarTechContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAllUsuariosAsync()
        {
            return await FindAll().OrderBy(o => o.UserName).ToListAsync();
        }

        public async Task<User> GetUsuarioByIdAsync(string id)
        {
            return await FindByCondition(o => o.Id == id).FirstOrDefaultAsync();
        }

        public void UpdateUser(User user)
        {
            Update(user);
        }
    }
}
