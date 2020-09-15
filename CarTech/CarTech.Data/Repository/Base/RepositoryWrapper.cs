using CarTech.Data.Context;
using CarTech.Data.Interface;
using CarTech.Data.Interface.Base;
using CarTech.Data.Repository;
using System.Threading.Tasks;

namespace CarTech.Data.Repository.Base
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private CarTechContext _context;
        private IClienteRepository _cliente;
        private IUserRepository _user;
        private ICategoriaRepository _categoria;

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
        public ICategoriaRepository Categoria
        {
            get
            {
                if (_categoria == null)
                {
                    _categoria = new CategoriaRepository(_context);
                }
                return _categoria;
            }
        }

        public IUserRepository User
        {
            get
            {
                if (_user == null)
                {
                    _user = new UserRepository(_context);
                }
                return _user;
            }
        }


        public RepositoryWrapper(CarTechContext context)
        {
            _context = context;
        }

        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
