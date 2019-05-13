using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Frame.Core.EntityBases
{
    /// <summary>
    /// 继承实体基类，默认主键为Guid
    /// </summary>
    public class EntityBase : EntityBase<Guid>
    {
        public EntityBase()
        {
            base.ID = Guid.NewGuid();
        }
    }

    /// <summary>
    /// 实体基类
    /// </summary>
    /// <typeparam name="TKey">主键</typeparam>
    public class EntityBase<TKey>
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        public virtual TKey ID { set; get; }
    }
}
