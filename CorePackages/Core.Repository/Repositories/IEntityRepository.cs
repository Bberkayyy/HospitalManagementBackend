using Core.Repository.EntityBaseModel;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Core.Repository.Repositories;

public interface IEntityRepository<TEntity, TId> where TEntity : Entity<TId>
{
    void Add(TEntity entity);

    void Delete(TEntity entity);

    void Uptade(TEntity entity);




    List<TEntity> GetAll(

        Expression<Func<TEntity, bool>>? predicate = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null

        );


    TEntity? GetById(

        TId id,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null

        );

    TEntity? GetByFilter(

        Expression<Func<TEntity, bool>> predicate,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null

        );

}
