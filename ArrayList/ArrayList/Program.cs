namespace ArrayList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ArrayList<int> list = new ArrayList<int>();
            list.Add(5);
            list.Add(6);
            list.Add(7);
            list.Add(8);
            list.Add(9);
            list.Add(10);
            for (int i = 0; i < list.Count; i++)
            {
                Console.Write(list[i] + " ");
            }
            list.RemoveAt(2);

        }
    }
    class ArrayList<T>
    {
        const int Initial_Capacity = 2;
        private T[] items;
        public int Count
        {
            get; private set;
        }
        public ArrayList()
        {
            this.items = new T[Initial_Capacity];
        }
        public T this[int index]
        {
            get {  
                ValidateIndex(index);
                return items[index]; }
            set {
                ValidateIndex(index);
                items[index] = value; }
        }
        private void ValidateIndex(int index)
        {
            if (index >= this.Count)
            {
                throw new IndexOutOfRangeException();
            }

        }
        public void Add(T item)
        {
                if (this.Count < this.items.Length)
                {
                    this.items[this.Count++] = item;
                }
                else
                {
                    T[] newarr = new T[this.items.Length * 2];
                    for (int i = 0; i < this.items.Length; i++)
                    {
                        newarr[i] = this.items[i];
                    }
                    this.items = newarr;
                    this.items[this.Count++] = item;
                }
            


        }
        public T RemoveAt(int index)
        {
            ValidateIndex(index);
            T elmnt = this.items[index];
            this.items[index] = default(T);
            for (int i = index; i < this.Count - 1; i++)
            {
                this.items[i] = this.items[i + 1];
            }
            this.Count--;

            return elmnt;
        }
    }
}
