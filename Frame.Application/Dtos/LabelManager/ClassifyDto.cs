﻿using Frame.ApplicationCore.DtoBases;
using Frame.Core.Entitys;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Frame.Application.Dtos.LabelManager
{
    /// <summary>
    /// 标签表Dto
    /// </summary>
    public class ClassifyDto : DtoBase
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
        public Guid? AdminMenuId { set; get; }

        /// <summary>
        /// 导航属性
        /// </summary>
        public ICollection<Article> Articles { set; get; }
    }
}
