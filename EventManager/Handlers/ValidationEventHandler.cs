using EventManager.Data.Entities;
using EventManager.Models.Events;
using NuGet.Protocol.Core.Types;

namespace EventManager.Handlers
{
    public class ValidationEventHandler<TModel> : BaseHandler<TModel> where TModel: EventModel
    {
        public ValidationEventHandler(IHandler<TModel> next):base(next)
        {
        }
        public override void Handle(TModel model)
        {
            if (model.FinishTime < model.StartTime || model.FinishTime < DateTime.Now)
                throw new Exception("Not correct finish time");
            if(model.StartTime < DateTime.Now)
                throw new Exception("Not correct start time");
            if(string.IsNullOrEmpty(model.Name))
                throw new Exception("Name cannot be null or empty");
            if (string.IsNullOrEmpty(model.Address.City))
                throw new Exception("City cannot be null or empty");
            _next.Handle(model);
            return;
        }
    }
}
