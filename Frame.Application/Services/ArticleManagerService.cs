﻿using AutoMapper;
using Frame.Application.Dtos.ArticleManager;
using Frame.Application.Dtos.Discuss;
using Frame.Application.Dtos.LabelManager;
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
    /// 文章管理服务实现
    /// </summary>
    public class ArticleManagerService : IArticleManagerService
    {
        private readonly IRepository<Article, Guid> _articleRepository;
        private readonly IRepository<Classify, Guid> _classifyRepository;
        private readonly IMapper _mapper;
        private readonly IRepository<ArticleComment, Guid> _commentRepository;
        private readonly IRepository<AdminMenu, Guid> _menuRepository;
        public ArticleManagerService(
            IRepository<Article, Guid> articleRepository,
            IMapper mapper,
            IRepository<Classify, Guid> classifyRepository,
            IRepository<ArticleComment, Guid> commentRepository,
            IRepository<AdminMenu, Guid> menuRepository
            )
        {
            _articleRepository = articleRepository;
            _mapper = mapper;
            _classifyRepository = classifyRepository;
            _commentRepository = commentRepository;
            _menuRepository = menuRepository;
        }

        public async Task<List<ClassifyDto>> GetAllLabel()
        {
            var entitylist = await _classifyRepository.GetAllListAsync();
            var result = _mapper.Map<List<ClassifyDto>>(entitylist);
            return result;
        }

        public async Task<List<AdminMenu>> GetAllMenu()
        {
            var result = await _menuRepository.GetAllListAsync();
            return result;
        }

        public async Task<IPageList<Article>> GetAllToPageList(ArticleSreachDto data)
        {
            var result = _articleRepository.GetAllIncluding(s => s.Classify).Where(s => s.SortDel == 0);
            if (!string.IsNullOrEmpty(data.AcName))
            {
                result = result.Where(s => s.AcName.Contains(data.AcName));
            }

            return await result.Sort(data.field, data.order).ToPageList(data.limit.Value, data.page.Value);
        }

        public async Task<ArticleDto> GetArticleById(Guid id)
        {
            var entity = await _articleRepository.FirstOrDefaultAsync(s => s.ID == id);
            return _mapper.Map<ArticleDto>(entity);
        }

        public async Task<bool> MeAddDiscuss(ArticleCommentDto dto)
        {
            dto.CommentTime = DateTime.Now;
            var entity = _mapper.Map<ArticleComment>(dto);
            await _commentRepository.InsertAsync(entity);
            return await _commentRepository.CommitAsync() > 0;
        }

        public async Task<bool> Save(ArticleDto dto)
        {
            if (dto.ID == Guid.Empty)
            {
                var entity = _mapper.Map<Article>(dto);
                entity.CreateTime = DateTime.Now;
                await _articleRepository.InsertAsync(entity);
                return await _articleRepository.CommitAsync() > 0;
            }
            else
            {
                var entity = await _articleRepository.FirstOrDefaultAsync(s => s.ID == dto.ID);
                if (entity == null) return false;
                dto.UpdateTime = DateTime.Now;
                await _articleRepository.UpdateAsync(_mapper.Map(dto, entity));
                return await _articleRepository.CommitAsync() > 0;
            }
        }

        public async Task<List<ArticleComment>> SelectDiscuss(Guid? id)
        {
            if (!id.HasValue) return new List<ArticleComment>();
            var datalist = _commentRepository
                .Where(s => s.SortDel == 0 && s.ArticleId == id && s.ParentId == null)
                .Include(s => s.ChildEntitis)
                .OrderBy(s => s.CommentTime);
            return await datalist.ToListAsync();
        }

        public async Task<bool> SortDel(Guid? id)
        {
            if (!id.HasValue) return false;
            var entity = await _articleRepository.FirstOrDefaultAsync(s => s.ID == id.Value);
            if (entity == null) return false;
            entity.SortDel = 1;
            entity.DelTime = DateTime.Now;
            return await _articleRepository.CommitAsync() > 0;
        }

        public async Task<bool> SortDiscuss(Guid value)
        {
            var entity = await _commentRepository.FirstOrDefaultAsync(s => s.ID == value);
            if (entity == null) return false;
            entity.SortDel = Core.Enums.YesOrNoEnum.是;
            return await _commentRepository.CommitAsync() > 0;
        }
    }
}
