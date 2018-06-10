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
            boardSize = new Label();
            radioButton6 = new RadioButton();
            radioButton8 = new RadioButton();
            radioButton10 = new RadioButton();
            players = new Label();
            playerOne = new Label();
            TextBoxPlayerOne = new TextBox();
            TextBoxPlayerTwo = new TextBox();
            playerTwo = new CheckBox();
            buttonDone = new Button();
            SuspendLayout();
            boardSize.AutoSize = true;
            boardSize.Location = new System.Drawing.Point(31, 19);
            boardSize.Name = "boardSize";
            boardSize.Size = new System.Drawing.Size(58, 13);
            boardSize.TabIndex = 0;
            boardSize.Text = "Board Size";
            radioButton6.AutoSize = true;
            radioButton6.Checked = true;
            radioButton6.Location = new System.Drawing.Point(55, 41);
            radioButton6.Name = "radioButton6";
            radioButton6.Size = new System.Drawing.Size(48, 17);
            radioButton6.TabIndex = 1;
            radioButton6.TabStop = true;
            radioButton6.Text = "6 x 6";
            radioButton6.UseVisualStyleBackColor = true;
            radioButton8.AutoSize = true;
            radioButton8.Location = new System.Drawing.Point(147, 41);
            radioButton8.Name = "radioButton8";
            radioButton8.Size = new System.Drawing.Size(48, 17);
            radioButton8.TabIndex = 2;
            radioButton8.TabStop = true;
            radioButton8.Text = "8 x 8";
            radioButton8.UseVisualStyleBackColor = true;
            radioButton10.AutoSize = true;
            radioButton10.Location = new System.Drawing.Point(239, 41);
            radioButton10.Name = "radioButton10";
            radioButton10.Size = new System.Drawing.Size(60, 17);
            radioButton10.TabIndex = 3;
            radioButton10.TabStop = true;
            radioButton10.Text = "10 x 10";
            radioButton10.UseVisualStyleBackColor = true;
            players.AutoSize = true;
            players.Location = new System.Drawing.Point(31, 67);
            players.Name = "players";
            players.Size = new System.Drawing.Size(44, 13);
            players.TabIndex = 4;
            players.Text = "Players:";
            playerOne.AutoSize = true;
            playerOne.Location = new System.Drawing.Point(52, 94);
            playerOne.Name = "playerOne";
            playerOne.Size = new System.Drawing.Size(48, 13);
            playerOne.TabIndex = 5;
            playerOne.Text = "Player 1:";
            TextBoxPlayerOne.Location = new System.Drawing.Point(147, 91);
            TextBoxPlayerOne.Name = "textBoxPlayerOne";
            TextBoxPlayerOne.Size = new System.Drawing.Size(152, 20);
            TextBoxPlayerOne.TabIndex = 6;
            TextBoxPlayerTwo.Enabled = false;
            TextBoxPlayerTwo.Text = "Computer";
            TextBoxPlayerTwo.Location = new System.Drawing.Point(147, 135);
            TextBoxPlayerTwo.Name = "textBoxPlayerTwo";
            TextBoxPlayerTwo.Size = new System.Drawing.Size(152, 20);
            TextBoxPlayerTwo.TabIndex = 8;
            playerTwo.AutoSize = true;
            playerTwo.Location = new System.Drawing.Point(33, 135);
            playerTwo.Name = "playerTwo";
            playerTwo.Size = new System.Drawing.Size(67, 17);
            playerTwo.TabIndex = 9;
            playerTwo.Text = "Player 2:";
            playerTwo.UseVisualStyleBackColor = true;
            playerTwo.CheckedChanged += new System.EventHandler(this.playerTwo_CheckedChanged);
            buttonDone.Location = new System.Drawing.Point(222, 171);
            buttonDone.Name = "buttonDone";
            buttonDone.Size = new System.Drawing.Size(75, 23);
            buttonDone.TabIndex = 10;
            buttonDone.Text = "Done";
            buttonDone.UseVisualStyleBackColor = true;
            buttonDone.Click += new System.EventHandler(this.buttonDone_Click);
            ClientSize = new System.Drawing.Size(320, 210);
            Controls.Add(buttonDone);
            Controls.Add(TextBoxPlayerTwo);
            Controls.Add(playerTwo);
            Controls.Add(TextBoxPlayerOne);
            Controls.Add(playerOne);
            Controls.Add(players);
            Controls.Add(radioButton10);
            Controls.Add(radioButton8);
            Controls.Add(radioButton6);
            Controls.Add(boardSize);
            Name = "FormLogin";
            Text = "Damka - Start Game";
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            FormClosing += new FormClosingEventHandler(FormLogin_FormClosing);
            ResumeLayout(false);
            PerformLayout();
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
            if (e.CloseReason == CloseReason.ApplicationExitCall) return;
            
        }

        private void buttonDone_Click(object sender, EventArgs e)
        {
            if (TextBoxPlayerOne.Text == string.Empty)
            {
                MessageBox.Show("Please add a name for Player One");
            }
            else if (TextBoxPlayerTwo.Text == string.Empty)
            {
                MessageBox.Show("Please add a name for Player Two");
            }
            else
            {
                setGameRules();
                this.DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void setGameRules()
        {
            Player playerOne = new Player
            {
                PlayerName = TextBoxPlayerOne.Text,
                TypeOfPiece = 0,
                Score = PlayGame.ScoreOfPlayerOne
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
                    TypeOfPiece = 1,
                    Score = PlayGame.ScoreOfPlayerTwo
                };
                GameRules.PlayerTwo = playerTwo;
            }
            else
            {
                Player playerTwo = new Player
                {
                    PlayerName = "Computer",
                    TypeOfPiece = 1,
                    Score = PlayGame.ScoreOfPlayerTwo
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
