using System;
using System.Collections.Generic;
using System.Text;

namespace Frame.ApplicationCore.DtoBases
{
    public class SreachDtoBase
    {
        /// <summary>
        /// 显示条数
        /// </summary>
        public int? limit { set; get; }

        /// <summary>
        /// 显示某页
        /// </summary>
        public int? page { set; get; }

        /// <summary>
        /// 排序字段
        /// </summary>
        public string field { set; get; }

        /// <summary>
        /// 排序规则
        /// </summary>
        public string order { set; get; }
    }
}
