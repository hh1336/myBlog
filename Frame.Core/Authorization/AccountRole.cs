using Frame.Core.Authorization.Roles;
using Frame.Core.EntityBases;
using Frame.Core.Entitys;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Frame.Core.Authorization
{
    /// <summary>
    /// 账号角色表
    /// </summary>
    public class AccountRole : EntityBase
    {
        /// <summary>
        /// 账号ID
        /// </summary>
        [ForeignKey("Account")]
        public Guid? AccountId { set; get; }

        /// <summary>
        /// 角色ID
        /// </summary>
        [ForeignKey("Role")]
        public Guid? RoleId { set; get; }

        /// <summary>
        /// 导航属性
        /// </summary>
        public Account Account { set; get; }

        /// <summary>
        /// 导航属性
        /// </summary>
        public Role Role { get; set; }
    }
}
