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

            Node curr = root;

            Insert(curr, key);

            if (curr.Keys.Count == Degree)
            {
                if (curr.Children == null)
                {
                    Node Left = new Node(new List<int> { curr.Keys[0] });

                    Node Right = new Node(new List<int> { curr.Keys[2] });

                    curr.Keys.RemoveAt(0);
                    curr.Keys.RemoveAt(1);
                    curr.Children = new List<Node>() { Left, Right };
                }
                else
                {
                    Node Left = new Node(new List<int> { curr.Keys[0] });

                    Node Right = new Node(new List<int> { curr.Keys[2] });

                    curr.Keys.RemoveAt(0);
                    curr.Keys.RemoveAt(1);

                    Node newLeftChildren = curr.Children[0];
                    Node newSecondChildren = curr.Children[1];

                    Node newThirdChildren = curr.Children[2];
                    Node newRightChildren = curr.Children[3];

                    curr.Children = new List<Node>() { Left, Right};

                    curr.Children[0].Children = new List<Node> { newLeftChildren, newSecondChildren};

                    curr.Children[1].Children = new List<Node> { newThirdChildren, newRightChildren };
                }
            }
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

                        SplitCheck(curr, i);

                        return;
                    }
                    else if ((key > curr.Keys[i] && curr.Keys.Count == i + 1) || key < curr.Keys[i + 1])
                    {
                        Insert(curr.Children[i + 1], key);

                        SplitCheck(curr, i + 1);

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
                else if ((key > curr.Keys[i] && curr.Keys.Count == i + 1) || key < curr.Keys[i])
                {
                    curr.Keys.Insert(i + 1, key);
                }
                if (curr.Keys.Count == Degree)
                {
                    return;
                }
            }

        }
        private void Split(Node curr, int i)
        {
            curr.Keys.Add(curr.Children[i].Keys[1]);

            curr.Children[i].Keys.Remove(curr.Children[i].Keys[1]);

            int rightChild = curr.Children[i].Keys[1];

            curr.Children[i].Keys.Remove(curr.Children[i].Keys[1]);

            Node newNode = new Node(new List<int>() { rightChild });

            curr.Children.Insert(i + 1, newNode);


            if (curr.Children[i].Children != null)
            {
                List<Node> newChildren = new List<Node>();

                for (int j = curr.Children[i].Children.Count / 2; j < curr.Children[i].Children.Count;)
                {
                    newChildren.Add(curr.Children[i].Children[j]);

                    curr.Children[i].Children.RemoveAt(j);
                }

                curr.Children[i + 1].Children = newChildren;
            }

            return;
        }
        public void SplitCheck(Node curr, int i)
        {
            if (curr.Children[i].Keys.Count == Degree)
            {
                Split(curr, i);
            }
        }
    }
}

