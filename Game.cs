using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Game
{
    internal class Game
    {
        private BallSprite ballSprite;
        private RectangleSprite playerSprite;

        public Size Resolution { get; set; }

        private readonly int LeftBorder;
        private readonly int RightBorder;
        private readonly int TopBorder;
        private readonly int BottomBorder;

        public Game(Size resolution)
        {
            Resolution = resolution;

            LeftBorder = 0;
            RightBorder = Resolution.Width;
            TopBorder = 0;
            BottomBorder = Resolution.Height;
        }

        public void Load()
        {
            ballSprite = new BallSprite(100, 100);

            float playerWidth = 90;
            float playerHeight = 10;
            playerSprite = new RectangleSprite(RightBorder / 2 + playerWidth / 2, BottomBorder - playerHeight, playerWidth, playerHeight, 0, 0);
        }

        public void Unload()
        {
            // Unload graphics
            // Turn off game music
        }

        public void Update(TimeSpan gameTime)
        {
            ballSprite.CollisionDetectionX(LeftBorder, RightBorder);
            ballSprite.CollisionDetectionTop(TopBorder);
            BallWithPlayerCollision();

            ballSprite.Move();
            playerSprite.Move();
        }

        public void BallWithPlayerCollision()
        {
            KeyValuePair<float, float>[] points = new KeyValuePair<float, float>[]
            {
                new KeyValuePair<float, float>(ballSprite.X, ballSprite.Y + ballSprite.Height),
                new KeyValuePair<float, float>(ballSprite.X + ballSprite.Width, ballSprite.Y + ballSprite.Height)
            };

            foreach (KeyValuePair<float, float> p in points)
            {
                float pointX = p.Key;
                float pointY = p.Value;

                if (pointX >= playerSprite.X && pointX < playerSprite.X + playerSprite.Width && pointY > playerSprite.Y)
                {
                    ballSprite.VelY = -ballSprite.VelY;
                    break;
                }
            }
        }

        public void Draw(Graphics gfx)
        {
            // Draw Background Color
            gfx.FillRectangle(new SolidBrush(Color.CornflowerBlue), new Rectangle(0, 0, Resolution.Width, Resolution.Height));

            // Draw Player Sprite
            ballSprite.Draw(gfx);
            playerSprite.Draw(gfx);
        }

        public void KeyDownEvent(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
                playerSprite.VelX = -10;
            if (e.KeyCode == Keys.Right)
                playerSprite.VelX = 10;
        }

        public void KeyUpEvent(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
                playerSprite.VelX = 0;
        }
    }
}