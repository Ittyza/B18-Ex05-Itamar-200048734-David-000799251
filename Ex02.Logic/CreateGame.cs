using System;

namespace Program
{
    internal class CreateGame : GameRules
    {
        public Piece[] Pieces;

        internal char[,] m_GameBoardAsArray;

        public char[,] GameBoardAsArray { get => m_GameBoardAsArray; set => m_GameBoardAsArray = value; }

        public CreateGame()
        {
            GameBoardAsArray = new char[SizeOfGameBoard, SizeOfGameBoard];
            initializePieces();
        }

        internal void initializePieces()
        {
            Pieces = new Piece[(SizeOfGameBoard * (SizeOfGameBoard - 2)) / 2];
            int k = 0;
            for (int i = 0; i < SizeOfGameBoard; i++)
            {
                for (int j = 0; j < SizeOfGameBoard; j++)
                {
                    if (i < (SizeOfGameBoard / 2) - 1)
                    {
                        if ((i + j) % 2 == 1)
                        {
                            Pieces[k] = new Piece();
                            Pieces[k].IsAlive = true;
                            Pieces[k].PositionOfPiece = new Position(i, j);
                            Pieces[k].Type = 1;
                            GameBoardAsArray[i, j] = char.Parse(((eType)Pieces[k].Type).ToString());
                            k++;
                        }
                    }

                    if (i > (SizeOfGameBoard / 2))
                    {
                        if ((i + j) % 2 == 1)
                        {
                            Pieces[k] = new Piece();
                            Pieces[k].IsAlive = true;
                            Pieces[k].PositionOfPiece = new Position(i, j);
                            Pieces[k].Type = 0;
                            GameBoardAsArray[i, j] = char.Parse(((eType)Pieces[k].Type).ToString());
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