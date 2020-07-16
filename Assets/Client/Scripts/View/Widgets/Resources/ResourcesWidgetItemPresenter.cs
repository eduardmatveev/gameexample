using Model;
using Utils;

namespace View
{
    public class ResourcesWidgetItemPresenter : IPresenter<ResourcesWidgetItemView>
    {
        public ResourcesWidgetItemView View { get; set; }
        public readonly ResourceModel Model;

        public ResourcesWidgetItemPresenter(ResourceModel model)
        {
            Model = model;
        }

        public void Setup()
        {
            View.Icon.sprite = AssetLibrary.GetSpriteByPath(Model.Data.Icon);
            View.Name.text = Model.Data.Name;
            
            Model.EventChanged += OnChanged;
            OnChanged();
        }

        public void Update()
        {
        }

        public void Destroy()
        {
            Model.EventChanged -= OnChanged;
        }

        private void OnChanged()
        {
            View.Amount.text = Model.Amount.ToString();
        }
    }
}