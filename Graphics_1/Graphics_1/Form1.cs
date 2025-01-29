using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace Graphics_1
{
    public partial class Form1 : Form
    {
        // Arcs
        private const int NUMBER_OF_CURVES = 5; // Number of curved lines to be drawn
        private const int LINE_WIDTH = 10;
        private const int PADDING_Y = 5;

        // Rectangle on which the arcs are bounded 
        private const int RECT_HEIGHT = 200; // Drawing Rectangle's height
        private const int RECT_WIDTH = 200;  // Drawing Rectangle's width
        private const int RECT_STEP = RECT_WIDTH / NUMBER_OF_CURVES; // The number of pixels that the width of the rectangle must be reduced for next line

        // Panel graphics'
        private Graphics gfx;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            gfx.Clear(panel.BackColor);
            pbSpinner.Image = null;
        }

        private void btnFigure_Click(object sender, EventArgs e)
        {
            Pen red = new Pen(Color.Red, LINE_WIDTH);
            Pen blue = new Pen(Color.Blue, LINE_WIDTH);

            for (int i = 0; i < NUMBER_OF_CURVES; i++)
            {
                Rectangle rect = new Rectangle(
                    (RECT_WIDTH + i*RECT_STEP) / 2, 
                    PADDING_Y + i*LINE_WIDTH, 
                    RECT_WIDTH - i*RECT_STEP, 
                    RECT_HEIGHT
                );

                // Alternate between red and blue color
                Pen pen = i % 2 == 0 ? blue : red;
                gfx.DrawArc(pen, rect, 180, 180);
            }

            // Clean resources
            red.Dispose();
            blue.Dispose();
        }

        private void btnMedia_Click(object sender, EventArgs e)
        {
            Stream stream = GetType().Assembly.GetManifestResourceStream("Graphics_1.animatedCircle.gif");
            Image image = Image.FromStream(stream);

            pbSpinner.Image = image;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            gfx = panel.CreateGraphics();
            gfx.SmoothingMode = SmoothingMode.AntiAlias; // For better quality curves
        }

    }
}
