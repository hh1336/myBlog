using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Frame.Application.Dtos.ArticleManager;
using Frame.ApplicationCore.Common;
using Frame.Core.Entitys;

namespace Frame.Application.Interfaces
{
    /// <summary>
    /// 我的笔记服务接口
    /// </summary>
    public interface IMyNoteService
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
