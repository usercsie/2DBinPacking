using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DBinPacking.PackingAlgorithms
{
    public enum MaxRectType
    {
        RightTop,
        TopRight
    }

    public class MaxRectAlgorithm : IPackingAlgorithm
    {   
        private List<RectangleF> _AvailableRectangles = new List<RectangleF>();

        public MaxRectType MaxRectTypeSelection { get; set; }

        public RectangleF[] FreeRectangles
        {
            get { return _AvailableRectangles.ToArray(); }
        }

        public bool Rotatable { get; set; }

        public MaxRectAlgorithm(RectangleF shelf)
        {
            Rotatable = true;
            _AvailableRectangles.Clear();
            _AvailableRectangles.Add(shelf);
            MaxRectTypeSelection = MaxRectType.RightTop;
        }

        public MaxRectAlgorithm(RectangleF shelf, MaxRectType type)
            : this(shelf)
        {
            MaxRectTypeSelection = type;
        }

        public bool Place(ref RectangleF rect)
        {
            RectangleF position = FindPosition(rect.Width, rect.Height);

            if (position == RectangleF.Empty)
                return false;
            
            PlaceRect(position);
            rect = position;            

            return true;                        
        }

        public void Set(RectangleF rect)
        {
            PlaceRect(rect);            
        }

        private void PlaceRect(RectangleF rect)
        {
            int numRectanglesToProcess = _AvailableRectangles.Count;
            for (int i = 0; i < numRectanglesToProcess; ++i)
            {
                RectangleF[] splitRects = SplitAvailableRect(_AvailableRectangles[i], rect);

                if (splitRects.Length > 0)
                {
                    _AvailableRectangles.AddRange(splitRects);
                    _AvailableRectangles.RemoveAt(i);
                    i--;
                    numRectanglesToProcess--;
                }
            }

            MergeFreeList();
        }

        private RectangleF FindPosition(float width, float height)
        {
            if (MaxRectTypeSelection == MaxRectType.RightTop)
            {
                return FindPositionForNewRectRightTop(width, height);
            }
            else
            {
                return FindPositionForNewRectTopRight(width, height);
            }
        }

        /// <summary>
        /// 將Rect放到最右邊, 上方的空間裡, 
        /// 如果Rotatable == true時, Rect的 Width < Height較為優先
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        private RectangleF FindPositionForNewRectRightTop(float width, float height)
        {
            RectangleF bestRect = new RectangleF();

            float biggestLeft = 0;
            float currentTop = float.MaxValue;

            for (int i = 0; i < _AvailableRectangles.Count; ++i)
            {                
                if (_AvailableRectangles[i].Width >= width && _AvailableRectangles[i].Height >= height)
                {                    
                    float left = _AvailableRectangles[i].Right - width;
                    if (left > biggestLeft || (left == biggestLeft && _AvailableRectangles[i].Top < currentTop))
                    {                        
                        bestRect.X = left;
                        bestRect.Y = _AvailableRectangles[i].Y;
                        bestRect.Width = width;
                        bestRect.Height = height;
                        currentTop = _AvailableRectangles[i].Y;
                        biggestLeft = left;
                    }
                }
                if (Rotatable && _AvailableRectangles[i].Width >= height && _AvailableRectangles[i].Height >= width)
                {                    
                    float left = _AvailableRectangles[i].Right - height;
                    if (left > biggestLeft || (left == biggestLeft && _AvailableRectangles[i].Top < currentTop))
                    {
                        bestRect.X = left;
                        bestRect.Y = _AvailableRectangles[i].Y;
                        bestRect.Width = height;
                        bestRect.Height = width;
                        currentTop = _AvailableRectangles[i].Y;
                        biggestLeft = left;
                    }
                }
            }
            return bestRect;
        }

        /// <summary>
        /// 將Rect放到最上方, 右邊的空間裡, 
        /// 如果Rotatable == true時, Rect的 Width < Height較為優先
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        private RectangleF FindPositionForNewRectTopRight(float width, float height)
        {
            RectangleF bestRect = new RectangleF();

            float smallestBottom = float.MaxValue;
            float currentRight = 0;

            for (int i = 0; i < _AvailableRectangles.Count; ++i)
            {
                if (_AvailableRectangles[i].Width >= width && _AvailableRectangles[i].Height >= height)
                {
                    float bottom = _AvailableRectangles[i].Top + height;
                    if (bottom < smallestBottom || (bottom == smallestBottom && _AvailableRectangles[i].Right > currentRight))
                    {
                        bestRect.X = _AvailableRectangles[i].Right - width;
                        bestRect.Y = _AvailableRectangles[i].Y;
                        bestRect.Width = width;
                        bestRect.Height = height;
                        currentRight = _AvailableRectangles[i].Right;
                        smallestBottom = bottom;
                    }
                }
                if (Rotatable && _AvailableRectangles[i].Width >= height && _AvailableRectangles[i].Height >= width)
                {
                    float bottom = _AvailableRectangles[i].Top + width;
                    if (bottom < smallestBottom || (bottom == smallestBottom && _AvailableRectangles[i].Right > currentRight))
                    {
                        bestRect.X = _AvailableRectangles[i].Right - height;
                        bestRect.Y = _AvailableRectangles[i].Y;
                        bestRect.Width = height;
                        bestRect.Height = width;
                        currentRight = _AvailableRectangles[i].Right;
                        smallestBottom = bottom;
                    }
                }
            }
            return bestRect;
        }

        private RectangleF[] SplitAvailableRect(RectangleF availableRect, RectangleF placingRect)
        {
            List<RectangleF> availableRects = new List<RectangleF>();

            if (Helper.IsOverlap(availableRect, placingRect) == false)
                return availableRects.ToArray();

            if (placingRect.X < availableRect.X + availableRect.Width && placingRect.X + placingRect.Width > availableRect.X)
            {
                // New node at the top side of the used node.
                if (placingRect.Y > availableRect.Y && placingRect.Y < availableRect.Y + availableRect.Height)
                {
                    RectangleF newNode = availableRect;
                    newNode.Height = placingRect.Y - newNode.Y;
                    availableRects.Add(newNode);
                }

                // New node at the bottom side of the used node.
                if (placingRect.Y + placingRect.Height < availableRect.Y + availableRect.Height)
                {
                    RectangleF newNode = availableRect;
                    newNode.Y = placingRect.Y + placingRect.Height;
                    newNode.Height = availableRect.Y + availableRect.Height - (placingRect.Y + placingRect.Height);
                    availableRects.Add(newNode);
                }
            }

            if (placingRect.Y < availableRect.Y + availableRect.Height && placingRect.Y + placingRect.Height > availableRect.Y)
            {
                // New node at the left side of the used node.
                if (placingRect.X > availableRect.X && placingRect.X < availableRect.X + availableRect.Width)
                {
                    RectangleF newNode = availableRect;
                    newNode.Width = placingRect.X - newNode.X;
                    availableRects.Add(newNode);
                }

                // New node at the right side of the used node.
                if (placingRect.X + placingRect.Width < availableRect.X + availableRect.Width)
                {
                    RectangleF newNode = availableRect;
                    newNode.X = placingRect.X + placingRect.Width;
                    newNode.Width = availableRect.X + availableRect.Width - (placingRect.X + placingRect.Width);
                    availableRects.Add(newNode);
                }
            }

            return availableRects.ToArray();
        }

        private void MergeFreeList()
        {
            for (int i = 0; i < _AvailableRectangles.Count; ++i)
            {
                for (int j = i + 1; j < _AvailableRectangles.Count; ++j)
                {
                    if (IsContainedIn(_AvailableRectangles[i], _AvailableRectangles[j]))
                    {
                        _AvailableRectangles.RemoveAt(i);
                        --i;
                        break;
                    }
                    if (IsContainedIn(_AvailableRectangles[j], _AvailableRectangles[i]))
                    {
                        _AvailableRectangles.RemoveAt(j);
                        --j;
                    }
                }
            }
        }
        private bool IsContainedIn(RectangleF a, RectangleF b)
        {
            return a.X >= b.X && a.Y >= b.Y
                && a.X + a.Width <= b.X + b.Width
                && a.Y + a.Height <= b.Y + b.Height;
        }
    }
}
