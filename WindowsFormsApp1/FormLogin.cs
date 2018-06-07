using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        public FormLogin()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.boardSize = new System.Windows.Forms.Label();
            this.radioButton6 = new System.Windows.Forms.RadioButton();
            this.radioButton8 = new System.Windows.Forms.RadioButton();
            this.radioButton10 = new System.Windows.Forms.RadioButton();
            this.players = new System.Windows.Forms.Label();
            this.playerOne = new System.Windows.Forms.Label();
            this.textBoxPlayerOne = new System.Windows.Forms.TextBox();
            this.textBoxPlayerTwo = new System.Windows.Forms.TextBox();
            this.playerTwo = new System.Windows.Forms.CheckBox();
            this.buttonDone = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // boardSize
            // 
            this.boardSize.AutoSize = true;
            this.boardSize.Location = new System.Drawing.Point(31, 19);
            this.boardSize.Name = "boardSize";
            this.boardSize.Size = new System.Drawing.Size(154, 32);
            this.boardSize.TabIndex = 0;
            this.boardSize.Text = "Board Size";
            this.boardSize.Click += new System.EventHandler(this.boardSize_Click);
            // 
            // radioButton6
            // 
            this.radioButton6.AutoSize = true;
            this.radioButton6.Checked = true;
            this.radioButton6.Location = new System.Drawing.Point(55, 41);
            this.radioButton6.Name = "radioButton6";
            this.radioButton6.Size = new System.Drawing.Size(112, 36);
            this.radioButton6.TabIndex = 1;
            this.radioButton6.TabStop = true;
            this.radioButton6.Text = "6 x 6";
            this.radioButton6.UseVisualStyleBackColor = true;
            this.radioButton6.CheckedChanged += new System.EventHandler(this.radioButton6_CheckedChanged);
            // 
            // radioButton8
            // 
            this.radioButton8.AutoSize = true;
            this.radioButton8.Location = new System.Drawing.Point(147, 41);
            this.radioButton8.Name = "radioButton8";
            this.radioButton8.Size = new System.Drawing.Size(112, 36);
            this.radioButton8.TabIndex = 2;
            this.radioButton8.TabStop = true;
            this.radioButton8.Text = "8 x 8";
            this.radioButton8.UseVisualStyleBackColor = true;
            this.radioButton8.CheckedChanged += new System.EventHandler(this.radioButton8_CheckedChanged);
            // 
            // radioButton10
            // 
            this.radioButton10.AutoSize = true;
            this.radioButton10.Location = new System.Drawing.Point(239, 41);
            this.radioButton10.Name = "radioButton10";
            this.radioButton10.Size = new System.Drawing.Size(144, 36);
            this.radioButton10.TabIndex = 3;
            this.radioButton10.TabStop = true;
            this.radioButton10.Text = "10 x 10";
            this.radioButton10.UseVisualStyleBackColor = true;
            this.radioButton10.CheckedChanged += new System.EventHandler(this.radioButton10_CheckedChanged);
            // 
            // players
            // 
            this.players.AutoSize = true;
            this.players.Location = new System.Drawing.Point(31, 67);
            this.players.Name = "players";
            this.players.Size = new System.Drawing.Size(118, 32);
            this.players.TabIndex = 4;
            this.players.Text = "Players:";
            // 
            // playerOne
            // 
            this.playerOne.AutoSize = true;
            this.playerOne.Location = new System.Drawing.Point(52, 94);
            this.playerOne.Name = "playerOne";
            this.playerOne.Size = new System.Drawing.Size(127, 32);
            this.playerOne.TabIndex = 5;
            this.playerOne.Text = "Player 1:";
            this.playerOne.Click += new System.EventHandler(this.playerOne_Click);
            // 
            // textBoxPlayerOne
            // 
            this.textBoxPlayerOne.Location = new System.Drawing.Point(147, 91);
            this.textBoxPlayerOne.Name = "textBoxPlayerOne";
            this.textBoxPlayerOne.Size = new System.Drawing.Size(152, 38);
            this.textBoxPlayerOne.TabIndex = 6;
            this.textBoxPlayerOne.TextChanged += new System.EventHandler(this.textBoxPlayerOne_TextChanged);
            // 
            // textBoxPlayerTwo
            // 
            this.textBoxPlayerTwo.Enabled = false;
            this.textBoxPlayerTwo.Location = new System.Drawing.Point(147, 135);
            this.textBoxPlayerTwo.Name = "textBoxPlayerTwo";
            this.textBoxPlayerTwo.Size = new System.Drawing.Size(152, 38);
            this.textBoxPlayerTwo.TabIndex = 8;
            this.textBoxPlayerTwo.TextChanged += new System.EventHandler(this.textBoxPlayerTwo_TextChanged);
            // 
            // playerTwo
            // 
            this.playerTwo.AutoSize = true;
            this.playerTwo.Location = new System.Drawing.Point(33, 135);
            this.playerTwo.Name = "playerTwo";
            this.playerTwo.Size = new System.Drawing.Size(165, 36);
            this.playerTwo.TabIndex = 9;
            this.playerTwo.Text = "Player 2:";
            this.playerTwo.UseVisualStyleBackColor = true;
            this.playerTwo.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
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
            this.Controls.Add(this.textBoxPlayerTwo);
            this.Controls.Add(this.playerTwo);
            this.Controls.Add(this.textBoxPlayerOne);
            this.Controls.Add(this.playerOne);
            this.Controls.Add(this.players);
            this.Controls.Add(this.radioButton10);
            this.Controls.Add(this.radioButton8);
            this.Controls.Add(this.radioButton6);
            this.Controls.Add(this.boardSize);
            this.Name = "FormLogin";
            this.Text = "Damka - Start Game";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void boardSize_Click(object sender, EventArgs e)
        {

        }

        private void radioButton10_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void playerOne_Click(object sender, EventArgs e)
        {

        }

        private void textBoxPlayerOne_TextChanged(object sender, EventArgs e)
        {

        }

        private void playerTwo_Click(object sender, EventArgs e)
        {

        }

        private void textBoxPlayerTwo_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void buttonDone_Click(object sender, EventArgs e)
        {

        }
    }
}
