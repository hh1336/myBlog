using Frame.Application.Dtos.ArticleManager;
using Frame.Application.Interfaces;
using Frame.ApplicationCore.Bases;
using Frame.ApplicationCore.Common;
using Frame.Core.Entitys;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frame.Application.Services
{
    /// <summary>
    /// 我的笔记服务实现
    /// </summary>
    public class MyNoteService : IMyNoteService
    {
        private readonly IRepository<Classify, Guid> _classifyRepository;
        private readonly IRepository<Article, Guid> _articleRepository;

        public MyNoteService(IRepository<Classify, Guid> classifyRepository, IRepository<Article, Guid> articleRepository)
        {
            _classifyRepository = classifyRepository;
            _articleRepository = articleRepository;
        }

        public async Task<List<Classify>> GetAllLabel()
        {
            var datalist = await _classifyRepository.GetAllListAsync(s => s.AdminMenuId == Guid.Parse("eb08f902-bab2-4d6c-e64f-08d6d83d314d"));
            return datalist;
        }

        public async Task<IPageList<Article>> GetArticles(ArticleSreachDto data)
        {
            var dataquery = _articleRepository
                .GetAllIncluding(s => s.Classify)
                .Where(s => s.SortDel == 0 && s.MenuId == Guid.Parse("eb08f902-bab2-4d6c-e64f-08d6d83d314d"));

            if (data.LabelId.HasValue)
            {
                dataquery = dataquery.Where(s => s.ClassifyId == data.LabelId.Value);
            }

            return await dataquery.Sort(data.field, data.order).ToPageList(data.limit.Value, data.page.Value);
        }
    }
}
