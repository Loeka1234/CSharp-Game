using System.Drawing;

namespace Game
{
    internal class BallSprite : GameSprite
    {
        public BallSprite(float XPos, float YPos) : base(XPos, YPos)
        {
        }

        public override void Draw(Graphics gfx)
        {
            SolidBrush br = new SolidBrush(Color.Red);
            gfx.FillEllipse(br, X, Y, Width, Height);
        }
    }
}