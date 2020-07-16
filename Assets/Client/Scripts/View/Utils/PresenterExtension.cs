﻿using UnityEngine;
using Object = UnityEngine.Object;

namespace Utils
{
    public static class PresenterExtension
    {
        public static void Attach<T>(this IPresenter<T> self, T view) where T : AttachableView
        {
            if (self.View != null)
                self.Detach();
            self.View = view;
            self.Setup();
        }

        public static void Detach<T>(this IPresenter<T> self) where T : AttachableView
        {
            if (self.View == null)
                return;
            self.Destroy();
            self.View = null;
        }
        
        public static void Load<T>(this IPresenter<T> self, T prefab, Transform parent) where T : LoadableView
        {
            if (self.View != null)
                self.Unload();
            self.View = Object.Instantiate(prefab.gameObject, parent).GetComponent<T>();
            self.Setup();
        }
        
        public static void Unload<T>(this IPresenter<T> self) where T : LoadableView
        {
            if (self.View == null)
                return;
            self.Destroy();
            Object.Destroy(self.View.gameObject);
            self.View = null;
        }
    }
}