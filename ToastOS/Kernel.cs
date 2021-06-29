using System;
using Cosmos.HAL;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Sys = Cosmos.System;
using System.Threading;
//using System.Threading.Tasks;

/*
 _____       _ _                ______                       _   _             _            
/  __ \     | | |               | ___ \                     | | | |           | |           
| /  \/ __ _| | |_   _ _ __ ___ | |_/ / ___ _ __  _ __   ___| |_| |_ ______ __| | _____   __
| |    / _` | | | | | | '_ ` _ \| ___ \/ _ \ '_ \| '_ \ / _ \ __| __|______/ _` |/ _ \ \ / /
| \__/\ (_| | | | |_| | | | | | | |_/ /  __/ | | | | | |  __/ |_| |_      | (_| |  __/\ V / 
 \____/\__,_|_|_|\__,_|_| |_| |_\____/ \___|_| |_|_| |_|\___|\__|\__|      \__,_|\___| \_/  
                                                                                                                                                                                        

ToastOS Source Code
Made by Callum Bennett (callumbennett-dev on GitHub)
Made using COSMOS user kit C#
Ongoing Project from March 2021

To do
read txt file
read .toast file
Edit txt file
Edit .toast file
Custom boot logos (CallumBennett-dev and ToastOS)
*/

namespace ToastOS
{
    public class Global
    {
        public static int adminState = 0;
        //public string username = "calben3358";
        //public string password = "admin";
    }
    public class Kernel : Sys.Kernel
    {

        //Variables
        public int adminState = 0;

        protected override void BeforeRun()
        {
            //read user data
            /*
            string Username = System.IO.File.ReadAllText("username.toast");
            string Password = System.IO.File.ReadAllText("password.toast");
            string Name = System.IO.File.ReadAllText("name.toast");
            */
            Global.adminState = 0;
            Console.Clear();
            //80 x 24
            Console.WriteLine("ToastOS 0.12\nCallumBennettDev\nPress Enter to continue boot");
            while (Console.ReadKey().Key != ConsoleKey.Enter)
            {
                continue;
            }
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
                /*case "update username":
                    updateDetails(0);
                    break;
                case "update password":
                    updateDetails(1);
                    break;*/
                case "admin":
                    adminLogin(0);
                    break;
                case "clear":
                    clear(0);
                    break;
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
                case "logout":
                    adminLogin(2);
                    break;
                case "hangman":
                    hangman();
                    break;
                case "conversion":
                    conversion();
                    break;
                default:
                    Console.WriteLine("Bad command, try again");
                    break;
            }
        }

        private static void about() //Tells the user about the System
        {
            Console.WriteLine("ToastOS 0.8");
            Console.WriteLine("Developed by Callum Bennett");
            Console.WriteLine("Software made using COSMOS C# user kit");
        }

        public static void adminLogin(int called) //This will tell if the user is logged in as an admin or not
        {
            //Adminstate
            //0 = not signed in 
            //1 = Signed in

            //called
            //0 = start login
            //1 = check admin state
            //2 = logout
            if (called == 0)
            {
                //Login
                Console.Write("username: ");
                string user = Console.ReadLine();
                Console.Write("password: ");
                string pass = Console.ReadLine();
                if (user == "calben3358")
                {
                    if (pass == "global") //Set as another global variable, maybe add method to change this value later
                    {
                        Global.adminState = 1;
                        Console.WriteLine("Logon Successful");
                    } else
                    {
                        Console.WriteLine("Wrong Password");
                    }
                } else
                {
                    Console.WriteLine("login unsuccessful");
                }

            } else if (called == 1)
            {
                //Check if the user is admin or not for the Clear Command
                if (Global.adminState == 0)
                {
                    //Not signed in 
                    Console.WriteLine("ToastOS User Console");
                } else if (Global.adminState == 1)
                {
                    //Signed in
                    Console.WriteLine("ToastOS Administrator Console"); 
                }
            } else if (called == 2)
            {
                Global.adminState = 0;
                clear(0);
            }
        }

        private static void clear(int value) //Clears the Console and calls adminLogin with an input value of 1
        {
            if (value == 0)
            {
                Console.Clear();
                adminLogin(1);
            } else if (value == 1)
            {
                Console.Clear();
                Console.WriteLine("Hangman");
            }

        }

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
            //Circle is switchValue 0
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

        private static void hangman()
        {
            /*
            string[] words = {"fdf", "sadf"};
            int livesLeft = 7;
            char[] word;

            //Clear console to begin
            clear(1);

            //Pick word randomly

            //Save the word in a char array

            //Instructions/demo (selector if statement)
            Console.WriteLine();
            Console.Write("Play (1), Instructions (2)");
            string strPlayValue = Console.ReadLine();
            int playValue = Convert.ToInt32(strPlayValue);
            if (playValue == 1)
            {

            }

            //Log _ according to the length of the word picked (For Loop)

            //gameplay
            //What happens when the word is incorrect
            //Clearing the console, and replacing any letters that are the same as the player guessed
            //display lives left
            */
        }
        private void conversion()
        {
            string whichConversion;
            Console.WriteLine("Enter what you would like to convert > ");
            whichConversion = Console.ReadLine();
            Console.WriteLine("What value would you like to convert > ");
            string strValue = Console.ReadLine();
            double value = Convert.ToInt32(strValue);
            switch (whichConversion)
            {
                case "degreesToRadians":
                    degreesToRadians(value);
                    break;
                case "radiansToDegrees":
                    radiansToDegrees(value);
                    break;
                case "cmToInch":
                    //Skip to function
                    break;
                case "inchToCm":
                    //Skip to function.
                    break;
            }
        }
        private void degreesToRadians(double input)
        {
            double result = (Math.PI / 180) * input;
            Console.WriteLine(result);
        }
        private void radiansToDegrees(double input)
        {
            double result = (180/Math.PI) * input;
            Console.WriteLine(result);
        }
        /*
        private void updateDetails(int switchValue) 
        {
            //read details in .txt/.toast file and update if called
            if (switchValue == 0) //username
            {
                Console.Write("Enter your new Username > ");
                string newUsername = Console.Readline();
                using StreamWriter file = new("username.toast", append: true);
                await file.WriteLineAsync(newUsername);
            } else if (switchValue == 1)//password
            {
                Console.Write("Enter your new Password");
                string newPword = Console.Readline();
                using StreamWriter file = new("password.toast", append: true);
                await file.WriteLineAsync(newPword);
            } else if (switchValue == 2)
            {
                Console.Write("Enter your new name > ");
                string newName = Console.ReadLine();
                using StreamWriter file = new("name.toast", append: true);
                await file.WriteLineAsync(newName);
            }
        }
        private void enterPassword() 
        {
            ConsoleKeyInfo key;
            string code = "";
            do
            {
                key = Console.ReadKey(true);

                if (Char.IsNumber(key.KeyChar))
                {
                        Console.Write("*");
                }
                code += key.KeyChar;
            } while (key.Key != ConsoleKey.Enter);

            return code;
        }
        */
    }
}