using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MFEA_IDPCDU.Graph;
using MFEA_IDPCDU.basic;
using System.IO;

namespace MFEA_IDPCDU.util.io
{
    internal class DataIO
    {
        public static Graph.Graph ReadFile(String file)
        {
            Graph.Graph graph = new Graph.Graph();
            string[] Lines = File.ReadAllLines(file);

            string[] N_and_D = Lines[0].Split(new char[] { ' ' }, StringSplitOptions.None);
            graph.N = int.Parse(N_and_D[0]);
            for(int i = 1; i <= int.Parse(N_and_D[0]); i++)
            {
                Node node = new Node(i);
                graph.Nodes.Add(node);
            }
            graph.Domain = int.Parse(N_and_D[1]);

            string[] NodeS_and_NodeT = Lines[1].Split(new char[] { ' ' }, StringSplitOptions.None);
            graph.Node_s = int.Parse(NodeS_and_NodeT[0]);
            graph.Node_t = int.Parse(NodeS_and_NodeT[1]);

            for(int i = 2; i < Lines.Length; i++)
            {
                string[] temp = Lines[i].Split(new char[] { ' ' }, StringSplitOptions.None);
                Edge edge = new Edge();
                edge.id_source = int.Parse(temp[0]);
                edge.id_destination = int.Parse(temp[1]);
                edge.Weight = int.Parse(temp[2]);
                edge.domain = int.Parse(temp[3]);

                graph.Nodes[edge.id_source-1].Out_Edge.Add(edge);
            }
            for(int i = 0; i < graph.Nodes.Count; i++)
            {
                graph.Nodes[i].Out_Edge.Sort(); //Sắp xếp theo id của node đích và sắp xếp theo cost (mặc định)
            }
            return graph;
        }
    }
}
