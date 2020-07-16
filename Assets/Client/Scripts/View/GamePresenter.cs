using Utils;
using Model;

namespace View
{
    public class GamePresenter : IPresenter<GameView>
    {
        public GameView View { get; set; }
        private readonly ResourcesWidgetPresenter _resourcesWidget;

        public GamePresenter(GameModel model)
        {
            _resourcesWidget = new ResourcesWidgetPresenter(model.User);
        }

        public void Setup()
        {
            _resourcesWidget.Attach(View.ResourcesWidget);
        }

        public void Update()
        {
            _resourcesWidget.Update();
        }

        public void Destroy()
        {
            _resourcesWidget.Detach();
        }
    }
}