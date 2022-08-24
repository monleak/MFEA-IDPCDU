﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace MFEA_IDPCDU.Graph
{
    public class Graph
    {
        public List<Node> Nodes;
        public int N;
        public int Domain;
        public int Node_s; // id node được đánh bắt đầu từ 1,2,...
        public int Node_t;

        public Graph()
        {
            this.Nodes = new List<Node>();
            N= 0;
            Domain= 0;
            Node_s= 0;
            Node_t= 0;
        }
    }
}
