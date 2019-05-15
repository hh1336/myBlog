using Frame.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Frame.ApplicationCore.Bases
{
    /// <summary>
    /// 仓储实现类
    /// </summary>
    public abstract class RepositoryBase<TEntity, TPrimaryKey> : IRepository<TEntity,TPrimaryKey> where TEntity : class
    {
        protected abstract void AttachIfNot(TEntity entity);
        public abstract int Commit();
        public abstract Task<int> CommitAsync();
        public abstract int Count();
        public abstract int Count(Expression<Func<TEntity, bool>> predicate);
        public abstract Task<int> CountAsync();
        public abstract Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate);
        public abstract bool Delete(TEntity entity);
        public abstract bool Delete(TPrimaryKey id);
        public abstract bool Delete(Expression<Func<TEntity, bool>> predicate);
        public abstract Task<bool> DeleteAsync(TEntity entity);
        public abstract Task<bool> DeleteAsync(TPrimaryKey id);
        public abstract Task<bool> DeleteAsync(Expression<Func<TEntity, bool>> predicate);
        public abstract TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate);
        public abstract Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
        public abstract TEntity Get(TPrimaryKey id);
        public abstract IQueryable<TEntity> GetAll();
        public abstract IQueryable<TEntity> GetAllIncluding(params Expression<Func<TEntity, object>>[] propertySelectors);
        public virtual List<TEntity> GetAllList() {
            return GetAll().ToList();
        }
        public abstract List<TEntity> GetAllList(Expression<Func<TEntity, bool>> predicate);
        public virtual async Task<List<TEntity>> GetAllListAsync() {
            return await Task.FromResult(GetAllList());
        }
        public abstract Task<List<TEntity>> GetAllListAsync(Expression<Func<TEntity, bool>> predicate);
        public abstract Task<TEntity> GetAsync(TPrimaryKey id);
        public abstract TEntity Insert(TEntity entity);
        public abstract Task<TEntity> InsertAsync(TEntity entity);
        public abstract T Query<T>(Func<IQueryable<TEntity>, T> queryMethod);
        public abstract TEntity Single(Expression<Func<TEntity, bool>> predicate);
        public abstract Task<TEntity> SingleAsync(Expression<Func<TEntity, bool>> predicate);
        public abstract TEntity Update(TEntity entity);
        public abstract TEntity Update(TPrimaryKey id, Action<TEntity> updateAction);
        public abstract Task<TEntity> UpdateAsync(TEntity entity);
        public abstract Task<TEntity> UpdateAsync(TPrimaryKey id, Func<TEntity, Task> updateAction);
        public abstract IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate);
    }
}
