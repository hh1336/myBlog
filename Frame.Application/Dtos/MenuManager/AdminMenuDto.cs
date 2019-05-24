using Frame.ApplicationCore.DtoBases;
using Frame.Core.Authorization;
using Frame.Core.Entitys;
using Frame.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Frame.Application.Dtos.MenuManager
{
    /// <summary>
    /// 菜单dto
    /// </summary>
    public class AdminMenuDto : DtoTimeBase
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
        public Guid? Pid { set; get; }

        /// <summary>
        /// 导航属性
        /// </summary>
        public virtual AdminMenuDto ParentEntity { set; get; }

        /// <summary>
        /// 导航属性
        /// </summary>
        [ForeignKey("Pid")]
        public virtual ICollection<AdminMenuDto> ChildEntitis { set; get; }

        /// <summary>
        /// 导航属性
        /// </summary>
        public List<Classify> Classifies { set; get; }

        /// <summary>
        /// 文章导航属性
        /// </summary>
        public List<Article> Articles { set; get; }
    }
}
