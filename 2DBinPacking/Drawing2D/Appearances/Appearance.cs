using _2DBinPacking.Drawing2D.Shape;
using _2DBinPacking.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2DBinPacking.Drawing2D.Appearances
{
    public class Appearance : IAppearance
    {
        private Pen _ActivePen = new Pen(Brushes.Black);
        private Font _Font = new Font(FontFamily.GenericSerif, 8);

        private IShape _Shape;
        public IShape Shape
        {
            get { return _Shape; }
            set { _Shape = value; }
        }

        public void Paint(IDocument doc, PaintEventArgs e)
        {
            if (IsValidGeometric(_Shape.Geometric) == false)
                return;

            float width = _Shape.Dimension.Width;
            float height = _Shape.Dimension.Height;

            if (width == 1)
                e.Graphics.DrawLine(_ActivePen, Point.Round(new PointF(_Shape.Location.X, _Shape.Location.Y)), Point.Round(new PointF(_Shape.Location.X, _Shape.Location.Y + _Shape.Dimension.Height)));
            else if (height == 1)
                e.Graphics.DrawLine(_ActivePen, Point.Round(new PointF(_Shape.Location.X, _Shape.Location.Y)), Point.Round(new PointF(_Shape.Location.X + _Shape.Dimension.Width, _Shape.Location.Y)));
            else
            {                
                e.Graphics.FillPath(Brushes.White, _Shape.Geometric);
                e.Graphics.DrawPath(_ActivePen, _Shape.Geometric);
            }
            //draw text
            if (string.IsNullOrEmpty(Shape.Text) == false)
            {
                e.Graphics.DrawString(Shape.Text, _Font, Brushes.Black, Shape.Center);
            }            
        }

        /// <summary>
        /// Checks if the geometric is valid (width and height not null).
        /// </summary>
        /// <param name="geometric">Path to check.</param>
        /// <returns></returns>
        protected bool IsValidGeometric(GraphicsPath geometric)
        {
            if (geometric.GetBounds().Size.Width == 0 || geometric.GetBounds().Size.Height == 0)
                return false;

            return true;
        }
    }
}
