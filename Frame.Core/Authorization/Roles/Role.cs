using Frame.Core.Authorization.Enums;
using Frame.Core.EntityBases;
using Frame.Core.Entitys;
using Frame.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Frame.Core.Authorization.Roles
{
    /// <summary>
    /// 角色表
    /// </summary>
    public class Role : EntityTimeBase
    {
        /// <summary>
        /// 角色名
        /// </summary>
        public string RoleName { set; get; }

        /// <summary>
        /// 角色类型
        /// </summary>
        public RoleTypeEnum RoleState { set; get; }

        /// <summary>
        /// 是否为系统默认账户
        /// </summary>
        public YesOrNoEnum IsSystemDefault { set; get; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Describe { set; get; }

        /// <summary>
        /// 导航属性
        /// </summary>
        public ICollection<Permission> Permissions { set; get; }

        /// <summary>
        /// 导航属性
        /// </summary>
        public ICollection<AccountRole> AccountRoles { set; get; }
    }
}
