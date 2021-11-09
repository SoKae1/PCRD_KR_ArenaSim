using System;
using System.Drawing;
using System.Windows.Forms;

namespace PCRD_KR_ArenaSim
{
    public partial class CaptureMask : Form
    {
        Pen pen = new Pen(Color.Red, 4);
        Rectangle rect;

        int mX = 0;
        int mY = 0;

        Boolean isHold = false;

        public CaptureMask()
        {
            InitializeComponent();

            this.Opacity = 0.73;



            //전체화면 설정 부분

            this.StartPosition = FormStartPosition.Manual;
            Rectangle fullScrenn_bounds = Rectangle.Empty;
            foreach (var screen in Screen.AllScreens)
            {
                fullScrenn_bounds = Rectangle.Union(fullScrenn_bounds, screen.Bounds);
            }
            this.ClientSize = new Size(fullScrenn_bounds.Width, fullScrenn_bounds.Height);
            this.Location = new Point(fullScrenn_bounds.Left, fullScrenn_bounds.Top);

            //전체화면 설정 부분


            Cursor = Cursors.Cross;
            this.Paint += new System.Windows.Forms.PaintEventHandler(Form2_Paint);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(Form2_MouseMove);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(Form2_MouseDown);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(Form2_MouseUp);
        }



        private void Form2_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(pen, rect);
        }



        private void Form2_MouseDown(object sender, MouseEventArgs e)
        {
            isHold = true;
            rect.Location = e.Location;
            mX = Cursor.Position.X;
            mY = Cursor.Position.Y;
        }



        private void Form2_MouseMove(object sender, MouseEventArgs e)
        {
            if (isHold)
            {
                int width = e.Location.X - rect.Location.X;
                int height = e.Location.Y - rect.Location.Y;

                rect.Width = Math.Abs(width);
                rect.Height = height;

                this.Invalidate();
            }
        }



        private void Form2_MouseUp(object sender, MouseEventArgs e)
        {
            isHold = false;
            this.Opacity = 0.001;

            int width = e.Location.X - rect.Location.X;
            int height = e.Location.Y - rect.Location.Y;

            rect.Width = width;
            rect.Height = height;

            MainWindow.mX = mX;
            MainWindow.mY = mY;

            MainWindow.mWidth = rect.Width;
            MainWindow.mHeigt = rect.Height;
            Close();
        }
    }
}
