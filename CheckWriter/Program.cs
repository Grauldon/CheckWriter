using System;

namespace CheckWriter {
    class Program {
        static void Main(string[] args) {

            decimal num = 6_743_013.23m;
            Check check = new Check("Susie S. Coot", num);
            Console.WriteLine(check.ToString());

            Console.Write("Press a key ...");
            Console.ReadLine();
            Console.Clear();

            decimal num2 = 4.01m;
            Check check2 = new Check("Joe Blow", num2, 15032);
            Console.WriteLine(check2.ToString());

            Console.Write("Press a key ...");
            Console.ReadLine();
            Console.Clear();

            decimal num3 = 3_013.23m;
            Check check3 = new Check("Uncle Sam", num3);
            Console.WriteLine(check3.ToString());

            Console.Write("Press a key ...");
            Console.ReadLine();
            Console.Clear();

            decimal num4 = 481.00m;
            Check check4 = new Check("Uncle Sam", num4);
            Console.WriteLine(check4.ToString());

            Console.Write("Press a key ...");
            Console.ReadLine();
            Console.Clear();

            decimal num5 = 1_000.00m;
            Check check5 = new Check("Uncle Sam", num5);
            Console.WriteLine(check5.ToString());

            Console.Write("Press a key ...");
            Console.ReadLine();
            Console.Clear();

            decimal num6 = 0.50m;
            Check check6 = new Check("Uncle Sam", num6);
            Console.WriteLine(check6.ToString());

            Console.Write("Press a key ...");
            Console.ReadLine();
            Console.Clear();

            decimal num7 = 0.00m;
            Check check7 = new Check("Uncle Sam", num7);
            Console.WriteLine(check7.ToString());
        }
    }
}
