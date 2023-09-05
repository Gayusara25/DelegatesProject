using System;

namespace DelegatesProject
{
    internal class Program
    {
        static void Main(string[] args)
        {


            Action act= () =>
            {
            Outer:
                string? Name;
                string? Password;
                Console.Write("Enter the username");
                Name = Console.ReadLine();
                Console.Write("Enter the password");
                Password = Console.ReadLine();


                Func<string, string, Tuple<string, string>> pt = (string tuple1, string tuple2) => {
                    Tuple<string, string> tuple= Tuple.Create<string, string>(tuple1, tuple2);
                    return tuple;

                };
                if ((Name != null) && (Password != null))
                {
                    Console.WriteLine("Successfully Registered");
                Inner:
                    Console.WriteLine("Login");
                    Tuple<string, string> Detail = pt(Name, Password);
                    Console.Write("Enter your username to Login");
                    string? Name1 = Console.ReadLine();
                    Console.Write("Enter your password to Login");
                    string? Password1 = Console.ReadLine();
                    Predicate<Tuple<string, string>> predicate = (Tuple<string, string> tuple3) =>
                    {
                        if (Name1 == tuple3.Item1 && Password1 == tuple3.Item2)
                        {
                            return true;
                        }
                        return false;

                    };
                    bool logging = predicate(Detail);
                    if (logging)
                    {
                        Console.WriteLine("You have successfully logged in");
                        Console.WriteLine("Continue operations");
                        ExampleDelegates();

                    }
                    else
                    {
                        Console.WriteLine("Login failed");

                        goto Inner;
                    }
                }
                else
                {
                    Console.WriteLine("Register again");

                    goto Outer;
                }


            };

            act();



            Console.ReadLine();
        }
        public delegate void ArithmeticOps(int var1, int var2);
        public static void ExampleDelegates()
        {
            Console.Write("Enter the first number: ");
            int var1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the second number: ");
            int var2 = Convert.ToInt32(Console.ReadLine());

            ArithmeticOps Operations = new ArithmeticOps(Sub);
            Operations += Sub;
            Operations += Mul;
            Operations += Div;
            Operations(var1, var2);

        }
        public static void Add(int var1, int var2)
        {
            Console.WriteLine($"Addition of two numbers are {var1 + var2}");
        }
        public static void Sub(int var1, int var2)
        {
            if (var1 > var2)
            { 
                Console.WriteLine($"Subtraction of x from y {var1 - var2}"); 
            }
            else
            { 
                Console.WriteLine($"Subtraction of y from x {var2 - var1}"); 
            }
        }
        public static void Mul(int var1, int var2)
        {
            Console.WriteLine($"Multiplication of x and y {var1 * var2}");
        }
        public static void Div(int var1, int var2)
        {
            if (var2 != 0)
            {
                Console.WriteLine($"Division from x by y {var1 / var2}");

            }
            else
            {
                Console.WriteLine("Divide by 0 not possible");
            }
        }
    }
}