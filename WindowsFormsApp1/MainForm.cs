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
        private PictureBox redPiece;
        private PictureBox redKing;
        private PictureBox blackPiece;
        private PictureBox gameBoard;
        private PictureBox blackKing;
        private FormLogin formLogin = new FormLogin();

        public MainForm()
        {
            InitializeComponent();
            InitiateImages();
        }

        public PictureBox GameBoard { get => gameBoard; set => gameBoard = value; }
        public Image BoardImage { get => BoardImage; set => BoardImage = value; }
        
        private void InitializeComponent()
        {
            this.playerOne = new Label();
            this.scorePlayer1 = new Label();
            this.scorePlayer2 = new Label();
            this.playerTwo = new Label();
            this.gameBoard = new PictureBox();
            this.SuspendLayout();


            // 
            // playerOne
            // 
            this.playerOne.AutoSize = true;
            this.playerOne.Text = GameRules.PlayerOne.PlayerName;
            this.playerOne.Top = 12;
            this.playerOne.Left = 12;
            this.playerOne.Name = "playerOne";
            // 
            // scorePlayer1
            // 
            this.scorePlayer1.AutoSize = true;
            this.scorePlayer1.Top = 12;
            this.scorePlayer1.Left = this.playerOne.Right + 12;
            this.scorePlayer1.Name = "scorePlayer1";
            this.scorePlayer1.Text = "0";
            // 
            // gameBoard
            // 
            this.gameBoard.Left = 12;
            this.gameBoard.Top = this.playerOne.Bottom + 12;
            this.gameBoard.Name = "gameBoard";
            this.gameBoard.SizeMode = PictureBoxSizeMode.AutoSize;
            // 
            // playerTwo
            // 
            this.playerTwo.AutoSize = true;
            this.playerTwo.Top = 12;
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



            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void InitiateImages()
        {
            this.redPiece = new PictureBox();
            this.redKing = new PictureBox();
            this.blackPiece = new PictureBox();
            this.blackKing = new PictureBox();
            this.redPiece.Image = global::WindowsFormsApp1.Properties.Resources.RedPiece;
            this.redPiece.SizeMode = PictureBoxSizeMode.AutoSize;
            this.redKing.Image = global::WindowsFormsApp1.Properties.Resources.KRed;
            this.redKing.SizeMode = PictureBoxSizeMode.AutoSize;
            this.blackPiece.Image = global::WindowsFormsApp1.Properties.Resources.BlackPiece;
            this.blackPiece.SizeMode = PictureBoxSizeMode.AutoSize;
            this.blackKing.Image = global::WindowsFormsApp1.Properties.Resources.KBlack;
            this.blackKing.SizeMode = PictureBoxSizeMode.AutoSize;
            this.blackKing.Left = playerTwo.Left +24;
            this.redPiece.Left = playerOne.Left + 24;
            this.Controls.Add(redPiece);
            this.Controls.Add(blackPiece);
        }
        
    }
}
