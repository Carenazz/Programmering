using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grundlæggende_Programmerings_Opgaver
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();

            // Siger hej til informationerne brugeren har indtastet.
            UsefulTools.SayHi(name);

            // Laver objekter og instanstiere book constructor klassen.
            Book book1 = new Book("Harry Potter", "JK Rowling", 309, "PG");
            Book book2 = new Book("Lord of the Rings", "Tolkein", 1214, "PG-13");
            Book book3 = new Book("Star Wars", "George Lucas", 512, "G");
            Book book4 = new Book("Den grimme ælling", "H.C. Andersen", 120, "G");

            // Skriver antallet af bøger ud.
            Console.WriteLine("Number of books: " + Book.bookCount);

            // En goto til fra error handling i tilfælde brugeren har indtastet forkert eller et ID som bøgerne ikke har.
            tryAgain:
            Console.Write("Select a book from ID: ");
            string bookID = Console.ReadLine();

            try
            {
                Console.WriteLine(Book.books[Convert.ToInt32(bookID) - 1].Summary());
            }
            // Error Handling, hvis man kom til at skrive f.eks. q i stedet for 1 eller der ikke findes en bog med ID'et og sender en tilbage for at prøve igen.
            catch(FormatException e)
            {
                Console.WriteLine(e.Message + " Returning to bookID input");
                goto tryAgain;
            }
            catch
            {
                Console.WriteLine("No such book, try again");
                goto tryAgain;
            }

            Console.ReadLine();
        }
    }
}

#region two dimensional array
//int[,] numberGrid =
//{
//    { 1, 2 },
//    { 3, 4 },
//    { 5, 6 },
//};

//Console.WriteLine(numberGrid[1, 1]);

//Console.ReadLine();
#endregion

#region get the power of a base number
//Console.WriteLine(GetPow(10, 60));
//static double GetPow(double baseNum, int powNum)
//{
//    double result = 1;

//    for (int i = 0; i < powNum; i++)
//    {
//        result *= baseNum;
//    }

//    return result;
//}
#endregion

#region Guessing game
//string secretWord = "giraffe";
//string guess = "";

//int guessCount = 0;
//int guessLimit = 3;

//bool outOfGuesses = false;

//while (guess != secretWord && !outOfGuesses)
//{
//    if (guessCount < guessLimit)
//    {
//        Console.Write("Enter guess: ");
//        guess = Console.ReadLine();
//        guessCount++;
//    }
//    else
//    {
//        Console.WriteLine("You are out of guesses");
//        outOfGuesses = true;
//    }
//}

//if (outOfGuesses)
//{
//    Console.WriteLine("You lost, word was: " + secretWord);
//}
//else
//{
//    Console.WriteLine("You win");
//}
#endregion

#region Switch Statements
//Console.Write("Enter a number to get a day: ");
//int num = Convert.ToInt32(Console.ReadLine());
//Console.WriteLine(GetDay(num));
//string dayName;

//switch (dayNum)
//{
//    case 0:
//        dayName = "Sunday";
//        break;
//    case 1:
//        dayName = "Monday";
//        break;
//    case 2:
//        dayName = "Tuesday";
//        break;
//    case 3:
//        dayName = "Wednesday";
//        break;
//    case 4:
//        dayName = "Thursday";
//        break;
//    case 5:
//        dayName = "Friday";
//        break;
//    case 6:
//        dayName = "Saturday";
//        break;

//    default:
//        dayName = "You entered an invalid number";
//        break;
//}

//return dayName;
#endregion

#region Calculator
//tryAgain:
//try
//{
//    Console.Write("Enter a number: ");
//    double num1 = Convert.ToDouble(Console.ReadLine());

//    Console.Write("Enter operator: ");
//    string op = Console.ReadLine();

//    Console.Write("Enter another number: ");
//    double num2 = Convert.ToDouble(Console.ReadLine());

//    if (op == "+")
//        Console.WriteLine(num1 + num2);
//    else if (op == "-")
//        Console.WriteLine(num1 - num2);
//    else if (op == "*")
//        Console.WriteLine(num1 * num2);
//    else if (op == "/")
//        Console.WriteLine(num1 / num2);
//    else
//        Console.WriteLine("Invalid operator");

//}
//catch (FormatException e)
//{
//    Console.WriteLine(e.Message);
//    goto tryAgain;
//}
//catch (DivideByZeroException e)
//{
//    Console.WriteLine(e.Message);
//}
//Console.ReadLine();
#endregion

#region Mad Lip
//string color, pluralNoun, celebrity;
//Console.Write("Enter a color: ");
//color = Console.ReadLine();
//Console.Write("Enter a plural noun: ");
//pluralNoun = Console.ReadLine();
//Console.Write("Enter a celebrity: ");
//celebrity = Console.ReadLine();

//Console.WriteLine("Roses are " + color);
//Console.WriteLine(pluralNoun + " are blue");
//Console.WriteLine("I love " + celebrity);
//Console.ReadLine();
#endregion

#region Arrays
/* Arrays

int[] luckyNumbers = {4, 8, 15, 16, 23, 42};
string[] friends = new string[3];
friends[0] = "Jeppe";
friends[1] = "Lasse";
friends[2] = "Thomas";

luckyNumbers[1] = 900;

Console.WriteLine(luckyNumbers[1]);

Console.ReadLine();
*/
#endregion