using Frame.Core.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
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

        public virtual DbSet<Article> Articles { set; get; }
        public virtual DbSet<ArticleComment> ArticleComments { set; get; }
        public virtual DbSet<ArticleImage> ArticleImages { set; get; }
        public virtual DbSet<Classify> Classifies { set; get; }
        public virtual DbSet<LeaveMessage> LeaveMessages { set; get; }



        #endregion

    }
}
