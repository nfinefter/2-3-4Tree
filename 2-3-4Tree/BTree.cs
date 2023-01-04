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
                root = new Node(key);
                return;
            }

            Node current = root;
            while (true)
            {
                if (current.Key2 == 0)
                {
                    // current is a 2-node
                    if (key < current.Key1)
                    {
                        current.Key2 = current.Key1;
                        current.Key1 = key;
                    }
                    else
                    {
                        current.Key2 = key;
                    }
                    break;
                }
                else if (current.Key3 == 0)
                {
                    // current is a 3-node
                    if (key < current.Key1)
                    {
                        current.Key3 = current.Key2;
                        current.Key2 = current.Key1;
                        current.Key1 = key;
                    }
                    else if (key < current.Key2)
                    {
                        current.Key3 = current.Key2;
                        current.Key2 = key;
                    }
                    else
                    {
                        current.Key3 = key;
                    }

                    // split the 3-node
                    Node left = new Node(current.Key1)
                    {
                        Left = current.Left,
                        Middle = current.Middle,
                        Parent = current
                    };
                    Node right = new Node(current.Key3)
                    {
                        Left = current.Right,
                        Parent = current
                    };
                    current.Left = left;
                    current.Middle = null;
                    current.Right = right;
                    current.Key1 = current.Key2;
                    current.Key2 = 0;
                    current.Key3 = 0;
                }
                else
                {
                    // current is a 4-node
                    if (key < current.Key1)
                    {
                        current.Key3 = current.Key2;
                        current.Key2 = current.Key1;
                        current.Key1 = key;
                    }
                    else if (key < current.Key2)
                    {
                        current.Key3 = current.Key2;
                        current.Key2 = key;
                    }
                    else if (key < current.Key3)
                    {
                        current.Key3 = key;
                    }
                    else
                    {
                        key = current.Key3;
                        current.Key3 = 0;
                    }

                    // split the 4-node
                    Node left = new Node(current.Key1);

                    left.Left = current.Left;
                    left.Middle = current.Middle;
                    left.Parent = current;


                    Node right = new Node(current.Key3);

                    right.Left = current.Right;
                    right.Parent = current;

                    current.Left = left;
                    current.Middle = null;
                    current.Right = right;
                    current.Key1 = current.Key2;
                    current.Key2 = 0;
                    current.Key3 = 0;
                }

                // move down the tree
                if (key < current.Key1)
                {
                    if (current.Left == null)
                    {
                        current.Left = new Node(key);
                        current.Left.Parent = current;
                        break;
                    }
                    current = current.Left;
                }
                else if (current.Key2 == 0 || key < current.Key2)
                {
                    if (current.Middle == null)
                    {
                        current.Middle = new Node(key);
                        current.Middle.Parent = current;
                        break;
                    }
                    current = current.Middle;
                }
                else
                {
                    if (current.Right == null)
                    {
                        current.Right = new Node(key);
                        current.Right.Parent = current;
                        break;
                    }
                    current = current.Right;
                }
            }
        }

    }
}

