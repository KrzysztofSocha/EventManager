namespace EventManager.Handlers
{
    public class ResultHandler<TModel> : BaseHandler<TModel>
    {
        public ResultHandler(IHandler<TModel> next) : base(next)
        {

        }
        public override void Handle(TModel model)
        {
            
        }
    }
}
