using System;
using System.Collections.Generic;
using System.Text;

namespace Frame.ApplicationCore.DtoBases
{
    /// <summary>
    /// 继承Dto基类，默认主键为Guid
    /// </summary>
    public class DtoBase : DtoBase<Guid>
    {

    }

    /// <summary>
    /// Dto主键基类
    /// </summary>
    /// <typeparam name="TKey">主键类型</typeparam>
    public class DtoBase<TKey>
    {
        /// <summary>
        /// 主键
        /// </summary>
        public TKey ID { set; get; }
    }
}
