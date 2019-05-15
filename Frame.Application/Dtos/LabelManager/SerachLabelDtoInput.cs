using Frame.ApplicationCore.DtoBases;
using System;
using System.Collections.Generic;
using System.Text;

namespace Frame.Application.Dtos.LabelManager
{
    /// <summary>
    /// 用于搜索标签Dto
    /// </summary>
    public class SerachLabelDtoInput : SreachDtoBase
    {
        /// <summary>
        /// 标签名
        /// </summary>
        public string labelName { set; get; }
    }
}
