using Frame.Core.EntityBases;
using Frame.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Frame.Core.Entitys
{
    /// <summary>
    /// 用户留言表
    /// </summary>
    public class LeaveMessage : EntityBase
    {
        public LeaveMessage()
        {
            this.ChildEntitis = new HashSet<LeaveMessage>(); //自关联
        }
        /// <summary>
        /// 留言时间
        /// </summary>
        public DateTime LeaveTime { set; get; }

        /// <summary>
        /// 留言信息
        /// </summary>
        public string MessAge { set; get; }

        /// <summary>
        /// 留言人ip
        /// </summary>
        public string Ip { set; get; }

        /// <summary>
        /// 显示昵称
        /// </summary>
        public string NickName { set; get; }

        /// <summary>
        /// 是否删除
        /// </summary>
        public YesOrNoEnum SortDel { set; get; }

        /// <summary>
        /// 联系方式
        /// </summary>
        public string ContactInformation { set; get; }

        /// <summary>
        /// 所有回复评论
        /// </summary>
        [ForeignKey("ParentId")]
        public virtual ICollection<LeaveMessage> ChildEntitis { set; get; }

        /// <summary>
        /// 父级评论
        /// </summary>
        public virtual LeaveMessage ParentEntity { set; get; }

        /// <summary>
        /// 父级评论id
        /// </summary>
        public Guid? ParentId { set; get; }
    }
}
