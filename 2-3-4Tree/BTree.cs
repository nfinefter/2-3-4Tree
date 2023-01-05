using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BTree
{
    public class Tree
    {
        private Node root;

        public Tree()
        {
            root = null;
        }

        public void Insert(int key)
        {
            if (root == null)
            {
                root = new Node(new List<int> { key});
                return;
            }

            Node current = root;

            int degree = current.Keys.Count + 1;

            Insert(current, key, -1);
        }

        private void Insert(Node curr, int key, int index)
        {
            if (curr == null)
            {
                return;
            }

            index++;
            foreach (var item in curr.Keys)
            {
                if (item.CompareTo(key) > 0)
                {
                    Insert(curr.Children[index], key, index);
                }
                else
                {
                    //curr.Keys.Insert()
                }
            }
        }
        public void Split(Node curr)
        {

        }
    }
}

