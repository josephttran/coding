namespace Code.Models
{
    class MinHeapNode
    {
        public int KIndex { get; set; }
        public int Value { get; set; }

        public MinHeapNode(int k, int v)
        {
            KIndex = k;
            Value = v;
        }
    }
}
