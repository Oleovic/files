using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TextFiles
{
    class Program
    {
        static bool MakeInt(string str,out int number)
        {
            bool ok = Int32.TryParse(str, out number);
            return ok;
        }
        static void TransformStringToInt(string[] mas1, int[]mas2)
        {
            int j = 0;
            int number;
            for (int i = 0; i < mas1.Length; i++)
            {
                if (MakeInt(mas1[i], out number))
                {
                    mas2[j] = number;
                    j++;
                }
            }

            
               
        }
        static void ReadTextFile(string filename,out int[]mas)
        {
            StreamReader f = new StreamReader(filename);
            string s = f.ReadToEnd();
            Console.WriteLine(s);
            f.Close();
            s.Trim();//удаляем пробелы из начала и конца

            bool ok = false;
            int nom = -1;
            while(!ok)
            {
                nom = s.IndexOf("  ");//ищем два пробела подряд
                if (nom > 0) s.Remove(nom, 1);
                else ok = true;
            }
           string[] strMas = s.Split();
            mas=new int[strMas.Length];

            TransformStringToInt(strMas, mas);
        }
        static void Main(string[] args)
        {
            int[] mas;
            ReadTextFile(@"D:\Git\files\TextFiles\TextFiles\text.txt", out mas);
            for (int i = 0; i < mas.Length; i++)
                Console.Write(mas[i] + "\t");
            Console.WriteLine();
        }
    }
}
