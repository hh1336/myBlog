using Frame.Core.Authorization;
using Frame.Core.EntityBases;
using Frame.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Frame.Core.Entitys
{
    /// <summary>
    /// 菜单实体
    /// </summary>
    public class AdminMenu : EntityTimeBase
    {
        /// <summary>
        /// 菜单名称
        /// </summary>
        public string MenuName { set; get; }

        /// <summary>
        /// 展示名称
        /// </summary>
        public string ShowName { set; get; }

        /// <summary>
        /// 图标地址
        /// </summary>
        public string IconAddress { set; get; }

        /// <summary>
        /// 链接地址
        /// </summary>
        public string LinkAddress { set; get; }

        /// <summary>
        /// 排序号
        /// </summary>
        public int SortNumber { set; get; }

        /// <summary>
        /// 是否显示
        /// </summary>
        public YesOrNoEnum IsShow { set; get; }

        /// <summary>
        /// 是否为系统默认菜单
        /// </summary>
        public YesOrNoEnum IsSystemDefault { set; get; }

        /// <summary>
        /// 父级菜单id
        /// </summary>
        [ForeignKey("adminMenu")]
        public Guid? Pid { set; get; }

        /// <summary>
        /// 导航属性
        /// </summary>
        public AdminMenu adminMenu { set; get; }

        /// <summary>
        /// 导航属性
        /// </summary>
        public ICollection<AdminMenu> AdminMenus { set; get; }

        /// <summary>
        /// 导航属性
        /// </summary>
        public ICollection<Permission> Permissions { set; get; }

        /// <summary>
        /// 导航属性
        /// </summary>
        public ICollection<Classify> Classifies { set; get; }

    }
}
