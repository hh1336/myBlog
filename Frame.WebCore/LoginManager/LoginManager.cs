using AutoMapper;
using Frame.ApplicationCore.Bases;
using Frame.ApplicationCore.Common;
using Frame.Core.Entitys;
using Frame.Core.Enums;
using Frame.WebCore.LoginManager.Dtos;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Frame.WebCore.LoginManager
{
    public class LoginManager : ILoginManager
    {
        private IRepository<UserInfo, Guid> _userInfoRepository;
        private IRepository<Account, Guid> _accountRepository;

        public LoginManager(
            IRepository<Account, Guid> accountRepository,
            IRepository<UserInfo, Guid> userRepository
            )
        {
            _accountRepository = accountRepository;
            _userInfoRepository = userRepository;
        }

        public async Task<LoginVerificationResultDto> Login(LoginDto data)
        {
            //验证登陆状态
            var result = await LoginVerification(data);
            if (!result.ResultBool)
            {
                return result;
            }
            if (Guid.Empty.Equals(result.UserInfoID.Value))
            {
                return result;
            }
            var user = await _userInfoRepository.GetAsync(result.UserInfoID.Value);
            result.Name = user.UserName;
            return result;

        }

        public async Task<LoginVerificationResultDto> LoginVerification(LoginDto data)
        {
            var result = new LoginVerificationResultDto();
            //查找用户是否存在
            var account = await _accountRepository.FirstOrDefaultAsync(s => s.AccountNumber == data.AccountNumber);
            if (account == null || account.AccountState == AccountStateEnum.已删除)
            {
                result.ResultBool = false;
                result.MessAge = "账号不存在";
                return result;
            }
            if (!account.PassWord.Equals(Common.GetMD5(data.PassWord)))
            {
                result.ResultBool = false;
                result.MessAge = "密码错误";
                return result;
            }
            if (account.AccountState == AccountStateEnum.冻结)
            {
                result.ResultBool = false;
                result.MessAge = "账户已被冻结，请联系管理员";
                return result;
            }
            result.ResultBool = true;
            result.MessAge = "登陆成功";
            result.AccountID = account.ID;
            result.AccountNumber = account.AccountNumber;
            result.AccountState = account.AccountState;
            result.UserInfoID = account.UserInfoId;
            return result;
        }

        public async Task UpdateLoginInfo(Guid? accountID, string iPAddress)
        {
            if (accountID.HasValue)
            {
                var account = await _accountRepository.FirstOrDefaultAsync(s => s.ID == accountID);
                account.LastLoginTime = DateTime.Now;
                account.LastLoginIp = iPAddress;
                account.LoginCount += 1;
                await _accountRepository.UpdateAsync(account);
                await _accountRepository.CommitAsync();
            }
        }
    }
}
