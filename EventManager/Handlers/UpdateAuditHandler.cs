using EventManager.Data.Entities.EntityBase;

namespace EventManager.Handlers
{
    public class UpdateAuditHandler : BaseHandler
    {
        private string CurrentUserId;
        public UpdateAuditHandler(IHandler next, string userId) : base(next)
        {
            CurrentUserId = userId;
        }
        public override void Handle(object model)
        {
            
            if (model is IHasModificationAudited)
            {
                var modificationUserId = model.GetType().GetProperty("ModificationUser");
                modificationUserId?.SetValue(model, CurrentUserId);
                var modificationTime = model.GetType().GetProperty("ModificationTime");
                modificationTime?.SetValue(model, DateTime.Now);
                _next.Handle(model);
                return;


            }

        }
    }
}
