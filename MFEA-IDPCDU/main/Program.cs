using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MFEA_IDPCDU.util.io;
using MFEA_IDPCDU.basic;
using MFEA_IDPCDU.Graph;
using MFEA_IDPCDU.Growing_Path_Algorithm;
using System.IO;

namespace MFEA_IDPCDU.main
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            //Đọc file và lấy list đồ thị
            string[] filePaths = Directory.GetFiles(Params.DATA_SET1_PATH, "*.idpc", SearchOption.TopDirectoryOnly);
            for (int i = 0; i < filePaths.Length; i++)
            {
                Graph.Graph graph = DataIO.ReadFile(filePaths[i]);
                Params.List_graph.Add(graph);
            }

            //Duyệt các đồ thị để lấy thuộc tính cho không gian chung
            for (int i = 0; i < Params.List_graph.Count; i++)
            {
                if (Params.USS_N < Params.List_graph[i].N) Params.USS_N = Params.List_graph[i].N;
                if (Params.USS_D < Params.List_graph[i].Domain) Params.USS_D = Params.List_graph[i].Domain;
            }
            Params.USS_S = new int[Params.USS_N];
            for (int node = 0; node < Params.USS_S.Length; node++)
            {
                for (int i = 0; i < Params.List_graph.Count; i++)
                {
                    if (Params.List_graph[i].N < node + 1) continue; //Nếu đồ thị không chưa node đang xét thì bỏ qua
                    if (Params.USS_S[node] < Params.List_graph[i].Nodes[node].Out_Edge.Count)
                    {
                        Params.USS_S[node] = Params.List_graph[i].Nodes[node].Out_Edge.Count;
                    }
                }
            }

            for (int seed = 1;seed <= 30; seed++)
            {
                Params.random = new Random(seed);

                Individual test = new Individual();
                test.randomInit();
                List<Edge> temp = GPA.runGPA(test, 20);
                foreach(Edge e in temp)
                {
                    Console.Write(e.id_source + " " + e.id_destination + "|");
                }
                Console.Write("\n");
            }
        }
    }
}