using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

namespace Demo.WebApi.NetCore.Contracts
{
  public interface IRepositoryBase<T>
    {
        //Encontrar Todas(GetAll)
        IQueryable<T> FindAll(bool trackChanges);

        //Encontrar por Condiciòn (GetByCondition)
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges);

        //Crear
        void Create(T entity);

        //Modificar
        void Update(T entity);

        //Eliminar
        void Delete(T entity);
    }
}
