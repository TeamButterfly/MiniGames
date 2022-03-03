using API.JsonModels;
using AutoMapper;
using BuisnessLogic;

namespace API
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<User, JsonUser>();
            CreateMap<JsonUser, User>();
            CreateMap<JsonUpdateUser, User>();

            CreateMap<Account, JsonAccount>();
            CreateMap<JsonAccount, Account>();
        }
    }
}
