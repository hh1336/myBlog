using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Frame.Application.Dtos.LabelManager;
using Frame.ApplicationCore.Common;
using Frame.Core.Entitys;

namespace Frame.Application.Interfaces
{
    public interface INoteLeableService
    {
        /// <summary>
        /// 获取所有数据作为表格
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<IPageList<Classify>> GetAll(SerachLabelDtoInput dto);
        
        /// <summary>
        /// 保存方法
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<bool> Save(ClassifyDto data);

        /// <summary>
        /// 删除方法
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        Task<bool> Delete(Guid value);
    }
}
