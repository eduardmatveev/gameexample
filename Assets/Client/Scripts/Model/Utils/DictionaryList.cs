namespace System.Collections.Generic
{
    public class DictionaryList<TKey, TValue>
    {
        private readonly Dictionary<TKey, TValue> _dictionary = new Dictionary<TKey, TValue>();
        private readonly List<TValue> _list = new List<TValue>();
        public IReadOnlyList<TValue> Values => _list;

        public void Add(TKey key, TValue value)
        {
            if (_dictionary.TryGetValue(key, out var oldValue))
            {
                _list[_list.IndexOf(oldValue)] = value;
                _dictionary[key] = value;
            }
            else
            {
                _list.Add(value);
                _dictionary.Add(key, value);
            }
        }

        public void Remove(TKey key)
        {
            if (_dictionary.TryGetValue(key, out var value))
            {
                _list.Remove(value);
                _dictionary.Remove(key);
            }
        }

        public void Clear()
        {
            _list.Clear();
            _dictionary.Clear();
        }

        public bool TryGetValue(TKey key, out TValue value) => _dictionary.TryGetValue(key, out value);
        public bool ContainsKey(TKey key) => _dictionary.ContainsKey(key);
    }
}