using System;
using System.Threading;
using System.Windows.Forms;

using Colors = System.Drawing.Color;

namespace Random
{
	public partial class Form1 : Form
    {
        public bool IsComputerMove;
        private bool _matchStarted;

        private readonly Move _playerMove = new Move();

        private Move _aiMove;

		public Form1()
		{
			InitializeComponent();

			Program.Form = this;
			P1Timer.Text = "00:00:00";
			P2Timer.Text = "00:00:00";

			P1Timer.ForeColor = Colors.Green;
			P2Timer.ForeColor = Colors.Black;

			timer1.Interval = 50;
		}

        private void button_Click(object sender, EventArgs e)
		{
            if (!this._matchStarted || this.IsComputerMove)
            {
                return;
            }

            if (!this.CheckAndPerform(sender))
            {
                return;
            }

            this.IsComputerMove = true;

            var computerThreadStart = new ThreadStart(Program.AiMove);
            computerThreadStart += SwitchTimerColors;

            var computerThread = new Thread(computerThreadStart);
            computerThread.Start();
        }

		private void SwitchTimerColors()
		{
            if (Program.CurrentColorMove == Color.White)
            {
                P1Timer.ForeColor = Colors.Green;
                P2Timer.ForeColor = Colors.Black;
            }
            else
            {
                P1Timer.ForeColor = Colors.Black;
                P2Timer.ForeColor = Colors.Green;
            }
        }

		public void HighlightAiPieces(Move move)
        {
            this.DeselectAllButtons();
            _playerMove.StartingPosition = null;
            _playerMove.EndPosition = null;

            this._aiMove = move;

            var startingButton = this.GetButtonFromPosition(move.StartingPosition);
            var endButton = this.GetButtonFromPosition(move.EndPosition);
            if (startingButton == null || endButton == null)
            {
                return;
            }

            this.ColorSwitch(move.StartingPosition, true);
            this.ColorSwitch(move.EndPosition, true);

            endButton.BackgroundImage = startingButton.BackgroundImage;
            startingButton.BackgroundImage = null;
        }

		private bool CheckAndPerform(object sender)
		{
            if (!(sender is Button clickedButton))
            {
                return false;
            }

            var buttonX = int.Parse(clickedButton.Name[clickedButton.Name.Length - 1].ToString());
            var buttonY = int.Parse(clickedButton.Name[clickedButton.Name.Length - 2].ToString());

            this.DeselectAllButtons();

            var isCorrectType = Program.IsCorrectType(buttonX, buttonY);
            if (isCorrectType)
            {
                this._playerMove.StartingPosition = new Position(buttonX, buttonY);

                this.ColorSwitch(this._playerMove.StartingPosition, true);

                return false;
            }

            if (this._playerMove.StartingPosition == null)
            {
                return false;
            }

            this._playerMove.EndPosition = new Position(buttonX, buttonY);
            if (!Program.IsValidMove(this._playerMove))
            {
                return false;
            }

            if (this._aiMove != null)
            {
                this.ColorSwitch(new Position(_aiMove.StartX, _aiMove.StartY), false);
                this.ColorSwitch(new Position(_aiMove.EndX, _aiMove.EndY), false);
            }
            
            this.ColorSwitch(this._playerMove.StartingPosition, true);
            this.ColorSwitch(this._playerMove.EndPosition, true);

            var startingButton = this.GetButtonFromPosition(this._playerMove.StartingPosition);

            clickedButton.BackgroundImage = startingButton.BackgroundImage;
            startingButton.BackgroundImage = null;

            Program.CurrentColorMove = Color.Black;

            return true;
        }

        private void DeselectAllButtons()
        {
            if (this._playerMove.StartingPosition != null)
            {
                this.ColorSwitch(this._playerMove.StartingPosition, false);
            }

            if (this._playerMove.EndPosition != null)
            {
                this.ColorSwitch(this._playerMove.EndPosition, false);
            }
        }

		private void ColorSwitch(Position position, bool selected)
        {
            var button = this.GetButtonFromPosition(position);
            if (button == null)
            {
                return;
            }

            var color = button.BackColor;
			if (selected)
			{
				if (color == Colors.Sienna)
				{
					button.BackColor = Colors.OliveDrab;
					button.ForeColor = Colors.OliveDrab;
				}
				else if (color == Colors.NavajoWhite)
				{
					button.BackColor = Colors.YellowGreen;
					button.ForeColor = Colors.YellowGreen;
				}
			}
			else
			{
				if (color == Colors.OliveDrab)
				{
					button.BackColor = Colors.Sienna;
					button.ForeColor = Colors.Sienna;
				}
				else if (color == Colors.YellowGreen)
				{
					button.BackColor = Colors.NavajoWhite;
					button.ForeColor = Colors.NavajoWhite;
				}
			}
		}

        private Button GetButtonFromPosition(Position position)
        {
            return this.Controls.Find($"Button{position.Y}{position.X}", true)[0] as Button;
        }

		private void timer1_Tick(object sender, EventArgs e)
		{
			var timer = (System.Windows.Forms.Timer)sender;
            if (!(timer.Tag is string tag))
            {
                return;
            }

            var values = tag.Split(',');
            if (Program.CurrentColorMove == Color.White)
            {
                var val = float.Parse(values[0]) + 0.056f;
                P1Timer.Text = TimeSpan.FromSeconds((int)val).ToString("hh':'mm':'ss");
                timer.Tag = $"{val.ToString()},{values[1]}";
            }
            else
            {
                var val = float.Parse(values[1]) + 0.056f;
                P2Timer.Text = TimeSpan.FromSeconds((int)val).ToString("hh':'mm':'ss");
                timer.Tag = $"{values[0]},{val.ToString()}";
            }
        }

		private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Application.Restart();
		}

		private void vsComp_Click(object sender, EventArgs e)
		{
            this._matchStarted = true;
            timer1.Enabled = true;

            this.DisableButtons();
        }

		private void set_Difficulty(object sender, EventArgs e)
		{
            if (sender is ToolStripMenuItem t)
			{
				Program.Difficulty = int.Parse(t.Text);
				Difficulty.Text = "Difficulty: " + Program.Difficulty;
			}
		}

        private void DisableButtons()
        {
            VsComp.Visible = false;
            TwoPlayer.Visible = false;
        }
        
        private void twoPlayer_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
