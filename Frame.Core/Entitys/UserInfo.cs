using Frame.Core.EntityBases;
using Frame.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Frame.Core.Entitys
{
    /// <summary>
    /// 用户实体类，继承时间基类
    /// </summary>
    public class UserInfo : EntityTimeBase
    {
        /// <summary>
        /// 用户姓名
        /// </summary>
        public string UserName { set; get; }

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
        /// 性别
        /// </summary>
        public SexEnum Sex { set; get; }

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
        /// 用户账户
        /// </summary>
        public ICollection<Account> Accounts { set; get; } 
    }
}
