using Frame.Core.Entitys;
using Microsoft.EntityFrameworkCore;
using System;

namespace Frame.EntityFrameworkCore
{
    public class FrameDbContext : DbContext
    {
        public FrameDbContext(DbContextOptions<FrameDbContext> options)
            : base(options)
        {

        }

        #region 注册实体

        public virtual DbSet<UserInfo> UserInfos { set; get; }

        public virtual DbSet<Account> Accounts { set; get; }

        #endregion

    }
}
