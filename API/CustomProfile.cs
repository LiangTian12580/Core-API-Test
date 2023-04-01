using AutoMapper;
using WebCore.Model;
using WebCore.ViewModel;
namespace WebCore.API
{
    public class CustomProfile : Profile
    {
       public   CustomProfile() 
        {
            /// <summary>
            /// 配置构造函数，用来创建关系映射
            /// </summary>
            CreateMap<Login, Users>();
            
        }
    }
}
