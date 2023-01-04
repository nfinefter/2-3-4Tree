using BTree;

namespace UnitTest
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(0)]
        public void Insert(int num)
        {
            Tree tree = new Tree();
            for (int i = 0; i < 5; i++)
            {
                tree.Insert(num += 10);
            }
        }

    }
}