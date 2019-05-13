using AutoMapper;
using Frame.Application.Dtos.MenuManager;
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
    /// <summary>
    /// 菜单管理服务实现
    /// </summary>
    public class MenuManagerService : IMenuManagerService
    {
        private readonly IRepository<AdminMenu, Guid> _menurepository;
        private readonly IMapper _mapper;
        private readonly FrameDbContext _dbContext;

        public MenuManagerService(
            IRepository<AdminMenu, Guid> menurepository,
            IMapper mapper,
            FrameDbContext dbContext
            )
        {
            _menurepository = menurepository;
            _mapper = mapper;
            _dbContext = dbContext;
        }


        public async Task<bool> Add(AdminMenuDto dto)
        {
            var data = _mapper.Map<AdminMenu>(dto);
            await _menurepository.InsertAsync(data);
            return await _menurepository.CommitAsync() > 0;
        }

        public async Task<List<AdminMenu>> GetAllMenu()
        {
            return await _dbContext.AdminMenus.Include(s => s.ChildEntitis).Where(s => s.Pid == null).ToListAsync();
        }

    }
}
