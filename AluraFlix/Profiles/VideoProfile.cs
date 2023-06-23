using AluraFlix.Data.Dtos;
using AluraFlix.Models;
using AutoMapper;

namespace AluraFlix.Profiles
{
    public class VideoProfile : Profile
    {
        public VideoProfile()
        {
            CreateMap<CreateVideoDto, Video>();
            CreateMap<UpdateVideoDto, Video>();
            CreateMap<Video, UpdateVideoDto>();
            CreateMap<Video, ReadVideoDto>();
        }
    }
}
