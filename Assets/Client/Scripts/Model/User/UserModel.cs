using System;
using System.Collections.Generic;
using Command;
using Data;

namespace Model
{
    public class UserModel : ICommandVisitor
    {
        public event Action EventResourcesChanged;
        public readonly DictionaryList<ResourceData, ResourceModel> Resources = new DictionaryList<ResourceData, ResourceModel>();

        internal void Simulate()
        {
            foreach (var model in Resources.Values)
                model.Update(model.Amount + model.Data.AppendPerSecond);
        }

        void ICommandVisitor.Visit(CommandUpdateResource cmd)
        {
            if (Resources.TryGetValue(cmd.Data, out var model))
            {
                model.Update(cmd.Amount);
            }
            else
            {
                Resources.Add(cmd.Data, new ResourceModel(cmd.Data, cmd.Amount));
                EventResourcesChanged?.Invoke();
            }
        }
        
        void ICommandVisitor.Visit(CommandUpdateResources cmd)
        {
            var changed = false;
            for (var i = Resources.Values.Count - 1; i >= 0; i--)
            {
                var model = Resources.Values[i];
                if (!cmd.Resources.ContainsKey(model.Data))
                {
                    Resources.Remove(model.Data);
                    changed = true;
                }
            }
            foreach (var pair in cmd.Resources)
            {
                if (Resources.TryGetValue(pair.Key, out var model))
                {
                    model.Update(pair.Value);
                }
                else
                {
                    Resources.Add(pair.Key, new ResourceModel(pair.Key, pair.Value));
                    changed = true;
                }
            }
            if (changed)
                EventResourcesChanged?.Invoke();
        }
    }
}