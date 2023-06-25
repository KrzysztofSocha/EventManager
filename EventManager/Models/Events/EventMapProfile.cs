using AutoMapper;
using EventManager.Data.Entities;
using EventManager.Helpers;

namespace EventManager.Models.Events
{
    public class EventMapProfile:Profile
    {
        public EventMapProfile()
        {
            CreateMap<EventModel, GetEventDto>()
                .ForMember(dest => dest.SharingTime, opt => opt.MapFrom(src => DateHelper.GetTaskTimeString(src.CreationTime)))
                .ForMember(dest => dest.SubcribersCount, opt => opt.MapFrom(src => src.Observers.Count()));
           
            CreateMap<EventUserModel, GetSubscriberDto>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.Observer.UserName))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ObserverId));
            CreateMap<NotificationModel, EventMessagesDto>().ForMember(dest => dest.SharingTime, opt => opt.MapFrom(src => DateHelper.GetTaskTimeString(src.CreationTime)));
        }
    }
}
