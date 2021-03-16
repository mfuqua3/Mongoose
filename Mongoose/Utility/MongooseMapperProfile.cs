using AutoMapper;
using GoogleCast;
using Mongoose.Models;

namespace Mongoose.Utility
{
    public class MongooseMapperProfile:Profile
    {
        public MongooseMapperProfile()
        {
            CreateMap<IReceiver, CastReceiverViewModel>()
                .ForMember(vm => vm.FriendlyName, opt => opt.MapFrom(rcvr => rcvr.FriendlyName))
                .ForMember(vm => vm.Id, opt => opt.MapFrom(rcvr => rcvr.Id))
                .ForAllOtherMembers(opt => opt.Ignore());
        }
    }
}