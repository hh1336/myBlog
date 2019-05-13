using Frame.Core.EntityBases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Frame.Core.Entitys
{
    /// <summary>
    /// 分类表
    /// </summary>
    public class Classify : EntityBase
    {
        /// <summary>
        /// 分类名
        /// </summary>
        public string Name { set; get; }

        /// <summary>
        /// 分类对应的菜单
        /// </summary>
        public AdminMenu AdminMenu { set; get; }

        /// <summary>
        /// 菜单id
        /// </summary>
        [ForeignKey("AdminMenu")]
        public Guid? AdminMenuId { set; get; }

        /// <summary>
        /// 导航属性
        /// </summary>
        public ICollection<Article> Articles { set; get; }
    }
}
