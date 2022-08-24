using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MFEA_IDPCDU.Graph;

namespace MFEA_IDPCDU.basic
{
    public class Individual
    {
        private static int counter = 0;

        public Graph.Graph graph;
        public int Individual_Id;
        public int[] Priority;
        public int[] Out_Edge_Index;

        public Individual(Graph.Graph new_graph)
        {
            this.Individual_Id = Individual.counter++;
            this.Priority = new int[new_graph.N];
            this.Out_Edge_Index = new int[new_graph.N];
            this.graph = new_graph;
        }

        public void randomInit()
        {
            for(int i=0;i< this.graph.N; i++)
            {
                //Tạo 1 mảng {1,2,3,...,N}
                this.Priority[i] = i + 1;
            }
            Random random = new Random(Params.SEED_RANDOM);
            for(int i=0;i< this.graph.N; i++)
            {   
                //Hoán vị mảng vừa tạo N lần
                int temp1 = random.Next(1, this.graph.N);
                int temp2 = random.Next(1, this.graph.N);
                int temp = this.Priority[temp1];
                this.Priority[temp1] = this.Priority[temp2];
                this.Priority[temp2] = temp;
            }

            for (int i = 0; i < this.graph.N; i++)
            {
                // = random trong khoảng từ 1 đến max out edge
                if (this.graph.Nodes[i].Out_Edge.Count == 0) 
                    this.Out_Edge_Index[i] = -1;
                else 
                    this.Out_Edge_Index[i] = random.Next(1, this.graph.Nodes[i].Out_Edge.Count);
            }
        }
    }
}
