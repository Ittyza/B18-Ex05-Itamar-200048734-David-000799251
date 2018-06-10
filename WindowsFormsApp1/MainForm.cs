using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ex05.Ex02.Logic;

namespace Ex05.Damka
{
    public partial class MainForm : Form
    {
        private Label playerTwo = new Label();
        private Label playerOne = new Label();
        private Button[,] buttonBoard;
        private bool m_ValidMove = false;
        private PlayGame playGame;
        private Button currentButtonToMove;
        

        public MainForm()
        {
            //InitializeComponent();
            //InitiateImages();
        }

        public Image BoardImage { get => BoardImage; set => BoardImage = value; }

        private void InitializeComponent()
        {
            playerOne = new Label();
            playerTwo = new Label();
            buttonBoard = new Button[GameRules.SizeOfGameBoard, GameRules.SizeOfGameBoard];
            playGame = new PlayGame();
            playGame.AggregateScore();
            SuspendLayout();
            playerOne.AutoSize = true;
            playerOne.Text = GameRules.PlayerOne.PlayerName + ": " + PlayGame.ScoreOfPlayerOne;
            playerOne.Top = 12;
            playerOne.Left = 12;
            playerOne.Name = "playerOne";
            playerTwo.AutoSize = true;
            playerTwo.Top = 12;
            playerTwo.Left = ClientSize.Width - 24 - this.playerTwo.Width;
            playerTwo.Name = "playerTwo";
            playerTwo.Text = GameRules.PlayerTwo.PlayerName + ": " + PlayGame.ScoreOfPlayerTwo;
            Controls.Add(this.playerOne);
            Controls.Add(this.playerTwo);
            Name = "MainForm";
            Text = "Damka";
            ClientSize = new Size((GameRules.SizeOfGameBoard * GameRules.SizeOfGameBoard) + 100, (GameRules.SizeOfGameBoard * GameRules.SizeOfGameBoard) + 110);
            AutoSize = true;
            int xStartValue = playerOne.Left;
            int yStartValue = playerOne.Height + 12;
            int xCurrentValue;
            int yCurrentValue;

            for (int row = 0; row < GameRules.SizeOfGameBoard; row++)
            {
                for (int col = 0; col < GameRules.SizeOfGameBoard; col++)
                {
                    buttonBoard[row, col] = new Button();
                    buttonBoard[row, col].Size = new Size(40, 40);
                    xCurrentValue = xStartValue + (col * 40);
                    yCurrentValue = yStartValue + (row * 40);
                    buttonBoard[row, col].Location = new Point(xCurrentValue, yCurrentValue);
                    if (((col + row) % 2) == 0)
                    {
                        buttonBoard[row, col].BackColor = Color.DarkGray;
                        buttonBoard[row, col].Enabled = false;
                    }
                    else
                    {
                        buttonBoard[row, col].BackColor = Color.White;
                    }

                    this.Controls.Add(buttonBoard[row, col]);
                    buttonBoard[row, col].Click += new EventHandler(buttonBoard_Click);
                }
            }

            ResumeLayout(false);
            PerformLayout();

        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            InitializeComponent();
            showBoardFromLogic();
        }

        private void showBoardFromLogic()
        {
            for (int row = 0; row < GameRules.SizeOfGameBoard; row++)
            {
                for (int col = 0; col < GameRules.SizeOfGameBoard; col++)
                {
                    if (buttonBoard[row, col].Enabled == true)
                    {
                        buttonBoard[row, col].Text = playGame.GameBoardAsArray[row, col].ToString();
                    }

                }
            }

            AIMoves();
            GameEnds();
        }

        private void GameEnds()
        {
            playGame.InitialiseMoves();
            if(playGame.CurrentPlayer.ValidMoves.Count == 0 && playGame.CurrentPlayer.ValidJumpMoves.Count == 0)
            {
                playGame.AggregateScore();
                if (PlayGame.ScoreOfPlayerOne >= PlayGame.ScoreOfPlayerTwo)
                {
                    GameRules.TotalScorePlayerOne += PlayGame.ScoreOfPlayerOne - PlayGame.ScoreOfPlayerTwo;
                }
                else
                {
                    GameRules.TotalScorePlayerTwo += PlayGame.ScoreOfPlayerTwo - PlayGame.ScoreOfPlayerOne;
                }

                DialogResult dialogResult = MessageBox.Show("Game Ended, do you want to play again?", "Damka", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Close();
                    new UI().Run();
                }
                else if (dialogResult == DialogResult.No)
                {
                    Close();
                }
            }
        }

        private void AIMoves()
        {
            Player.SetPlayer(ref playGame.CurrentPlayer);
            if (playGame.CurrentPlayer.PlayerName.Equals("Computer"))
            {
                GameEnds();
                try
                {
                    playGame.MovePieceFromLetters(playGame.GetAIMoves().ToString());
                }
                catch (NullReferenceException)
                {

                }

                showBoardFromLogic();
                return;
            }
        }

        private void buttonBoard_Click(object sender, EventArgs e)
        {

            if (!m_ValidMove)
            {
                currentButtonToMove = (sender as Button);
                startMove(currentButtonToMove);
            }
            else
            {
                endMove(currentButtonToMove, (sender as Button));
                m_ValidMove = false;
            }

            playGame.AggregateScore();
            playerOne.Text = GameRules.PlayerOne.PlayerName + ": " + PlayGame.ScoreOfPlayerOne;
            playerTwo.Text = GameRules.PlayerTwo.PlayerName + ": " + PlayGame.ScoreOfPlayerTwo;
            showBoardFromLogic();
        }

        private void endMove(Button currentButtonToMove, Button end)
        {
            int yValueStart = (currentButtonToMove.Location.X - buttonBoard[0, 0].Location.X) / 40;
            int xValueStart = (currentButtonToMove.Location.Y - buttonBoard[0, 0].Location.Y) / 40;
            int yValueEnd = (end.Location.X - buttonBoard[0, 0].Location.X) / 40;
            int xValueEnd = (end.Location.Y - buttonBoard[0, 0].Location.Y) / 40;
            if (xValueStart == xValueEnd && yValueStart == yValueEnd)
            {
                currentButtonToMove.BackColor = Color.White;
                m_ValidMove = false;
                return;
            }

            Position m_PositionStart = new Position(xValueStart, yValueStart);
            Position m_PositionEnd = new Position(xValueEnd, yValueEnd);
            Move move = new Move(m_PositionStart, m_PositionEnd);
            playGame.MovePiece(move);
            currentButtonToMove.BackColor = Color.White;
            m_ValidMove = false;
        }

        private void startMove(Button start)
        {
            int yValueStart = (start.Location.X - buttonBoard[0, 0].Location.X) / 40;
            int xValueStart = (start.Location.Y - buttonBoard[0, 0].Location.Y) / 40;
            if (GameRules.IsPlayerOneGame)
            {
                if (playGame.GameBoardAsArray[xValueStart, yValueStart] == char.Parse(PlayGame.eType.X.ToString()) ||
                playGame.GameBoardAsArray[xValueStart, yValueStart] == char.Parse(PlayGame.eType.K.ToString()))
                {
                    m_ValidMove = true;
                    start.BackColor = Color.LightBlue;
                }
            }
            else if (!GameRules.IsPlayerOneGame)
            {
                if (playGame.GameBoardAsArray[xValueStart, yValueStart] == char.Parse(PlayGame.eType.O.ToString()) ||
                playGame.GameBoardAsArray[xValueStart, yValueStart] == char.Parse(PlayGame.eType.U.ToString()))
                {
                    m_ValidMove = true;
                    start.BackColor = Color.LightBlue;
                }
            }
        }
    }
}
