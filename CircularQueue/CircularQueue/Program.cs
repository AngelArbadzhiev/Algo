namespace CircularQueue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CircularQueue<int> queue = new CircularQueue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            var arrqueue = queue.ToArray();
            for (int i = 0; i < queue.Count; i++)
            {
                Console.Write(arrqueue[i] + " ");
            }
            queue.Dequeue();
            Console.WriteLine();
            for (int i = 0; i < queue.Count; i++)
            {
                Console.Write(arrqueue[i] + " ");
            }

        }
    }
    public class CircularQueue<T>
    {
        private T[] elements;
        private int startIndex = 0;
        private int endIndex = 0;

        private const int DefaultCapacity = 4;
        public int Count { get; private set; }
        public CircularQueue()
        {
            int capacity = 16;
            elements = new T[capacity];
        }
        public CircularQueue(int capacity = DefaultCapacity)
        {
            elements = new T[capacity];
        }
        public void Enqueue(T element)
        {
            if (this.Count >= this.elements.Length)
            {
                this.Grow();
            }
            this.elements[this.endIndex] = element;
            this.endIndex = (this.endIndex + 1) % this.elements.Length;
            this.Count++;
        }
        public void Grow()
        {
            var newElements = new T[2 * this.elements.Length];
            this.CopyAllElementsTo(newElements);
            this.elements = newElements;
            this.startIndex = 0;
            this.endIndex = this.Count;
        }
        public void CopyAllElementsTo(T[] resultArr)
        {
            int sourceindex = this.startIndex;
            int destinationIndex = 0;
            for (int i = 0; i < this.Count; i++)
            {
                resultArr[destinationIndex] = this.elements[sourceindex];
                sourceindex = (sourceindex + 1 ) % this.elements.Length;
                destinationIndex++;

            }
        }
        public T Dequeue()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }
            var result = this.elements[startIndex];
            this.startIndex = (startIndex + 1) % this.elements.Length;
            this.Count--;
            return result;
        }
        public T[] ToArray()
        {
            var resultArr = new T[this.Count];
            CopyAllElementsTo(resultArr);
            return resultArr;
        }
    }
}
