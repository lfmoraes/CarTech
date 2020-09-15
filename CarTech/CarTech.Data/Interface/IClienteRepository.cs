using CarTech.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarTech.Data.Interface
{
    public interface IClienteRepository
    {
        Task<IEnumerable<Cliente>> GetAllClientesAsync();
        Task<Cliente> GetClienteByIdAsync(int clienteId);
        void CreateCliente(Cliente cliente);
        void UpdateCliente(Cliente cliente);
        void DeleteCliente(Cliente cliente);
    }
}
