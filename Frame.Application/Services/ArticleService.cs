using AutoMapper;
using Frame.Application.Dtos.ArticleManager;
using Frame.Application.Dtos.Discuss;
using Frame.Application.Interfaces;
using Frame.ApplicationCore.Bases;
using Frame.Core.Entitys;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Frame.Application.Services
{
    /// <summary>
    /// 前端显示文章实现
    /// </summary>
    public class ArticleService : IArticleService
    {
        private IRepository<Article, Guid> _articleRepository;
        private IMapper _mapper;
        private IRepository<ArticleComment, Guid> _commentRepository;
        public ArticleService(IRepository<Article, Guid> articleRepository,IMapper mapper)
        {
            _articleRepository = articleRepository;
            _mapper = mapper;
        }

        public async Task<bool> AddDiscuss(ArticleCommentDto data)
        {
            var entity = _mapper.Map<ArticleComment>(data);
            await _commentRepository.InsertAsync(entity);
            return await _commentRepository.CommitAsync() > 0;
        }

        public async Task<ArticleDto> GetById(Guid value)
        {
            var data = await _articleRepository.GetAllIncluding(s => s.Classify).FirstOrDefaultAsync(s => s.ID == value);
            return _mapper.Map<ArticleDto>(data);
        }
    }
}
