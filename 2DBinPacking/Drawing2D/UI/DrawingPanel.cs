using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _2DBinPacking.Drawing2D.Shape;

namespace _2DBinPacking.UI
{
    public partial class DrawingPanel : UserControl, IDocument
    {
        private ShapeCollection _Shapes = new ShapeCollection();

        public ShapeCollection Shapes
        {
            get
            {
                return _Shapes;
            }
        }

        public Control DrawingControl
        {
            get
            {
                return this;
            }
        }

        public DrawingPanel()
        {
            InitializeComponent();
        }

        
        protected override void OnPaint(PaintEventArgs e)
        {          
            foreach(var shape in Shapes)
            {
                shape.Paint(this, e);
            }
        }
    }
}
