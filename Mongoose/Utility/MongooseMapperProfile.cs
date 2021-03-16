using System.IO;
using AutoMapper;
using GoogleCast;
using Mongoose.Core.Entities;
using Mongoose.Models;

namespace Mongoose.Utility
{
    public class MongooseMapperProfile : Profile
    {
        public MongooseMapperProfile()
        {
            CreateMap<IReceiver, CastReceiverViewModel>()
                .ForMember(vm => vm.FriendlyName, opt => opt.MapFrom(rcvr => rcvr.FriendlyName))
                .ForMember(vm => vm.Id, opt => opt.MapFrom(rcvr => rcvr.Id))
                .ForAllOtherMembers(opt => opt.Ignore());

            CreateMap<VideoInfo, VideoInfoViewModel>()
                .ReverseMap()
                .ForMember(vi => vi.Id, opt => opt.Ignore());

            CreateMap<FileInfo, FileInfoViewModel>();

            CreateMap<Season, SeasonViewModel>()
                .ReverseMap();

            CreateMap<Series, SeriesViewModel>()
                .ReverseMap();

            CreateMap<Episode, EpisodeViewModel>()
                .ReverseMap();
        }
    }
}