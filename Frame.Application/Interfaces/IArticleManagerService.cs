using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Frame.Application.Dtos.ArticleManager;
using Frame.Application.Dtos.Discuss;
using Frame.Application.Dtos.LabelManager;
using Frame.ApplicationCore.Common;
using Frame.Core.Entitys;

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

        /// <summary>
        /// 获取列表数据
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<IPageList<Article>> GetAllToPageList(ArticleSreachDto data);
        
        /// <summary>
        /// 获取所有label标签
        /// </summary>
        /// <returns></returns>
        Task<List<ClassifyDto>> GetAllLabel();

        /// <summary>
        /// 保存文章
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<bool> Save(ArticleDto dto);

        /// <summary>
        /// 软删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> SortDel(Guid? id);

        /// <summary>
        /// 查看文章的所有评论
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<List<ArticleComment>> SelectDiscuss(Guid? id);

        /// <summary>
        /// 回复评论
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<bool> MeAddDiscuss(ArticleCommentDto dto);

        /// <summary>
        /// 删除评论
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        Task<bool> SortDiscuss(Guid value);

        /// <summary>
        /// 获取菜单信息
        /// </summary>
        /// <returns></returns>
        Task<List<AdminMenu>> GetAllMenu();
    }
}
