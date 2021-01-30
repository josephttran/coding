namespace Code.Ds
{
    public class DisjointSet
    {
        int[] rank;

        public DisjointSet(int num)
        {
            rank = new int[num];

            for (int i = 0; i < num; i++)
            {
                rank[i] = i;
            }
        }

        public bool IsConnected(int x, int y)
        {
            int xRoot = Find(x);
            int yRoot = Find(y);

            if (xRoot == yRoot)
            {
                return true;
            }

            return false;
        }

        public int Find(int i)
        {
            while (rank[i] != i)
            {
                rank[i] = rank[rank[i]];
                i = rank[i];
            }

            return i;
        }

        public void Union(int x, int y)
        {
            int xRoot = Find(x);
            int yRoot = Find(y);

            if (xRoot == yRoot)
            {
                return;
            }

            rank[xRoot] = yRoot;
        }
    }
}
