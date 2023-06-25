using EventManager.Data.Entities.EntityBase;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace EventManager.Handlers
{
    public class AuthorizationHandler<TModel> : BaseHandler<TModel>
    {
        private string CurrentUserId;
        private string RoleName;
        public AuthorizationHandler(IHandler<TModel> next, string userId, string roleName) : base(next)
        {
            CurrentUserId = userId;
            RoleName = roleName;
        }
        public override void Handle(TModel model)
        {
            if (RoleName == "Admin")
            {
                _next.Handle(model);
                return;
            }
            if (model is IHasCreationAudited)
            {
                var creatorUserId = model.GetType().GetProperty("CreatorUserId")?.GetValue(model) as string;
                if (creatorUserId == CurrentUserId)
                {
                    _next.Handle(model);
                    return;
                }
                throw new Exception("You have no permissions to this operation");
            }
            
        }
    }
}
