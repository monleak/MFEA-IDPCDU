using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MFEA_IDPCDU.util.io;
using MFEA_IDPCDU.basic;

namespace MFEA_IDPCDU.main
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Graph.Graph graph = DataIO.ReadFile(Params.DATA_SET1_PATH + "\\idpc_10x5x425.idpc");
            Individual temp = new Individual(graph);
            temp.randomInit();

        }
    }
}