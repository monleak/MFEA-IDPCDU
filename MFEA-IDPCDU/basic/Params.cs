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

        public static int countEvals = 0; //Đếm số lần đánh giá
        public static int maxEvals; //Số lần đánh giá tối đa

        public static int USS_N = 0; //Số node trong không gian chung
        public static int USS_D = 0; //Số miền trong không gian chung
        public static int[] USS_S; //Số lượng "cạnh nối ra" trong không gian chung

        public static int MAX_POP_SIZE = 100; //Số lượng cá thể mỗi quần thể
        public static int MIN_POP_SIZE = 5; //Số cá thể tối thiểu mỗi tác vụ
        public static int MAX_EVALS_PER_TASK = 100000;

        public static double R_mutation = 0.05;
        public static double rmp = 0.5;

        public static List<Graph.Graph> List_graph = new List<Graph.Graph>();

        public static String DATA_SET1_PATH = "..\\..\\..\\..\\Data\\set1";
        public static String DATA_SET2_PATH = "..\\..\\..\\..\\Data\\set2";
    }
}
