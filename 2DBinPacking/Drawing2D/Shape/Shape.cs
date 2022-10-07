using _2DBinPacking.Drawing2D.Appearances;
using _2DBinPacking.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2DBinPacking.Drawing2D.Shape
{
    public class Shape : IShape
    {
        private IAppearance _Appearance = new Appearances.Appearance();

        private GraphicsPath _Geometric = new GraphicsPath();

        private string _Text;
        public string Text
        {
            get { return _Text; }
            set { _Text = value; }
        }

        public GraphicsPath Geometric
        {
            get
            {
                return _Geometric;
            }
        }

        public PointF Center
        {
            get
            {
                float x = this.Location.X + this.Dimension.Width / 2f;
                float y = this.Location.Y + this.Dimension.Height / 2f;

                return new PointF(x, y);
            }
        }

        public SizeF Dimension
        {
            get { return _Geometric.GetBounds().Size; }
        }

        public PointF Location
        {
            get { return _Geometric.GetBounds().Location; }
        }

        public virtual void Paint(IDocument doc, PaintEventArgs e)
        {
            _Appearance.Shape = this;
            _Appearance.Paint(doc, e);
        }
    }
}
