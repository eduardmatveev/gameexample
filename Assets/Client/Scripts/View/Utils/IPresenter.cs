using UnityEngine;

namespace Utils
{
    public interface IPresenter<T> where T : Component
    {
        T View { get; set; }
        void Setup();
        void Update();
        void Destroy();
    }
}