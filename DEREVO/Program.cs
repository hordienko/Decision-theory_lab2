using System;
using System.Collections;
using System.IO;

namespace DEREVO
{
    class Program
    {
        static double[] fileData;
        public static void Main(string[] args)
        {
            GetData();

            ArrayList Variants = new ArrayList();
            Variants.Add(Variant_A());
            Variants.Add(Variant_B());
            Variants.Add(Variant_CA());
            Variants.Add(Variant_CB());

            ArrayList Variants_names = new ArrayList(); // для запису назв варіантів
            Variants_names.Add("Варiант A");
            Variants_names.Add("Варiант Б");
            Variants_names.Add("Варiант C(а)");
            Variants_names.Add("Варiант C(b)");

            ArrayList Sorted_variants = new ArrayList();
            Sorted_variants.AddRange(Variants);
            Sorted_variants.Sort();
            double maxDohid = (double)Sorted_variants[3];
            int maxindex = Variants.IndexOf(maxDohid);
            string variant = (string)Variants_names[maxindex];

            Console.WriteLine($"У {variant} буде найкращий дохiд, який дорiвнює - {maxDohid} тис.");

        }

        public static double[] GetData() //зчитування з файлу
        {
            string filePath = Path.GetFullPath("1.txt");

            using var fileReader = new StreamReader(filePath);
            string file = fileReader.ReadToEnd();
            string[] lines = file.Split('\n');

            fileData = new double[lines.Length];

            for (int i = 0; i < fileData.Length; i++) // запис в масив
            {
                fileData[i] = Convert.ToDouble(lines[i]);
            }
            return fileData;
        }

        public static double Variant_A()
        {
            GetData();
            int n = 5;// кількість років 
            double m1 = fileData[0], d1 = fileData[1], p1 = fileData[2], d2 = fileData[3], p2 = fileData[4];


            double dohid = d1 * n,
                   zbutku = d2 * n,
                   clean_dohid = (p1 * dohid + p2 * zbutku) - m1;

            Console.WriteLine($"У варiантi А чистий дохiд становитиме - {clean_dohid} тис.");
            return clean_dohid;

        }


        public static double Variant_B()
        {
            GetData();
            int n = 5;

            double m2 = fileData[5], d1 = fileData[6], p1 = fileData[7], d2 = fileData[8], p2 = fileData[9];

            double dohid = d1 * n,
                   zbutku = d2 * n,
                   clean_dohid = (p1 * dohid + p2 * zbutku) - m2;
            Console.WriteLine($"У варiантi Б чистий дохiд становитиме - {clean_dohid} тис.");

            return clean_dohid;
        }



        public static double Variant_CA()
        {
            GetData();
            int n = 4;
            double m1 = fileData[0], d1 = fileData[1], p1 = fileData[12], d2 = fileData[3], p2 = fileData[13], p3 = fileData[10];

            double dohid = d1 * n,
                   zbutku = d2 * n,
                   clean_dohid = p3 * (p1 * dohid + p2 * zbutku - m1);
            Console.WriteLine($"У варiантi В(а) чистий дохiд становитиме - {clean_dohid} тис.");

            return clean_dohid;
        }



        public static double Variant_CB()
        {
            GetData();
            int n = 4;

            double m2 = fileData[5], d1 = fileData[6], p1 = fileData[12], d2 = fileData[8], p2 = fileData[13], p3 = fileData[10];


            double dohid = d1 * n,
                   zbutku = d2 * n,
                   clean_dohid = p3 * ((p1 * dohid + p2 * zbutku) - m2);

            Console.WriteLine($"У варiантi В(б) чистий дохiд становитиме - {clean_dohid} тис.");

            return clean_dohid;
        }






    }
}
