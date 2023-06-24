namespace EventManager.Handlers
{
    public class ValidationHandler<TModel> : BaseHandler<TModel>
    {
        public ValidationHandler(IHandler<TModel> next):base(next)
        {
        }
        public override void Handle(TModel model)
        {
            throw new NotImplementedException();
        }
    }
}
