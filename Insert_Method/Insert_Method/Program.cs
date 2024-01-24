namespace ConsoleApp2;

class ConsoleApp2
{
    static void Main()
    {
        Console.Write("Enter a sorted array of elements (separated by spaces):");
        int[] array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray(); //reads a sorted array

        Console.Write("Enter a number: ");
        int numberToInsert = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException()); //converts number to int and checks if it's a null
        
        int[] newArray = Insert(array, numberToInsert); //inserts the number

        Console.WriteLine("New array:");
        Console.WriteLine(string.Join(" ", newArray));

        Console.WriteLine("Both arrays:");
        Console.WriteLine("Before inserting: " + string.Join(" ", array));
        Console.WriteLine("After inserting: " + string.Join(" ", newArray));
    }

    static int[] Insert(int[] array, int numberToInsert)
    {
        int indexToInsert = Array.BinarySearch(array, numberToInsert); //insert a number using a binary search

        if (indexToInsert < 0)
        {
            indexToInsert = ~indexToInsert; //if the index is below 0 it uses a bitwise operator to substract 1 and convert it to a positive integer
        }

        int[] newArray = new int[array.Length + 1]; //creates a new array
        Array.Copy(array, newArray, indexToInsert); //copies the first array into the second array
        newArray[indexToInsert] = numberToInsert;
        Array.Copy(array, indexToInsert, newArray, indexToInsert + 1, array.Length - indexToInsert);

        return newArray;
    }
}