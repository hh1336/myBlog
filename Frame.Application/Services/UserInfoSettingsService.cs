using AutoMapper;
using Frame.Application.Dtos;
using Frame.Application.Interfaces;
using Frame.ApplicationCore.Bases;
using Frame.ApplicationCore.Common;
using Frame.Core.Entitys;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Frame.Application.Services
{
    public class UserInfoSettingsService : IUserInfoSettingsService
    {
        private IRepository<UserInfo, Guid> _userInfoRepository;
        private IMapper _mapper;
        private IRepository<Account, Guid> _accountRepository;
        public UserInfoSettingsService(IRepository<UserInfo, Guid> userInfoRepository, IMapper mapper, IRepository<Account, Guid> accountRepository)
        {
            _userInfoRepository = userInfoRepository;
            _mapper = mapper;
            _accountRepository = accountRepository;
        }

        public async Task<UserInfo> GetById(Guid? userInfoID)
        {
            if (!userInfoID.HasValue) return new UserInfo();
            var userinfo = await _userInfoRepository.FirstOrDefaultAsync(s => s.ID == userInfoID.Value);
            if(userinfo == null) return new UserInfo();
            return userinfo;
        }

        public async Task<bool> SaveAccountPWD(AccountInputDto data)
        {
            var entity = await _accountRepository.FirstOrDefaultAsync(s => s.AccountNumber == data.AccountNumber);
            if (entity == null) return false;
            entity.UpdateTime = DateTime.Now;
            entity.OldPassWord = entity.PassWord;
            entity.PassWord = Common.GetMD5(data.PassWord);
            return await _accountRepository.CommitAsync() > 0;
        }

        public async Task<bool> SaveUserInfo(UserInfoDto data)
        {
            var entity = await _userInfoRepository.FirstOrDefaultAsync(s => s.ID == data.ID);
            if (entity == null) return  false;
            await _userInfoRepository.UpdateAsync(_mapper.Map(data, entity));
            return await _userInfoRepository.CommitAsync() > 0;
        }

        public async Task<bool> UserVilidata(AccountInputDto data)
        {
            if (string.IsNullOrEmpty(data.AccountNumber) || string.IsNullOrEmpty(data.PassWord)) return false;
            var entity = await _accountRepository.FirstOrDefaultAsync(s => s.AccountNumber == data.AccountNumber && s.PassWord == Common.GetMD5(data.PassWord));
            return entity != null;
        }
    }
}
