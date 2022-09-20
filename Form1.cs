using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComGraph_Lab_2
{
    public partial class Form1 : Form
    {
        Pen pen = new Pen(Color.Black, 4);
        public Form1()
        {
            InitializeComponent();
        }

        private void formPaint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            paintNotebook(g, 50, 50, 300);
        }
        private void paintNotebook(Graphics g, float x, float y, float width)
        {
            SolidBrush B = new SolidBrush(Color.White);
            Pen p = new Pen(Color.Black, (float)(Math.Floor(width / 300f)));

            float logoWidth = width / 3f;

            g.FillRectangle(B, x, y, width, width * 1.5f);
            g.DrawRectangle(p, x, y, width, width * 1.5f);

            float clipStep = width / 30f;
            p = new Pen(Color.Gray, (float)(Math.Floor(width / 300f)));
            p.DashPattern = new float[] { clipStep, clipStep };

            g.DrawLine(p, x + clipStep, y + clipStep, x + clipStep, y + width * 1.5f - clipStep);
            g.DrawLine(p, x + 2 * clipStep, y + clipStep, x + 2 * clipStep, y + width * 1.5f - clipStep);


            paintTPULogo(g, x + logoWidth, y + 1.5f * logoWidth, logoWidth);

            float textX = x + 0.2f * width;
            float textY = x + 2.7f * logoWidth;

            float firstTextSize = width * 13 / 300f;
            float secondTextSize = width * 5.2f / 300f;
            float textLinesPadding = width * 50 / 300f;

            g.DrawString(" Инженерная школа\nядерных технологий", new Font("Arial Font", firstTextSize), new SolidBrush(Color.Black), new PointF(textX, textY));

            g.DrawString("ТОМСКИЙ ПОЛИТЕХНИЧЕСКИЙ УНИВЕРСИТЕТ", new Font("Arial Font", secondTextSize), new SolidBrush(Color.Black), new PointF(textX, textY + textLinesPadding));
        }
        private void paintTPULogo(Graphics g, float x, float y, float width)
        {
            float padding = width * 15 / 330f;
            float smallCubeSide = (width - 2 * padding) / 3f;
            float bigCubeSide = smallCubeSide * 2 + padding;


            SolidBrush bGreen = new SolidBrush(Color.Green);
            SolidBrush bBlack = new SolidBrush(Color.Black);
            SolidBrush bRed = new SolidBrush(Color.Red);
            Pen pWhite = new Pen(Color.White, (float)(Math.Floor(width / 110)));
            SolidBrush bWhite = new SolidBrush(Color.White);

            g.FillRectangle(bGreen, x, y, smallCubeSide, smallCubeSide);
            g.FillRectangle(bGreen, x + smallCubeSide + padding, y, smallCubeSide, bigCubeSide);
            g.FillRectangle(bGreen, x + 2 * smallCubeSide + 2 * padding, y, smallCubeSide, smallCubeSide);

            g.FillRectangle(bBlack, x, y + smallCubeSide + padding, smallCubeSide, bigCubeSide);
            g.FillRectangle(bBlack, x + 2 * smallCubeSide + 2 * padding, y + smallCubeSide + padding, smallCubeSide, bigCubeSide);

            g.FillRectangle(bRed, x + smallCubeSide + padding, y + bigCubeSide + padding, smallCubeSide, smallCubeSide);

            float D = 0.8f * smallCubeSide;
            float d = 0.4f * smallCubeSide;

            float ellX = x + smallCubeSide + padding + 0.5f * (smallCubeSide - D);
            float ellY = y + bigCubeSide + padding + 0.5f * (smallCubeSide - d);

            float xc = ellX + D / 2f;
            float yc = ellY + d / 2f;

            g.DrawEllipse(pWhite, ellX, ellY, D, d);

            g.TranslateTransform(xc, yc);
            g.RotateTransform(60.0F);
            g.TranslateTransform(-xc, -yc);

            g.DrawEllipse(pWhite, ellX, ellY, D, d);

            g.TranslateTransform(xc, yc);
            g.RotateTransform(60.0F);
            g.TranslateTransform(-xc, -yc);

            g.DrawEllipse( pWhite, ellX, ellY, D, d);


            g.TranslateTransform(xc, yc);
            g.RotateTransform(-120.0F);
            g.TranslateTransform(-xc, -yc);

            float r = smallCubeSide / 4f;
            g.FillEllipse(bWhite, xc - r/2f, yc - r/2f, r, r);
        }
    }
}
