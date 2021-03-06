using API.JsonModels;
using AutoMapper;
using BuisnessLogic;
using Hangman;
using TicTacToe;

namespace API
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<User, UserModel>();
            CreateMap<UserModel, User>();
            CreateMap<UserModelUpdate, User>();

            CreateMap<Account, AccountModel>();
            CreateMap<AccountModel, Account>();

            CreateMap<HangmanResponseModel, HangmanModel>();
            CreateMap<HangmanModel, HangmanResponseModel>();

            CreateMap<TicTacToeResponseModel, TicTacToeModel>();
            CreateMap<TicTacToeModel, TicTacToeResponseModel>();
        }
    }
}
