using AutoMapper;
using Walks.Api.Models.Domains;
using Walks.Api.Models.DTOs;

namespace Walks.Api.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Region, RegionDto>().ReverseMap();
            CreateMap<Region, AddRegionRequestDto>().ReverseMap();
            CreateMap<Region, UpdateRegionRequestDto>().ReverseMap();


            CreateMap<Walk, WalkDto>().ReverseMap();
            CreateMap<Walk, AddWalkRequestDto>().ReverseMap();
            CreateMap<Walk, UpdateWalkRequestDto>().ReverseMap();


            CreateMap<WalkDifficulty, WalkDifficultyDto>().ReverseMap();



        }
    }
}
