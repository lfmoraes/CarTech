using CarTech.Registration.Data.Context;
using CarTech.Registration.Data.Interface;
using CarTech.Registration.Data.Interface.Base;
using System.Threading.Tasks;

namespace CarTech.Registration.Data.Repository.Base
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RegistrationDbContext _context;
        private IClienteRepository _cliente;

        public IClienteRepository Cliente
        {
            get
            {
                if(_cliente == null)
                {
                    _cliente = new ClienteRepository(_context);
                }
                return _cliente;
            }
        }


        public RepositoryWrapper(RegistrationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
