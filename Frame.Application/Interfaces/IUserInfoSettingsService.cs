using Frame.Application.Dtos;
using Frame.Core.Entitys;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Frame.Application.Interfaces
{
    /// <summary>
    /// 用户设置功能接口
    /// </summary>
    public interface IUserInfoSettingsService
    {
        /// <summary>
        /// 根据id获取用户信息
        /// </summary>
        /// <param name="userInfoID"></param>
        /// <returns></returns>
        Task<UserInfo> GetById(Guid? userInfoID);

        /// <summary>
        /// 保存用户信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<bool> SaveUserInfo(UserInfoDto data);
        
        /// <summary>
        /// 验证用户信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<bool> UserVilidata(AccountInputDto data);

        /// <summary>
        /// 保存用户修改的密码
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<bool> SaveAccountPWD(AccountInputDto data);
    }
}
