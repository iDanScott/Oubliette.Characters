using AutoMapper;
using Oubliette.Characters.Domain.Models;
using Oubliette.Characters.WebApi.Models.Characters;

namespace Oubliette.Characters.WebApi.Profiles
{
    public class CharacterProfile : Profile
    {
        public CharacterProfile()
        {
            CreateMap<CreateCharacterRequest, Character>();
        }
    }
}
