using System;
using System.Collections.Generic;
using System.Linq;
using Command;
using Newtonsoft.Json.Linq;

namespace Model
{
    public abstract class GameNetworkBase
    {
        static GameNetworkBase()
        {
            foreach (var type in AppDomain.CurrentDomain.GetAssemblies().SelectMany(s => s.GetTypes()).Where(p => p.BaseType == typeof(CommandBase)))
                CommandTypeByStringType.Add(type.Name.Replace("Command", ""), type);
        }
        private static readonly Dictionary<string, Type> CommandTypeByStringType = new Dictionary<string, Type>();
        public event Action<CommandBase> EventReceiveCommand;

        internal void ReceiveJson(string json)
        {
            var jobj = JObject.Parse(json);
            if (CommandTypeByStringType.TryGetValue(jobj.GetValue("Type").ToString(), out var cmdType))
                EventReceiveCommand?.Invoke(jobj.ToObject(cmdType) as CommandBase);
        }
    }
}