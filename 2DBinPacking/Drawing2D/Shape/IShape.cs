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
    public interface IShape
    {
        string Text { get; set; }
        PointF Location { get;}
        SizeF Dimension { get;}
        PointF Center { get; }

        GraphicsPath Geometric { get; }

        void Paint(IDocument document, PaintEventArgs e);
    }    
}
