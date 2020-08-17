using System.Threading.Tasks;

namespace CarTech.Registration.Data.Interface.Base
{
    public interface IRepositoryWrapper
    {
        IClienteRepository Cliente { get; }
        Task<bool> SaveAsync();
    }
}
