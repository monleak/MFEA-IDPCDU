using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace MFEA_IDPCDU.Graph
{
    public class Node
    {
        public int id;
        public List<Edge> Out_Edge;

        public Node(int id)
        {
            this.id = id;
            Out_Edge = new List<Edge>();
        }
    }
}
