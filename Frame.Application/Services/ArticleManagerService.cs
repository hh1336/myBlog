using AutoMapper;
using Frame.Application.Dtos.ArticleManager;
using Frame.Application.Interfaces;
using Frame.ApplicationCore.Bases;
using Frame.Core.Entitys;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Frame.Application.Services
{
    /// <summary>
    /// 文章管理服务实现
    /// </summary>
    public class ArticleManagerService : IArticleManagerService
    {
        private readonly IRepository<Article, Guid> _articleRepository;
        private readonly IMapper _mapper;
        public ArticleManagerService(
            IRepository<Article, Guid> articleRepository,
            IMapper mapper
            )
        {
            _articleRepository = articleRepository;
            _mapper = mapper;
        }

        public async Task<ArticleDto> GetArticleById(Guid id)
        {
            var entity = await _articleRepository.FirstOrDefaultAsync(s => s.ID == id);
            return _mapper.Map<ArticleDto>(entity);
        }
    }
}
