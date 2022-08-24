using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MFEA_IDPCDU.util.io;
using MFEA_IDPCDU.basic;
using MFEA_IDPCDU.Graph;
using MFEA_IDPCDU.Growing_Path_Algorithm;

namespace MFEA_IDPCDU.main
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Graph.Graph graph = DataIO.ReadFile(Params.DATA_SET1_PATH + "\\idpc_10x5x425.idpc");

            Individual test = new Individual(graph);
            test.randomInit();
            List<Edge> temp = GPA.runGPA(test);
            for(int i = 0; i < temp.Count; i++)
            {
                Console.WriteLine(temp[i].id_source + " " + temp[i].id_destination);
            }
        }
    }
}