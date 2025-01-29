namespace DrawingCircles
{
    public class Ball
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int VelocityX { get; set; }
        public int VelocityY { get; set; }
        public int Radius { get; }
        public int Diameter { get; }


        public Ball(int x, int y, int velocityX, int velocityY, int radius)
        {
            X = x;
            Y = y;
            VelocityX = velocityX;
            VelocityY = velocityY;
            Radius = radius;
            Diameter = 2 * radius;
        }

        public bool CollidesWith(Ball other)
        {
            int xSq = (other.X - X) * (other.X - X);
            int ySq = (other.Y - Y) * (other.Y - Y);
            int rSq = (other.Radius + Radius) * (other.Radius + Radius);

            return xSq + ySq <= rSq;
        }

        public void ReverseVelocity()
        {
            VelocityX = -VelocityX;
            VelocityY = -VelocityY;
        }
    }
}
