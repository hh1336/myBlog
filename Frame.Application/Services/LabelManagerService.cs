using AutoMapper;
using Frame.Application.Dtos.LabelManager;
using Frame.Application.Interfaces;
using Frame.ApplicationCore.Bases;
using Frame.ApplicationCore.Common;
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
    /// 标签管理实现
    /// </summary>
    public class LabelManagerService : ILabelManagerService
    {
        private IRepository<Classify, Guid> _classifyRepository;
        private FrameDbContext _db;
        private IMapper _mapper;

        public LabelManagerService(IRepository<Classify, Guid> classifyRepository, FrameDbContext db, IMapper mapper)
        {
            _classifyRepository = classifyRepository;
            _db = db;
            _mapper = mapper;
        }

        public async Task<bool> Delete(Guid id)
        {
            await _classifyRepository.DeleteAsync(s => s.ID == id);
            return await _classifyRepository.CommitAsync() > 0;
        }

        public async Task<List<AdminMenu>> GetAllMenu()
        {
            return await (from item in _db.AdminMenus
                          select item).ToListAsync();
        }

        public async Task<IPageList<Classify>> GetPageList(SerachLabelDtoInput data)
        {
            var result = _classifyRepository.GetAll();
            if (!string.IsNullOrEmpty(data.labelName))
            {
                result = result.Where(s => s.Name.Contains(data.labelName));
            }

            return await result.Sort(data.field, data.order).ToPageList(data.limit.Value, data.page.Value);
        }

        public async Task<bool> Save(ClassifyDto data)
        {
            if (data.ID == Guid.Empty)
            {
                var entity = _mapper.Map<Classify>(data);
                await _classifyRepository.InsertAsync(entity);
            }
            else
            {
                var entity = await _classifyRepository.FirstOrDefaultAsync(s => s.ID == data.ID);
                if (entity == null) return false;
                await _classifyRepository.UpdateAsync(_mapper.Map(data, entity));
            }
            return await _classifyRepository.CommitAsync() > 0;
        }
    }
}
