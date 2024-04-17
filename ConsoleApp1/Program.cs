namespace ConsoleApp1
{

    public class Program
    {
        public static void Main()
        {
            CustomList<int> myList = new CustomList<int>();

            myList.Add(1);
            myList.Add(2);
            myList.Add(3);
            myList.Add(4);
            myList.Add(5);

            Console.WriteLine("list elements");
            for (int i = 0; i < myList.Count; i++)
            {
                Console.WriteLine(myList.Find(x => true));
            }

            myList.Remove(3);
            Console.WriteLine("list elements after remove 3");
            for (int i = 0; i < myList.Count; i++)
            {
                Console.WriteLine(myList.Find(x => true));
            }
        }
    }
}
