using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex05.Ex02.Logic
{
    public struct Player
    {
        private string playerName;
        private int typeOfPiece;
        private List<Move> validJumpMoves;
        private List<Move> validMoves;
        private int score;

        public string PlayerName { get => playerName; set => playerName = value; }

        public int TypeOfPiece { get => typeOfPiece; set => typeOfPiece = value; }

        public List<Move> ValidJumpMoves { get => validJumpMoves; set => validJumpMoves = value; }

        public int Score { get => score; set => score = value; }

        public List<Move> ValidMoves { get => validMoves; set => validMoves = value; }

        public static void SetPlayer(ref Player currentPlayer)
        {
            if (GameRules.IsPlayerOneGame)
            {
                currentPlayer = GameRules.PlayerOne; 
            }
            else
            {
                currentPlayer = GameRules.PlayerTwo;
            }
        }

        internal static void changeCurrentPlayer(ref Player currentPlayer)
        {
            if (GameRules.IsPlayerOneGame)
            {
                GameRules.IsPlayerOneGame = false;
                currentPlayer = GameRules.PlayerOne;
            }
            else
            {
                GameRules.IsPlayerOneGame = true;
                currentPlayer = GameRules.PlayerTwo;
            }
        }
    }
}