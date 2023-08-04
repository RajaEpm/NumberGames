using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberGuessingGame
{
    class Program
    {
        static string userName = "";
        static string computerNumber = "";
        static int numberOfGuesses = 0;

        static void Main(string[] args)
        {
            StartNewGame();
            while (true)
            {
                UserGuess();
            }
        }

        static void StartNewGame()
        {
            Console.Write("Enter your name: ");
            userName = Console.ReadLine();
            computerNumber = GenerateComputerNumber();
            numberOfGuesses = 0;
        }

        static string GenerateComputerNumber()
        {
            List<char> digits = new List<char> { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            string number = "";
            Random random = new Random();
            for (int i = 0; i < 4; i++)
            {
                int index = random.Next(digits.Count);
                number += digits[index];
                digits.RemoveAt(index);
            }
            return number;
        }

        static void UserGuess()
        {
            Console.Write("Enter your guess (four digits): ");
            string guess = Console.ReadLine();
            numberOfGuesses++;
            string response = CheckGuess(guess);
            Console.WriteLine(response);
            if (response == "++++")
            {
                Console.WriteLine($"Congratulations {userName}! You won in {numberOfGuesses} guesses.");
                SaveScore();
                ShowBestScore();
                StartNewGame();
            }
        }

        static string CheckGuess(string guess)
        {
            string response = "";
            for (int i = 0; i < 4; i++)
            {
                if (guess[i] == computerNumber[i])
                {
                    response += "+";
                }
                else if (computerNumber.Contains(guess[i]))
                {
                    response += "-";
                }
            }
            return response;
        }

        static void SaveScore()
        {

        }

        static void ShowBestScore()
        {

        }
    }
}