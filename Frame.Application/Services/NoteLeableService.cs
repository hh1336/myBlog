using AutoMapper;
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
    public class NoteLeableService : INoteLeableService
    {
        private readonly IRepository<Classify, Guid> _classifyRepository;
        private readonly IMapper _mapper;

        public NoteLeableService(IRepository<Classify, Guid> classifyRepository, IMapper mapper)
        {
            _classifyRepository = classifyRepository;
            _mapper = mapper;
        }



        public async Task<IPageList<Classify>> GetAll(SerachLabelDtoInput dto)
        {
            var result = _classifyRepository.Where(s => s.AdminMenuId == Guid.Parse("eb08f902-bab2-4d6c-e64f-08d6d83d314d"));

            if (!string.IsNullOrEmpty(dto.labelName))
            {
                result = result.Where(s => s.Name.Contains(dto.labelName));
            }

            return await result.Sort(dto.field, dto.order).ToPageList(dto.limit.Value, dto.page.Value);
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

        public async Task<bool> Delete(Guid id)
        {
            await _classifyRepository.DeleteAsync(s => s.ID == id);
            return await _classifyRepository.CommitAsync() > 0;
        }
    }
}
