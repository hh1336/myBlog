using Frame.ApplicationCore.DtoBases;
using Frame.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Frame.Application.Dtos.Discuss
{
    /// <summary>
    /// 评论dto
    /// </summary>
    public class ArticleCommentDto : DtoBase
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
        /// 父级评论id
        /// </summary>
        public Guid? ParentId { set; get; }
    }
}
