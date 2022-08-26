using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFEA_IDPCDU.basic
{
    internal class Params
    {
        public static Random random;
        public static int USS_N = 0; //Số node trong không gian chung
        public static int USS_D = 0; //Số miền trong không gian chung
        public static int[] USS_S; //Số lượng "cạnh nối ra" trong không gian chung

        public static List<Graph.Graph> List_graph = new List<Graph.Graph>();

        public static String DATA_SET1_PATH = "..\\..\\..\\..\\Data\\set1";
        public static String DATA_SET2_PATH = "..\\..\\..\\..\\Data\\set2";
    }
}
