using Frame.Application.Dtos;
using Frame.ApplicationCore.Bases;
using Frame.Core.Entitys;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Frame.Application.Interfaces
{
    public interface IHomeService 
    {
        /// <summary>
        /// 加载所有菜单
        /// </summary>
        /// <returns></returns>
        Task<List<AdminMenu>> GetAllMenu();
    }
}
