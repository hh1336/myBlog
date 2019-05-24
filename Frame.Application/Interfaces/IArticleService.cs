using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Frame.Application.Dtos.ArticleManager;
using Frame.Application.Dtos.Discuss;
using Frame.Core.Entitys;

namespace Frame.Application.Interfaces
{
    /// <summary>
    /// 前端显示文章接口
    /// </summary>
    public interface IArticleService
    {
        /// <summary>
        /// 根据id获取文章信息
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        Task<ArticleDto> GetById(Guid value);

        /// <summary>
        /// 添加评论
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<bool> AddDiscuss(ArticleCommentDto data);

        /// <summary>
        /// 加载所有评论
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<List<ArticleComment>> LoadDiscuss(Guid? id);

        /// <summary>
        /// 用户点赞
        /// </summary>
        /// <param name="value"></param>
        /// <param name="ipaddress"></param>
        /// <returns></returns>
        Task<bool> AddLike(Guid value, string ipaddress);


        Task Test();
    }
}
