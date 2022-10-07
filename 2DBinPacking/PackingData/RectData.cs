using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DBinPacking
{
    public class RectData : ICloneable
    {
        private string _Key;
        private RectangleF _Rect;
        private int _ShelfId;

        public RectData(string key, float width, float height)
            :this(key, new RectangleF(0, 0, width, height))
        {
        }

        public RectData(string key, RectangleF rect)
        {
            _Key = key;
            _Rect = rect;
            _ShelfId = -1;
        }

        private RectData(RectData right)
        {
            _Key = right.Key;
            _Rect = right.Rect;
            _ShelfId = right.ShelfId;
        }

        public string Key
        {
            get
            {
                return _Key;
            }

            set
            {
                _Key = value;
            }
        }

        [Browsable(false)]
        public RectangleF Rect
        {
            get { return _Rect; }
            set { _Rect = value; }
        }

        //in order to display on datagridview.
        public float Left { get { return _Rect.Left; } }
        public float Top { get { return _Rect.Top; } }
        public float Width { get { return _Rect.Width; } }        
        public float Height { get { return _Rect.Height; } }

        public bool Placed
        {
            get { return _ShelfId >= 0; }
        }

        public int ShelfId
        {
            get { return _ShelfId; }
            set { _ShelfId = value; }
        }

        public void SwapWidthAndHeight()
        {            
            float tmp = _Rect.Width;
            _Rect.Width = _Rect.Height;
            _Rect.Height = tmp;
        }

        object ICloneable.Clone()
        {
            return Clone();
        }

        public RectData Clone()
        {
            return new RectData(this);
        }
    }

}
