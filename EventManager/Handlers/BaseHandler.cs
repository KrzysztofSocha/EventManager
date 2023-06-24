namespace EventManager.Handlers
{
    public abstract class BaseHandler<TModel>:IHandler<TModel>
    {
        protected IHandler<TModel> _next;
        protected BaseHandler(IHandler<TModel> next)
        {
            _next = next;
        }

        public abstract void Handle(TModel model);
        
    }
}
