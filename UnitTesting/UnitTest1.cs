using BTree;

namespace UnitTesting
{
    public class UnitTest1
    {
        [Fact]
        public void Insert()
        {
            Tree tree = new Tree();
            for (int i = 10; i < 160; i+= 10)
            {
                tree.Insert(i);
            }
        }
    }
}