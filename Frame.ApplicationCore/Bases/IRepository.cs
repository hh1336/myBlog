using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Frame.ApplicationCore.Bases
{

    /// <summary>
    /// 仓储接口
    /// </summary>
    public interface IRepository<TEntity, TPrimaryKey> where TEntity : class
    {
        #region Select/Get/Query

        IQueryable<TEntity> GetAll();

        IQueryable<TEntity> GetAllIncluding(params Expression<Func<TEntity, object>>[] propertySelectors);

        List<TEntity> GetAllList();

        Task<List<TEntity>> GetAllListAsync();

        List<TEntity> GetAllList(Expression<Func<TEntity, bool>> predicate);

        Task<List<TEntity>> GetAllListAsync(Expression<Func<TEntity, bool>> predicate);

        T Query<T>(Func<IQueryable<TEntity>, T> queryMethod);

        TEntity Get(TPrimaryKey id);

        Task<TEntity> GetAsync(TPrimaryKey id);

        TEntity Single(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity> SingleAsync(Expression<Func<TEntity, bool>> predicate);


        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);

        IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate);

        #endregion

        #region Insert

        TEntity Insert(TEntity entity);

        Task<TEntity> InsertAsync(TEntity entity);

        #endregion

        #region Update

        TEntity Update(TEntity entity);

        Task<TEntity> UpdateAsync(TEntity entity);

        TEntity Update(TPrimaryKey id, Action<TEntity> updateAction);

        Task<TEntity> UpdateAsync(TPrimaryKey id, Func<TEntity, Task> updateAction);

        #endregion

        #region Delete

        bool Delete(TEntity entity);

        Task<bool> DeleteAsync(TEntity entity);

        bool Delete(TPrimaryKey id);

        Task<bool> DeleteAsync(TPrimaryKey id);

        bool Delete(Expression<Func<TEntity, bool>> predicate);

        Task<bool> DeleteAsync(Expression<Func<TEntity, bool>> predicate);

        #endregion

        #region Aggregates

        int Count();

        Task<int> CountAsync();

        int Count(Expression<Func<TEntity, bool>> predicate);

        Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate);

        int Commit();

        Task<int> CommitAsync();

        #endregion

    }
}
