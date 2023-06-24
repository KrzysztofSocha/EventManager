using AutoMapper;
using EventManager.Data.Entities;
using EventManager.Helpers;

namespace EventManager.Models.Notification
{
    public class NotificationMapProfile:Profile
    {
        public NotificationMapProfile()
        {
            CreateMap<UserNotificationModel, NotificationViewModel>()
                .ForMember(dest => dest.EventId, opt => opt.MapFrom(src => src.Notification.EventId))
                .ForMember(dest => dest.Message, opt => opt.MapFrom(src => src.Notification.Message))
                .ForMember(dest => dest.SharingTime, opt => opt.MapFrom(src => DateHelper.GetTaskTimeString(src.Notification.CreationTime)))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Notification.Id));
        }
    }
}
