//Angelo Maragos
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace UML.Assignment9
{
    // This program intentionally performs functions
    // that throw exceptions. These are the more common exceptions
    // that you'll see in day-to-day programming.
    // Your job is to figure out the specific exceptions that get 
    // thrown and to catch them.

    class BadProgram
    {
#if true
        public static void Main()
        {
            object o = null;
            int a = 100, b = 100, c = 200;
            try
            {
                double d = c / (a - b);
            }

            catch (System.DivideByZeroException ex)
            {
                Console.WriteLine("{0}", ex.ToString());
            }
            finally
            {
                Console.WriteLine();
                Console.WriteLine("finally handler block of code here.");
                Console.WriteLine();
            }
            try
            {

                StreamReader sr = new StreamReader(@"c:\temp\myfile.txt");
                string contents = sr.ReadToEnd();
                sr.Close();
            }

            catch(FileNotFoundException ex)
            {
                Console.WriteLine(ex);
            }

            finally
            {
                Console.WriteLine();
                Console.WriteLine("finally handler block of code here.");
                Console.WriteLine();
            }

            try
            {
                byte bx = 0x0;
                for (int i = 0; i < 50; i++)
                {
                    checked { bx += 10; }
                }
            }

            catch(System.OverflowException ex)
            {
                Console.WriteLine("{0}", ex.ToString());
            }

            finally
            {
                Console.WriteLine();
                Console.WriteLine("finally handler block of code here.");
                Console.WriteLine();
            }
            int[] odds = new[] { 1, 3, 5, 7, 9, 11, 13, 15, 17, 19, 21, 23, 25 };

            try
            {
                odds[26] = 27;
            }

            catch (System.IndexOutOfRangeException ex)
            {

                Console.WriteLine("{0}", ex.ToString());
            }

            finally
            {
                Console.WriteLine();
                Console.WriteLine("finally handler block of code here.");
                Console.WriteLine();
            }

            try
            {
                Console.WriteLine("This object as a string = {0}", o.ToString());
            }

            catch (NullReferenceException ex)
            {
                Console.WriteLine("{0}", ex.ToString());
            }

            finally
            {
                Console.WriteLine();
                Console.WriteLine("finally handler block of code here.");
                Console.WriteLine();
            }

            Console.ReadLine();
        }
#endif
    }
}
