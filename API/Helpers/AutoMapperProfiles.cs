using API.DTOs;
using API.Entities;
using AutoMapper;

namespace API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<AppProduct, ProductDto>()
                    .ForMember(dest => dest.Thumbnail,
                    opt => opt.MapFrom(src => src.Photos
                    .FirstOrDefault(x => x.AppProductId == src.Id).Url));
            CreateMap<Photo, PhotoDto>();

            CreateMap<ProductDto, AppProduct>();
            CreateMap<RegisterDto, AppUser>();
        }
    }
}