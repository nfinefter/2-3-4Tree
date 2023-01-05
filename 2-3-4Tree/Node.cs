using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BTree
{
    public class Node
    {
        //public int Key1 { get; set; }
        //public int Key2 { get; set; }
        //public int Key3 { get; set; }
        //public Node Left { get; set; }
        //public Node Middle { get; set; }
        //public Node Right { get; set; }
        //public Node Parent { get; set; }

        //public Node(int key1)
        //{
        //    Key1 = key1;
        //}

        public List<int> Keys { get; set; }
        public List<Node> Children { get; set; }

        public Node(List<int> keys)
        {
            Keys = keys;
        }

    }
}
