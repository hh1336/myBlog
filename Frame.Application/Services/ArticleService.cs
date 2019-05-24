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
        #region 构造函数注入
        private IRepository<Article, Guid> _articleRepository;
        private IMapper _mapper;
        private IRepository<ArticleComment, Guid> _commentRepository;
        private IRepository<LikeArticles, Guid> _likeRepository;
        public ArticleService(
            IRepository<Article, Guid> articleRepository,
            IMapper mapper,
            IRepository<ArticleComment, Guid> commentRepository,
            IRepository<LikeArticles, Guid> likeRepository
            )
        {
            _articleRepository = articleRepository;
            _mapper = mapper;
            _commentRepository = commentRepository;
            _likeRepository = likeRepository;
        }
        #endregion

        public async Task<bool> AddDiscuss(ArticleCommentDto data)
        {
            var entity = _mapper.Map<ArticleComment>(data);
            await _commentRepository.InsertAsync(entity);
            return await _commentRepository.CommitAsync() > 0;
        }

        public async Task<bool> AddLike(Guid value, string ipaddress)
        {
            var entity = await _likeRepository.FirstOrDefaultAsync(s => s.IP == ipaddress && s.ArticleId == value);
            if (entity != null) return false;
            var acentity = await _articleRepository.FirstOrDefaultAsync(s => s.ID == value && s.SortDel == 0);
            acentity.Like++;
            await _articleRepository.CommitAsync();
            var data = new LikeArticles() { ArticleId = value, IP = ipaddress, LikeTime = DateTime.Now };
            await _likeRepository.InsertAsync(data);
            return await _likeRepository.CommitAsync() > 0;
        }

        public async Task<ArticleDto> GetById(Guid value)
        {
            var data = await _articleRepository.GetAllIncluding(s => s.Classify).FirstOrDefaultAsync(s => s.ID == value);
            return _mapper.Map<ArticleDto>(data);
        }

        public async Task<List<ArticleComment>> LoadDiscuss(Guid? id)
        {
            if (!id.HasValue) return new List<ArticleComment>();
            var data = _commentRepository.Where(s => s.ArticleId == id.Value && s.ParentId == null).Include(s => s.ChildEntitis).OrderByDescending(a => a.CommentTime);
            return await data.ToListAsync();
        }

        public async Task Test()
        {
            var data = _articleRepository.Where(s => s.ClassifyId == Guid.Parse("8dddef30-c6c6-44cb-2e05-08d6daa2b066"));
            foreach (var item in data)
            {
                item.MenuId = Guid.Parse("eb08f902-bab2-4d6c-e64f-08d6d83d314d");
            }
            await _articleRepository.CommitAsync();
        }
    }
}
