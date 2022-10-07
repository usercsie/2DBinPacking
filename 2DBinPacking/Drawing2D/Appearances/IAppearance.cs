using _2DBinPacking.Drawing2D.Shape;
using _2DBinPacking.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2DBinPacking.Drawing2D.Appearances
{
    public interface IAppearance
    {
        IShape Shape { get; set; }

        void Paint(IDocument doc, PaintEventArgs e);
    }
}
