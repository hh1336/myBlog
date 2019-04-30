using System;
using System.Collections.Generic;
using System.Text;

namespace Frame.ApplicationCore.DtoBases
{
    /// <summary>
    /// 继承Dto时间基类,默认使用Guid为主键
    /// </summary>
    public class DtoTimeBase : DtoTimeBase<Guid>
    {

    }

    /// <summary>
    /// Dto时间基类
    /// </summary>
    /// <typeparam name="TKey">主键类型</typeparam>
    public class DtoTimeBase<TKey> : DtoBase<TKey>
        where TKey : struct
    {
        /// <summary>
        /// 创建时间
        /// </summary>
        public virtual DateTime? CreateTime { set; get; }

        /// <summary>
        /// 创建用户
        /// </summary>
        public virtual TKey? CreateUser { set; get; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public virtual DateTime? UpdateTime { set; get; }

        /// <summary>
        /// 修改用户
        /// </summary>
        public virtual TKey? UpdateUser { set; get; }

        /// <summary>
        /// 删除时间
        /// </summary>
        public virtual DateTime? DelTime { set; get; }

        /// <summary>
        /// 删除用户
        /// </summary>
        public virtual TKey? DelUser { set; get; }

        /// <summary>
        /// 软删除
        /// </summary>
        public virtual int? SortDel { set; get; }
    }
}
