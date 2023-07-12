namespace TradingApp.UI.Views
{
    public abstract class BaseView
    {
        protected readonly UIController Controller;

        protected BaseView(UIController controller)
        {
            Controller = controller;
        }

        internal abstract void Show();
    }

    public abstract class BaseView<TModel> : BaseView
    {
        protected BaseView(UIController controller) : base(controller)
        {
        }

        public TModel Model { get; init; }
    }
}
