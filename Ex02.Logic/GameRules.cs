using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex05.Ex02.Logic
{
    public class GameRules 
    {
        private static Player m_playerOne;
        private static Player m_playerTwo;
        private static bool againstPlayerTwo;
        private static int m_sizeOfGameBoard;
        private static bool gameIsOff;
        private static bool isPlayerOneGame;
        private static int s_TotalScorePlayerOne = 0;
        private static int s_TotalScorePlayerTwo = 0;

        public static bool AgainstPlayerTwo { get => againstPlayerTwo; set => againstPlayerTwo = value; }

        public static int SizeOfGameBoard { get => m_sizeOfGameBoard; set => m_sizeOfGameBoard = value; }

        public static bool GameIsOff { get => gameIsOff; set => gameIsOff = value; }

        public static bool IsPlayerOneGame { get => isPlayerOneGame; set => isPlayerOneGame = value; }

        public static Player PlayerOne { get => m_playerOne; set => m_playerOne = value; }

        public static Player PlayerTwo { get => m_playerTwo; set => m_playerTwo = value; }

        public static int TotalScorePlayerOne { get => s_TotalScorePlayerOne; set => s_TotalScorePlayerOne = value; }

        public static int TotalScorePlayerTwo { get => s_TotalScorePlayerTwo; set => s_TotalScorePlayerTwo = value; }
    }
}
