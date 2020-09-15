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
    public class CategoriaRepository : RepositoryBase<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(CarTechContext context)
        : base(context)
        {
            _context = context;
        }

        public void CreateCategoria(Categoria categoria)
        {
            Create(categoria);
        }

        public void DeleteCategoria(Categoria categoria)
        {
            Delete(categoria);
        }

        public async Task<IEnumerable<Categoria>> GetAllCategoriasAsync()
        {
            return await FindAll().OrderBy(o => o.Descricao).ToListAsync();
        }

        public async Task<Categoria> GetCategoriaByIdAsync(int categoriaId)
        {
            return await FindByCondition(categoria => categoria.Id.Equals(categoriaId)).FirstOrDefaultAsync();
        }

        public void UpdateCategoria(Categoria categoria)
        {
            Update(categoria);
        }
    }
}
