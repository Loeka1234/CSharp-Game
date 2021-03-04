using System.Collections.Generic;
using System.Drawing;

namespace Game
{
    internal abstract class GameSprite
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public int VelX { get; set; }
        public int VelY { get; set; }

        public const int DEFAULT_VELOCITY = 4;
        public const int DEFAULT_RADIUS = 35;

        /// <summary>
        /// GameSprite with custom X and Y positions
        /// </summary>
        /// <param name="XPos"></param>
        /// <param name="YPos"></param>
        /// <param name="rectangle"></param>
        public GameSprite(float XPos, float YPos)
        {
            SetDefaultValues();
            X = XPos;
            Y = YPos;
        }

        /// <summary>
        /// GameSprite with custom X and Y positions, custom Width and Height, custom Velocity
        /// </summary>
        /// <param name="XPos"></param>
        /// <param name="YPos"></param>
        /// <param name="customWidth"></param>
        /// <param name="customHeight"></param>
        /// <param name="customVelocityX"></param>
        /// <param name="customVelocityY"></param>
        /// <param name="rectangle"></param>
        public GameSprite(float XPos, float YPos, float customWidth, float customHeight, int customVelocityX, int customVelocityY)
        {
            SetDefaultValues();
            X = XPos;
            Y = YPos;
            Width = customWidth;
            Height = customHeight;
            VelX = customVelocityX;
            VelY = customVelocityY;
        }

        private void SetDefaultValues()
        {
            Width = DEFAULT_RADIUS;
            Height = DEFAULT_RADIUS;
            VelX = DEFAULT_VELOCITY;
            VelY = DEFAULT_VELOCITY;
        }

        /// <summary>
        /// Handles colision detecten on the X axis and returns true if collided
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public bool CollisionDetectionX(float left, float right)
        {
            bool collision = CollisionDetectionLeft(left);
            if (!collision) collision = CollisionDetectionRight(right);
            return collision;
        }

        /// <summary>
        /// Handles collision detection on the Y axis and returns true if collided
        /// </summary>
        /// <param name="top"></param>
        /// <param name="bottom"></param>
        /// <returns></returns>
        public bool CollisionDetectionY(float top, float bottom)
        {
            bool collision = CollisionDetectionTop(top);
            if (!collision) collision = CollisionDetectionBottom(bottom);
            return collision;
        }

        public bool CollisionDetectionTop(float top)
        {
            if (Y <= top)
            {
                VelY = -VelY;
                return true;
            }
            return false;
        }

        public bool CollisionDetectionBottom(float bottom)
        {
            if (Y + Height >= bottom)
            {
                VelY = -VelY;
                return true;
            }
            return false;
        }

        public bool CollisionDetectionLeft(float left)
        {
            if (X <= left)
            {
                VelX = -VelX;
                return true;
            }
            return false;
        }

        public bool CollisionDetectionRight(float right)
        {
            if (X + Width >= right)
            {
                VelX = -VelX;
                return true;
            }
            return false;
        }

        public void CollisionDetectionWithOtherSprite(GameSprite sprite)
        {
            KeyValuePair<float, float>[] points = new KeyValuePair<float, float>[]
            {
                new KeyValuePair<float, float>(X, Y),
                new KeyValuePair<float, float>(X, Y + Height),
                new KeyValuePair<float, float>(X + Width, Y),
                new KeyValuePair<float, float>(X + Width, Y + Height)
            };

            foreach (KeyValuePair<float, float> p in points)
            {
                float pointX = p.Key;
                float pointY = p.Value;

                if (pointX >= sprite.X && pointX < sprite.X + sprite.Width && pointY < sprite.Y)
                {
                    VelY = -VelY;
                    break;
                }
            }
        }

        public void Move()
        {
            X += VelX;
            Y += VelY;
        }

        public abstract void Draw(Graphics gfx);
    }
}