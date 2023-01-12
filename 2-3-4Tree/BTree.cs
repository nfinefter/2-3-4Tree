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
        public const int Degree = 3;

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

            Insert(current, key);
        }

        private void Insert(Node curr, int key)
        {
            if (curr == null)
            {
                return;
            }

            if (curr.Children != null)
            {
                for (int i = 0; i < curr.Keys.Count; i++)
                {
                    if (key < curr.Keys[i])
                    {
                        Insert(curr.Children[i], key);
                     
                        //checks for split
                        
                        return;
                    }
                    else if ((key > curr.Keys[i] && curr.Keys.Count == i + 1) || key < curr.Keys[i + 1])
                    {
                        Insert(curr.Children[i + 1], key);

                        //checks for split

                        return;
                    }
                }
            }

            for (int i = 0; i < curr.Keys.Count; i++)
            {
                if (key < curr.Keys[i])
                {
                    curr.Keys.Insert(i, key);
                }
                else if ((key > curr.Keys[i] && curr.Keys.Count == i + 1) || key < curr.Keys[i + 1])
                {
                    curr.Keys.Insert(i + 1, key);
                }
                if (curr.Keys.Count == Degree)
                {
                    return;
                }
            }

        }
        public void Split(Node curr, int key)
        {

        }
    }
}

