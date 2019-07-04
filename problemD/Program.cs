using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace problemD
{
    class Program
    {
        static String fixedString(string str)
        {
            return str.PadRight(16, ' ');
        }
        static void printPart1(int n,int[] spaceArray)
        {
            Console.Write("　　　　　█");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j <= spaceArray[i]; j++)
                {
                    Console.Write("█");
                }
            }
            Console.WriteLine();
        }
        static void printPart2(int n, int[] spaceArray)
        {
            Console.Write("　　　　　");
            for (int i = 0; i < n; i++)
            {
                Console.Write("█");
                Console.Write("".PadRight(spaceArray[i] * 2, ' '));
            }
            Console.Write("█");
            Console.WriteLine();
        }
        static void printPart2(string str,int n, int[] spaceArray)
        {
            Console.Write(str);
            for (int i = 0; i < n; i++)
            {
                Console.Write("█");
                Console.Write("".PadRight(spaceArray[i] * 2, ' '));
            }
            Console.Write("█");
            Console.WriteLine();
        }
        static void printPart2(string str, int n, int[] spaceArray, int[] programming, List<int>[] group)
        {
            Console.Write(str);
            for (int i = 0; i < n; i++)
            {
                Console.Write("█");
                string rst = "";
                for (int j = 0; j < group[i].Count(); j++)
                {
                    int id = group[i][j];
                    if (programming[id] == 0) continue;
                    rst += ("P" + (id + 1)).PadRight(programming[id] * 2, '=');
                }
                rst = rst.PadRight(spaceArray[i]*2, ' ');
                Console.Write(rst);
            }
            Console.Write("█");
            Console.WriteLine();
        }
        static void printPart3(int n, int[] spaceArray)
        {
            Console.Write("　　　　　　");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < spaceArray[i]; j++)
                {
                    Console.Write((j+1) + "-");
                }
                Console.Write("  ");
            }
            Console.Write("　");
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            int n, m;
            Console.WriteLine("記憶體管理程式-最適配置法(Best Fit)");
            Console.Write("請輸入記憶體區塊數(<6):");
            n = Convert.ToInt32(Console.ReadLine());
            Console.Write("請輸入程序數(<6):");
            m = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("請輸入各區塊大小(<10)---");
            int[] spaceArray = new int[6];
            int[] programArray = new int[6];
            for (int i = 0; i < 6; spaceArray[i] = 0, i++) ;
            for (int i = 0; i < 6; programArray[i] = 0, i++) ;
            for(int i = 0; i < n; i++)
            {
                Console.Write("區塊" + (i + 1) + ":");
                spaceArray[i] = Convert.ToInt16(Console.ReadKey().KeyChar - '0');
                Console.Write(", ");
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("請輸入各程式所需大小(<10)---");
            for (int i = 0; i < m; i++)
            {
                Console.Write("程序" + (i + 1) + ":");
                programArray[i] = Convert.ToInt16(Console.ReadKey().KeyChar - '0');
                Console.Write(", ");
            }
            int[] select = new int[6];
            List<int>[] group = new List<int>[6];
            for (int i = 0; i < 6; select[i] = 0, i++);
            int count = 100000;
            for (int a = 0; a < n; a++)
            {
                for (int b = 0; b < n; b++)
                {
                    for (int c = 0; c < n; c++)
                    {
                        for (int d = 0; d < n; d++)
                        {
                            for (int e = 0; e < n; e++)
                            {
                                for (int f = 0; f < n; f++)
                                {
                                    int[] vec = new int[6];
                                    int[] item = new int[6];
                                    bool[] put = new bool[6];
                                    for (int i = 0; i < 6; i++)
                                    {
                                        vec[i] = spaceArray[i];
                                    }
                                    for (int i = 0; i < 6; i++)
                                    {
                                        item[i] = programArray[i];
                                    }
                                    if (vec[a] - item[0] >= 0)
                                    {
                                        put[0] = true;
                                        vec[a] -= item[0];
                                    }
                                    if (vec[b] - item[1] >= 0)
                                    {
                                        put[1] = true;
                                        vec[b] -= item[1];
                                    }
                                    if (vec[c] - item[2] >= 0)
                                    {
                                        put[2] = true;
                                        vec[c] -= item[2];
                                    }
                                    if (vec[d] - item[3] >= 0)
                                    {
                                        put[3] = true;
                                        vec[d] -= item[3];
                                    }
                                    if (vec[e] - item[4] >= 0)
                                    {
                                        put[4] = true;
                                        vec[e] -= item[4];
                                    }
                                    if (vec[f] - item[5] >= 0)
                                    {
                                        put[5] = true;
                                        vec[f] -= item[5];
                                    }
                                    bool find = false;
                                    int mn = 0;
                                    for (int i = 0; i < 6 && find == false; i++)
                                    {
                                        mn += vec[i];
                                    }
                                    if (mn < count)
                                    {
                                        select[0] = (put[0] == true ? a : -1);
                                        select[1] = (put[1] == true ? b : -1);
                                        select[2] = (put[2] == true ? c : -1);
                                        select[3] = (put[3] == true ? d : -1);
                                        select[4] = (put[4] == true ? e : -1);
                                        select[5] = (put[5] == true ? f : -1);
                                        for (int i = 0; i < 6; group[i] = new List<int>(), i++) ;
                                        for (int i = 0; i < select.Length; i++)
                                        {
                                            int val = select[i];
                                            if (val == -1) continue;
                                            group[val].Add(i);
                                        }
                                        count = mn;
                                    }                                   
                                }
                            }
                        }
                    }
                }
            }
            Console.WriteLine();
            Console.WriteLine();
            for (int i = 0; i <= m; i++)
            {
                if(i == 0)
                {
                    Console.WriteLine("程式編號　　　　所需大小　　　　區塊編號　　　　區塊大小　　　　剩餘空間");
                    continue;
                }
                Console.Write(fixedString(i.ToString()));
                Console.Write(fixedString(programArray[i - 1].ToString()));
                int sel = select[i - 1];
                if (sel != -1)
                {
                    Console.Write(fixedString((select[i - 1] + 1).ToString()));
                    Console.Write(fixedString(spaceArray[select[i - 1]].ToString()));
                    Console.Write(fixedString((spaceArray[select[i - 1]] - programArray[i - 1]).ToString()));
                }
                else
                {
                    Console.Write("未分配記憶體區塊");
                    Console.Write(fixedString(""));
                    Console.Write(fixedString(""));
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            printPart1(n, spaceArray);
            printPart2(n, spaceArray);
            printPart2("配置程序前", n, spaceArray);
            printPart2(n, spaceArray);
            printPart1(n, spaceArray);
            printPart3(n, spaceArray);
            printPart1(n, spaceArray);
            printPart2(n, spaceArray);
            printPart2("程序配置後", n, spaceArray,programArray,group);
            printPart2(n, spaceArray);
            printPart1(n, spaceArray);
        }
    }
}
