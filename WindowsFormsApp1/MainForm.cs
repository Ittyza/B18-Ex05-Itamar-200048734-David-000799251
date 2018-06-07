using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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



        public MainForm()
        {
            InitializeComponent();
        }

        public PictureBox GameBoard { get => gameBoard; set => gameBoard = value; }
        public Image BoardImage { get => BoardImage; set => BoardImage = value; }

        private void InitializeComponent()
        {
            //this.gameBoard = new System.Windows.Forms.PictureBox();
            this.playerOne = new System.Windows.Forms.Label();
            this.scorePlayer1 = new System.Windows.Forms.Label();
            this.scorePlayer2 = new System.Windows.Forms.Label();
            this.playerTwo = new System.Windows.Forms.Label();
            this.gameBoard = new PictureBox();
            this.SuspendLayout();
            // 
            // playerOne
            // 
            this.playerOne.AutoSize = true;
            this.playerOne.Location = new System.Drawing.Point(113, 44);
            this.playerOne.Name = "playerOne";
            this.playerOne.Size = new System.Drawing.Size(48, 13);
            this.playerOne.TabIndex = 0;
            this.playerOne.Text = "Player 1:";
            // 
            // scorePlayer1
            // 
            this.scorePlayer1.AutoSize = true;
            this.scorePlayer1.Location = new System.Drawing.Point(167, 44);
            this.scorePlayer1.Name = "scorePlayer1";
            this.scorePlayer1.Size = new System.Drawing.Size(13, 13);
            this.scorePlayer1.TabIndex = 1;
            this.scorePlayer1.Text = "0";
            // 
            // scorePlayer2
            // 
            this.scorePlayer2.AutoSize = true;
            this.scorePlayer2.Location = new System.Drawing.Point(401, 44);
            this.scorePlayer2.Name = "scorePlayer2";
            this.scorePlayer2.Size = new System.Drawing.Size(13, 13);
            this.scorePlayer2.TabIndex = 3;
            this.scorePlayer2.Text = "0";
            // 
            // playerTwo
            // 
            this.playerTwo.AutoSize = true;
            this.playerTwo.Location = new System.Drawing.Point(347, 44);
            this.playerTwo.Name = "playerTwo";
            this.playerTwo.Size = new System.Drawing.Size(48, 13);
            this.playerTwo.TabIndex = 2;
            this.playerTwo.Text = "Player 2:";
            // 
            // pictureBox1
            // 
            this.GameBoard.Location = new System.Drawing.Point(24, 102);
            this.GameBoard.Name = "pictureBox1";
            this.GameBoard.Size = new System.Drawing.Size(500, 407);
            this.GameBoard.TabIndex = 4;
            this.GameBoard.TabStop = false;
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(561, 591);
            this.Controls.Add(this.GameBoard);
            this.Controls.Add(this.scorePlayer2);
            this.Controls.Add(this.playerTwo);
            this.Controls.Add(this.scorePlayer1);
            this.Controls.Add(this.playerOne);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Damka";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            FormLogin formLogin = new FormLogin();
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
    }
}
