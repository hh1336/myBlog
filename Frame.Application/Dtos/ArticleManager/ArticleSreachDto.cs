using Frame.ApplicationCore.DtoBases;
using System;
using System.Collections.Generic;
using System.Text;

namespace Frame.Application.Dtos.ArticleManager
{
    /// <summary>
    /// 文章检索dto
    /// </summary>
    public class ArticleSreachDto : SreachDtoBase
    {
        /// <summary>
        /// 根据标题查找
        /// </summary>
        public string AcName { set; get; }
    }
}
