﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace MFEA_IDPCDU.Graph
{
    internal class Node
    {
        public int id;
        public int max_Out_Edge;
        public List<Edge> Out_Edge;

        public Node(int id)
        {
            this.id = id;
            max_Out_Edge = 0;
            Out_Edge = new List<Edge>();
        }
    }
}