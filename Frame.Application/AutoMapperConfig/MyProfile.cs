using AutoMapper;
using Frame.Application.Dtos;
using Frame.Application.Dtos.ArticleManager;
using Frame.Application.Dtos.Discuss;
using Frame.Application.Dtos.LabelManager;
using Frame.Application.Dtos.MenuManager;
using Frame.Core.Entitys;
using System.Linq;

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
            CreateMap<Classify, ClassifyDto>().ReverseMap();
            CreateMap<AccountInputDto, Account>().ReverseMap();
            CreateMap<ArticleComment, ArticleCommentDto>().ReverseMap();
            CreateMap<Article, ArticleDto>().ReverseMap()
                .ForMember(ent => ent.CreateTime, opt => opt.Ignore())
                .ForMember(ent => ent.DelTime, opt => opt.Ignore());
            CreateMap<Article, ArticleListOutPutDto>().ReverseMap().ForMember(ent => ent.Content,opt => opt.Ignore());
        }
    }
}
