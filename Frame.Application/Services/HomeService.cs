using AutoMapper;
using Frame.Application.Dtos;
using Frame.Application.Dtos.ArticleManager;
using Frame.Application.Interfaces;
using Frame.ApplicationCore.Bases;
using Frame.ApplicationCore.Common;
using Frame.ApplicationCore.DtoBases;
using Frame.Core.Entitys;
using Frame.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frame.Application.Services
{
    public class HomeService : IHomeService
    {
        private IRepository<UserInfo, Guid> _userInfoRepository;
        private readonly IMapper _mapper;
        private readonly FrameDbContext _dbContext;
        private readonly IRepository<AdminMenu, Guid> _menuRepository;
        private readonly IRepository<Article, Guid> _articleRepository;

        public HomeService(
            IRepository<UserInfo, Guid> userRepository,
            IMapper mapper,
            FrameDbContext dbContext,
            IRepository<AdminMenu, Guid> menuRepository,
            IRepository<Article, Guid> articleRepository
            )
        {
            _userInfoRepository = userRepository;
            _mapper = mapper;
            _dbContext = dbContext;
            _menuRepository = menuRepository;
            _articleRepository = articleRepository;
        }

        public async Task<List<AdminMenu>> GetAllMenu()
        {
            return 
                await _dbContext.AdminMenus
                .Include(s => s.ChildEntitis)
                .Where(s => s.Pid == null)
                .OrderByDescending(s => s.SortNumber)
                .ToListAsync();
        }

        public async Task<UserInfoDto> GetUserInfo(Guid? id)
        {
            var entity = await _userInfoRepository.FirstOrDefaultAsync(s => s.ID == id);
            if (entity == null || !id.HasValue) return new UserInfoDto();
            var result = _mapper.Map<UserInfoDto>(entity);
            return result;
        }

        public async Task<IPageList<Article>> GetArticles(SreachDtoBase data)
        {
            var datalist = await _articleRepository.GetAllIncluding(s => s.Classify).Where(s => s.SortDel == 0).Sort(data.field, data.order).ToPageList(data.limit.Value, data.page.Value);
            return datalist;
        }
    }
}
