namespace LRUCache
{
    internal class Cache<TKey, TValue>
    {
        private LinkedList<Node<TKey, TValue>> _list;
        public int Capacity { get; }

        private Dictionary<TKey, Node<TKey, TValue>> _map;

        public Cache(int capacity){
            Capacity = capacity;
            _list = new LinkedList<Node<TKey, TValue>>();
            _map = new Dictionary<TKey, Node<TKey, TValue>>();
        }

        public void Put(TKey key, TValue value)
        {
            if (_map.ContainsKey(key))
            {
                var existingNode = _map[key];
                existingNode.Value = value;
                MoveToFront(existingNode);
                return;
            }

            if (_map.Count == Capacity)
            {
                var removedNode = _list.Last;
                _list.Remove(removedNode);
                _map.Remove(removedNode.Value.Key);
            }

            var newNode = new Node<TKey, TValue>(key, value);
            _list.AddFirst(newNode);

            _map.Add(key, newNode);
        }

        public TValue? Get(TKey key)
        {
            if (!_map.ContainsKey(key)) return default;

            var node = _map[key];
            MoveToFront(node);
            return node.Value;
        }

        private void MoveToFront(Node<TKey, TValue> node)
        {
            _list.Remove(node);
            _list.AddFirst(node);
        }
    }
}
