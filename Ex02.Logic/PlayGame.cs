using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ex05.Ex02.Logic
{
    public partial class PlayGame : CreateGame
    {
        public Player CurrentPlayer = new Player();
        public static int ScoreOfPlayerOne = 0;
        public static int ScoreOfPlayerTwo = 0;

        internal void RunGame()
        {
            string inputPositionFromUser = string.Empty;
            while (!GameRules.GameIsOff)
            {
                Player.SetPlayer(ref CurrentPlayer);
                InitialiseMoves();

                GameEnds();
                

                Console.Write("{0}\'s turn ({1}) : ", CurrentPlayer.PlayerName, (eType)CurrentPlayer.TypeOfPiece);

                if (CurrentPlayer.PlayerName.Equals("Computer"))
                {
                    inputPositionFromUser = GetAIMoves().ToString();
                }
                else
                {
                }

                if (!theUserWantToQuit(inputPositionFromUser))
                {
                    MovePieceFromLetters(inputPositionFromUser);
                    Tools.PrintBoard(GameBoardAsArray);
                    Console.WriteLine("{0}'s move was ({1}): {2}", CurrentPlayer.PlayerName, (eType)CurrentPlayer.TypeOfPiece, inputPositionFromUser);
                }
            }
        }

        public void GameEnds()
        {
            InitialiseMoves();
            if (CurrentPlayer.ValidMoves.Count == 0 && CurrentPlayer.ValidJumpMoves.Count == 0)
            {
                this.AggregateScore();
                Console.WriteLine("No valid moves, do you want to play again? Please type yes");
            }
        }

        public void FinishGame()
        {
            if (ScoreOfPlayerOne >= ScoreOfPlayerTwo)
            {
                TotalScorePlayerOne += ScoreOfPlayerOne - ScoreOfPlayerTwo;
            }
            else
            {
                TotalScorePlayerTwo += ScoreOfPlayerTwo - ScoreOfPlayerOne;
            }

            Console.WriteLine("1Score: " + TotalScorePlayerOne + ", 2Score: " + TotalScorePlayerTwo);

            string isYes = Console.ReadLine();
            if (isYes.ToLower().Equals("yes"))
            {
            }
            else
            {
                Console.WriteLine("GoodBye");
            }
        }

        public void MovePieceFromLetters(string i_InputFromConsole)
        {
            int oldPositionOfPieceColumn = (int)Enum.Parse(typeof(eCapitalLetterDictionary), i_InputFromConsole[0].ToString());
            int oldPositionOfPieceRow = (int)Enum.Parse(typeof(eCapitalLetterDictionary), i_InputFromConsole[1].ToString().ToUpper());
            int newPositionOfPieceColumn = (int)Enum.Parse(typeof(eCapitalLetterDictionary), i_InputFromConsole[3].ToString());
            int newPositionOfPieceRow = (int)Enum.Parse(typeof(eCapitalLetterDictionary), i_InputFromConsole[4].ToString().ToUpper());
            Position oldPosition = new Position(oldPositionOfPieceRow, oldPositionOfPieceColumn);
            Position newPosition = new Position(newPositionOfPieceRow, newPositionOfPieceColumn);
            Move move = new Move(oldPosition, newPosition);
            MovePiece(move);
        }

        public Move GetAIMoves()
        {
            Random random = null;
            Move AIMove = null;
            InitialiseMoves();
            if (!(CurrentPlayer.ValidJumpMoves.Count == 0))
            {
                random = new Random();
                int randomNumber = random.Next(CurrentPlayer.ValidJumpMoves.Count);
                AIMove = CurrentPlayer.ValidJumpMoves.ElementAt(randomNumber);
            }
            else if (!(CurrentPlayer.ValidMoves.Count == 0))
            {
                random = new Random();
                int randomNumber = random.Next(CurrentPlayer.ValidMoves.Count);
                AIMove = CurrentPlayer.ValidMoves.ElementAt(randomNumber);
            }

            return AIMove;
        }

        // $G$ DSN-003 (-5) This method is too long. 
        public void MovePiece(Move i_Move)
        {
            InitialiseMoves();

            // There are no valid Jump Moves
            if (CurrentPlayer.ValidJumpMoves.Count == 0)
            {
                Position startPosition = i_Move.StartPosition;
                Position endPosition = i_Move.EndPosition;

                Piece pieceToMove = null;

                int index = 0;
                for (int i = 0; i < Pieces.Length; i++)
                {
                    if (Pieces[i].PositionOfPiece.RowPosition == startPosition.RowPosition &&
                        Pieces[i].PositionOfPiece.ColumnPosition == startPosition.ColumnPosition &&
                        (Pieces[i].Type % 2) == CurrentPlayer.TypeOfPiece)
                    {
                        pieceToMove = Pieces[i];
                        index = i;
                    }
                }

                if (pieceToMove == null)
                {
                    MessageBox.Show("Invalid Piece");
                }

                if (GameBoardAsArray[endPosition.RowPosition, endPosition.ColumnPosition] != '\0')
                {
                    MessageBox.Show("THERE'S A PIECE ON THAT SQUARE");
                }
                else
                {
                    if (!(CurrentPlayer.ValidMoves.Count == 0))
                    {
                        Pieces[index].PositionOfPiece = endPosition;
                        GameBoardAsArray[startPosition.RowPosition, startPosition.ColumnPosition] = '\0';

                        if (IsPlayerOneGame && endPosition.RowPosition == 0)
                        {

                            GameBoardAsArray[endPosition.RowPosition, endPosition.ColumnPosition] = 'K';

                            Pieces[index].Type = 2;

                        }
                        else if (!IsPlayerOneGame && endPosition.RowPosition == SizeOfGameBoard - 1)
                        {
                            GameBoardAsArray[endPosition.RowPosition, endPosition.ColumnPosition] = 'U';
                            Pieces[index].Type = 3;
                        }
                        else
                        {
                            GameBoardAsArray[endPosition.RowPosition, endPosition.ColumnPosition] = char.Parse(((eType)pieceToMove.Type).ToString());
                        }

                        Player.changeCurrentPlayer(ref CurrentPlayer);
                    }
                    else
                    {
                        Console.WriteLine("Not a valid end position");
                    }
                }
            }
            else
            {
                foreach (Move move in CurrentPlayer.ValidJumpMoves)
                {
                    if (move.StartPosition.Equals(i_Move.StartPosition) && move.EndPosition.Equals(i_Move.EndPosition))
                    {
                        implementJumpMove(move);
                        break;
                    }
                    else
                    {
                        MessageBox.Show(String.Format(
                            "Pay Attention, you can eat one in {0}{1}>{2}{3}",
                            (eCapitalLetterDictionary)move.StartPosition.ColumnPosition,
                            ((eCapitalLetterDictionary)move.StartPosition.RowPosition).ToString().ToLower(),
                            (eCapitalLetterDictionary)move.EndPosition.ColumnPosition,
                            ((eCapitalLetterDictionary)move.EndPosition.RowPosition).ToString().ToLower()));
                    }
                }
            }
        }

        public void AggregateScore()
        {
            ScoreOfPlayerOne = 0;
            ScoreOfPlayerTwo = 0;
            foreach (Piece piece in Pieces)
            {
                if (piece.IsAlive)
                {
                    if (piece.Type % 2 == 0)
                    {
                        ScoreOfPlayerOne++;
                    }

                    if (piece.Type % 2 == 1)
                    {
                        ScoreOfPlayerTwo++;
                    }

                    if (piece.Type == 2)
                    {
                        ScoreOfPlayerOne += 3;
                    }

                    if (piece.Type == 3)
                    {
                        ScoreOfPlayerTwo += 3;
                    }
                }
            }
        }

        private void implementJumpMove(Move i_Move)
        {
            for (int i = 0; i < Pieces.Length; i++)
            {
                if (Pieces[i].PositionOfPiece.RowPosition == i_Move.StartPosition.RowPosition &&
                    Pieces[i].PositionOfPiece.ColumnPosition == i_Move.StartPosition.ColumnPosition)
                {
                    Pieces[i].PositionOfPiece = i_Move.EndPosition;

                    GameBoardAsArray[i_Move.StartPosition.RowPosition, i_Move.StartPosition.ColumnPosition] = '\0';
                    if (IsPlayerOneGame && i_Move.EndPosition.RowPosition == 0)
                    {
                        GameBoardAsArray[i_Move.EndPosition.RowPosition, i_Move.EndPosition.ColumnPosition] = 'K';
                        Pieces[i].Type = 2;
                    }
                    else if (!IsPlayerOneGame && i_Move.EndPosition.RowPosition == SizeOfGameBoard - 1)
                    {
                        GameBoardAsArray[i_Move.EndPosition.RowPosition, i_Move.EndPosition.ColumnPosition] = 'U';
                        Pieces[i].Type = 3;
                    }
                    else
                    {
                        GameBoardAsArray[i_Move.EndPosition.RowPosition, i_Move.EndPosition.ColumnPosition] = char.Parse(((eType)Pieces[i].Type).ToString());
                    }
                }

                if (Pieces[i].PositionOfPiece.RowPosition == (i_Move.StartPosition.RowPosition + i_Move.EndPosition.RowPosition) / 2 &&
                    Pieces[i].PositionOfPiece.ColumnPosition == (i_Move.StartPosition.ColumnPosition + i_Move.EndPosition.ColumnPosition) / 2)
                {
                    Pieces[i].IsAlive = false;

                    GameBoardAsArray[(i_Move.StartPosition.RowPosition + i_Move.EndPosition.RowPosition) / 2,
                        (i_Move.StartPosition.ColumnPosition + i_Move.EndPosition.ColumnPosition) / 2] = '\0';
                }
            }

            Player.changeCurrentPlayer(ref CurrentPlayer);
        }

        public void InitialiseMoves()
        {
            CurrentPlayer.ValidMoves = new List<Move>();
            CurrentPlayer.ValidJumpMoves = new List<Move>();

            foreach (Piece piece in Pieces)
            {
                if (piece.IsAlive)
                {
                    // Player 1
                    if (CurrentPlayer.TypeOfPiece == 0 && piece.Type % 2 == 0)
                    {
                        this.attemptAddingUpLeftMove(piece);
                        this.attemptAddingUpRightMove(piece);
                        this.attemptAddingUpLeftJumpMove(piece);
                        this.attemptAddingUpRightJumpMove(piece);

                        // Player 1 - King
                        if (piece.Type == 2)
                        {
                            this.attemptAddingDownRightMove(piece);
                            this.attemptAddingDownLeftMove(piece);
                            this.attemptAddingDownLeftJumpMove(piece);
                            this.attemptAddingDownRightJumpMove(piece);
                        }
                    }

                    // Player 2
                    if (CurrentPlayer.TypeOfPiece == 1 && piece.Type % 2 == 1)
                    {
                        this.attemptAddingDownLeftMove(piece);
                        this.attemptAddingDownRightMove(piece);
                        this.attemptAddingDownLeftJumpMove(piece);
                        this.attemptAddingDownRightJumpMove(piece);

                        // Player 2 - King
                        if (piece.Type == 3)
                        {
                            this.attemptAddingUpLeftMove(piece);
                            this.attemptAddingUpRightMove(piece);
                            this.attemptAddingUpLeftJumpMove(piece);
                            this.attemptAddingUpRightJumpMove(piece);
                        }
                    }
                }
            }
        }

        private void attemptAddingDownRightJumpMove(Piece i_Piece)
        {
            if (i_Piece.Type % 2 == 0)
            {
                try
                {
                    if (GameBoardAsArray[i_Piece.PositionOfPiece.RowPosition + 2,
                        i_Piece.PositionOfPiece.ColumnPosition + 2] == '\0' &&
                        (GameBoardAsArray[i_Piece.PositionOfPiece.RowPosition + 1,
                        i_Piece.PositionOfPiece.ColumnPosition + 1] == 'O' ||
                        GameBoardAsArray[i_Piece.PositionOfPiece.RowPosition + 1,
                        i_Piece.PositionOfPiece.ColumnPosition + 1] == 'U'))
                    {
                        Position oldPosition = new Position(i_Piece.PositionOfPiece.RowPosition, i_Piece.PositionOfPiece.ColumnPosition);

                        Position endPosition = new Position(i_Piece.PositionOfPiece.RowPosition + 2, i_Piece.PositionOfPiece.ColumnPosition + 2);

                        Move newUpRightJump = new Move(oldPosition, endPosition);

                        CurrentPlayer.ValidJumpMoves.Add(newUpRightJump);
                    }
                }
                catch (IndexOutOfRangeException)
                {
                }
            }

            if (i_Piece.Type % 2 == 1)
            {
                try
                {
                    if (GameBoardAsArray[i_Piece.PositionOfPiece.RowPosition + 2,
                        i_Piece.PositionOfPiece.ColumnPosition + 2] == '\0' &&
                        (GameBoardAsArray[i_Piece.PositionOfPiece.RowPosition + 1,
                        i_Piece.PositionOfPiece.ColumnPosition + 1] == 'X' ||
                        GameBoardAsArray[i_Piece.PositionOfPiece.RowPosition + 1,
                        i_Piece.PositionOfPiece.ColumnPosition + 1] == 'K'))
                    {
                        Position oldPosition = new Position(i_Piece.PositionOfPiece.RowPosition, i_Piece.PositionOfPiece.ColumnPosition);

                        Position endPosition = new Position(i_Piece.PositionOfPiece.RowPosition + 2, i_Piece.PositionOfPiece.ColumnPosition + 2);

                        Move newUpRightJump = new Move(oldPosition, endPosition);

                        CurrentPlayer.ValidJumpMoves.Add(newUpRightJump);
                    }
                }
                catch (IndexOutOfRangeException)
                {
                }
            }
        }

        private void attemptAddingDownLeftJumpMove(Piece piece)
        {
            if (piece.Type % 2 == 0)
            {
                try
                {
                    if (GameBoardAsArray[piece.PositionOfPiece.RowPosition + 2,
                        piece.PositionOfPiece.ColumnPosition - 2] == '\0' &&
                        (GameBoardAsArray[piece.PositionOfPiece.RowPosition + 1,
                        piece.PositionOfPiece.ColumnPosition - 1] == 'O' ||
                        GameBoardAsArray[piece.PositionOfPiece.RowPosition + 1,
                        piece.PositionOfPiece.ColumnPosition - 1] == 'U'))
                    {
                        Position oldPosition = new Position(piece.PositionOfPiece.RowPosition, piece.PositionOfPiece.ColumnPosition);

                        Position endPosition = new Position(piece.PositionOfPiece.RowPosition + 2, piece.PositionOfPiece.ColumnPosition - 2);

                        Move newUpLeftJump = new Move(oldPosition, endPosition);

                        CurrentPlayer.ValidJumpMoves.Add(newUpLeftJump);
                    }
                }
                catch (IndexOutOfRangeException)
                {
                }
            }

            if (piece.Type % 2 == 1)
            {
                try
                {
                    if (GameBoardAsArray[piece.PositionOfPiece.RowPosition + 2,
                        piece.PositionOfPiece.ColumnPosition - 2] == '\0' &&
                        (GameBoardAsArray[piece.PositionOfPiece.RowPosition + 1,
                        piece.PositionOfPiece.ColumnPosition - 1] == 'X' ||
                        GameBoardAsArray[piece.PositionOfPiece.RowPosition + 1,
                        piece.PositionOfPiece.ColumnPosition - 1] == 'K'))
                    {
                        Position oldPosition = new Position(piece.PositionOfPiece.RowPosition, piece.PositionOfPiece.ColumnPosition);

                        Position endPosition = new Position(piece.PositionOfPiece.RowPosition + 2, piece.PositionOfPiece.ColumnPosition - 2);

                        Move newUpLeftJump = new Move(oldPosition, endPosition);

                        CurrentPlayer.ValidJumpMoves.Add(newUpLeftJump);
                    }
                }
                catch (IndexOutOfRangeException)
                {
                }
            }
        }

        private void attemptAddingDownRightMove(Piece piece)
        {
            try
            {
                if (GameBoardAsArray[piece.PositionOfPiece.RowPosition + 1,
                    piece.PositionOfPiece.ColumnPosition + 1] == '\0')
                {
                    Position oldPosition = new Position(piece.PositionOfPiece.RowPosition, piece.PositionOfPiece.ColumnPosition);
                    Position endPosition = new Position(piece.PositionOfPiece.RowPosition + 1, piece.PositionOfPiece.ColumnPosition + 1);
                    Move newUpRight = new Move(oldPosition, endPosition);
                    CurrentPlayer.ValidMoves.Add(newUpRight);
                }
            }
            catch (IndexOutOfRangeException)
            {
            }
        }

        private void attemptAddingDownLeftMove(Piece piece)
        {
            try
            {
                if (GameBoardAsArray[piece.PositionOfPiece.RowPosition + 1,
                    piece.PositionOfPiece.ColumnPosition - 1] == '\0')
                {
                    Position oldPosition = new Position(piece.PositionOfPiece.RowPosition, piece.PositionOfPiece.ColumnPosition);
                    Position endPosition = new Position(piece.PositionOfPiece.RowPosition + 1, piece.PositionOfPiece.ColumnPosition - 1);
                    Move newUpLeft = new Move(oldPosition, endPosition);
                    CurrentPlayer.ValidMoves.Add(newUpLeft);
                }
            }
            catch (IndexOutOfRangeException)
            {
            }
        }

        private void attemptAddingUpRightJumpMove(Piece piece)
        {
            if (piece.Type % 2 == 0)
            {
                try
                {
                    if (GameBoardAsArray[piece.PositionOfPiece.RowPosition - 2,
                    piece.PositionOfPiece.ColumnPosition + 2] == '\0' &&
                    (GameBoardAsArray[piece.PositionOfPiece.RowPosition - 1,
                    piece.PositionOfPiece.ColumnPosition + 1] == 'O' ||
                    GameBoardAsArray[piece.PositionOfPiece.RowPosition - 1,
                    piece.PositionOfPiece.ColumnPosition + 1] == 'U'))
                    {
                        Position oldPosition = new Position(piece.PositionOfPiece.RowPosition, piece.PositionOfPiece.ColumnPosition);

                        Position endPosition = new Position(piece.PositionOfPiece.RowPosition - 2, piece.PositionOfPiece.ColumnPosition + 2);

                        Move newUpRightJump = new Move(oldPosition, endPosition);

                        CurrentPlayer.ValidJumpMoves.Add(newUpRightJump);
                    }
                }
                catch (IndexOutOfRangeException)
                {
                }
            }

            if (piece.Type % 2 == 1)
            {
                try
                {
                    if (GameBoardAsArray[piece.PositionOfPiece.RowPosition - 2,
                    piece.PositionOfPiece.ColumnPosition + 2] == '\0' &&
                    (GameBoardAsArray[piece.PositionOfPiece.RowPosition - 1,
                    piece.PositionOfPiece.ColumnPosition + 1] == 'X' ||
                    GameBoardAsArray[piece.PositionOfPiece.RowPosition - 1,
                    piece.PositionOfPiece.ColumnPosition + 1] == 'K'))
                    {
                        Position oldPosition = new Position(piece.PositionOfPiece.RowPosition, piece.PositionOfPiece.ColumnPosition);

                        Position endPosition = new Position(piece.PositionOfPiece.RowPosition - 2, piece.PositionOfPiece.ColumnPosition + 2);

                        Move newUpRightJump = new Move(oldPosition, endPosition);
                        CurrentPlayer.ValidJumpMoves.Add(newUpRightJump);
                    }
                }
                catch (IndexOutOfRangeException)
                {
                }
            }
        }

        // $G$ DSN-004 (-10) Code Duplication!
        private void attemptAddingUpLeftJumpMove(Piece piece)
        {
            if (piece.Type % 2 == 0)
            {
                try
                {
                    if (GameBoardAsArray[piece.PositionOfPiece.RowPosition - 2,
                        piece.PositionOfPiece.ColumnPosition - 2] == '\0' &&
                        (GameBoardAsArray[piece.PositionOfPiece.RowPosition - 1,
                        piece.PositionOfPiece.ColumnPosition - 1] == 'O' ||
                        GameBoardAsArray[piece.PositionOfPiece.RowPosition - 1,
                        piece.PositionOfPiece.ColumnPosition + 1] == 'U'))
                    {
                        Position oldPosition = new Position(piece.PositionOfPiece.RowPosition, piece.PositionOfPiece.ColumnPosition);

                        Position endPosition = new Position(piece.PositionOfPiece.RowPosition - 2, piece.PositionOfPiece.ColumnPosition - 2);

                        Move newUpLeftJump = new Move(oldPosition, endPosition);

                        CurrentPlayer.ValidJumpMoves.Add(newUpLeftJump);
                    }
                }
                catch (IndexOutOfRangeException)
                {
                }
            }

            if (piece.Type % 2 == 1)
            {
                try
                {
                    if (GameBoardAsArray[piece.PositionOfPiece.RowPosition - 2,
                        piece.PositionOfPiece.ColumnPosition - 2] == '\0' &&
                        (GameBoardAsArray[piece.PositionOfPiece.RowPosition - 1,
                        piece.PositionOfPiece.ColumnPosition - 1] == 'X' ||
                        GameBoardAsArray[piece.PositionOfPiece.RowPosition - 1,
                        piece.PositionOfPiece.ColumnPosition + 1] == 'K'))
                    {
                        Position oldPosition = new Position(piece.PositionOfPiece.RowPosition, piece.PositionOfPiece.ColumnPosition);

                        Position endPosition = new Position(piece.PositionOfPiece.RowPosition - 2, piece.PositionOfPiece.ColumnPosition - 2);

                        Move newUpLeftJump = new Move(oldPosition, endPosition);

                        CurrentPlayer.ValidJumpMoves.Add(newUpLeftJump);
                    }
                }
                catch (IndexOutOfRangeException)
                {
                }
            }
        }

        private void attemptAddingUpRightMove(Piece piece)
        {
            try
            {
                if (GameBoardAsArray[piece.PositionOfPiece.RowPosition - 1,
                    piece.PositionOfPiece.ColumnPosition + 1] == '\0')
                {
                    Position oldPosition = new Position(piece.PositionOfPiece.RowPosition, piece.PositionOfPiece.ColumnPosition);

                    Position endPosition = new Position(piece.PositionOfPiece.RowPosition - 1, piece.PositionOfPiece.ColumnPosition + 1);

                    Move newUpRight = new Move(oldPosition, endPosition);

                    CurrentPlayer.ValidMoves.Add(newUpRight);
                }
            }
            catch (IndexOutOfRangeException)
            {
            }
        }

        private void attemptAddingUpLeftMove(Piece piece)
        {
            try
            {
                if (GameBoardAsArray[piece.PositionOfPiece.RowPosition - 1,
                                             piece.PositionOfPiece.ColumnPosition - 1] == '\0')
                {
                    Position oldPosition = new Position(piece.PositionOfPiece.RowPosition, piece.PositionOfPiece.ColumnPosition);

                    Position endPosition = new Position(piece.PositionOfPiece.RowPosition - 1, piece.PositionOfPiece.ColumnPosition - 1);

                    Move newUpLeft = new Move(oldPosition, endPosition);

                    CurrentPlayer.ValidMoves.Add(newUpLeft);
                }
            }
            catch (IndexOutOfRangeException)
            {
            }
        }

        private bool theUserWantToQuit(string i_InputPositionFromUser)
        {
            bool result = false;
            AggregateScore();
            if (i_InputPositionFromUser.Equals('Q'.ToString()))
            {
                bool isPlayerOneWinning = ScoreOfPlayerOne > ScoreOfPlayerTwo ? true : false;
                bool isPlayerTwoWinning = ScoreOfPlayerOne < ScoreOfPlayerTwo ? true : false;
                result = true;
                if ((isPlayerOneWinning && !GameRules.IsPlayerOneGame) || (isPlayerTwoWinning && GameRules.IsPlayerOneGame))
                {
                    Console.WriteLine("The game ended. if you want to start again press yes please");
                    GameIsOff = true;
                    FinishGame();
                }
                else if (ScoreOfPlayerOne == ScoreOfPlayerTwo)
                {
                    Console.WriteLine("This is a tie. You are not yet allowed to quit.");
                }
                else
                {
                    Console.WriteLine("You are winning, why would you quit?");
                }
            }

            return result;
        }
    }
}
