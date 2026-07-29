namespace LRUCache
{
    internal class Node<TKey, TValue>
    {
        public TKey Key { get; set; }
        public TValue Value { get; set; }

        public Node(TKey key, TValue value)
        {
            this.Key = key;
            this.Value = value;
        }
    }
}
