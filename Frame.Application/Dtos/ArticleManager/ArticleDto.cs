using Frame.ApplicationCore.DtoBases;
using Frame.Core.Entitys;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Frame.Application.Dtos.ArticleManager
{
    /// <summary>
    /// 文章Dto
    /// </summary>
    public class ArticleDto : DtoTimeBase
    {
        /// <summary>
        /// 文章名
        /// </summary>
        public string AcName { set; get; }

        /// <summary>
        /// 喜欢数量
        /// </summary>
        [DefaultValue(0)]
        public long Like { set; get; }

        /// <summary>
        /// 文章内容key
        /// </summary>
        public string ContentKey { set; get; }

        /// <summary>
        /// 关联分类
        /// </summary>
        public Classify Classify { set; get; }

        /// <summary>
        /// 关联分类
        /// </summary>
        [ForeignKey("Classify")]
        public Guid? ClassifyId { set; get; }

        /// <summary>
        /// 导航属性
        /// </summary>
        public List<ArticleImage> ArticleImages { set; get; }

        /// <summary>
        /// 导航属性
        /// </summary>
        public List<ArticleComment> ArticleComments { set; get; }
    }
}
