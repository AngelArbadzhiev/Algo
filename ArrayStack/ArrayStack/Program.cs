using System.ComponentModel;

namespace ArrayStack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ArrayStack<int> arrayStack = new ArrayStack<int>(); //creating new int srray srack
            arrayStack.Push(1);
            arrayStack.Push(2);
            arrayStack.Push(3);
            arrayStack.Push(4);
            arrayStack.Push(5);
            arrayStack.Push(6);
            arrayStack.Push(7);
            arrayStack.Push(8);
            arrayStack.Push(9);
            arrayStack.Push(10);
            arrayStack.Push(11);
            arrayStack.Push(12);
            arrayStack.Push(13);
            arrayStack.Push(14);
            arrayStack.Push(15);
            arrayStack.Push(16);
            arrayStack.Push(17);
            for (int i = 0; i < arrayStack.Count; i++)
            {
                Console.Write(arrayStack.ToArray()[i] + " "); //printing all elements
            }
            arrayStack.Pop();// popping the last element 
            Console.WriteLine();
            for (int i = 0; i < arrayStack.Count; i++)
            {
                Console.Write(arrayStack.ToArray()[i] + " "); //printing all element except the last one, beacuse it has been popped
            }
        }
    }
    class ArrayStack<T>
    {
        private T[] elements;
        private int index;
        private const int InitialCapacity = 16; 
        public int Count { get; private set;}
        public ArrayStack(int capacity = InitialCapacity)
        {
            elements = new T[InitialCapacity];
        }
        public void Push(T element) //pusing an element into the array stack
        {
            if (this.Count == this.elements.Length) 
            {
                Grow();
            }
            this.elements[this.Count++] = element;

        }
        public T Pop() //FILO priniciple 
        {
            if (elements == null) //if nothing in array stk throw exception
            {
                throw new InvalidOperationException();
            }
            this.Count--; //decrementing the array stack
            return this.elements[this.Count];

        }
        public T[] ToArray()
        {
            return elements;
        }
        private void Grow() //creating a new array stack double the elements 
        {
            if (this.Count <= this.elements.Length)
            {
                var newarr = new T[2 * this.elements.Length];
                this.CopyAllElementsTo(newarr);
                this.elements = newarr;
            }

        }
        private void CopyAllElementsTo(T[] resultarr)
        {
            int sourceIndex = this.index;
            int destinationIndex = 0;
            for (int i = 0; i < this.Count; i++)
            {
                resultarr[destinationIndex] = this.elements[sourceIndex];
                sourceIndex++; 
                destinationIndex++;
            }
        }

    }
}
