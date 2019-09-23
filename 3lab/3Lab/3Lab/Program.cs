using System;

namespace _3Lab
{
    public static class Tests
    {
        public static bool NotNegativeInputX()
        {
            if (Triangle.CreateTriangle(-5, 10, 10))
            {
                Console.Write("Ошибка в NotNegativeInput X");
                return false;
            }
            else
            {
                return true;
            }
        }
        public static bool NotNegativeInputY()
        {
            if (Triangle.CreateTriangle(5, -10, 10))
            {
                Console.Write("Ошибка в NotNegativeInput Y");
                return false;
            }
            else
            {
                return true;
            }
        }
        public static bool NotNegativeInputZ()
        {
            if (Triangle.CreateTriangle(5, 10, -10))
            {
                Console.Write("Ошибка в NotNegativeInput Z");
                return false;
            }
            else
            {
                return true;
            }
        }
        public static bool NotLine1()
        {
            if (Triangle.CreateTriangle(5, 5, 10))
            {
                Console.Write("Ошибка в NotLine 1");
                return false;
            }
            else
            {
                return true;
            }
        }
        public static bool NotLine2()
        {
            if (Triangle.CreateTriangle(5, 10, 5))
            {
                Console.Write("Ошибка в NotLine 2");
                return false;
            }
            else
            {
                return true;
            }
        }
        public static bool NotLine3()
        {
            if (Triangle.CreateTriangle(5, 10, 5))
            {
                Console.Write("Ошибка в NotLine 3");
                return false;
            }
            else
            {
                return true;
            }
        }
        public static bool CorrectEntries()
        {
            if (!Triangle.CreateTriangle(5, 5, 5))
            {
                Console.Write("Ошибка в CorrectEntries");
                return false;
            }
            else
            {
                return true;
            }
        }
        public static bool ZeroInputX()
        {
            if (Triangle.CreateTriangle(0, 5, 5))
            {
                Console.Write("Ошибка в ZeroInput");
                return false;
            }
            else
            {
                return true;
            }
        }
        public static bool ZeroInputY()
        {
            if (Triangle.CreateTriangle(5, 0, 5))
            {
                Console.Write("Ошибка в ZeroInput");
                return false;
            }
            else
            {
                return true;
            }
        }
        public static bool ZeroInputZ()
        {
            if (Triangle.CreateTriangle(5, 5, 0))
            {
                Console.Write("Ошибка в ZeroInput");
                return false;
            }
            else
            {
                return true;
            }
        }
        public static bool LittleLines1()
        {
            if (Triangle.CreateTriangle(10, 1, 1))
            {
                Console.Write("Ошибка в LittleLines 1");
                return false;
            }
            else
            {
                return true;
            }
        }
        public static bool LittleLines2()
        {
            if (Triangle.CreateTriangle(1, 10, 1))
            {
                Console.Write("Ошибка в LittleLines 2");
                return false;
            }
            else
            {
                return true;
            }
        }
        public static bool LittleLines3()
        {
            if (Triangle.CreateTriangle(1, 1, 10))
            {
                Console.Write("Ошибка в LittleLines 3");
                return false;
            }
            else
            {
                return true;
            }
        }
    }

    public static class Triangle
    {
        public static bool CreateTriangle(double x, double y, double z)
        {
            if (((x + y) > z) && ((x + z) > y) && ((z + y) > x))
                return true;
            else
                return false;

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Test #1 - " + Tests.NotNegativeInputX());
            Console.WriteLine("Test #2 - " + Tests.NotNegativeInputY());
            Console.WriteLine("Test #3 - " + Tests.NotNegativeInputZ());
            Console.WriteLine("Test #4 - " + Tests.NotLine1()); 
            Console.WriteLine("Test #5 - " + Tests.NotLine2()); 
            Console.WriteLine("Test #6 - " + Tests.NotLine3()); 
            Console.WriteLine("Test #7 - " + Tests.CorrectEntries()); 
            Console.WriteLine("Test #8 - " + Tests.ZeroInputX()); 
            Console.WriteLine("Test #9 - " + Tests.ZeroInputY()); 
            Console.WriteLine("Test #10 - " + Tests.ZeroInputZ()); 
            Console.WriteLine("Test #11 - " + Tests.LittleLines1()); 
            Console.WriteLine("Test #12 - " + Tests.LittleLines2()); 
            Console.WriteLine("Test #13 - " + Tests.LittleLines3()); 

            Console.ReadLine();
        }
    }
}
