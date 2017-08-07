using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateBit
{
    class Program
    {
        //设置某一个bit为0
        static uint ClearBit(uint n, int i)
        {
            uint mask = 0xffffffff;
            mask = mask ^ (1u << i);
            return n & mask;
        }

        static uint CreateBitWithinLimit32(int n) //n<=32时得到n个1的二进制数
        {
            uint mask = 0xffffffff;
            return mask >> (32- n);

            //uint figure = 0u;
            //for (int i = 0; i < n; i++)
            //{
            //    figure = figure | (1u << i);
            //}
            //return figure;
        }

        static long CreateBitOverLimit32(int n) //n>32时得到n个1的二进制数
        {
            long figure = 0L;
            for (int i = 0; i < n; i++)
            {
                figure = figure | (1L << i);
            }
            return figure;
        }
        
        static uint CreateBitWithOneAndZero(int n) //n<=32时得到n个1和(32-n)个0
        {
            uint mask = 0xffffff;
            return mask << (32 - n);

            //var created = CreateBitWithinLimit32(n);
            //int numberOfZero = 32 - n;
            //for(int i = numberOfZero; i >= 0; i--)
            //{
            //    uint mask = 0xffffffff;
            //    mask = mask ^ (1u << i);
            //    created = created & mask;
            //}
            //return created;
        }
        

        static void Main(string[] args)
        {
            Console.WriteLine("请输入1的个数：");
            int n = Convert.ToInt32(Console.ReadLine());
            
            if (n <= 32)
            {
                var limitWithinBit32 = CreateBitWithinLimit32(n);
                var bitWithOneAndZero = CreateBitWithOneAndZero(n);
                Console.WriteLine("n <= 32，未越界：");
                Console.WriteLine(Convert.ToString(limitWithinBit32, 2));
                Console.WriteLine("n个1和(32-n)个0的二进制数：");
                Console.WriteLine(Convert.ToString(bitWithOneAndZero, 2));
            }
            else
            {
                var limitOverBit32 = CreateBitOverLimit32(n);
                Console.WriteLine("n > 32，越界：");
                Console.WriteLine(Convert.ToString(limitOverBit32, 2));
            }
            

            Console.ReadKey();
        }
    }
}
