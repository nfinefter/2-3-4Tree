﻿using System;
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

        public List<int> Keys { get; set; }
        public List<Node> Children { get; set; }

        public Node(List<int> keys)
        {
            Keys = keys;
        }

    }
}
