using EventManager.Data.Entities;
using EventManager.Models.Events;
using NuGet.Protocol.Core.Types;

namespace EventManager.Handlers
{
    public class ValidationEventHandler : BaseHandler
    {
        public ValidationEventHandler(IHandler next ):base(next)
        {
        }
        public override async void Handle(object model)
        {
            if (model is EventModel eventModel)
            {

                if (eventModel.FinishTime < eventModel.StartTime || eventModel.FinishTime < DateTime.Now)
                    eventModel.FinishTime = null;
                if (eventModel.StartTime < DateTime.Now)
                    throw new Exception("Not correct start time");
                if (string.IsNullOrEmpty(eventModel.Name))
                    throw new Exception("Name cannot be null or empty");
                if (string.IsNullOrEmpty(eventModel.Address.City))
                    throw new Exception("City cannot be null or empty");
                _next.Handle(model);                
                return;
            }
        }
    }
}
