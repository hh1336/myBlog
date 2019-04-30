using System;
using System.Collections.Generic;
using System.Text;

namespace Frame.Core.EntityBases
{
    /// <summary>
    /// 继承时间字段基类，默认主键为Guid
    /// </summary>
    public class EntityTimeBase : EntityTimeBase<Guid>
    {

    }

    /// <summary>
    /// 时间字段基类
    /// </summary>
    /// <typeparam name="TKey">设定主键</typeparam>
    public class EntityTimeBase<TKey> : EntityBase<TKey>
        where TKey : struct
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public EntityTimeBase()
        {
            CreateTime = DateTime.Now.Date;
            SortDel = 0;
        }

        /// <summary>
        /// 创建时间
        /// </summary>
        public virtual DateTime CreateTime { set; get; }

        /// <summary>
        /// 创建用户
        /// </summary>
        public virtual Nullable<TKey> CreateUser { set; get; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public virtual Nullable<DateTime> UpdateTime { set; get; }

        /// <summary>
        /// 修改用户
        /// </summary>
        public virtual Nullable<TKey> UpdateUser { set; get; }

        /// <summary>
        /// 删除时间
        /// </summary>
        public virtual Nullable<DateTime> DelTime { set; get; }

        /// <summary>
        /// 删除用户
        /// </summary>
        public virtual Nullable<TKey> DelUser { set; get; }

        /// <summary>
        /// 软删除
        /// </summary>
        public virtual int SortDel { set; get; }

    }
}
