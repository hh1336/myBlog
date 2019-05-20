using Frame.Application.Interfaces;
using Frame.ApplicationCore.Bases;
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
        public UserInfoSettingsService(IRepository<UserInfo, Guid> userInfoRepository)
        {
            _userInfoRepository = userInfoRepository;
        }

        public async Task<UserInfo> GetById(Guid? userInfoID)
        {
            if (!userInfoID.HasValue) return new UserInfo();
            var userinfo = await _userInfoRepository.FirstOrDefaultAsync(s => s.ID == userInfoID.Value);
            if(userinfo == null) return new UserInfo();
            return userinfo;
        }
    }
}
