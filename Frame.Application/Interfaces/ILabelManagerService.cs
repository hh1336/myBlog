using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frame.Application.Dtos.LabelManager;
using Frame.ApplicationCore.Common;
using Frame.Core.Entitys;

namespace Frame.Application.Interfaces
{
    /// <summary>
    /// 标签管理接口
    /// </summary>
    public interface ILabelManagerService
    {
        /// <summary>
        /// 得到标签的数据转换为PageList
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<IPageList<Classify>> GetPageList(SerachLabelDtoInput data);

        /// <summary>
        /// 得到所有菜单数据
        /// </summary>
        /// <returns></returns>
        Task<List<AdminMenu>> GetAllMenu();

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<bool> Save(ClassifyDto data);

        /// <summary>
        /// 删除方法
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> Delete(Guid id);
    }
}
