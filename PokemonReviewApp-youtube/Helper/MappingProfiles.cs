using AutoMapper;
using PokemonReviewApp_youtube.Dto;
using PokemonReviewApp_youtube.Models;

namespace PokemonReviewApp_youtube.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Pokemon, PokemonDto>();
            CreateMap<CategoryDto, Category>();
        }
    }
}
