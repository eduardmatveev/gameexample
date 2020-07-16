using UnityEngine;

namespace Utils
{
    public static class AssetLibrary
    {
        private const string AssetsPath = "Assets/Client/Assets/";
        
        public static Sprite GetSpriteByPath(string path)
        {
#if UNITY_EDITOR
            return UnityEditor.AssetDatabase.LoadAssetAtPath<Sprite>(AssetsPath + path);
#else
            //TODO: implement load form bundle
#endif
        }
        public static TextAsset GetTextByPath(string path)
        {
#if UNITY_EDITOR
            return UnityEditor.AssetDatabase.LoadAssetAtPath<TextAsset>(AssetsPath + path);
#else
            //TODO: implement load form bundle
#endif
        }
    }
}