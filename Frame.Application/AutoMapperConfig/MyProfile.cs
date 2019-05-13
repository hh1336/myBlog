using AutoMapper;
using Frame.Application.Dtos;
using Frame.Application.Dtos.MenuManager;
using Frame.Core.Entitys;

namespace Frame.Application.AutoMapperConfig
{
    public class MyProfile : Profile
    {
        /// <summary>
        /// 映射用法
        /// /*添加一个映射规则*/
        /// CreateMap<UserInfo, UserInfoDto>();
        /// 
        /// /*双向映射*/
        /// CreateMap<UserInfo, UserInfoDto>().ReverseMap();
        /// 
        /// /*添加一个规则，从UserInfoDto到UserInfo映射，将ID设为忽略映射对象*/
        /// CreateMap<UserInfoDto, UserInfo>().ForMember(ent => ent.ID ,opt => opt.Ignore());
        /// </summary>
        public MyProfile()
        {
            CreateMap<UserInfo, UserInfoDto>().ReverseMap();
            CreateMap<AdminMenu, AdminMenuDto>().ReverseMap();
        }
    }
}
