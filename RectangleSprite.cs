using System.Drawing;

namespace Game
{
    internal class RectangleSprite : GameSprite
    {
        public RectangleSprite(float XPos, float YPos, float customWidth, float customHeight, int customVelocityX, int customVelocityY)
            : base(XPos, YPos, customWidth, customHeight, customVelocityX, customVelocityY) { }

        public override void Draw(Graphics gfx)
        {
            SolidBrush br = new SolidBrush(Color.Red);
            gfx.FillRectangle(br, X, Y, Width, Height);
        }
    }
}