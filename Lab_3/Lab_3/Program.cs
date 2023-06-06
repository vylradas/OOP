using System;

namespace Lab_3
{
    using System;

    public interface ILinear2EqsSystem//Інтерфейс створення параметрів для системи двох рівнянь
    {
        double A1 { get; set; }
        double B1 { get; set; } 
        double C1 { get; set; }
    }
    public interface ILinear3EqsSystem//Інтерфейс створення параметрів для системи трьох рівнянь
    {
        double A2 { get; set; }
        double B2 { get; set; }
        double C2 { get; set; }
        double D2 { get; set; }
    }
    class EqsCalculation
    {
        double a1, b1, c1;
        double a2, b2, c2, d2;
        /*public EqsCalculation()  //пустий конструктор
        {

        }*/
        public EqsCalculation(double a, double b, double c) //конструктор з трьома параметрами
        {
            this.a1 = a;
            this.b1 = b;
            this.c1 = c;
        }
        public EqsCalculation(double a, double b, double c, double d) //конструктор з чотирьма параметрами
        {
            this.a2 = a;
            this.b2 = b;
            this.c2 = c;
            this.d2 = d;
        }
        public double A1 { get => a1; set => a1 = value; }  //оголошення параметрів з інтерфесу
        public double B1 { get => b1; set => b1 = value; }
        public double C1 { get => c1; set => c1 = value; }
        public double A2 { get => a2; set => a2 = value; }
        public double B2 { get => b2; set => b2 = value; }
        public double C2 { get => c2; set => c2 = value; }
        public double D2 { get => d2; set => d2 = value; }
        public void Solve2Eq(EqsCalculation obj)
        {

            double determinant = a1 * obj.b1 - b1 * obj.a1;
            double x = (c1 * obj.b1 - b1 * obj.c1) / determinant;
            double y = (a1 * obj.c1 - c1 * obj.a1) / determinant;
            Console.WriteLine($"Розв'язок системи двох лiнiйних рiвнянь з двома невiдомими (x; y): ({x}; {y})");
        }
        public void Solve3Eq(EqsCalculation obj1, EqsCalculation obj2)
        {
            double determinant = a2 * (obj1.b2 * obj2.c2 - obj2.b2 * obj1.c2) - b2 * (obj1.a2 * obj2.c2 - obj2.a2 * obj1.c2) + c2 * (obj1.a2 * obj2.b2 - obj2.a2 * obj1.b2);
            double x = ((d2 * (obj1.b2 * obj2.c2 - obj2.b2 * obj1.c2)) - (b2 * (obj1.d2 * obj2.c2 - obj2.d2 * obj1.c2)) + (c2 * (obj1.d2 * obj2.b2 - obj2.d2 * obj1.b2))) / determinant;
            double y = ((a2 * (obj1.d2 * obj2.c2 - obj2.d2 * obj1.c2)) - (obj1.d2 * (obj1.a2 * obj2.c2 - obj2.a2 * obj1.c2)) + (c1 * (obj1.a2 * obj2.d2 - obj2.a2 * d2))) / determinant;
            double z = ((a2 * (obj1.b2 * obj2.d2 - obj2.b2 * obj1.d2)) - (b2 * (obj1.a2 * obj2.d2 - obj2.a2 * obj1.d2)) + (d2 * (obj1.a2 * obj2.b2 - obj2.a2 * obj1.b2))) / determinant;

            Console.WriteLine($"Розв'язок системи трьох лiнійних рiвнянь з трьома невiдомими (x; y; z): ({x}; {y}; {z})");
        }
    }
    

    class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("Меню:");
                Console.WriteLine("1. Ввести параметри для системи двох рiвнянь");
                Console.WriteLine("2. Ввести параметри для системи трьох рiвнянь");
                Console.WriteLine("3. Розв'язання готової системи двох рiвнянь");
                Console.WriteLine("4. Розв'язання готової системи трьох рiвнянь");
                Console.WriteLine("0. Вийти");

                Console.Write("Введіть номер опції: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        
                        try
                        {   
                            Console.WriteLine("Введіть 6 параметрiв для системи двох рiвнянь:");
                            double a = Convert.ToDouble(Console.ReadLine());
                            double b = Convert.ToDouble(Console.ReadLine());
                            double c = Convert.ToDouble(Console.ReadLine());
                            double a1 = Convert.ToDouble(Console.ReadLine());
                            double b1 = Convert.ToDouble(Console.ReadLine());
                            double c1 = Convert.ToDouble(Console.ReadLine());
                            EqsCalculation equale01 = new EqsCalculation(a, b, c);
                            EqsCalculation equale11 = new EqsCalculation(a1, b1, c1); 
                            equale01.Solve2Eq(equale11);
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Виникла помилка. Спробуйте ввести знову.");
                        }                       
                        Console.ReadKey();
                        break;
                    case "2":
                        try
                        {
                            Console.WriteLine("Введіть 12 параметрiв для системи двох рiвнянь:");
                            double ad = Convert.ToDouble(Console.ReadLine());
                            double bd = Convert.ToDouble(Console.ReadLine());
                            double cd = Convert.ToDouble(Console.ReadLine());
                            double dd = Convert.ToDouble(Console.ReadLine());
                            double ad1 = Convert.ToDouble(Console.ReadLine());
                            double bd1 = Convert.ToDouble(Console.ReadLine());
                            double cd1 = Convert.ToDouble(Console.ReadLine());
                            double dd1 = Convert.ToDouble(Console.ReadLine());
                            double ad2 = Convert.ToDouble(Console.ReadLine());
                            double bd2 = Convert.ToDouble(Console.ReadLine());
                            double cd2 = Convert.ToDouble(Console.ReadLine());
                            double dd2 = Convert.ToDouble(Console.ReadLine());
                            EqsCalculation equale2d = new EqsCalculation(ad, bd, cd, dd);
                            EqsCalculation equale3d = new EqsCalculation(ad1, bd1, cd1, dd1);
                            EqsCalculation equale4d = new EqsCalculation(ad2, bd2, cd2, dd2);
                            equale2d.Solve3Eq(equale3d, equale4d);

                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Виникла помилка. Спробуйте ввести знову.");
                        }
                        Console.ReadKey();
                        break;
                    case "3":
                        EqsCalculation equale = new EqsCalculation(2, 5, 9);
                        EqsCalculation equale1 = new EqsCalculation(5, 1, -10);
                        equale.Solve2Eq(equale1);                       
                        Console.ReadKey();
                        break;
                    case "4":
                        EqsCalculation equale2 = new EqsCalculation(1, 1, 1, 1);
                        EqsCalculation equale3 = new EqsCalculation(-3, 10, 9, 5);
                        EqsCalculation equale4 = new EqsCalculation(-9, 1, 1, 1);
                        equale2.Solve3Eq(equale3, equale4);
                        Console.ReadKey();
                        break;
                    case "0":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Невiрний номер опцiї!");
                        Console.ReadKey();
                        break;
                }
            }

            
            
        }
    }
}
