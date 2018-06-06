using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    internal class GameRules : UI
    {
        private static Player m_playerOne;
        private static Player m_playerTwo;
        private static bool againstPlayerTwo;
        private static int m_sizeOfGameBoard;
        private static bool gameIsOff;
        private static bool isPlayerOneGame;
        internal static int s_TotalScorePlayerOne = 0;
        internal static int s_TotalScorePlayerTwo = 0;

        public static bool AgainstPlayerTwo { get => againstPlayerTwo; set => againstPlayerTwo = value; }

        public static int SizeOfGameBoard { get => m_sizeOfGameBoard; set => m_sizeOfGameBoard = value; }

        public static bool GameIsOff { get => gameIsOff; set => gameIsOff = value; }

        public static bool IsPlayerOneGame { get => isPlayerOneGame; set => isPlayerOneGame = value; }

        internal static Player PlayerOne { get => m_playerOne; set => m_playerOne = value; }

        internal static Player PlayerTwo { get => m_playerTwo; set => m_playerTwo = value; }
    }
}
