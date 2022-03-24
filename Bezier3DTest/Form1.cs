using HelixToolkit.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace Bezier3DTest
{
    public partial class Form1 : Form
    {
        public UserControl1 render = new UserControl1();

        public Form1()
        {
            InitializeComponent();

            elementHost1.Child = render;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Quadratic
            List<Point3D> BezierTwoPoint = new List<Point3D>();
            BezierTwoPoint.Add(new Point3D(-5, 0, 10));
            BezierTwoPoint.Add(new Point3D(0, 10, 15));
            BezierTwoPoint.Add(new Point3D(5, 0, 10));

            HTK_3DES.PathTools.DrawPath_Line(render, BezierTwoPoint, 0.9, Colors.Green);

            var B2 = HTK_3DES.PathTools.BezierCurve3DP2.RenderQuadraticBezierCurve(BezierTwoPoint[0], BezierTwoPoint[1], BezierTwoPoint[2], 1);

            HTK_3DES.PathTools.DrawPath_Line(render, B2, 0.9, Colors.Red);



            //Cubic (De Casteljau's Algorithm)
            List<Point3D> BezierCubic = new List<Point3D>();
            BezierCubic.Add(new Point3D(-10, 0, -10));
            BezierCubic.Add(new Point3D(0, 6, -19));
            BezierCubic.Add(new Point3D(5, 3, -13));
            BezierCubic.Add(new Point3D(10, 0, -16));

            HTK_3DES.PathTools.DrawPath_Line(render, BezierCubic, 0.9, Colors.Orange);

            var B3 = HTK_3DES.PathTools.BezierCurve3DP2.RenderCubicBezierCurve(BezierCubic[0], BezierCubic[1], BezierCubic[2], BezierCubic[3], 1);

            HTK_3DES.PathTools.DrawPath_Line(render, B3, 0.9, Colors.Magenta);



            //N-Order Bezier
            List<Point3D> BezierNOrder = new List<Point3D>();
            BezierNOrder.Add(new Point3D(-10, 0, -7));
            BezierNOrder.Add(new Point3D(0, 6, 2));
            BezierNOrder.Add(new Point3D(5, 3, -4));
            BezierNOrder.Add(new Point3D(10, 0, -1));
            BezierNOrder.Add(new Point3D(5, -5, 1));
            BezierNOrder.Add(new Point3D(0, -5, 3));
            BezierNOrder.Add(new Point3D(-10, -5, -1));

            HTK_3DES.PathTools.DrawPath_Line(render, BezierNOrder, 0.9, Colors.DeepPink);

            var B4 = HTK_3DES.PathTools.BezierCurve3DP2.RenderN_OrderBezierCurve(BezierNOrder, 1);

            HTK_3DES.PathTools.DrawPath_Line(render, B4, 0.9, Colors.SlateBlue);
        }
    }
}
