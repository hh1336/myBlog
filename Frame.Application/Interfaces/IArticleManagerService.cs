using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Frame.Application.Dtos.ArticleManager;

namespace Frame.Application.Interfaces
{
    /// <summary>
    /// 文章管理接口
    /// </summary>
    public interface IArticleManagerService
    {

        /// <summary>
        /// 根据id获取文章信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ArticleDto> GetArticleById(Guid id);
    }
}
