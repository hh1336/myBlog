using Frame.Core.Authorization.Enums;
using Frame.Core.Authorization.Roles;
using Frame.Core.EntityBases;
using Frame.Core.Entitys;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Frame.Core.Authorization
{
    public class Permission : EntityBase
    {
        /// <summary>
        /// 角色主键
        /// </summary>
        [ForeignKey("Role")]
        public Guid? RoleId { set; get; }

        /// <summary>
        /// 菜单主键
        /// </summary>
        [ForeignKey("AdminMenu")]
        public Guid? MenuId { set; get; }

        /// <summary>
        /// 账号主键
        /// </summary>
        [ForeignKey("Account")]
        public Guid? AccountId { set; get; }

        /// <summary>
        /// 操作功能
        /// </summary>
        public CRUDEnum ActionType { set; get; }

        /// <summary>
        /// 导航属性
        /// </summary>
        public Role Role { set; get; }

        /// <summary>
        /// 导航属性
        /// </summary>
        public AdminMenu AdminMenu { set; get; }

        /// <summary>
        /// 导航属性
        /// </summary>
        public Account Account { set; get; }
    }
}
