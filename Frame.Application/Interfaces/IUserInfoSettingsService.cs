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
    }
}
