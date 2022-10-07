using _2DBinPacking.Drawing2D.Shape;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2DBinPacking.UI
{
    public interface IDocument
    {
        Control DrawingControl { get; }

        ShapeCollection Shapes { get; }

        int Width { get; }
        int Height { get; }
    }
}
