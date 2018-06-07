using System;
using System.Text;

namespace Ex05.Ex02.Logic
{
    public class UI
    {
        internal void Run()
        {
            setGameRules();
            PlayGame newGame = new PlayGame();
            Tools.PrintBoard(newGame.GameBoardAsArray);
            Player.SetPlayer(ref newGame.CurrentPlayer);
            newGame.RunGame();
            Console.ReadLine();          
        }

        private void setGameRules()
        {
            Player playerOne = new Player
            {
                PlayerName = ValidateUserInput.validInputFromUser(),
                TypeOfPiece = 0
            };
            GameRules.PlayerOne = playerOne;
            GameRules.GameIsOff = false;
            GameRules.IsPlayerOneGame = true;
            Console.WriteLine("Please choose a board size between 6,8 or 10.");
            GameRules.SizeOfGameBoard = ValidateUserInput.validateInputFromUserAsInt6or8or10();
            Console.WriteLine("Do you want to play against a real person? Please type yes");
            GameRules.AgainstPlayerTwo = Console.ReadLine().ToLower().Equals("yes");
            if (GameRules.AgainstPlayerTwo)
            {
                Player playerTwo = new Player
                {
                    PlayerName = ValidateUserInput.validInputFromUser(),
                    TypeOfPiece = 1
                };
                GameRules.PlayerTwo = playerTwo;
            }
            else
            {
                Player playerTwo = new Player
                {
                    PlayerName = "Computer",
                    TypeOfPiece = 1,
                    Score = PlayGame.ScoreOfPlayerTwo
                };
                GameRules.PlayerTwo = playerTwo;
            }
        }        
    }
}