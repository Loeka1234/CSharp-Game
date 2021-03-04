using System;
using System.Drawing;
using System.Windows.Forms;

namespace Game
{
    public partial class Form1 : Form
    {
        private Timer graphicsTimer;
        private GameLoop gameLoop;

        public Form1()
        {
            InitializeComponent();

            DoubleBuffered = true;

            Paint += Form1_Paint;
            // Initialize graphicsTimer
            graphicsTimer = new Timer();
            graphicsTimer.Interval = 1000 / 120;
            graphicsTimer.Tick += GraphicsTimer_Tick;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Initialize Game
            Game myGame = new Game(new Size(ClientRectangle.Width, ClientRectangle.Height));

            KeyDown += myGame.KeyDownEvent;
            KeyUp += myGame.KeyUpEvent;

            // Initialize & Start GameLoop
            gameLoop = new GameLoop();
            gameLoop.Load(myGame);
            gameLoop.Start();

            // Start Graphics Timer
            graphicsTimer.Start();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            // Draw game graphics on Form1
            gameLoop.Draw(e.Graphics);
        }

        private void GraphicsTimer_Tick(object sender, EventArgs e)
        {
            // Refresh Form1 graphics
            Invalidate();
        }
    }
}