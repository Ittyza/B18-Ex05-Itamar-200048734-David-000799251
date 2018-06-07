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
        private Label scorePlayer1;
        private Label scorePlayer2;
        private Label playerTwo;
        private Label playerOne;
        private Image boardImage;
        private Image redPiece;
        private Image redKing;
        private Image blackPiece;
        private PictureBox gameBoard;
        private Image blackKing;
        private FormLogin formLogin = new FormLogin();
        private GameRules m_GameRules = new GameRules();

        public MainForm()
        {
            InitializeComponent();
        }

        public PictureBox GameBoard { get => gameBoard; set => gameBoard = value; }
        public Image BoardImage { get => BoardImage; set => BoardImage = value; }
        public GameRules GameRules { get => m_GameRules; set => m_GameRules = value; }

        private void InitializeComponent()
        {
            this.playerOne = new Label();
            this.scorePlayer1 = new Label();
            this.scorePlayer2 = new Label();
            this.playerTwo = new Label();
            this.gameBoard = new PictureBox();
            this.SuspendLayout();

            //Creates Board size
            setSizeOfBoard();
            // 
            // playerOne
            // 
            this.playerOne.AutoSize = true;
            this.playerOne.Text = GameRules.PlayerOne.PlayerName;
            this.playerOne.BackColor = Color.Cyan;
            this.playerOne.Top = 12;
            this.playerOne.Left = 12;
            this.playerOne.Name = "playerOne";
            // 
            // scorePlayer1
            // 
            this.scorePlayer1.AutoSize = true;
            this.scorePlayer1.BackColor = Color.Yellow;
            this.scorePlayer1.Top = 12;
            this.scorePlayer1.Left = this.playerOne.Right + 12;
            this.scorePlayer1.Name = "scorePlayer1";
            this.scorePlayer1.Text = "0";
            // 
            // gameBoard
            // 
            this.gameBoard.Left = 12;
            this.gameBoard.Top = this.playerOne.Bottom + 12;
            this.gameBoard.Size = this.gameBoard.Image.Size;
            this.gameBoard.Name = "gameBoard";
            // 
            // playerTwo
            // 
            this.playerTwo.AutoSize = true;
            this.playerTwo.Top = 12;
            this.playerTwo.BackColor = Color.Green;
            this.playerTwo.Left = ClientSize.Width - 24 - this.playerTwo.Width;
            this.playerTwo.Name = "playerTwo";
            this.playerTwo.Size = new System.Drawing.Size(48, 13);
            this.playerTwo.TabIndex = 2;
            this.playerTwo.Text = GameRules.PlayerTwo.PlayerName;
            // 
            // scorePlayer2
            // 
            this.scorePlayer2.AutoSize = true;
            this.scorePlayer2.Top = 12;
            this.scorePlayer2.Left = ClientSize.Width - 12;
            this.scorePlayer2.Name = "scorePlayer2";
            this.scorePlayer2.Text = "0";
            // 
            // MainForm
            // 
            this.Controls.Add(this.playerOne);
            this.Controls.Add(this.scorePlayer1);
            this.Controls.Add(this.gameBoard);
            this.Controls.Add(this.playerTwo);
            this.Controls.Add(this.scorePlayer2);
            
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Damka";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gameBoard)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            formLogin.Owner = this;
            formLogin.ShowDialog();
        }

        private void InitiateImages()
        {

            redPiece = Image.FromFile("Resources/RedPiece.jpg");
            redKing = Image.FromFile("Resources/KRed.jpg");
            blackPiece = Image.FromFile("Resources/BlackPiece.jpg");
            blackKing = Image.FromFile("Resources/KBlack.jpg");
        }
        private void setSizeOfBoard()
        {
            // THis is always true for some reason - Will always load 6x6 board
            if (formLogin.RadioButton6.Checked)
            {
                this.GameBoard.Image = global::WindowsFormsApp1.Properties.Resources._6x6board;
            }

            else if (formLogin.RadioButton8.Checked)
            {
                this.GameBoard.Image = global::WindowsFormsApp1.Properties.Resources._8x8board;
            }

            else if (formLogin.RadioButton10.Checked)
            {
                this.GameBoard.Image = global::WindowsFormsApp1.Properties.Resources._10x10board;
            }

            this.ClientSize = new Size(gameBoard.Image.Width + 24, gameBoard.Image.Height + 36 + this.playerOne.Height);
        }
    }
}
