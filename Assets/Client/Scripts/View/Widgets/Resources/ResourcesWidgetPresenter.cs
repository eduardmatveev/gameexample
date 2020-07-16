using System.Collections.Generic;
using Data;
using Model;
using Utils;

namespace View
{
    public class ResourcesWidgetPresenter : IPresenter<ResourcesWidgetView>
    {
        public ResourcesWidgetView View { get; set; }
        private readonly UserModel _model;
        private readonly List<ResourcesWidgetItemPresenter> _items = new List<ResourcesWidgetItemPresenter>();

        public ResourcesWidgetPresenter(UserModel model)
        {
            _model = model;
        }

        public void Setup()
        {
            _model.EventResourcesChanged += OnResourcesChanged;
            OnResourcesChanged();
        }

        public void Update()
        {
            foreach (var presenter in _items)
                presenter.Update();
        }

        public void Destroy()
        {
            _model.EventResourcesChanged -= OnResourcesChanged;
            foreach (var presenter in _items)
                presenter.Unload();
            _items.Clear();
        }

        private void OnResourcesChanged()
        {
            foreach (var presenter in _items)
                presenter.Unload();
            _items.Clear();
            foreach (var model in _model.Resources.Values)
            {
                var presenter = new ResourcesWidgetItemPresenter(model);
                presenter.Load(View.ItemPrefab, View.transform);
                _items.Add(presenter);
            }
        }
    }
}