using CarTech.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarTech.Data.Interface
{
    public interface ICategoriaRepository
    {
        Task<IEnumerable<Categoria>> GetAllCategoriasAsync();
        Task<Categoria> GetCategoriaByIdAsync(int categoriaId);
        void CreateCategoria(Categoria categoria);
        void UpdateCategoria(Categoria categoria);
        void DeleteCategoria(Categoria categoria);
    }
}
