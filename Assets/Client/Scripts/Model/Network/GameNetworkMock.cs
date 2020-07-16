#if UNITY_EDITOR
using System;
using UnityEditor;
using UnityEngine;
using Random = System.Random;

namespace Model
{
    public class GameNetworkMock : GameNetworkBase
    {
        private static readonly Random Rnd = new Random((int)DateTime.UtcNow.Ticks);
        private static GameNetworkMock _instance;
        private static long _nextRandomCommandTicks;
        
        public GameNetworkMock()
        {
            _instance = this;
            EditorApplication.update += Update;
        }

        private static void Update()
        {
            var currentTime = DateTime.UtcNow.Ticks;
            if (currentTime >= _nextRandomCommandTicks)
            {
                ServerCommandRandom();
                _nextRandomCommandTicks = currentTime + 10000 * 1000 * (5 + Rnd.Next(10));
            }
        }

        [MenuItem("Mocks/ServerCommandRandom")]
        public static void ServerCommandRandom()
        {
            _instance?.ReceiveJson(AssetDatabase.LoadAssetAtPath<TextAsset>("Assets/Client/Assets/Mocks/Command" + Rnd.Next(5) + ".json").text);
        }
        
        [MenuItem("Mocks/ServerCommand0")]
        public static void ServerCommand0()
        {
            _instance?.ReceiveJson(AssetDatabase.LoadAssetAtPath<TextAsset>("Assets/Client/Assets/Mocks/Command0.json").text);
        }
        
        [MenuItem("Mocks/ServerCommand1")]
        public static void ServerCommand1()
        {
            _instance?.ReceiveJson(AssetDatabase.LoadAssetAtPath<TextAsset>("Assets/Client/Assets/Mocks/Command1.json").text);
        }
        
        [MenuItem("Mocks/ServerCommand2")]
        public static void ServerCommand2()
        {
            _instance?.ReceiveJson(AssetDatabase.LoadAssetAtPath<TextAsset>("Assets/Client/Assets/Mocks/Command2.json").text);
        }
        
        [MenuItem("Mocks/ServerCommand3")]
        public static void ServerCommand3()
        {
            _instance?.ReceiveJson(AssetDatabase.LoadAssetAtPath<TextAsset>("Assets/Client/Assets/Mocks/Command3.json").text);
        }
        
        [MenuItem("Mocks/ServerCommand4")]
        public static void ServerCommand4()
        {
            _instance?.ReceiveJson(AssetDatabase.LoadAssetAtPath<TextAsset>("Assets/Client/Assets/Mocks/Command4.json").text);
        }
    }
}
#endif