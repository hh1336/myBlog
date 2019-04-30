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
        /// 根据id获取数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<UserInfoDto> Get(Guid id);

        /// <summary>
        /// 插入一条数据
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<UserInfo> Insert(UserInfoDto data);

        /// <summary>
        /// 修改一条数据
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<bool> Update(UserInfoDto dto);
    }
}
