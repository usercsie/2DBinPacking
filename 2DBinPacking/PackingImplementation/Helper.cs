using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DBinPacking
{
    public class Helper
    {
        public static bool IsOverlap(RectangleF r1, RectangleF r2)
        {
            RectangleF overlap = RectangleF.Intersect(r1, r2);
            if (overlap.Width == 0 ||
                overlap.Height == 0)
            {
                return false;
            }
            else
                return true;
        }

        public static bool IsFullyOverlap(RectangleF r1, RectangleF r2)
        {
            RectangleF overlap = RectangleF.Intersect(r1, r2);

            if (r1.Width * r1.Height < r2.Width * r2.Height)
            {
                return overlap.Width == r1.Width && overlap.Height == r1.Height;
            }
            else
            {
                return overlap.Width == r2.Width && overlap.Height == r2.Height;
            }
        }
    }
}
