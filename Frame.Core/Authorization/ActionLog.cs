using Frame.Core.Authorization.Enums;
using Frame.Core.EntityBases;
using Frame.Core.Entitys;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Frame.Core.Authorization
{
    /// <summary>
    /// 权限操作日志
    /// </summary>
    public class ActionLog : EntityBase
    {
        /// <summary>
        /// 操作类型
        /// </summary>
        public CRUDEnum ActionType { set; get; }

        /// <summary>
        /// 执行操作的账号
        /// </summary>
        [ForeignKey("Account")]
        public Guid ActionAccount { set; get; }

        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime ActionTime { set; get; }

        /// <summary>
        /// 操作ip
        /// </summary>
        public string ActionIpAddress { set; get; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Describe { set; get; }

        /// <summary>
        /// 导航属性
        /// </summary>
        public Account Account { set; get; }
    }
}
