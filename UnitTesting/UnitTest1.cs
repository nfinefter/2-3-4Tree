using BTree;

namespace UnitTesting
{
    public class UnitTest1
    {
        [Fact]
        public void Insert()
        {
            Tree tree = new Tree();
            //for (int i = 10; i < 160; i += 10)
            //{
            //    tree.Insert(i);
            //}

            Random rand = new Random(0);

            int repeat = rand.Next(0, 10);

            for (int i = 0; i < repeat; i++)
            {
                var a = rand.Next(0, 100);
                Console.WriteLine(a);
                tree.Insert(a);
            }
        }
    }
}