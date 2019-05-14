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
            return await _menurepository.GetAllListAsync();
        }

        public async Task<List<AdminMenu>> GetAllMenuIncludeChildren()
        {
            return await _dbContext.AdminMenus.Include(s => s.ChildEntitis).Where(s => s.Pid == null).ToListAsync();
        }

        public async Task<AdminMenu> GetByMenuId(Guid id)
        {
            var result = await _dbContext.AdminMenus.Include(s => s.ChildEntitis).SingleOrDefaultAsync(s => s.ID == id);
            return result;
        }

        public async Task<List<AdminMenu>> GetParentMenu()
        {
            return await _menurepository.GetAllListAsync(s => s.Pid == null);
        }

        public async Task<bool> SaveMenuInfo(AdminMenuDto data)
        {
            if (Guid.Empty == data.ID)//新增
            {
                var adddata = _mapper.Map<AdminMenu>(data);
                await _menurepository.InsertAsync(adddata);
            }
            else
            {
                var entity = await _menurepository.FirstOrDefaultAsync(s => s.ID == data.ID);
                if (entity != null)
                {
                    var entitydata = _mapper.Map(data, entity);
                    await _menurepository.UpdateAsync(entitydata);
                }
            }

            return await _menurepository.CommitAsync() > 0;
        }
    }
}
