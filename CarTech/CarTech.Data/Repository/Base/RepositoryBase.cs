using CarTech.Data.Context;
using CarTech.Data.Interface.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace CarTech.Data.Repository.Base
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected CarTechContext _context { get; set; }

        public RepositoryBase(CarTechContext context)
        {
            _context = context;
        }

        public void Create(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            _context.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public IQueryable<T> FindAll()
        {
            return _context.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression).AsNoTracking();
        }

        
    }
}
