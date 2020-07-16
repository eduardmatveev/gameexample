using System;
using Data;

namespace Model
{
    public class ResourceModel
    {
        public event Action EventChanged;
        public readonly ResourceData Data;
        public uint Amount { get; private set; }

        public ResourceModel(ResourceData data, uint amount)
        {
            Data = data;
            Amount = amount;
        }

        internal void Update(uint amount)
        {
            if (amount != Amount)
            {
                Amount = amount;
                EventChanged?.Invoke();
            }
        }
    }
}