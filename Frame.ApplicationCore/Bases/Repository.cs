using Frame.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Frame.ApplicationCore.Bases
{
    public class Repository<TEntity> : Repository<TEntity,Guid>
        where TEntity : class
    {
        public Repository(FrameDbContext db) : base(db)
        {

        }
    }

    public class Repository<TEntity, TPrimaryKey> : EfRepositoryBase<FrameDbContext, TEntity, TPrimaryKey>
        where TEntity :class
    {
        public Repository(FrameDbContext db):base(db)
        {

        }
    }
}
