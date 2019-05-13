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
        Task<List<AdminMenu>> GetAllMenu();
    }
}
