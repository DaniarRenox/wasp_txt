using System;
using System.Data;
using System.Globalization;
using System.Numerics;
using System.Runtime.Serialization.Formatters.Binary;
namespace dz1
{
    class dz1
    {
        static void Razdel1()
        {
            static void R1z1()
            {
                int b = 4321;
                for (int i = 0; i < 6666; i += 1111) Console.WriteLine(b + i);
            }
            static void R1z2()
            {
                Console.WriteLine("input b");
                int b = Convert.ToInt32(Console.ReadLine());
                for (int i = 0; i < b; i++)//строки
                {
                    for (int j = 0; j < i; j++)//столбцы до главной диагонали
                    {
                        Console.Write($"{b - i + j} ");
                    }
                    Console.Write($"{b} ");
                    for (int j = i + 1; j < b; j++)
                    {
                        Console.Write($"{b - (j - i)} ");
                    }
                    Console.Write("\n");
                }
            }
            void line(char[,] A, int X1, int X2, int Y1, int Y2)//соединяем точки линиями
            {

                if (X1 != X2 && Y1 != Y2)//рисуем диагонали между точками, выбирая направление движения диагонали в зависимости от их взаимного расположения
                {
                    if (X1 < X2)
                    {
                        if (Y1 < Y2)
                        {
                            for (int i = 1; i < X2 - X1; i++)
                            {
                                A[X1 + i, Y1 + i] = '*';
                            }
                            for (int i = 1; i < X2 - X1; i++)
                            {
                                A[X1 + i, Y1 + i] = '*';
                            }
                        }
                        else
                        {
                            for (int i = 1; i < X2 - X1; i++)
                            {
                                A[X1 + i, Y1 - i] = '*';
                            }
                            for (int i = 1; i < X2 - X1; i++)
                            {
                                A[X1 + i, Y1 - i] = '*';
                            }
                        }
                    }

                    else
                    {
                        if (Y1 < Y2)
                        {
                            for (int i = 1; i < X1 - X2; i++)
                            {
                                A[X1 - i, Y1 + i] = '*';
                            }
                            for (int i = 1; i < X1 - X2; i++)
                            {
                                A[X1 - i, Y1 + i] = '*';
                            }
                        }
                        else
                        {
                            for (int i = 1; i < X1 - X2; i++)
                            {
                                A[X1 - i, Y1 - i] = '*';
                            }
                            for (int i = 1; i < X1 - X2; i++)
                            {
                                A[X1 - i, Y1 - i] = '*';
                            }
                        }
                    }
                }
                else if (X1 == X2)//теперь прямые
                {
                    int minim = Math.Min(Y2, Y1);
                    for (int i = 0; i <= Math.Abs(Y2 - Y1); i++)
                    {
                        A[X1, minim + i] = '*';
                    }
                }
                else
                {
                    int minim = Math.Min(X2, X1);
                    for (int i = 0; i <= Math.Abs(X2 - Y1); i++)
                    {
                        A[minim + i, Y1] = '*';
                    }
                }
            }
            void R1z3()//ВНИМАНИЕ! прога работает только с треугольниками с углами 90 и 45 градусов соответственно из-за ограничений консоли.
            {
                Console.WriteLine("input X and Y of 3 points sequentively; the left upper angle of the console is the 0 coordinate");
                int Y1 = Convert.ToInt32(Console.ReadLine());
                int X1 = Convert.ToInt32(Console.ReadLine());
                int Y2 = Convert.ToInt32(Console.ReadLine());
                int X2 = Convert.ToInt32(Console.ReadLine());
                int Y3 = Convert.ToInt32(Console.ReadLine());
                int X3 = Convert.ToInt32(Console.ReadLine());
                int width = Math.Max(Math.Max(X1, X2), X3);//берем данные для создания массива - системы координат
                int height = Math.Max(Math.Max(Y1, Y2), Y3);
                char[,] A = new char[width + 1, height + 1];//система координат заданного размера
                for (int i = 0; i <= width; i++)//заполняем систму "мусором"
                {
                    for (int j = 0; j <= height; j++)
                    {
                        A[i, j] = '-';
                    }
                }
                A[X1, Y1] = '*';//размещаем точки в системе
                A[X2, Y2] = '*';
                A[X3, Y3] = '*';
                line(A, X1, X2, Y1, Y2);//чертим прямые между точками
                line(A, X1, X3, Y1, Y3);
                line(A, X2, X3, Y2, Y3);

                for (int i = 0; i <= height; i++)//заполняем пробелы между уже стоящими точками.
                {
                    int x = -8;
                    int counter = 0;
                    for (int j = 0; j <= width; j++)//проверяем, есть ли в строке две точки, т.е. нужно ли заполнять пространство между ними
                    {
                        if (A[i, j] == '*') counter++;
                        if (counter >= 2) break;
                    }
                    if (counter >= 2)//если нужно, то:
                    {
                        for (int j = 0; j <= width; j++)
                        {
                            if (x == -8 && A[i, j] != '*')//пока мы не встретили первую из точек, переменная-индикатор X=-8, а в консоль выводятся "пустые" клетки
                            {
                                Console.Write('-');
                            }
                            else if (x == -8 && A[i, j] == '*')//с первой найденной точкой в строке мы меняем X на любое другое число, пусть будет j, и обозначаем эту точку в консольке.
                            {
                                x = j;
                                Console.Write('*');
                            }

                            else if (x != -8 && A[i, j] != '*')//когда x=j, т.е. x!=8, т.е. j сейчас между первой и второй точками, заполняем консоль точками.
                            {
                                Console.Write('*');
                            }
                            else if (x != -8 && A[i, j] == '*')//когда встречаем вторую (и последнюю) точку в строке, выводим её и обратно делаем x=-8.
                            {                                  //тогда цикл будет отправлять нас в первое условие и печатать тире до конца строки.

                                Console.Write('*');
                                x = -8;
                            }
                        }
                    }
                    else //если двух точек в строке нет, то заполнять ничего не надо
                    {
                        for (int j = 0; j <= width; j++)
                        {
                            if (A[i, j] != '*') Console.Write('-');//надо выводить тире, если только мы не встречаем намеченную пользователем точку
                            else Console.Write('*');//ну и собственно эту точку
                        }
                    }
                    Console.Write('\n');
                }
            }
            Console.WriteLine("which task`d u prefer to check? 1 to 3 and 10 to go to main");
            int a = Convert.ToInt32(Console.ReadLine());
            switch (a)
            {
                case 1:
                    R1z1();
                    Main();
                    break;
                case 2:
                    R1z2();
                    Main();
                    break;
                case 3:
                    R1z3();
                    Main();
                    break;
                case 10:
                    Main();
                    break;
            }
        }
        static void Razdel2()
        {
            string izInt32v2(int b)
            {
                int check = 1 << 30;
                int n = 0;
                string answer = "";
                while ((check & b) == 0)
                {
                    check >>= 1;
                    n++;
                }
                for (int i = 0; i < 31 - n; i++)
                {
                    if ((check & b) > 0)
                    {
                        answer+= "1";
                    }
                    else
                    {
                        answer+=  "0";
                    }
                    check >>= 1;
                }
                return answer;
            }
            string izInt16v2(short b)
            {
                int check = 1 << 15;
                string answer = "";
                for (int i = 0; i < 16; i++)
                {
                    if ((check & b) > 0)
                    {
                        answer += "1";
                    }
                    else
                    {
                        answer += "0";
                    }
                    check >>= 1;
                }
                return answer;
            }
            void R2z1()
            {
                Console.WriteLine("input the number");
                int b = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine($"{izInt32v2(b)}");
                Console.Write('\n');
            }
            void R2z2()
            {
                Console.WriteLine("input m and n");
                int m1 = Convert.ToInt32(Console.ReadLine());
                int n1 = Convert.ToInt32(Console.ReadLine());
                int result1 = n1 + m1;
                string m = izInt32v2(m1);
                string n = izInt32v2(n1);
                string result = izInt32v2(n1+m1);
                while (m.Length < result.Length)
                {
                    m = '0' + m;
                }
                while (n.Length < result.Length)
                {
                    n = '0' + n;
                }
                Console.WriteLine(m); Console.WriteLine(n);
                Console.WriteLine(result);
            }
            void R2z3()
            {
                string longstr = "";
                Console.WriteLine("input 4 short values");
                short a = Convert.ToInt16(Console.ReadLine());
                short b = Convert.ToInt16(Console.ReadLine());
                short c = Convert.ToInt16(Console.ReadLine());
                short d = Convert.ToInt16(Console.ReadLine());
                longstr += izInt16v2(d);
                longstr += izInt16v2(c);
                longstr += izInt16v2(b);
                longstr += izInt16v2(a);
                Console.WriteLine(longstr);
                Console.WriteLine(Convert.ToInt64(longstr,2));
            }
            Console.WriteLine("which task`d u prefer to check? 1 to 3 and 10 to go to main");
            int a = Convert.ToInt32(Console.ReadLine());
            switch (a)
            {
                case 1:
                    R2z1();
                    Main();
                    break;
                case 2:
                    R2z2();
                    Main();
                    break;
                case 3:
                    R2z3();
                    Main();
                    break;
                case 10:
                    Main();
                    break;
            }
        }
        
        static void Razdel3()
        {
            void R3z1()
            {
                List<int> A = new List<int> { };
                Console.WriteLine("input length of the array, then p-number and array elements");
                int N = Convert.ToInt32(Console.ReadLine());
                int p = Convert.ToInt32(Console.ReadLine());
                int summ = 0;
                for (int i = 0; i < N; i++)
                {
                    A.Add(Convert.ToInt32(Console.ReadLine()));
                    summ += A[i];//использую массив для галочки, здесь он по факту не нужен
                }
                double result = Math.Pow(summ, 1.0 / p);
                Console.WriteLine($"{result}");
            }
            void R3z2()
            {
                Console.WriteLine("input length of the array, then elements in it and the k number of the minimum");
                int N = Convert.ToInt32(Console.ReadLine());
                List<int> A = new List<int> { };
                for (int i = 0; i < N; i++) A.Add(Convert.ToInt32(Console.ReadLine()));
                A.Sort();
                int k = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(A[k]);
            }
            void R3z3()
            {
                List<int> A = new List<int> { };
                Console.WriteLine("input length of the array, then elements in it, then how`d u like to crop it in format begining:end:step");
                int N = Convert.ToInt32(Console.ReadLine());
                for (int i = 0; i < N; i++) A.Add(Convert.ToInt32(Console.ReadLine()));
                string input = Console.ReadLine();
                string buffer = "";//буфер для записи чисел без разделительных : из input
                List<int> Instruct = new List<int> { };//список чисел из input
                for (int i = 0; i < input.Length; i++)
                {
                    if (input[i] == ':')
                    {
                        Instruct.Add(Convert.ToInt32(buffer));
                        buffer = "";
                        continue;
                    }
                    buffer += input[i];
                }
                Instruct.Add(Convert.ToInt32(buffer));
                int a = Instruct[0];
                int b = Instruct[1];
                int c = Instruct[2];
                //с этого момента instruct не нужен для хранения предыдущих данных, а значит можно его использовать как массив-результат
                if (c > 0)//при шаге >0 идем из меньшей координаты в большую
                {
                    Instruct.Clear();
                    for (int i = a; i < b; i += c)
                    {
                        Instruct.Add(A[i]);//здесь тоже по факту можно массив не составлять, но раз уж просят...
                        Console.Write(A[i]);
                    }
                }
                else//и наоборот
                {
                    Instruct.Clear();
                    for (int i = b; i > a; i += c)
                    {
                        Instruct.Add(A[i]);//здесь тоже по факту можно массив не составлять, но раз уж просят...
                        Console.Write(A[i]);
                    }
                }
                Console.WriteLine("\n");
            }
            Console.WriteLine("which task`d u prefer to check? 1 to 3, and 10 to go to main");
            int a = Convert.ToInt32(Console.ReadLine());
            switch (a)
            {
                case 1:
                    R3z1();
                    Main();
                    break;
                case 2:
                    R3z2();
                    Main();
                    break;
                case 3:
                    R3z3();
                    Main();
                    break;
                case 10:
                    Main();
                    break;
            }
        }
        public static void Main()
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