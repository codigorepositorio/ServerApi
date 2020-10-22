using Demo.WebApi.NetCore.Contracts;
using Demo.WebApi.NetCore.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Demo.WebApi.NetCore.Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected ContextDatabase RepositoryContext;

        public RepositoryBase(ContextDatabase repositoryContext)
        {
            RepositoryContext = repositoryContext;
        }
       
        public IQueryable<T> FindAll(bool trackChanges)
        {
            return !trackChanges ? RepositoryContext.Set<T>().AsNoTracking() 
                                 : RepositoryContext.Set<T>();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges)
        {
            return !trackChanges ? RepositoryContext.Set<T>().Where(expression).AsNoTracking() : //False
                                   RepositoryContext.Set<T>().Where(expression);                 //True
        }
       
        public void Create(T entity) => RepositoryContext.Set<T>().Add(entity);
        public void Delete(T entity) => RepositoryContext.Set<T>().Update(entity);
        public void Update(T entity) => RepositoryContext.Set<T>().Remove(entity);
        
    }
}
