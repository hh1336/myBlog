using Frame.Application.Dtos.ArticleManager;
using Frame.ApplicationCore.Common;
using Frame.Core.Entitys;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Frame.Application.Interfaces
{
    /// <summary>
    /// 日志分享接口
    /// </summary>
    public interface IMyLogService
    {
        /// <summary>
        /// 获取所有标签
        /// </summary>
        /// <returns></returns>
        Task<List<Classify>> GetAllLabel();

        /// <summary>
        /// 获取文章
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<IPageList<Article>> GetArticles(ArticleSreachDto data);
    }
}
