using Frame.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Frame.ApplicationCore.Bases
{
    public class EfRepositoryBase<TDbContext, TEntity, TPrimaryKey> : RepositoryBase<TEntity, TPrimaryKey>
        where TEntity : class
        where TDbContext : FrameDbContext
    {

        public virtual TDbContext Context { private set; get; }

        public virtual DbSet<TEntity> Table => Context.Set<TEntity>();

        public EfRepositoryBase(TDbContext context)
        {
            Context = context;
        }




        public override int Count()
        {
            return Table.Count();
        }

        public override int Count(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public override async Task<int> CountAsync()
        {
            return await Task.FromResult(Table.Count());
        }

        public override Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public override void Delete(TEntity entity)
        {
            Table.Remove(entity);
        }

        public override void Delete(TPrimaryKey id)
        {
            var entity = Get(id);
            Table.Remove(entity);
        }

        public override void Delete(Expression<Func<TEntity, bool>> predicate)
        {
            var entity = Table.SingleOrDefault(predicate);
            if (entity != null)
            {
                Table.Remove(entity);
            }
        }

        public override async Task DeleteAsync(TEntity entity)
        {
            await Task.FromResult(Table.Remove(entity));
        }

        public override async Task DeleteAsync(TPrimaryKey id)
        {
            var entity = await Task.FromResult(Get(id));
            await Task.FromResult(Table.Remove(entity));
        }

        public override async Task DeleteAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var entity = await Task.FromResult(Table.SingleOrDefault(predicate));
            await DeleteAsync(entity);
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }


        public override TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return Table.FirstOrDefault(predicate);
        }


        public override async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Task.FromResult(FirstOrDefault(predicate));
        }

        /// <summary>
        /// 根据主键构建判断表达式
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        protected static Expression<Func<TEntity, bool>> CreateEqualityExpressionForId(TPrimaryKey id)
        {
            var lambdaParam = Expression.Parameter(typeof(TEntity));
            var lambdaBody = Expression.Equal(
                Expression.PropertyOrField(lambdaParam, "Id"),
                Expression.Constant(id, typeof(TPrimaryKey))
                );

            return Expression.Lambda<Func<TEntity, bool>>(lambdaBody, lambdaParam);
        }

        public override TEntity Get(TPrimaryKey id)
        {
            return Table.SingleOrDefault(CreateEqualityExpressionForId(id));
        }


        public override List<TEntity> GetAllList()
        {
            return Table.ToList();
        }

        public override List<TEntity> GetAllList(Expression<Func<TEntity, bool>> predicate)
        {
            return Table.Where(predicate).ToList();
        }

        public override async Task<List<TEntity>> GetAllListAsync()
        {
            return await Task.FromResult(GetAllList());
        }

        public override async Task<List<TEntity>> GetAllListAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Table.Where(predicate).ToListAsync();
        }

        public override async Task<TEntity> GetAsync(TPrimaryKey id)
        {
            return await Task.FromResult(Get(id));
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override TEntity Insert(TEntity entity)
        {
            return Table.Add(entity).Entity;
        }

        public override async Task<TEntity> InsertAsync(TEntity entity)
        {
            return await Task.FromResult(Insert(entity));
        }


        public override T Query<T>(Func<IQueryable<TEntity>, T> queryMethod)
        {
            throw new NotImplementedException();
        }

        public override TEntity Single(Expression<Func<TEntity, bool>> predicate)
        {
            return Table.Single(predicate);
        }

        public override async Task<TEntity> SingleAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Task.FromResult(Single(predicate));
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public override TEntity Update(TEntity entity)
        {
            AttachIfNot(entity);
            Context.Entry<TEntity>(entity).State = EntityState.Modified;
            return entity;
        }

        public override TEntity Update(TPrimaryKey id, Action<TEntity> updateAction)
        {
            throw new NotImplementedException();
        }

        public override async Task<TEntity> UpdateAsync(TEntity entity)
        {
            return await Task.FromResult(Update(entity));
        }

        public override Task<TEntity> UpdateAsync(TPrimaryKey id, Func<TEntity, Task> updateAction)
        {
            throw new NotImplementedException();
        }

        public override IQueryable<TEntity> GetAll()
        {
            return Table;
        }

        public override IQueryable<TEntity> GetAllIncluding(params Expression<Func<TEntity, object>>[] propertySelectors)
        {
            throw new NotImplementedException();
        }

        public override int Commit()
        {
            return Context.SaveChanges();
        }

        public override async Task<int> CommitAsync()
        {
            return await Context.SaveChangesAsync();
        }

        protected override void AttachIfNot(TEntity entity)
        {
            if (Enumerable.FirstOrDefault<EntityEntry>(this.Context.ChangeTracker.Entries(), delegate (EntityEntry ent)
            {
                return ent.Entity == entity;
            }) == null)
            {
                this.Table.Attach(entity);
            }
        }

        public override IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
        {
            return Table.Where(predicate);
        }
    }
}
