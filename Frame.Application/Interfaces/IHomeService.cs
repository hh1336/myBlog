using Frame.Application.Dtos;
using Frame.Application.Dtos.ArticleManager;
using Frame.ApplicationCore.Bases;
using Frame.ApplicationCore.Common;
using Frame.ApplicationCore.DtoBases;
using Frame.Core.Entitys;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Frame.Application.Interfaces
{
    public interface IHomeService 
    {
        /// <summary>
        /// 加载所有菜单
        /// </summary>
        /// <returns></returns>
        Task<List<AdminMenu>> GetAllMenu();

        /// <summary>
        /// 根据id获取用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<UserInfoDto> GetUserInfo(Guid? id);

        /// <summary>
        /// 获取所有文章
        /// </summary>
        /// <returns></returns>
        Task<IPageList<Article>> GetArticles(ArticleSreachDto data);
    }
}
