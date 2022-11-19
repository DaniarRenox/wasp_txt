using System;
using System.Data;

namespace dz1
{
    class dz1
    {
        static void Razdel1()
        {
            static void R1z1()
            {
                int b= 4321;
                for (int i = 0; i < 6666; i += 1111) Console.WriteLine(b + i);
            }
            int a;
            Console.WriteLine("which task`d u prefer to check");
            a = Convert.ToInt32(Console.ReadLine());
            switch (a)
            {
                case 1:
                    R1z1();
                    break;
            }
        }
        static void Razdel2()
        {

        }
        static void Razdel3()
        {

        }

        public static void Main(string[] args)
        {
            Console.WriteLine("which hw stack`d u prefer to choose");
            int a = Convert.ToInt32(Console.ReadLine());
            switch (a)
            {
                case 1:
                    Razdel1();
                    break;
                case 2:
                    Razdel2();
                    break;
                case 3:
                    Razdel3();
                    break;
            }
        }
    }
}