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
        public bool adminTrue = false;
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
                default:
                    oops();
                    break;
                case "about":
                    about();
                    break;
                case "admin":
                    adminLogin(0);
                    break;
                case "clear":
                    clear();
                    break;
                case "caesar encrypt":
                    caesarEncrypt();
                    break;
                case "calculator":
                    calculator(0);
                    break;
            }
        }
        private static void oops() //This will trigger when a command not listed is entered
        {
            Console.WriteLine("Bad command, try again");
        }
        private static void about() //Tells the user about the System
        {
            Console.WriteLine("ToastOS 0.4");
            Console.WriteLine("Developed by Callum Bennett");
            Console.WriteLine("Software made using COSMOS C# user kit");
        }
        private static void adminLogin(int called) //This will tell if the user is logged in as an admin or not
        {
            bool adminLoggedIn = false;
            if (called == 0)
            {
                Console.WriteLine("username: ");
                string userName = Console.ReadLine();
                Console.WriteLine("password: ");
                string password = Console.ReadLine();
                if (userName == "administrator" && password == "administrator")
                {
                    adminLoggedIn = true;
                } else
                {
                    Console.WriteLine("logon failed");
                    clear();
                }
            } else if (called == 1) //for the Clear command, this will write if the user is an admin or not
            {
                if (adminLoggedIn == true)
                {
                    Console.WriteLine("ToastOS Admin Console");
                } else
                {
                    Console.WriteLine("ToastOS User Console");
                }
            }
        }
        private static void clear() //Clears the Console and calls adminLogin with a value of 1
        {
            Console.Clear();
            adminLogin(1);
        }
        private static void caesarEncrypt() //Encrypts a string using Caesar Cipher shifting 3 places
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
        }
        private static void calculator(int input)
        {
            if (input == 0)
            {

            }
        }
    }
}