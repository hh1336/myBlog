using AutoMapper;
using Frame.Application.Dtos.ArticleManager;
using Frame.Application.Dtos.Discuss;
using Frame.Application.Interfaces;
using Frame.ApplicationCore.Bases;
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
    /// 前端显示文章实现
    /// </summary>
    public class ArticleService : IArticleService
    {
        private IRepository<Article, Guid> _articleRepository;
        private IMapper _mapper;
        private IRepository<ArticleComment, Guid> _commentRepository;
        public ArticleService(
            IRepository<Article, Guid> articleRepository,
            IMapper mapper,
            IRepository<ArticleComment, Guid> commentRepository
            )
        {
            _articleRepository = articleRepository;
            _mapper = mapper;
            _commentRepository = commentRepository;
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

        public async Task<List<ArticleComment>> LoadDiscuss(Guid? id)
        {
            if (!id.HasValue) return new List<ArticleComment>();
            var data = _commentRepository.Where(s => s.ArticleId == id.Value && s.ParentId == null).Include(s =>s.ChildEntitis).OrderByDescending(a => a.CommentTime);
            return await data.ToListAsync();
        }

        public async Task Test()
        {
            var data = await _commentRepository.FirstOrDefaultAsync(s => s.ID == Guid.Parse("2aa245d9-ad58-4f36-8bb9-08d6de9b16e9"));
            data.ParentId = Guid.Parse("dbdafccf-e843-4ed7-b415-08d6de8d5c69");
            await _commentRepository.CommitAsync();
        }
    }
}
