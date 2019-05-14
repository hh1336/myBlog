using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Frame.Application.Dtos.MenuManager;
using Frame.Core.Entitys;

namespace Frame.Application.Interfaces
{
    /// <summary>
    /// 菜单管理接口服务
    /// </summary>
    public interface IMenuManagerService
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<bool> Add(AdminMenuDto dto);

        /// <summary>
        /// 获取所有菜单与子菜单
        /// </summary>
        /// <returns></returns>
        Task<List<AdminMenu>> GetAllMenuIncludeChildren();

        /// <summary>
        /// 加载父级菜单
        /// </summary>
        /// <returns></returns>
        Task<List<AdminMenu>> GetParentMenu();

        /// <summary>
        /// 保存菜单信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<bool> SaveMenuInfo(AdminMenuDto data);

        /// <summary>
        /// 根据菜单id获取数据
        /// </summary>
        /// <returns></returns>
        Task<AdminMenu> GetByMenuId(Guid id);
        
        /// <summary>
        /// 加载所有菜单
        /// </summary>
        /// <returns></returns>
        Task<List<AdminMenu>> GetAllMenu();
    }
}
