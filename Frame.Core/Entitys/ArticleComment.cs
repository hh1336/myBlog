﻿using Frame.Core.EntityBases;
using Frame.Core.Enums;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Frame.Core.Entitys
{
    /// <summary>
    /// 文章评论
    /// </summary>
    public class ArticleComment : EntityBase
    {
        /// <summary>
        /// 评论时间
        /// </summary>
        public DateTime CommentTime { set; get; }

        /// <summary>
        /// ip地址
        /// </summary>
        public string Ip { set; get; }

        /// <summary>
        /// 内容
        /// </summary>
        public string Content { set; get; }

        /// <summary>
        /// 是否删除
        /// </summary>
        public YesOrNoEnum SortDel { set; get; }

        /// <summary>
        /// 联系方式
        /// </summary>
        public string ContactInformation { set; get; }

        /// <summary>
        /// 显示昵称
        /// </summary>
        public string NickName { set; get; }

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