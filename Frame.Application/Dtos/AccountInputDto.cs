using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Frame.Application.Dtos
{
    public class AccountInputDto 
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
        public string PassWord { set; get; }
    }
}
