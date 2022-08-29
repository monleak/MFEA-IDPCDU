using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MFEA_IDPCDU.util.io;
using MFEA_IDPCDU.basic;
using MFEA_IDPCDU.Graph;
using MFEA_IDPCDU.Growing_Path_Algorithm;
using MFEA_IDPCDU.util.crossover;
using MFEA_IDPCDU.core;
using System.IO;

namespace MFEA_IDPCDU.main
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Reading data....");
            DataIO.paramsInit(); //Đọc dữ liệu đầu vào và khởi tạo tham số
            Console.WriteLine("Finish reading data");
            for (int seed = 30;seed <= 30; seed++)
            {
                Params.random = new Random(seed);
                MFEA solver = new MFEA();
                Console.WriteLine("Runing....");
                List<Individual> result = solver.run1();

                for (int i = 0; i < result.Count; i++)
                {
                    result[i].printIndividual();
                }
            }
        }
    }
}