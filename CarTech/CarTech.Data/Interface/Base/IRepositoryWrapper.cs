using System.Threading.Tasks;

namespace CarTech.Data.Interface.Base
{
    public interface IRepositoryWrapper
    {
        IClienteRepository Cliente { get; }
        ICategoriaRepository Categoria { get; }
        IUserRepository User { get; }
        Task<bool> SaveAsync();
    }
}
