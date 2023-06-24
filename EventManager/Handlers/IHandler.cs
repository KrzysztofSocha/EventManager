namespace EventManager.Handlers
{
    public interface IHandler<TModel>
    {
        void Handle(TModel model);
    }
}
