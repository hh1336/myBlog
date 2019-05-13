using Frame.Core.EntityBases;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Frame.Core.Entitys
{
    /// <summary>
    /// 文章图片信息
    /// </summary>
    public class ArticleImage : EntityBase
    {
        /// <summary>
        /// 图片路径
        /// </summary>
        public string url { set; get; }

        /// <summary>
        /// 导航属性
        /// </summary>
        public Article Article { set; get; }

        /// <summary>
        /// 关联文章
        /// </summary>
        [ForeignKey("Article")]
        public Guid? ArticleId { set; get; }
    }
}