using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ex05.Ex02.Logic;

namespace Ex05.Damka
{
    public partial class MainForm : Form
    {
        private Label playerTwo;
        private Label playerOne;
        private PictureBox redPiece;
        private PictureBox redKing;
        private PictureBox blackPiece;
        private PictureBox blackKing;
        private Button[,] buttonBoard;
        private bool m_ValidMove = false;
        private CreateGame createGame;
        Button currentButtonToMove;

        public MainForm()
        {
            //InitializeComponent();
            //InitiateImages();
        }

        public Image BoardImage { get => BoardImage; set => BoardImage = value; }

        private void InitializeComponent()
        {
            this.playerOne = new Label();
            this.playerTwo = new Label();
            this.buttonBoard = new Button[GameRules.SizeOfGameBoard, GameRules.SizeOfGameBoard];
            this.createGame = new CreateGame();
            this.SuspendLayout();
            // 
            // playerOne
            // 
            this.playerOne.AutoSize = true;
            this.playerOne.Text = GameRules.PlayerOne.PlayerName + ": " + GameRules.PlayerOne.Score;
            this.playerOne.Top = 12;
            this.playerOne.Left = 12;
            this.playerOne.Name = "playerOne";
            // 
            // playerTwo
            // 
            this.playerTwo.AutoSize = true;
            this.playerTwo.Top = 12;
            this.playerTwo.Left = ClientSize.Width - 24 - this.playerTwo.Width;
            this.playerTwo.Name = "playerTwo";
            this.playerTwo.Text = GameRules.PlayerTwo.PlayerName + ": " + GameRules.PlayerTwo.Score;
            //
            // MainForm
            // 
            this.Controls.Add(this.playerOne);
            this.Controls.Add(this.playerTwo);
            this.Name = "MainForm";
            this.Text = "Damka";
            this.ClientSize = new Size((GameRules.SizeOfGameBoard * GameRules.SizeOfGameBoard) + 100, (GameRules.SizeOfGameBoard * GameRules.SizeOfGameBoard) + 110);

            this.AutoSize = true;

            int startX = playerOne.Left;
            int startY = playerOne.Height + 12;
            int currentX;
            int currentY;

            for (int row = 0; row < GameRules.SizeOfGameBoard; row++)
            {
                for (int col = 0; col < GameRules.SizeOfGameBoard; col++)
                {
                    buttonBoard[row, col] = new Button();
                    buttonBoard[row, col].Size = new Size(40, 40);
                    currentX = startX + (row * 40);
                    currentY = startY + (col * 40);
                    buttonBoard[row, col].Location = new Point(currentX, currentY);
                    if (((col + row) % 2) == 0)
                    {
                        buttonBoard[row, col].BackColor = Color.DarkGray;
                        buttonBoard[row, col].Enabled = false;
                    }

                    this.Controls.Add(buttonBoard[row, col]);
                    buttonBoard[row, col].Click += new EventHandler(buttonBoard_Click);
                }
            }
            this.ResumeLayout(false);
            this.PerformLayout();

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
                    if (buttonBoard[col, row].Enabled == true)
                    {
                        buttonBoard[col, row].Text = createGame.GameBoardAsArray[row, col].ToString();
                    }
                }
            }
        }
        private void buttonBoard_Click(object sender, EventArgs e)
        {

            Button end;
            if (!m_ValidMove)
            {
                currentButtonToMove = (sender as Button);
                startMove(currentButtonToMove);
            }
            else
            {
                end = (sender as Button);
                endMove(currentButtonToMove, end);


            }
        }

        private void endMove(Button currentButtonToMove, Button end)
        {
            int xValueStart = (currentButtonToMove.Location.X - buttonBoard[0, 0].Location.X) / 40;
            int yValueStart = (currentButtonToMove.Location.Y - buttonBoard[0, 0].Location.Y) / 40;
            int xValueEnd = (end.Location.X - buttonBoard[0, 0].Location.X) / 40;
            int yValueEnd = (end.Location.Y - buttonBoard[0, 0].Location.Y) / 40;
            PlayGame playGame = new PlayGame();
            Move move = new Move(new Position(xValueStart, yValueStart), new Position(xValueEnd, yValueEnd));
            playGame.MovePiece(move);

        }

        private void startMove(Button start)
        {
            int xValueStart = (start.Location.X - buttonBoard[0, 0].Location.X) / 40;
            int yValueStart = (start.Location.Y - buttonBoard[0, 0].Location.Y) / 40;
            if (GameRules.IsPlayerOneGame)
            {
                if (createGame.GameBoardAsArray[yValueStart, xValueStart] == char.Parse(PlayGame.eType.X.ToString()) ||
                createGame.GameBoardAsArray[yValueStart, xValueStart] == char.Parse(PlayGame.eType.K.ToString()))
                {
                    m_ValidMove = true;
                }
                else if (createGame.GameBoardAsArray[yValueStart, xValueStart] == char.Parse(PlayGame.eType.O.ToString()) ||
                createGame.GameBoardAsArray[yValueStart, xValueStart] == char.Parse(PlayGame.eType.U.ToString()))
                {
                    m_ValidMove = true;
                }
                if (m_ValidMove)
                {
                    start.BackColor = Color.LightBlue;
                }
            }
        }

        private void InitiateImages()
        {
            this.redPiece = new PictureBox();
            this.redKing = new PictureBox();
            this.blackPiece = new PictureBox();
            this.blackKing = new PictureBox();
            this.redPiece.Image = WindowsFormsApp1.Properties.Resources.RedPiece;
            this.redPiece.SizeMode = PictureBoxSizeMode.AutoSize;
            this.redKing.Image = WindowsFormsApp1.Properties.Resources.KRed;
            this.redKing.SizeMode = PictureBoxSizeMode.AutoSize;
            this.blackPiece.Image = WindowsFormsApp1.Properties.Resources.BlackPiece;
            this.blackPiece.SizeMode = PictureBoxSizeMode.AutoSize;
            this.blackKing.Image = WindowsFormsApp1.Properties.Resources.KBlack;
            this.blackKing.SizeMode = PictureBoxSizeMode.AutoSize;
            //this.blackKing.Left = scorePlayer2.Right + 12;
            //this.redPiece.Left = scorePlayer1.Right + 12;
            this.Controls.Add(redPiece);
            this.Controls.Add(blackPiece);
        }

    }
}
