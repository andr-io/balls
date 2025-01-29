using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace DrawingCircles
{
    public partial class Form1 : Form
    {
        private const int SPEED_MULTIPLIER = 7;

        // Ball 1 Config
        private const int BALL_1_STARTING_VELOCITY_X = 1 * SPEED_MULTIPLIER;
        private const int BALL_1_STARTING_VELOCITY_Y = 1 * SPEED_MULTIPLIER;
        private const int BALL_1_RADIUS = 40;

        // Ball 2 center offsets from bottom right corner
        private const int BALL_1_START_OFFSET_X = BALL_1_RADIUS + 5;
        private const int BALL_1_START_OFFSET_Y = BALL_1_RADIUS + 5;

        // Ball 2 Config
        private const int BALL_2_STARTING_VELOCITY_X = - 1 * SPEED_MULTIPLIER;
        private const int BALL_2_STARTING_VELOCITY_Y = - 1 * SPEED_MULTIPLIER;
        private const int BALL_2_RADIUS = 30;

        // Ball 2 center offsets from bottom right corner
        private const int BALL_2_START_OFFSET_X = - 2 * BALL_2_RADIUS - 5;
        private const int BALL_2_START_OFFSET_Y = -2 *  BALL_2_RADIUS - 5;

        // Ball 3 Config
        private const int BALL_3_STARTING_VELOCITY_X = -1 * SPEED_MULTIPLIER;
        private const int BALL_3_STARTING_VELOCITY_Y = -1 * SPEED_MULTIPLIER;
        private const int BALL_3_RADIUS = 15;

        // Ball 3 center offsets from bottom left corner
        private const int BALL_3_START_OFFSET_X = 2 * BALL_3_RADIUS + 5;
        private const int BALL_3_START_OFFSET_Y = -2 * BALL_2_RADIUS - 5;

        // Collision Message
        private const string COLLISION_MESSAGE = "BOOM!";
        private const int COLLISION_MESSAGE_FONT_SIZE = 32;

        private Ball ball1;
        private Ball ball2;
        private Ball ball3;

        private bool ballsHaveCollided = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            timerForDrawingCircles.Start();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            timerForDrawingCircles.Stop();
        }

        private void timerForDrawingCircles_Tick(object sender, EventArgs e)
        {
            updateBall(ball1);
            updateBall(ball2);
            updateBall(ball3);

            checkForCollisions();

            if (ballsHaveCollided)
            {
                timerForDrawingCircles.Stop();
            }

            pictureBox.Invalidate();
        }

        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            // Graphics
            Graphics gfx = e.Graphics;
            gfx.SmoothingMode = SmoothingMode.HighQuality;

            // Choose brushes
            SolidBrush green = new SolidBrush(Color.DarkGreen);
            SolidBrush gray = new SolidBrush(Color.DarkSlateGray);
            SolidBrush cyan = new SolidBrush(Color.DarkCyan);

            // Calculate drawing coordinates for ball 1
            int ball1EllipseX = ball1.X - ball1.Radius;
            int ball1EllipseY = ball1.Y - ball1.Radius;

            // Calculate drawing coordinates for ball 2
            int ball2EllipseX = ball2.X - ball2.Radius;
            int ball2EllipseY = ball2.Y - ball2.Radius;

            // Calculate drawing coordinates for ball 3
            int ball3EllipseX = ball3.X - ball3.Radius;
            int ball3EllipseY = ball3.Y - ball3.Radius;

            // Draw circles
            gfx.FillEllipse(green, ball1EllipseX, ball1EllipseY, ball1.Diameter, ball1.Diameter);
            gfx.FillEllipse(gray, ball2EllipseX, ball2EllipseY, ball2.Diameter, ball2.Diameter);
            gfx.FillEllipse(cyan, ball3EllipseX, ball3EllipseY, ball3.Diameter, ball3.Diameter);

            // Draw collision message if nessesary
            if (ballsHaveCollided)
            {
                Font font = new Font("Arial", COLLISION_MESSAGE_FONT_SIZE);

                gfx.DrawString(
                    COLLISION_MESSAGE,
                    font,
                    Brushes.Red,
                    new Point(pictureBox.Width / 2, pictureBox.Height / 2)
                );

                // Clean message resources
                font.Dispose();
            }

            // Clean resources
            green.Dispose();
            gray.Dispose();
            cyan.Dispose();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Start timer
            timerForDrawingCircles.Enabled = true;

            // Initialize first ball
            int ball1X = BALL_1_START_OFFSET_X;
            int ball1Y = BALL_1_START_OFFSET_Y;

            // Ball(x, y, velocityX, velocityY, diameter)
            ball1 = new Ball(
                ball1X, 
                ball1Y, 
                BALL_1_STARTING_VELOCITY_X, 
                BALL_1_STARTING_VELOCITY_Y, 
                BALL_1_RADIUS
            );


            // Initialize second ball
            int ball2X = pictureBox.Width + BALL_2_START_OFFSET_X;
            int ball2Y = pictureBox.Height + BALL_2_START_OFFSET_Y;

            ball2 = new Ball(
                ball2X,
                ball2Y,
                BALL_2_STARTING_VELOCITY_X,
                BALL_2_STARTING_VELOCITY_Y,
                BALL_2_RADIUS
            );

            // Initialize third ball
            int ball3X = BALL_3_START_OFFSET_X;
            int ball3Y = pictureBox.Height + BALL_3_START_OFFSET_Y;

            ball3 = new Ball(
                ball3X,
                ball3Y,
                BALL_3_STARTING_VELOCITY_X,
                BALL_3_STARTING_VELOCITY_Y,
                BALL_3_RADIUS
            );
        }

        private void updateBall(Ball ball)
        {
            ball.X += ball.VelocityX;
            ball.Y += ball.VelocityY;
            reflectOnHit(ball);
        }

        private void reflectOnHit(Ball ball)
        {
            // Check if the ball hits the left boundary
            if (ball.X - ball.Radius < 0)
            {
                ball.VelocityX = -ball.VelocityX;
                ball.X = ball.Radius;
            }

            // Check if the ball hits the right boundary
            if (ball.X + ball.Radius > pictureBox.Width)
            {
                ball.VelocityX = -ball.VelocityX;
                ball.X = pictureBox.Width - ball.Radius;
            }

            // Check if the ball hits the top boundary
            if (ball.Y - ball.Radius < 0)
            {
                ball.VelocityY = -ball.VelocityY;
                ball.Y = ball.Radius;
            }

            // Check if the ball hits the bottom boundary
            if (ball.Y + ball.Radius > pictureBox.Height)
            {
                ball.VelocityY = -ball.VelocityY;
                ball.Y = pictureBox.Height - ball.Radius;
            }
        }

        private bool checkForCollisions()
        {
            ballsHaveCollided = false;

            if (ball1.CollidesWith(ball2))
            {
                ball1.ReverseVelocity();
                ball2.ReverseVelocity();
                ballsHaveCollided = true;
            }

            if (ball1.CollidesWith(ball3))
            {
                ball1.ReverseVelocity();
                ball3.ReverseVelocity();
                ballsHaveCollided = true;
            }

            if (ball2.CollidesWith(ball3))
            {
                ball2.ReverseVelocity();
                ball3.ReverseVelocity();
                ballsHaveCollided = true;
            }

            return ballsHaveCollided;
        }

    }
}
