using EventManager.Data.Entities.EntityBase;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace EventManager.Handlers
{
    public class AuthorizationHandler : BaseHandler
    {
        private string CurrentUserId;
        private string RoleName;
        public AuthorizationHandler(IHandler next,  string userId, string roleName) : base(next)
        {
            CurrentUserId = userId;
            RoleName = roleName;
        }
        public override void Handle(object model)
        {
            if(CurrentUserId == null)
                throw new Exception("You have no permissions to this operation");
            if (RoleName == "Admin")
            {
                _next.Handle(model);
                return;
            }
            if (model is IHasCreationAudited)
            {
                var creatorUserId = model.GetType().GetProperty("CreatorUserId")?.GetValue(model) as string;
                if(creatorUserId != null)
                {
                    if (creatorUserId == CurrentUserId)
                    {
                        _next.Handle(model);
                        return;
                    }
                    throw new Exception("You have no permissions to this operation");
                }
                else
                    _next.Handle(model);

            }
            
        }
    }
}
