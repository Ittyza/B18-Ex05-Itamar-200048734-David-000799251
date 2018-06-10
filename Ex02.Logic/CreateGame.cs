using System;

namespace Ex05.Ex02.Logic
{
    public class CreateGame : GameRules
    {
        private Piece[] m_pieces;

        internal char[,] m_GameBoardAsArray;

        public char[,] GameBoardAsArray { get => m_GameBoardAsArray; set => m_GameBoardAsArray = value; }
        public Piece[] Pieces { get => m_pieces; set => m_pieces = value; }

        public CreateGame()
        {
            GameBoardAsArray = new char[SizeOfGameBoard, SizeOfGameBoard];
            initializePieces();
        }

        internal void initializePieces()
        {
            Pieces = new Piece[(SizeOfGameBoard * (SizeOfGameBoard - 2)) / 2];
            int k = 0;
            for (int row = 0; row < SizeOfGameBoard; row++)
            {
                for (int col = 0; col < SizeOfGameBoard; col++)
                {
                    if (row < (SizeOfGameBoard / 2) - 1)
                    {
                        if ((row + col) % 2 == 1)
                        {
                            Pieces[k] = new Piece();
                            Pieces[k].IsAlive = true;
                            Pieces[k].PositionOfPiece = new Position(row, col);
                            Pieces[k].Type = 1;
                            GameBoardAsArray[row, col] = char.Parse(((eType)Pieces[k].Type).ToString());
                            k++;
                        }
                    }

                    if (row > (SizeOfGameBoard / 2))
                    {
                        if ((row + col) % 2 == 1)
                        {
                            Pieces[k] = new Piece();
                            Pieces[k].IsAlive = true;
                            Pieces[k].PositionOfPiece = new Position(row, col);
                            Pieces[k].Type = 0;
                            GameBoardAsArray[row, col] = char.Parse(((eType)Pieces[k].Type).ToString());
                            k++;
                        }
                    }
                }
            }
        }

        public enum eType
        {
            X = 0,
            O,
            K,
            U
        }

        public enum eCapitalLetterDictionary
        {
            A,
            B,
            C,
            D,
            E,
            F,
            G,
            H,
            I,
            J,
        }
    }
}