using Frame.Core.EntityBases;
using Frame.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Frame.Core.Entitys
{
    /// <summary>
    /// 用户实体类
    /// </summary>
    public class UserInfo : EntityBase
    {
        /// <summary>
        /// 用户姓名
        /// </summary>
        [Required]
        public string UserName { set; get; }

        /// <summary>
        /// 性别
        /// </summary>
        [Required]
        public SexEnum Sex { set; get; }

        /// <summary>
        /// 是否软删除
        /// </summary>
        [DefaultValue(0)]
        public int SortDel { set; get; }

        /// <summary>
        /// 用户年龄
        /// </summary>
        public int? Age { set; get; }

        /// <summary>
        /// 住址
        /// </summary>
        public string Address { set; get; }

        /// <summary>
        /// 用户邮箱
        /// </summary>
        public string Email { set; get; }

        /// <summary>
        /// 手机号
        /// </summary>
        [Phone]
        public string Phone { set; get; }

        /// <summary>
        /// 照片
        /// </summary>
        public string Photo { set; get; }


        /// <summary>
        /// 个人简介
        /// </summary>
        public string Introduce { set; get; }


        /// <summary>
        /// 用户账户
        /// </summary>
        public ICollection<Account> Accounts { set; get; } 
    }
}
