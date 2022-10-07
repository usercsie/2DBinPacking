using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DBinPacking
{
    public class RectDataCollection : Collection<RectData>
    {
        public int UnPlacedCount
        {
            get { return this.Where(v => v.Placed == false).Count(); }
        }

        public bool IsAllPlaced()
        {
            return this.Where(v => v.Placed == false).Count() == 0;
        }

        public void AddRange(RectData[] rects)
        {
            foreach(var r in rects)
            {
                this.Add(r);
            }
        }

        public void SetPadding(int width, int height)
        {
            foreach (var r in this)
            {
                RectangleF t = r.Rect;
                t.Width += width;
                t.Height += height;
                r.Rect = t;
            }
        }

        public void SetPadding(int index, int width, int height)
        {
            var r = this[index];
            RectangleF t = r.Rect;
            t.Width += width;
            t.Height += height;
            r.Rect = t;
        }

        public void Reset()
        {
            foreach(var r in this)
            {
                r.ShelfId = -1;
            }
        }
    }
}
