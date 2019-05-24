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
        /// 介绍信息
        /// </summary>
        public string Introduce { set; get; }

        /// <summary>
        /// 封面图片
        /// </summary>
        public string ImgUrl { set; get; }

        /// <summary>
        /// 喜欢数量
        /// </summary>
        [DefaultValue(0)]
        public long Like { set; get; }

        /// <summary>
        /// 文章内容
        /// </summary>
        public string Content { set; get; }

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
        public List<ArticleComment> ArticleComments { set; get; }

        /// <summary>
        /// 菜单导航属性
        /// </summary>
        public AdminMenu AdminMenu { set; get; }

        /// <summary>
        /// 关联菜单id
        /// </summary>
        [ForeignKey("AdminMenu")]
        public Guid? MenuId { set; get; }
    }
}
