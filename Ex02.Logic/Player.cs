using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    internal struct Player
    {
        private string playerName;
        private int typeOfPiece;
        private List<Move> validJumpMoves;
        private List<Move> validMoves;
        private int score;

        internal string PlayerName { get => playerName; set => playerName = value; }

        internal int TypeOfPiece { get => typeOfPiece; set => typeOfPiece = value; }

        internal List<Move> ValidJumpMoves { get => validJumpMoves; set => validJumpMoves = value; }

        internal int Score { get => score; set => score = value; }

        internal List<Move> ValidMoves { get => validMoves; set => validMoves = value; }

        internal static void SetPlayer(ref Player currentPlayer)
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