namespace CircularQueue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CircularQueue<int> queue = new CircularQueue<int>(); //creating a new circular queue
            queue.Enqueue(1);//inserting elements
            queue.Enqueue(2);//inserting elements
            queue.Enqueue(3);//inserting elements
            queue.Enqueue(4);//inserting elements
            var arrqueue = queue.ToArray(); //casting queue to an arr
            for (int i = 0; i < queue.Count; i++) // looping to the length of the queue and then printing each element
            {
                Console.Write(arrqueue[i] + " ");
            }
            queue.Dequeue(); // removing the last element, because it is on FILO principle
            Console.WriteLine();
            for (int i = 0; i < queue.Count; i++) // displaying the new arr with the last num removed
            {
                Console.Write(arrqueue[i] + " ");
            }

        }
    }
    public class CircularQueue<T> //creating a generic class
    {
        private T[] elements;//creating an arr of elements
        private int startIndex = 0;
        private int endIndex = 0;

        private const int DefaultCapacity = 4; //setting the default capacity to 4
        public int Count { get; private set; } 
        public CircularQueue() //ctor to initialize if not entered a capacity it sets to 16
        {
            int capacity = 16;
            elements = new T[capacity];
        }
        public CircularQueue(int capacity = DefaultCapacity) // if entered a capacity set to that elase above
        {
            elements = new T[capacity];
        }
        public void Enqueue(T element) //inserting an element into the queue (FILO prinicple)
        {
            if (this.Count >= this.elements.Length)
            {
                this.Grow(); //growing the queue if the nums are more than it's capacity
            }
            this.elements[this.endIndex] = element;
            this.endIndex = (this.endIndex + 1) % this.elements.Length; //math formula (given)
            this.Count++;
        }
        public void Grow()
        {
            var newElements = new T[2 * this.elements.Length]; //creating a new array that is double the capacity of the previus one 
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
                sourceindex = (sourceindex + 1 ) % this.elements.Length; //math formula (given)
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
            this.startIndex = (startIndex + 1) % this.elements.Length; //math formula (given)
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
