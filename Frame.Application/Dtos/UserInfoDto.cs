using Frame.ApplicationCore.DtoBases;
using Frame.Core.Entitys;
using Frame.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Frame.Application.Dtos
{
    /// <summary>
    /// UserInfo实体的Dto
    /// </summary>
    public class UserInfoDto : DtoTimeBase
    {
        /// <summary>
        /// 用户姓名
        /// </summary>
        [StringLength(20)]
        public string UserName { set; get; }

        /// <summary>
        /// 用户年龄
        /// </summary>
        [MaxLength(+2, ErrorMessage = "年龄不能超过100")]
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
        public List<Account> Accounts { set; get; }
    }
}
