using CarTech.Data.Context;
using CarTech.Data.Interface;
using CarTech.Data.Repository.Base;
using CarTech.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarTech.Data.Repository
{
    public class ClienteRepository : RepositoryBase<Cliente>, IClienteRepository
    {
        public ClienteRepository(CarTechContext context)
            : base(context)
        {
            _context = context;
        }

        public void CreateCliente(Cliente cliente)
        {
            Create(cliente);
        }

        public void UpdateCliente(Cliente cliente)
        {
            Update(cliente);
        }

        public void DeleteCliente(Cliente cliente)
        {
            Delete(cliente);
        }

        public async Task<IEnumerable<Cliente>> GetAllClientesAsync()
        {
            return await FindAll().OrderBy(o => o.Nome).ToListAsync();
        }

        public async Task<Cliente> GetClienteByIdAsync(int clienteId)
        {
            return await FindByCondition(cliente => cliente.Id.Equals(clienteId)).FirstOrDefaultAsync();
        }

       
    }
}
