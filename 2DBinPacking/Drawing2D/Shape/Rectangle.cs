using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DBinPacking.Drawing2D.Shape
{
    public class Rectangle : Shape
    {        
        public Rectangle()
        {
            Geometric.AddRectangle(new System.Drawing.Rectangle(0, 0, 1, 1));
        }

        public Rectangle(int left, int top, int width, int height)
        {
            Geometric.AddRectangle(new System.Drawing.Rectangle(left, top, width, height));            
        }

        public Rectangle(string text, int left, int top, int width, int height)
            :this(left, top, width, height)
        {
            Text = text;
        }
    }
}
