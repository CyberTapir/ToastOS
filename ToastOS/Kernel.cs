/*
ToastOS Source Code
Made by Callum Bennett (callumbennett-dev on GitHub)
Made using COSMOS C#
Project from March 2021
*/

using System;
using Cosmos.HAL;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;

namespace ToastOS
{
    public class Kernel : Sys.Kernel
    {

        //Variables
        //public int adminState = 0;

        protected override void BeforeRun()
        {
            Console.Clear();
            Console.WriteLine("ToastOS User Console");
        }

        protected override void Run()
        {
            Console.Write("> ");
            string input = Console.ReadLine();
            //To figure out what to call
            switch (input)
            {
                case "about":
                    about();
                    break;
                case "admin":
                    adminLogin(0);
                    break;
                case "clear":
                    clear();
                    break;
                //case "caesar encrypt":
                    //caesarEncrypt();
                    //break;
                case "calculator":
                    calculator(0);
                    break;
                case "calculator 2":
                    calculator(1);
                    break;
                case "circle area":
                    area(0);
                    break;
                case "rect area":
                    area(1);
                    break;
                case "triangle area":
                    area(2);
                    break;
                default:
                    oops();
                    break;
            }
        }

        private static void oops() //This will trigger when a command not listed is entered
        {
            Console.WriteLine("Bad command, try again");
        }

        private static void about() //Tells the user about the System
        {
            Console.WriteLine("ToastOS 0.6");
            Console.WriteLine("Developed by Callum Bennett");
            Console.WriteLine("Software made using COSMOS C# user kit");
        }

        private static void adminLogin(int called) //This will tell if the user is logged in as an admin or not
        {
            /*bool adminTrue;
            if (called == 0)
            {
                adminTrue = false;
                Console.WriteLine("username: ");
                string userName = Console.ReadLine();
                Console.WriteLine("password: ");
                string password = Console.ReadLine();
                if (userName == "administrator" && password == "administrator")
                {
                    adminTrue = 1;
                } else
                {
                    Console.WriteLine("logon failed");
                    clear();
                }
            } else if (called == 1) //for the Clear command, this will write if the user is an admin or not
            {
                if (adminTrue == true)
                {
                    Console.WriteLine("ToastOS Admin Console");
                } else
                {
                    Console.WriteLine("ToastOS User Console");
                }
            }*/
        }

        private static void clear() //Clears the Console and calls adminLogin with an input value of 1
        {
            Console.Clear();
            adminLogin(1);
        }

        /*private static void caesarEncrypt() //Encrypts a string using Caesar Cipher shifting 3 places
        {
            char[] alphabet = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            Console.Write("Enter message to Encrypt > ");
            string secretInput1 = Console.ReadLine();
            string secretInput = secretInput1.ToLower();
            char[] secretMessage = secretInput.ToCharArray();
            char[] encryptedMessage = new char[secretMessage.Length];
            for (int i = 0; i < secretMessage.Length; i++)
            {
                char currentLetter = secretMessage[i];
                int position = Array.IndexOf(alphabet, currentLetter);
                int newPosition = (position + 3) % 26;
                char newLetter = alphabet[newPosition];
                encryptedMessage[i] = newLetter;
            }
            string output = String.Join("", encryptedMessage);
            Console.WriteLine(output);
        }*/

        private static void calculator(int input)
        {
            if (input == 0) //For two numbers with +, -, * and /
            {
                int result = 0;
                Console.WriteLine();
                Console.Write("Enter the equation > ");
                var numInput = Console.ReadLine();
                var a = numInput.Split(' ');
                int v0 = int.Parse(a[0]);
                int v1 = int.Parse(a[2]);
                if (a[1].Contains("+"))
                {
                    result = v0 + v1;
                } else if (a[1].Contains("-"))
                {
                    result = v0 - v1;
                } else if (a[1].Contains("*"))
                {
                    result = v0 * v1;
                } else if (a[1].Contains("/"))
                {
                    result = v0 / v1;
                } else
                {
                    Console.WriteLine("Please format as below");
                    Console.WriteLine("5 + 4");
                }
                Console.WriteLine(result);
            } else if (input == 1)//This will be for 3 numbers, with order of operations
            {
                int result1 = 0;
                int result2 = 0;
                Console.WriteLine();
                Console.Write("Enter the equation > ");
                var numInput2 = Console.ReadLine();
                var a = numInput2.Split();
                int x0 = int.Parse(a[0]);
                int x1 = int.Parse(a[2]);
                int x2 = int.Parse(a[4]);
                //This is long, but covers order of operations
                if (a[1].Contains("+"))
                {
                    if (a[3].Contains("*"))
                    {
                        result1 = x1 * x2;
                        result2 = x0 + result1;
                    } else if (a[3].Contains("/"))
                    {
                        result1 = x1 / x2;
                        result2 = x0 + result1;
                    } else if (a[3].Contains("+"))
                    {
                        result1 = x1 + x2;
                        result2 = x0 + result1;
                    } else if (a[3].Contains("-"))
                    {
                        result1 = x0 + x1;
                        result2 = result1 - x2;
                    }
                } else if (a[1].Contains("-"))
                {
                    if (a[3].Contains("*"))
                    {
                        result1 = x1 * x2;
                        result2 = x0 - result1;
                    } else if (a[3].Contains("/"))
                    {
                        result1 = x1 / x2;
                        result2 = x0 - result1;
                    } else if (a[3].Contains("+"))
                    {
                        result1 = x0 + x1;
                        result2 = result1 - x2; 
                    } else if (a[3].Contains("-"))
                    {
                        result1 = x0 - x1;
                        result2 = result1 - x2;
                    }
                } else if (a[1].Contains("*"))
                {
                    result1 = x0 * x1;
                    if (a[3].Contains("*"))
                    {
                        result2 = result1 * x2;
                    } else if (a[3].Contains("/"))
                    {
                        result2 = result1 / x2;
                    } else if (a[3].Contains("+"))
                    {
                        result2 = result1 + x2;
                    } else if (a[3].Contains("-"))
                    {
                        result2 = result1 - x2;
                    }
                } else if (a[1].Contains("/"))
                {
                    result1 = x0 / x1;
                    if (a[3].Contains("*"))
                    {
                        result2 = result1 * x2;
                    } else if (a[3].Contains("/"))
                    {
                        result2 = result1 / x2;
                    } else if (a[3].Contains("+"))
                    {
                        result2 = result1 + x2;
                    } else if (a[3].Contains("-"))
                    {
                        result2 = result1 - x2;
                    }
                }
                Console.WriteLine(result2);
            }
        }

        private static void area(int switchValue) //Area calculator for circles, triangles, and rectangles
        {
            //Circle is switchVale 0
            //Rect is switchValue 1
            //Triangle is switchValue 2
            if (switchValue == 0) //Circle Area
            {
                Console.Write("Enter the radius of the circle: ");
                string strInput = Console.ReadLine();
                double radius = Convert.ToInt32(strInput);
                double rSquared = Math.Pow(radius, 2);
                double circleArea = (Math.PI * rSquared);
                Console.WriteLine(circleArea);
            } else if (switchValue == 1) //Rect Area
            {
                Console.Write("Enter the width: ");
                string strWidth = Console.ReadLine();
                Console.Write("\nEnter the length: ");
                string strLength = Console.ReadLine();
                double width = Convert.ToInt32(strWidth);
                double length = Convert.ToInt32(strLength);
                double area = width * length;
                Console.WriteLine(area);
            } else if (switchValue == 2) //Triangle Area
            {
                Console.Write("Enter the width: ");
                string strWidth = Console.ReadLine();
                Console.Write("\nEnter the height: ");
                string strLength = Console.ReadLine();
                double width = Convert.ToInt32(strWidth);
                double length = Convert.ToInt32(strLength);
                double area = width * length;
                Console.WriteLine(area / 2);
            }
        }
    }
}