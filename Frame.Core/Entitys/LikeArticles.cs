using Frame.Core.EntityBases;
using System;
using System.Collections.Generic;
using System.Text;

namespace Frame.Core.Entitys
{
    /// <summary>
    /// 点赞的用户
    /// </summary>
    public class LikeArticles : EntityBase
    {
        /// <summary>
        /// 用户ip
        /// </summary>
        public string IP { set; get; }

        /// <summary>
        /// 点赞时间
        /// </summary>
        public DateTime LikeTime { set; get; }

        /// <summary>
        /// 点赞文章id
        /// </summary>
        public Guid? ArticleId { set; get; }

        /// <summary>
        /// 导航属性
        /// </summary>
        public Article Article { set; get; }
    }
}
