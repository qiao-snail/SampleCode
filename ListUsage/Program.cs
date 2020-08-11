﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace ListUsage
{
    /*
     * 算法面试题：一个List，要求删除里面的男生，不用Linq和Lamda，求各种解，并说明优缺点！
     */
    class Program
    {
        #region 数据
        /// <summary>
        /// 1男0女
        /// </summary>
        static string text = "0000100010101001101101011110111111100000100010001101010101001101111010100001010101100101011011101011111010101000111100110101001001000010100000010111010110011010111100000101110011011100100010110101100010111010100010110000001011110110000011110001101001000000111100110101101111111000011100010110010000000101111010111011100000101111000011101101110100111010101001010000001101000100111011111101010100011011000001001010100100001001011001100011001010111110110100101101101010010100010101011100110101110011011101001001001110101101011010101001000011001111010101110101010001111010110001011100010001000011000101000011010011011000100011111110111010001111111000100011110000100010010101000111110111111101111111000000001011010101000100100101010100000111101111010011011011100000001001000110011100110110001110100100110010011100000110111010010011100011001100010001011100010010001011100110101110000001000010001111101010110000111111110101110100111101110000111000110011110101001110010001010100110110010100011110110111010010011011100011010111011010100110011010001110011101000100010100011110001000101010100000010111011010101100001111011000001110110010011111011000010001101100001101100001010010000001001101110101110001100000100100100110101110110110101001111011011010111000100110011011111001010001100001011000110000100011000010010101011010100111001000110001011101010100010101111101100101001110100111000011110101111111001011100001001001100110011001010001111000110000101111010101010011101010111000000001001111001111101010101010101101100101010111001011100000010001011001000001110101000110111000011110101010110101101001001101001110000010000000010011111110101001111111000100100010001100101111011111000110100000000000110010011101010010011100000000111111000001011100000101100001100010101111010110000100011101101101111011100010011111100100100001001001011001000000010100110101110101101100001000011110001100010101011000100000000011101001101101100101010011000101100100001010100011100111110011100110110011100011100011110001101100000001111011100111110011111100001100001111101101111101110001111011010100011000101000111110110111011000011110010110010010100011100101111000101110010110100000011010000101110100001101001001110010110101101011110110001111101101000000011011010001111000010110000011110100101011011100100111001101001101110011101010001001001010010111100010111111111001101010000011000000000101111101011110111001001000010100000010100000110101001101100001111001011100000101010000010000111101100111011101001111000011110111011100011101110000101111000111011101010100000110011000010001101101110000111010111100001011110001101100001000110101010010001010000000001110111011110001110101000000101110010100110010110101011100000100010011100001001010100110100100101111010111100000101010100100101001010110000101110110010110100101101111000010100001010011111111010011101001001011001000101000010000000100111001011010110000010001110010011100010111111100101001010100111000100011001111100101100011100000101100110010101100110111100000001111111011000100010100110111011011001000010110100000001111011010001010101110010111101000010110001010110011001010100101010001110100110100111101010011011110011101011111100101011010101101010010000100110111000011011110110000010110110000001010101011110001110001101100110111011010001001010011110100011111110110110000000111100111100111001110111011011010010100101110001111001110001100110011111001001000110011101111111100111011001001010011101100010000111010111000111101010101100010100101000001000111000010001010110110100010100011010110111110111111101001101000010111000111111011001100001111110011111100000110100110000011010110100111001001100111001010011011011000111100001001111100100101101101010111101001101001000101000100101000010110010100001111001010010111101001100011100010111001110100111111101110011100000011110110100001100001011110110100011010010001100000011111110110001001101001010010010000001000111000110101111000011110111011111010100010011011100111010101101010101000000111001111101001001010011011001101111000000111111111111101001011011000001100110111100011100110010111001111001011100001100001100000001010100011010101111101111011010001100010000001101110100111111100111011010110101000110111101001011010100001101001010011110011111101010100010110111001000001110101001111000001100100110100100010110001111001100011111010000101011101001100001101110111111001111100010110101010110011011100101110100001001110011101101011011010100011100110101100000101001111101101000011110000110011011110100111110000001000010100011000110100000111100011101101000000111111101010000111101100100110001011111100011101010011001000001001000111011111101000110111011000110100110000010100001000100101010110011010011110100100000000001000101011000001010011011011110101110001001101110001100110101011001110010111000101001111101011011011000100100011100110100011000111111110100101000001101000000111101111101100000111011110111001101010011010011011010001100010010100101001000111111110001100100001001111010000101010101111011000111111011101110100110010100000001010000101011101011001110111001100010100101111010111100100010111011110100010001001010100110011110110010110101010010011111010011111111101111100110110000101110000110101100111110111011000001101110100110011010010110001111110001110100011011101110000100101110110101010100010110111100010100110100101110001001011011010100001001110100100110101110110100111010010011001001010000101010100100100100101110101001000100110110100011010101101010101011011001001000001101101000000100001011010110010010111010111101001011100110000100010110000100001100110011110101101000101011100010111111000100011111111111111001101011111010100100100010001000111111010110001111000110011111001001100100000010010101100000101011000001101111001010110000001100111111001111101101111101001011110101011111101100010100100100100110001110011010101111110100000011000100111101110010001001101010001101100110010101111011011001001010010101111100100001111010101001010000001001010110101111100111111101001101011101001100101000001000000001001110100010011001110110010011010000011100011011110100010111111011001000001101100111111110110111111111011110110100100100011010000111110001101011000100100110010011101111001010011100100101001001110001000101010000001100000111101000111011001000101110100010101000110100101100001100011111010001010100111001111111111000100111001110011010101101001010111110000110111010000100011000000000101010000101011100010100111101110110010100111001111000101110011111001100101011101011110101011010010111000101100000001100000001001011011111110101000100101110111001001111100000010110110010011001111101110101010000011110001010100001010010111101010011101100010011110111001111110111110000110001011110101001100110101000000010111101011100000010110101010101001110011011001100101001011111101010110101010010111010101110101010001111001111110010111001000100001010101011100111010100001000100111110101111000010000001111111101001010110000101111101110000011011110001011010101100110111001000010110001011001100101110100101100111001000000000111111010110010111011000100100001110110100010001010101110100110111100111010011000001011101001010111011101101000001000111110000011011011010100011111110101100111111101001001001111001100001001110011100001011111001000001011000010100100110101001111100111001000000001000111001000000000010011000111000111111010100000001101010001001010001011011101100010110111010000110001110000110100001001011101001001011111000111010010101101111000100101010001101110110010011011110000101111111111110111101010100101101000011010001101101100101011100011011101100110101011100110100010101011000010110110111101001001101111101011010111010101100010001001010011111100010100111101100001100100111111011110101111111111000100000001001010110011001101001000001111000100110110001110010001011110010110001010110001011110010010000000100100001111111001110011111111000111010000001100000000011001110100000011101110000100100110110101111110101100101100001000001001000100001011110100000011010100111001110100111110101010011010010011101000111011000111001111011111100010110100010101001010100110100000000111111100011010110001111010000100001110000010100111101101001101100110111010010101110101010110011000011000111010100011100000001111110100110010000111000010001010011111011101000110000011100100111000100000111011010101000110010111100010111010011101001000111001101000001110100010110101100101111111000001110010100011111101001110110101100011101100100001111001001111110000001011000100001100110001001101000111111001100001010111010001001011011111110011111110001000110111101011011101010000001100010000010010011010110010100010000101010100000101010100010011010101010100110111000001110100100100011100101000000010001011010001011111110111110000110110111000010010001000000101000000100101110110111011010010111000000101110001001000010010111110111010110000000111101010111111011000001010010010001101010000111101000111011100111011001010011001001101000111111111110000110100110101110110010010100011100001000010001001011111110001111111001100001110110011111110100000011110010011110111111111011000001111101100110111011101000100111001000000101100101101001100111110100111010010110101010111101001000010111010011000010000110111100011011110000010011111001010100100000100000100110000100111000110001010100101001001011010000011010110101100100101011010000001010000011110100101001101000100100001000101100100110101111001001010110101010011111100000111110011101011000001101011000010000001110010101010100000111000100011111100101000010011010110111110011100010111101100101111101101110000100001100010101011101100001101000011110100100101100110000011010010100000011111000111111001010010011110110011010100100010111110110100001101110101111110001000000001000111111011011010000000010010111101011110011100000111000000100111001010010011110010010100100100010101100001001011011101110011110001000011011001001011100111101000100101110110110011000101010010111000111111011111100000010011010101110000101000001110011001001011111100011111010100111100010110001111010100010100001110000101101100000111100101000011010010010111010111001011101011011000111";
        #endregion
        static void Main(string[] args)
        {
            List<int> students = new List<int>(text.Length);
            for (int i = 0; i < text.Length; i++)
            {
                students.Add(text[i] - 48);
            }
            Console.WriteLine("Hello World!");

            Stopwatch sw = new Stopwatch();
            sw.Start();
            var count = Method1(students);
            sw.Stop();
            Console.WriteLine("Method1结果：" + count + " Method1耗时:" + sw.ElapsedMilliseconds);

            sw.Restart();
            var count2 = Method2(students);
            sw.Stop();
            Console.WriteLine("Method2结果：" + count2 + " Method2耗时:" + sw.ElapsedMilliseconds);

            Console.Read();
        }

        /*
         * 暴力解法：遍历数组，将要获取的数据添加到一个新的集合中
         */
        private static int Method1(List<int> students)
        {
            //避免新数组在添加数据时因为自动扩容，导致内存过大而无效
            List<int> newStudents = new List<int>(students.Count);
            for (int i = 0; i < students.Count; i++)
            {
                if (students[i] == 1)
                    newStudents.Add(students[i]);
            }
            return newStudents.Count;
        }
        private static int Method2(List<int> students)
        {
            int total = 0;
            for (int i = 0; i < students.Count; i++)
            {
                if (i == 0 && students[i] == 1)
                    total++;

                for (int j = 0; j < i; j++)
                {
                    if (students[j] < students[i])
                    {
                        var stu = students[i];
                        students[i] = students[j];
                        students[j] = stu;
                        total++;
                        break;
                    }
                }
            }

            int[] newStudents = new int[total];
            students.CopyTo(0, newStudents, 0, newStudents.Length);
            return total;
        }
    }


}
