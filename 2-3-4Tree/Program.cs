using BTree;

namespace _2_3_4Tree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Tree tree = new Tree();


            Random rand = new Random(0);

            int repeat = 500000;

            for (int i = 0; i < repeat; i++)
            {
                var a = rand.Next(0, 100);
                tree.Insert(a);
            }
        }
    }
}