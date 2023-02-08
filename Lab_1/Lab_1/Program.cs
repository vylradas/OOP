using System;
using static System.Math;

namespace OOPLab5
{
    class TTriangle
    {
        public double a;
        public double b;
        public double c;
        public TTriangle()
        {
            a = 0;
            b = 0;
            c = 0;
        }
        public TTriangle(double storona1, double storona2, double storona3)
        {
            this.a = storona1;
            this.b = storona2;
            this.c = storona3;
        }
        public TTriangle(TTriangle tr)
        {
            a = tr.a;
            b = tr.b;
            c = tr.c;
        }
        public void Input_Triangle()
        {
            Console.WriteLine("Vvedenya storin trykutnyka: ");
            a = Convert.ToInt32(Console.ReadLine());
            b = Convert.ToInt32(Console.ReadLine());
            c = Convert.ToInt32(Console.ReadLine());
            if ((a <= 0) || (b <= 0) || (c <= 0))
            {
                Console.WriteLine("Error! Please, try again.");
                Input_Triangle();
            }
        }
        public void Output_Triangle()
        {
            Console.WriteLine("Vyvedenya storin trykutnyka: ");
            Console.WriteLine("I: " + a + " " + "II: " + b + " " + "III: " + c);
        }
        public void Perimeter()
        {
            double P;
            P = a + b + c;
            Console.WriteLine("P = " + P);
        }
        public void TriangleArea()
        {
            double S;
            S = Sqrt((a + b + c) * (a + b) * (a + c) * (b + c));
            Console.WriteLine("S = " + S);
        }

        public void Comparison(TTriangle t)
        {
            bool q;
            q = this.Equals(t);
            Console.WriteLine("The triangles are similar: " + q);
            if (this.a > t.a)
            {
                Console.WriteLine("The side of the main triangle is larger than the side of the new one");
            }
            if (this.a < t.a)
            {
                Console.WriteLine("The side of the new triangle is larger than the side of the main one");
            }
        }
        public static TTriangle operator +(TTriangle x, TTriangle y)
        {
            return new TTriangle(x.a + y.a, x.b + y.b, x.c + y.c);
        }
        public static TTriangle operator -(TTriangle x, TTriangle y)
        {
            return new TTriangle(Math.Abs(x.a - y.a), Math.Abs(x.b - y.b), Math.Abs(x.c - y.c));
        }
        public static TTriangle operator *(TTriangle x, int n)
        {
            return new TTriangle(x.a * n, x.b * n, x.c * n);
        }

        class TTrianglePrizm : TTriangle
        {
            public double h;
            public TTrianglePrizm()
            {
                this.a = 0;
                this.b = 0;
                this.c = 0;
                this.h = 0;
            }
            public TTrianglePrizm(double storona1, double storona2, double storona3, double vysota)
            {
                this.a = storona1;
                this.b = storona2;
                this.c = storona3;
                this.h = vysota;
            }
            public void Input_TrianglePrizm()
            {
                Console.WriteLine("Vvedenya storin trykutnyka-osnovy: ");
                a = Convert.ToInt32(Console.ReadLine());
                b = Convert.ToInt32(Console.ReadLine());
                c = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Vvedenya vysoty pryzmy: ");
                h = Convert.ToInt32(Console.ReadLine());
                if ((a <= 0) || (b <= 0) || (c <= 0) || (h <= 0))
                {
                    Console.WriteLine("Error! Please, try again.");
                    Input_TrianglePrizm();
                }
            }

            public void Output_TrianglePrizm()
            {
                Console.WriteLine("Vyvedenya storin trykutnoyi pryzmy: ");
                Console.WriteLine("a = " + a + '\t' + "b = " + b + '\t' + "c = " + c + '\t' + "h = " + h);
            }
            public void PerimeterPrizm()
            {
                double P;
                P = 2 * a + 2 * b + 2 * c + 3 * h;
                Console.WriteLine("P = " + P);
            }
            public void TrianglePrizmArea()
            {
                double S;
                S = 2 * Sqrt((a + b + c) * (a + b) * (a + c) * (b + c)) + h * a + h * b + h * c;
                Console.WriteLine("S = " + S);
            }
            public void PrizmaVolume()
            {
                double V;
                V = Sqrt((a + b + c) * (a + b) * (a + c) * (b + c)) * h;
                Console.WriteLine("V =" + V);
            }
            public static TTrianglePrizm operator +(TTrianglePrizm x, TTrianglePrizm y)
            {
                return new TTrianglePrizm(x.a + y.a, x.b + y.b, x.c + y.c, x.h + y.h);
            }
            public static TTrianglePrizm operator -(TTrianglePrizm x, TTrianglePrizm y)
            {
                return new TTrianglePrizm(Math.Abs(x.a - y.a), Math.Abs(x.b - y.b), Math.Abs(x.c - y.c), Math.Abs(x.h - y.h));
            }
            public static TTrianglePrizm operator *(TTrianglePrizm x, int n)
            {
                return new TTrianglePrizm(x.a * n, x.b * n, x.c * n, x.h * n);
            }
        }

        class Program
        {
            static void Main(string[] args)
            {
                TTriangle triangle = new TTriangle();
                TTriangle triangle1 = new TTriangle(9, 7, 5);
                Console.WriteLine("Vladyslav Rybchynchuk PP-21");
                triangle.Input_Triangle();
                triangle.Output_Triangle();
                byte select;
                do
                {
                    Console.WriteLine("---------------------------------------");
                    Console.WriteLine("Triangle Menu");
                    Console.WriteLine("1. Area of TTriangle");
                    Console.WriteLine("2. Perimeter of TTriangle");
                    Console.WriteLine("3. Comprassion with another TTriangle");
                    Console.WriteLine("4. Reload operators");
                    Console.WriteLine("---------------------------------------");
                    select = Convert.ToByte(Console.ReadLine());
                    Console.WriteLine();
                    switch (select)
                    {
                        case 1:
                            triangle.TriangleArea();
                            break;

                        case 2:
                            triangle.Perimeter();
                            break;

                        case 3:
                            triangle.Comparison(triangle1);
                            break;

                        case 4:
                            Console.Write("Choose the type of reload(1: + ; 2: - ; 3: *n ): ");
                            byte s = Convert.ToByte(Console.ReadLine());
                            if (s == 1)
                            {
                                Console.WriteLine(triangle + triangle1);
                                triangle = triangle + triangle1;

                            }
                            if (s == 2)
                            {
                                Console.WriteLine(triangle - triangle1);
                                triangle = triangle - triangle1;
                            }
                            if (s == 3)
                            {
                                Console.Write("Enter the number: ");
                                int n = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine(triangle * n);
                                triangle = triangle * n;
                            }
                            triangle.Output_Triangle();
                            break;

                        default:
                            break;
                    }
                }
                while (select != 0);

                TTrianglePrizm prizma = new TTrianglePrizm();
                TTrianglePrizm prizm1 = new TTrianglePrizm(15, 9, 34, 10);
                prizma.Input_TrianglePrizm();
                prizma.Output_TrianglePrizm();
                do
                {
                    Console.WriteLine("---------------------------------------");
                    Console.WriteLine("TrianglePrizm Menu");
                    Console.WriteLine("1. Area of TTrianglePrizm");
                    Console.WriteLine("2. Perimeter of TTrianglePrizm");
                    Console.WriteLine("3. Volume of TTrianglePrizm");
                    Console.WriteLine("4. Reload operators");
                    Console.WriteLine("---------------------------------------");
                    select = Convert.ToByte(Console.ReadLine());
                    Console.WriteLine();
                    switch (select)
                    {
                        case 1:
                            prizma.TrianglePrizmArea();
                            break;
                        case 2:
                            prizma.PerimeterPrizm();
                            break;
                        case 3:
                            prizma.PrizmaVolume();
                            break;
                        case 4:
                            Console.Write("Choose the type of reload(1: + ; 2: - ; 3: *n ): ");
                            byte s = Convert.ToByte(Console.ReadLine());
                            if (s == 1)
                            {
                                Console.WriteLine(prizma + prizm1);
                                prizma = prizma + prizm1;

                            }
                            if (s == 2)
                            {
                                Console.WriteLine(prizma - prizm1);
                                prizma = prizma - prizm1;
                            }
                            if (s == 3)
                            {
                                Console.Write("Enter the number: ");
                                int n = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine(triangle * n);
                                prizma = prizma * n;
                            }
                            prizma.Output_TrianglePrizm();
                            break;

                        default:
                            break;
                    }
                }
                while (select != 0);


            }
        }
    }
}