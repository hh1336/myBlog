using Frame.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Frame.WebCore.LoginManager.Dtos
{
    /// <summary>
    /// 登陆验证信息结果
    /// </summary>
    public class LoginVerificationResultDto
    {
        /// <summary>
        /// 登陆结果
        /// </summary>
        public bool ResultBool { set; get; }

        /// <summary>
        /// 处理信息
        /// </summary>
        public string MessAge { set; get; }

        /// <summary>
        /// 账号ID
        /// </summary>
        public Guid? AccountID { set; get; }

        /// <summary>
        /// 账号
        /// </summary>
        public string AccountNumber { set; get; }

        /// <summary>
        /// 账号状态
        /// </summary>
        public AccountStateEnum AccountState { set; get; }

        /// <summary>
        /// 当前登陆IP地址
        /// </summary>
        public string IPAddress { set; get; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string Name { set; get; }

        /// <summary>
        /// 保存用户信息ID
        /// </summary>
        public Guid? UserInfoID { set; get; }

    }
}
