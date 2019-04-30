using Frame.ApplicationCore.Bases;
using Frame.ApplicationCore.Bases.AutoFac;
using Frame.WebCore.LoginManager.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Frame.WebCore.LoginManager
{
    /// <summary>
    /// 登陆管理器接口
    /// </summary>
    public interface ILoginManager
    {
        /// <summary>
        /// 登陆验证
        /// </summary>
        /// <param name="data">用户名密码</param>
        /// <returns></returns>
        Task<LoginVerificationResultDto> LoginVerification(LoginDto data);

        /// <summary>
        /// 登陆，并全局初始化用户信息
        /// </summary>
        /// /// <param name="data">用户名密码</param>
        /// <returns></returns>
        Task<LoginVerificationResultDto> Login(LoginDto data);
        
        /// <summary>
        /// 更新登陆信息和IP地址
        /// </summary>
        /// <param name="accountID"></param>
        /// <param name="iPAddress"></param>
        /// <returns></returns>
        Task UpdateLoginInfo(Guid? accountID, string iPAddress);
    }
}
