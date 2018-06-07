using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ex05.Ex02.Logic;

namespace Ex05.Damka
{
    class FormLogin : Form
    {
        private RadioButton radioButton6;
        private RadioButton radioButton8;
        private RadioButton radioButton10;
        private Label players;
        private Label playerOne;
        private TextBox textBoxPlayerOne;
        private TextBox textBoxPlayerTwo;
        private CheckBox playerTwo;
        private Button buttonDone;
        private Label boardSize;
        private MainForm mainForm;

        public RadioButton RadioButton6 { get => radioButton6; set => radioButton6 = value; }
        public RadioButton RadioButton8 { get => radioButton8; set => radioButton8 = value; }
        public RadioButton RadioButton10 { get => radioButton10; set => radioButton10 = value; }
        public TextBox TextBoxPlayerOne { get => textBoxPlayerOne; set => textBoxPlayerOne = value; }
        public TextBox TextBoxPlayerTwo { get => textBoxPlayerTwo; set => textBoxPlayerTwo = value; }

        public FormLogin()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.boardSize = new Label();
            this.radioButton6 = new RadioButton();
            this.radioButton8 = new RadioButton();
            this.radioButton10 = new RadioButton();
            this.players = new Label();
            this.playerOne = new Label();
            this.TextBoxPlayerOne = new TextBox();
            this.TextBoxPlayerTwo = new TextBox();
            this.playerTwo = new CheckBox();
            this.buttonDone = new Button();
            this.SuspendLayout();
            // 
            // boardSize
            // 
            this.boardSize.AutoSize = true;
            this.boardSize.Location = new System.Drawing.Point(31, 19);
            this.boardSize.Name = "boardSize";
            this.boardSize.Size = new System.Drawing.Size(58, 13);
            this.boardSize.TabIndex = 0;
            this.boardSize.Text = "Board Size";
            // 
            // radioButton6
            // 
            this.radioButton6.AutoSize = true;
            this.radioButton6.Checked = true;
            this.radioButton6.Location = new System.Drawing.Point(55, 41);
            this.radioButton6.Name = "radioButton6";
            this.radioButton6.Size = new System.Drawing.Size(48, 17);
            this.radioButton6.TabIndex = 1;
            this.radioButton6.TabStop = true;
            this.radioButton6.Text = "6 x 6";
            this.radioButton6.UseVisualStyleBackColor = true;
            // 
            // radioButton8
            // 
            this.radioButton8.AutoSize = true;
            this.radioButton8.Location = new System.Drawing.Point(147, 41);
            this.radioButton8.Name = "radioButton8";
            this.radioButton8.Size = new System.Drawing.Size(48, 17);
            this.radioButton8.TabIndex = 2;
            this.radioButton8.TabStop = true;
            this.radioButton8.Text = "8 x 8";
            this.radioButton8.UseVisualStyleBackColor = true;
            // 
            // radioButton10
            // 
            this.radioButton10.AutoSize = true;
            this.radioButton10.Location = new System.Drawing.Point(239, 41);
            this.radioButton10.Name = "radioButton10";
            this.radioButton10.Size = new System.Drawing.Size(60, 17);
            this.radioButton10.TabIndex = 3;
            this.radioButton10.TabStop = true;
            this.radioButton10.Text = "10 x 10";
            this.radioButton10.UseVisualStyleBackColor = true;
            // 
            // players
            // 
            this.players.AutoSize = true;
            this.players.Location = new System.Drawing.Point(31, 67);
            this.players.Name = "players";
            this.players.Size = new System.Drawing.Size(44, 13);
            this.players.TabIndex = 4;
            this.players.Text = "Players:";
            // 
            // playerOne
            // 
            this.playerOne.AutoSize = true;
            this.playerOne.Location = new System.Drawing.Point(52, 94);
            this.playerOne.Name = "playerOne";
            this.playerOne.Size = new System.Drawing.Size(48, 13);
            this.playerOne.TabIndex = 5;
            this.playerOne.Text = "Player 1:";
            // 
            // textBoxPlayerOne
            // 
            this.TextBoxPlayerOne.Location = new System.Drawing.Point(147, 91);
            this.TextBoxPlayerOne.Name = "textBoxPlayerOne";
            this.TextBoxPlayerOne.Size = new System.Drawing.Size(152, 20);
            this.TextBoxPlayerOne.TabIndex = 6;
            // 
            // textBoxPlayerTwo
            // 
            this.TextBoxPlayerTwo.Enabled = false;
            this.TextBoxPlayerTwo.Text = "Computer";
            this.TextBoxPlayerTwo.Location = new System.Drawing.Point(147, 135);
            this.TextBoxPlayerTwo.Name = "textBoxPlayerTwo";
            this.TextBoxPlayerTwo.Size = new System.Drawing.Size(152, 20);
            this.TextBoxPlayerTwo.TabIndex = 8;
            // 
            // playerTwo
            // 
            this.playerTwo.AutoSize = true;
            this.playerTwo.Location = new System.Drawing.Point(33, 135);
            this.playerTwo.Name = "playerTwo";
            this.playerTwo.Size = new System.Drawing.Size(67, 17);
            this.playerTwo.TabIndex = 9;
            this.playerTwo.Text = "Player 2:";
            this.playerTwo.UseVisualStyleBackColor = true;
            this.playerTwo.CheckedChanged += new System.EventHandler(this.playerTwo_CheckedChanged);
            // 
            // buttonDone
            // 
            this.buttonDone.Location = new System.Drawing.Point(222, 171);
            this.buttonDone.Name = "buttonDone";
            this.buttonDone.Size = new System.Drawing.Size(75, 23);
            this.buttonDone.TabIndex = 10;
            this.buttonDone.Text = "Done";
            this.buttonDone.UseVisualStyleBackColor = true;
            this.buttonDone.Click += new System.EventHandler(this.buttonDone_Click);
            // 
            // FormLogin
            // 
            this.ClientSize = new System.Drawing.Size(320, 210);
            this.Controls.Add(this.buttonDone);
            this.Controls.Add(this.TextBoxPlayerTwo);
            this.Controls.Add(this.playerTwo);
            this.Controls.Add(this.TextBoxPlayerOne);
            this.Controls.Add(this.playerOne);
            this.Controls.Add(this.players);
            this.Controls.Add(this.radioButton10);
            this.Controls.Add(this.radioButton8);
            this.Controls.Add(this.radioButton6);
            this.Controls.Add(this.boardSize);
            this.Name = "FormLogin";
            this.Text = "Damka - Start Game";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            //this.FormClosing += new FormClosingEventHandler(this.FormLogin_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void playerTwo_CheckedChanged(object sender, EventArgs e)
        {
            if (TextBoxPlayerTwo.Enabled == false)
            {
                TextBoxPlayerTwo.Enabled = true;
                TextBoxPlayerTwo.Text = string.Empty;
            }
            else
            {
                TextBoxPlayerTwo.Enabled = false;
                TextBoxPlayerTwo.Text = "Computer";
            }
        }
        private void FormLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.WindowsShutDown) return;

            if (this.DialogResult == DialogResult.Cancel)
            {
                switch (MessageBox.Show(this, "Are you sure?", "Do you want to close ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    case DialogResult.No:
                        e.Cancel = true;
                        break;
                    case DialogResult.Yes:
                        break;
                    default:
                        break;
                }
            }
        }

        private void buttonDone_Click(object sender, EventArgs e)
        {
            if (TextBoxPlayerOne.Text == string.Empty)
            {
                MessageBox.Show("Please add a name for Player One");
            }
            else
            {
                setGameRules();
                Close();
                setSizeOfBoard();


            }
        }
        private void setSizeOfBoard()
        {
            mainForm = new MainForm();
            switch (GameRules.SizeOfGameBoard)
            {
                case 6:
                    mainForm.GameBoard.Image = WindowsFormsApp1.Properties.Resources._6x6board;
                    break;
                case 8:
                    mainForm.GameBoard.Image = WindowsFormsApp1.Properties.Resources._8x8board;
                    break;
                case 10:
                    mainForm.GameBoard.Image = WindowsFormsApp1.Properties.Resources._10x10board;
                    break;
            }
            mainForm.ClientSize = new Size(mainForm.GameBoard.Image.Width + 24, mainForm.GameBoard.Image.Height + 36 + this.playerOne.Height);
            mainForm.ShowDialog();
        }

        private void setGameRules()
        {
            Player playerOne = new Player
            {
                PlayerName = TextBoxPlayerOne.Text,
                TypeOfPiece = 0
            };
            GameRules.PlayerOne = playerOne;
            GameRules.GameIsOff = false;
            GameRules.IsPlayerOneGame = true;
            GameRules.SizeOfGameBoard = getSizeOfBoard();
            GameRules.AgainstPlayerTwo = TextBoxPlayerTwo.Enabled;
            if (GameRules.AgainstPlayerTwo)
            {
                Player playerTwo = new Player
                {
                    PlayerName = TextBoxPlayerTwo.Text,
                    TypeOfPiece = 1
                };
                GameRules.PlayerTwo = playerTwo;
            }
            else
            {
                Player playerTwo = new Player
                {
                    PlayerName = "Computer",
                    TypeOfPiece = 1,
                    //Score = PlayGame.ScoreOfPlayerTwo
                };
                GameRules.PlayerTwo = playerTwo;
            }
        }

        private int getSizeOfBoard()
        {
            int toReturn = 0;
            if (RadioButton6.Checked)
            {
                toReturn = 6;
            }

            else if (RadioButton8.Checked)
            {
                toReturn = 8;
            }

            else if (RadioButton10.Checked)
            {
                toReturn = 10;
            }
            return toReturn;
        }
    }
}
