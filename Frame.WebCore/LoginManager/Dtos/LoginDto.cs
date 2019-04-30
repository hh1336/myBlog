using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Frame.WebCore.LoginManager.Dtos
{
    /// <summary>
    /// 登陆传输对象
    /// </summary>
    public class LoginDto
    {
        /// <summary>
        /// 账号
        /// </summary>
        [Required]
        [StringLength(6)]
        public string AccountNumber { set; get; }

        /// <summary>
        /// 密码
        /// </summary>
        [Required]
        [StringLength(8)]
        public string PassWord { set; get; }
    }
}
