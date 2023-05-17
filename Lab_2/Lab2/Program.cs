using System;

namespace Lab2
{
    class Array
    {
        public int n;
        public double[] mas;
        public double[] mas1;
        public double[] crossmas;
        public void CreateArray()
        {
            Console.WriteLine("Введення розмiрностi одновимiрного масиву: ");
            n = Convert.ToInt32(Console.ReadLine());
            mas = new double[n];
            Console.WriteLine("Введення елементiв одновимiрного масиву: ");
            for (int i = 0; i < n; i++)
            {
                mas[i] = Convert.ToDouble(Console.ReadLine());
            }
        }
        public void Output()
        {
            Console.WriteLine("Виведення елементiв матрицi: ");
            for (int i = 0; i < n; i++)
            {
                Console.Write(mas[i] + " ");
            }
            Console.WriteLine("");
        }
        public void findMin()
        {
            double min = mas[0];
            for(int i = 0; i < n; i++)
            {
                if (mas[i] < min)
                {
                    min = mas[i];
                }
            }
            Console.WriteLine("Найменший елемент масиву: " + min);
        }
        public void Compression()
        {
            int i, j;
            for (i = 0, j = 0; i < n; i++)
            {
                if (Math.Abs(mas[i]) > 1)
                {
                    mas[j] = mas[i];
                    j++;
                }
            }
            for (; j < n; j++) 
            {
                mas[j] = 0;
            }
            for (i = 0; i < n; i++)
            {
                Console.Write(mas[i] + " ");
            }
            Console.WriteLine(" ");
        }
        public void CreateVector()
        {
            Console.WriteLine("Введення координат другого вектора");
            mas1 = new double[n];
            for (int i = 0; i < n; i++)
            {
                mas1[i] = (float)Convert.ToDouble(Console.ReadLine());
            }
        }
        public void crossProduct()
        {
            crossmas = new double[n];
            for (int i = 0; i < n; i++)
            {
                crossmas[i] = mas[i] * mas1[i];
            }
            Console.WriteLine("Результат векторного множення: ");
            /*for (int i = 0; i < n; i++)
            {
                Console.Write(crossmas[i]);
                for (int j = 0; j < n - 1; j++)
                {
                    Console.Write("; ");
                }
            }*/
            string formattedArray = string.Join("; ", crossmas);
            Console.WriteLine("(" + formattedArray + ")");
        }
    }
    class Vector
    {
        public double[] x;
        public double[] y;
        public double[] xy;
        public int n;
        public void CreateVectors()
        {
            Console.WriteLine("Введення кiлькiсть координат векторiв" + ": ");
            n = Convert.ToInt32(Console.ReadLine());
            x = new double[n];
            y = new double[n];
            xy = new double[n];
            Console.WriteLine("Введення елементiв першого вектору: ");
            for (int i = 0; i < n; i++)
            {
                x[i] = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("Введення елементiв другого вектору: ");
            for (int i = 0; i < n; i++)
            {
                y[i] = Convert.ToInt32(Console.ReadLine());
            }
        }
        public void crossProduct()
        {
            for (int i = 0; i < n; i++)
            {
                xy[i] = x[i] * y[i];
            }
            Console.WriteLine("Результат векторного множення: ");
            string formattedArray = string.Join("; ", xy);
            Console.WriteLine("(" + formattedArray + ")");
        }

    }
    class TwoDArray
    {
        public int n;
        public int[,] matrx;
        public void Create2DArray()
        {
            Console.WriteLine("Введення розмiрностi матрицi: ");
            n = Convert.ToInt32(Console.ReadLine());
            matrx = new int[n, n];
            Console.WriteLine("Вибiр способу заповнення матрицi: 0 - вручну; 1 - рандом");
            byte select = Convert.ToByte(Console.ReadLine());

            if (select == 0)
            {
                Console.WriteLine("Введення матрицi: ");
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        matrx[i, j] = Convert.ToInt32(Console.ReadLine());
                    }
                }
            }
            else if (select == 1)
            {
                Random rand = new Random();
                Console.WriteLine("Введення числових меж елементiв матрицi: ");
                int l1 = Convert.ToInt32(Console.ReadLine());
                int l2 = Convert.ToInt32(Console.ReadLine());
                if (l1 >= l2)
                {
                    Console.WriteLine("Нижнiй лiмiт(перше введене число) не може перевищувати верхнiй. Спробуйте ще раз.");
                    Create2DArray();
                }
                else
                {
                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            matrx[i, j] = rand.Next(l1, l2);
                        }
                    }

                }

            }
            else { Create2DArray(); }
        }
        public void Output2DArray()
        {
            Console.WriteLine("Виведення матрицi:");
            for (int i = 0; i < n; i++)
            {

                for (int j = 0; j < n; j++)
                {
                    Console.Write(matrx[i, j] + " ");

                }
                Console.WriteLine(" ");
            }
        }
        public void SortByOddColums()
        {
            for (int j = 1; j < n; j += 2)
            {
                // копіювання елементів непарного стовпця у окремий масив
                int[] column = new int[n];
                for (int i = 0; i < n; i++)
                {
                    column[i] = matrx[i, j];
                }

                // Функція сортування елементів скопійовоного стовпця у порядку зростання
                SortArray(column);

                // Повернення відсортованих елементів назад у матрицю
                for (int i = 0; i < n; i++)
                {
                    matrx[i, j] = column[i];
                }
            }
            Console.WriteLine("Виведення нового двовимiрного масиву: ");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(matrx[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
        static void SortArray(int[] array)
        {
            int n = array.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (array[j] < array[i])
                    {
                        int temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }
        }
        public void findProduct()
        {
            for (int i = 0; i < n; i++)
            {
                bool hasNegative = false; // прапорець для пошуку від'ємних чисел в рядках
                int rowProduct = 1; 
                for (int j = 0; j < n; j++)
                {
                    if (matrx[i, j] < 0) //перевірка на наявність від'ємних чисел
                    {
                        hasNegative = true;
                        break;
                    }

                    rowProduct *= matrx[i, j];
                }

                // Виведення добутку, якщо рядок не містить від'ємних чисел
                if (!hasNegative)
                {
                    Console.WriteLine("Добуток елементів у рядку {0}: {1}", i, rowProduct);
                }
            }
        } 
        public void findMaxSum()
        {
            int MaxSum = 0;
            //Перелік елементів діагоналі, паралельній головній
            for (int i = 0; i < n; i++)
            {
                int Sum = 0;
                for (int j = 0; j < n - i; j++) //перебір елементів діагоналі і пошук їх сум
                {
                    Sum += matrx[j, i + j];
                }
                if (Sum > MaxSum)
                {
                    MaxSum = Sum;
                }
            }
            //Перелік елементів діагоналі,паралельній головній (але вже без головної)
            for (int i = 1; i < n; i++)
            {
                int Sum = 0; 
                for (int j = 0; j < n - i; j++)
                {
                    Sum += matrx[i + j, j];
                }
                if (Sum > MaxSum)
                {
                    MaxSum = Sum;
                }
            }
            Console.WriteLine("Максимальна сума елементiв дiагоналей, паралельних головнiй дiагоналi: " + MaxSum);
        } 
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Rybchynchuk Vladyslav" + "\n" + "Variant #4");            
            Array mas = new Array();
            Vector vect = new Vector();
            TwoDArray array = new TwoDArray();
            byte select;
            do
            {
                Console.WriteLine("________________________________________");
                Console.WriteLine("__________Меню вибору завдання__________");
                Console.WriteLine("1._Одновимiрнi масиви_/_Завдання 1.1/2/3");
                Console.WriteLine("2._Одновимiрнi масиви_/_Завдання 1.2____");                
                Console.WriteLine("3._Двовимiрнi масиви_/_Завдання 2.1/2/2_");
                Console.WriteLine("________________________________________");
                select = Convert.ToByte(Console.ReadLine());
                Console.WriteLine();
                switch (select)
                {
                    case 1:  
                        mas.CreateArray();
                        mas.Output();                                              
                        mas.findMin();
                        mas.Compression();
                        mas.CreateVector();
                        mas.crossProduct();
                        break;
                    case 2:
                        vect.CreateVectors();
                        vect.crossProduct();
                        break;
                    case 3:
                        array.Create2DArray();
                        array.Output2DArray();
                        array.SortByOddColums();
                        array.findProduct();
                        array.findMaxSum();
                        break;
                }
            } while (select != 0);
            
        }
    }
}
