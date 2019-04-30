using Frame.ApplicationCore.DtoBases;
using Frame.Core.Authorization;
using Frame.Core.Entitys;
using Frame.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Frame.Application.Dtos
{
    /// <summary>
    /// 账户Dto
    /// </summary>
    public class AccountDto : DtoTimeBase
    {
        /// <summary>
        /// 账号
        /// </summary>
        [Required]
        [StringLength(6)]
        public string AccountNumber { set; get; }

        /// <summary>
        /// 密码
        /// </summary>
        [Required]
        public string PassWord { set; get; }

        /// <summary>
        /// 账户状态
        /// </summary>
        public AccountStateEnum AccountState { set; get; }

        /// <summary>
        /// 旧密码
        /// </summary>
        public string OldPassWord { set; get; }

        /// <summary>
        /// 外键，关联用户信息
        /// </summary>
        [ForeignKey("UserInfo")]
        public Guid? UserInfoId { set; get; }

        /// <summary>
        /// 登陆次数
        /// </summary>
        public int LoginCount { set; get; }

        /// <summary>
        /// 最后一次登陆的IP地址
        /// </summary>
        public string LastLoginIp { set; get; }

        /// <summary>
        /// 最后一次登陆的时间
        /// </summary>
        public DateTime? LastLoginTime { set; get; }

        /// <summary>
        /// 导航属性
        /// </summary>
        public UserInfo UserInfo { set; get; }

        /// <summary>
        /// 导航属性
        /// </summary>
        public List<AccountRole> AccountRoles { set; get; }

        /// <summary>
        /// 导航属性
        /// </summary>
        public List<Permission> Permissions { set; get; }
    }
}
