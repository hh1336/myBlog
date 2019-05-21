using Frame.ApplicationCore.DtoBases;
using Frame.Core.Entitys;
using Frame.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Frame.Application.Dtos
{
    /// <summary>
    /// UserInfo实体的Dto
    /// </summary>
    public class UserInfoDto : DtoBase
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
        /// 是否软删除
        /// </summary>
        public int SortDel { set; get; }

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
        public string Phone { set; get; }

        /// <summary>
        /// 照片
        /// </summary>
        public string Photo { set; get; }

        /// <summary>
        /// 用户账户
        /// </summary>
        public List<Account> Accounts { set; get; }

        /// <summary>
        /// 个人简介
        /// </summary>
        public string Introduce { set; get; }
    }
}
