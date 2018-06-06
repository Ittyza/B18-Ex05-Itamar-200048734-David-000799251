using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    internal class ValidateUserInput
    {
        internal static string InputFromUserAsString = string.Empty;
        internal static int NumberOfSizeBoard = 0;
        internal static int NumberOfMaxNumber = 20;

        internal static int validateInputFromUserAsInt6or8or10()
        {
            bool isValid = false;
            while (!isValid)
            {
                bool booleanToTry = int.TryParse(Console.ReadLine(), out NumberOfSizeBoard);
                if (!booleanToTry)
                {
                    Console.WriteLine("The input must be of a number, please try again {0}", Environment.NewLine);
                    continue;
                }

                if (NumberOfSizeBoard == 6 || NumberOfSizeBoard == 8 || NumberOfSizeBoard == 10)
                {
                    isValid = true;
                }
                else
                {
                    Console.WriteLine("The input must be of a a 6, 8 or 10, please try again {0}", Environment.NewLine);
                    continue;
                }
            }

            return NumberOfSizeBoard;
        }

        // $G$ CSS-999 (-3) internal methods should start with an uppercase letter
        internal static string validInputFromUser()
        {
            bool isValid = false;

            while (!isValid)
            {
                if (GameRules.AgainstPlayerTwo)
                {
                    Console.WriteLine("Please Insert Player 2 Name:");
                }
                else
                {
                    Console.WriteLine("Please Insert Player 1 name: ");
                }

                InputFromUserAsString = Console.ReadLine();

                if (InputFromUserAsString.Length > NumberOfMaxNumber)
                {
                    Console.WriteLine("The input must be of at least {0} digits{1}", NumberOfMaxNumber, Environment.NewLine);
                    continue;
                }
                else if (InputFromUserAsString.Length == 0)
                {
                    Console.WriteLine("Please type a name");
                    continue;
                }

                isValid = true;
            }

            return InputFromUserAsString;
        }

        internal static string validateInputPositionFromUser()
        {
            string inputFromConsole = string.Empty;
            bool isValid = false;
            bool firstLetter = false;
            bool secondLetter = false;
            bool thirdLetter = false;
            bool fourthLetter = false;
            bool firstLetterSize = false;
            bool secondLetterSize = false;
            bool thirdLetterSize = false;
            bool fourthLetterSize = false;
            while (!isValid)
            {
                inputFromConsole = Console.ReadLine();
                if (inputFromConsole.Length == 5)
                {
                    if (inputFromConsole[2] == '>')
                    { 
                        firstLetter = Enum.IsDefined(typeof(CreateGame.eCapitalLetterDictionary), inputFromConsole[0].ToString());
                        secondLetter = Enum.IsDefined(typeof(CreateGame.eCapitalLetterDictionary), inputFromConsole[1].ToString().ToUpper());
                        thirdLetter = Enum.IsDefined(typeof(CreateGame.eCapitalLetterDictionary), inputFromConsole[3].ToString());
                        fourthLetter = Enum.IsDefined(typeof(CreateGame.eCapitalLetterDictionary), inputFromConsole[4].ToString().ToUpper());
                        try
                        {
                            firstLetterSize = (int)Enum.Parse(typeof(CreateGame.eCapitalLetterDictionary), inputFromConsole[0].ToString()) <= NumberOfSizeBoard;
                            secondLetterSize = (int)Enum.Parse(typeof(CreateGame.eCapitalLetterDictionary), inputFromConsole[1].ToString().ToUpper()) <= NumberOfSizeBoard;
                            thirdLetterSize = (int)Enum.Parse(typeof(CreateGame.eCapitalLetterDictionary), inputFromConsole[3].ToString()) <= NumberOfSizeBoard;
                            fourthLetterSize = (int)Enum.Parse(typeof(CreateGame.eCapitalLetterDictionary), inputFromConsole[4].ToString().ToUpper()) <= NumberOfSizeBoard;
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Plese write as COLrow>COLrow (i.e. Af>Be)");
                            isValid = false;
                            continue;
                        }
                        
                        if (firstLetter && secondLetter && thirdLetter && fourthLetter && firstLetterSize && secondLetterSize && thirdLetterSize && fourthLetterSize)
                        {
                            isValid = true;
                        }
                        else if (!firstLetterSize || !secondLetterSize || !thirdLetterSize || !fourthLetterSize)
                        {
                            Console.WriteLine("The attack is out of the bounds, please try again");
                            isValid = false;
                            continue;
                        }
                        else
                        {
                            Console.WriteLine("Plese write as COLrow>COLrow (i.e. Af>Be)");
                            isValid = false;
                            continue;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Remember to use > in between the old position and the new one");

                        continue;
                    }
                }
                else if (inputFromConsole.Equals('Q'.ToString()))
                {
                    isValid = true;
                }
                else
                {
                    Console.WriteLine("The length has to be 5, plese write as COLrow>COLrow (i.e. Af>Be), try again");
                }
            }

            return inputFromConsole;
        }
    }
}
