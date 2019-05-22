using Frame.Core.EntityBases;
using Frame.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Frame.Core.Entitys
{
    /// <summary>
    /// 文章评论
    /// </summary>
    public class ArticleComment : EntityBase
    {
        public ArticleComment()
        {
            base.ID = Guid.NewGuid();
            this.SortDel = YesOrNoEnum.否;
            this.IsMe = YesOrNoEnum.否;
            this.ChildEntitis = new HashSet<ArticleComment>(); //自关联
        }

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

        /// <summary>
        /// 所有回复评论
        /// </summary>
        [ForeignKey("ParentId")]
        public virtual ICollection<ArticleComment> ChildEntitis { set; get; }

        /// <summary>
        /// 父级评论
        /// </summary>
        public virtual ArticleComment ParentEntity { set; get; }

        /// <summary>
        /// 父级评论id
        /// </summary>
        public Guid? ParentId { set; get; }

        /// <summary>
        /// 是否是我的回复
        /// </summary>
        public YesOrNoEnum IsMe { set; get; }
    }
}