using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp
{
     public class Greetings
     {
         static public void SayHi()
         {
             Console.Write("Enter your name: ");
             string name = Console.ReadLine();
             Console.WriteLine(
                 "--------------------------- \n" +
                 "Hello " + name + "!" + "\n" +
                 "---------------------------"
                 );
         }
     }
}
