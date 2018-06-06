using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    internal class Tools
    {
        // $G$ CSS-013 (-3) Input parameters names should start with i_PascaleCase.
        public static void PrintBoard(char[,] i_gameBoard)
        {
            string printableBoard = string.Empty;
            for (int i = 0; i < GameRules.SizeOfGameBoard; i++)
            {
                for (int j = 0; j < GameRules.SizeOfGameBoard; j++)
                {
                    if (i == 0)
                    {
                        printableBoard += "   " + ((CreateGame.eCapitalLetterDictionary)j).ToString();
                    }
                }

                printableBoard += Environment.NewLine;
                printableBoard += "  ";
                for (int j = 0; j < GameRules.SizeOfGameBoard; j++)
                {
                    printableBoard += "====";
                }

                printableBoard += Environment.NewLine;
                printableBoard += ((CreateGame.eCapitalLetterDictionary)i).ToString().ToLower() + "|";
                for (int j = 0; j < GameRules.SizeOfGameBoard; j++)
                {
                    printableBoard += " " + i_gameBoard[i, j].ToString() + " |";
                }

                if (i == GameRules.SizeOfGameBoard - 1)
                {
                    printableBoard += Environment.NewLine;
                    printableBoard += "  ";

                    for (int j = 0; j < GameRules.SizeOfGameBoard; j++)
                    {
                        printableBoard += "====";
                    }
                }
            }

            Console.WriteLine(printableBoard);
        }
    }
}
