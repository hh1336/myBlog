using AutoMapper;
using Frame.Application.Dtos;
using Frame.Application.Interfaces;
using Frame.ApplicationCore.Bases;
using Frame.Core.Entitys;
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

        public HomeService(IRepository<UserInfo, Guid> userRepository, IMapper mapper)
        {
            _userInfoRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserInfoDto> Get(Guid id)
        {
            var entity = await _userInfoRepository.GetAsync(id);
            return _mapper.Map<UserInfoDto>(entity);
        }

        public async Task<UserInfo> Insert(UserInfoDto data)
        {
            var entity = _mapper.Map<UserInfo>(data);
            //entity.ID = Guid.NewGuid();
            var result = await _userInfoRepository.InsertAsync(entity);
            await _userInfoRepository.CommitAsync();
            return result;
        }

        public async Task<bool> Update(UserInfoDto dto)
        {
            var entity = await _userInfoRepository.GetAsync(dto.ID);
            var entity1 = _mapper.Map(dto, entity);

            await _userInfoRepository.UpdateAsync(entity1);
            return await _userInfoRepository.CommitAsync() > 0;


        }
    }
}
