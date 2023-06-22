using AutoMapper;
using EventManager.Data.Entities;
using EventManager.Helpers;

namespace EventManager.Models.Events
{
    public class EventMapProfile:Profile
    {
        public EventMapProfile()
        {
            CreateMap<EventModel, GetEventDto>().ForMember(dest => dest.SharingTime, opt => opt.MapFrom(src => DateHelper.GetTaskTimeString(src.CreationTime)));
            CreateMap<EventUserModel, GetSubscriberDto>().ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.Observer.UserName));
            CreateMap<NotificationModel, EventMessagesDto>().ForMember(dest => dest.SharingTime, opt => opt.MapFrom(src => DateHelper.GetTaskTimeString(src.CreationTime)));
        }
    }
}
