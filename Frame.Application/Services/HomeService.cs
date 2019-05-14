using AutoMapper;
using Frame.Application.Dtos;
using Frame.Application.Interfaces;
using Frame.ApplicationCore.Bases;
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

        public HomeService(
            IRepository<UserInfo, Guid> userRepository,
            IMapper mapper,
            FrameDbContext dbContext,
            IRepository<AdminMenu, Guid> menuRepository
            )
        {
            _userInfoRepository = userRepository;
            _mapper = mapper;
            _dbContext = dbContext;
            _menuRepository = menuRepository;
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
    }
}
