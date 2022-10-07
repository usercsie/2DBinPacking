using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DBinPacking.PackingAlgorithms
{
    public class FCNR_ShelvesAlgorithm : IPackingAlgorithm
    {
        private RectangleF _Shelf;
        private float _AvailableFloorPostion;
        private float _AvailableCeilingPosition;
        private List<RectangleF> _PlacedPositions;

        public FCNR_ShelvesAlgorithm(RectangleF shelf)
        {
            _Shelf = shelf;
            _PlacedPositions = new List<RectangleF>();
            Reset();
        }

        public bool Place(ref RectangleF rect)
        {            
            if (IsRectBigThanShelf(rect) == true)
                return false;

            if (PlaceOnTheFloor(ref rect) == true)
                return true;

            if (PlaceOnTheCeilling(ref rect) == true)
                return true;

            return false;
        }

        public void Reset()
        {
            _AvailableFloorPostion = _Shelf.Left;
            _AvailableCeilingPosition = _Shelf.Right - 1;
        }

        private bool IsRectBigThanShelf(RectangleF rect)
        {
            return rect.Height > _Shelf.Height || rect.Width > _Shelf.Width;                 
        }

        private bool PlaceOnTheFloor(ref RectangleF rect)
        {
            if (_AvailableFloorPostion + rect.Width <= _Shelf.Right)
            {
                rect.X = _AvailableFloorPostion;
                rect.Y = _Shelf.Top;

                _AvailableFloorPostion = rect.Left + rect.Width;
                _PlacedPositions.Add(rect);

                return true;
            }
            else
                return false;
        }

        private bool PlaceOnTheCeilling(ref RectangleF rect)
        {
            //天花板是由右往左放
            float left = _AvailableCeilingPosition - rect.Width + 1;
            if (left >= _Shelf.Left)
            {
                RectangleF temp = rect;
                temp.X = left;
                temp.Y = _Shelf.Top + _Shelf.Height - rect.Height;

                if (IsOverlapWithPlacedPositions(temp) == false)
                {
                    rect = temp;
                    _AvailableCeilingPosition = left - 1;
                    _PlacedPositions.Add(rect);
                    return true;
                }                
            }            

            return false;
        }

        private bool IsOverlapWithPlacedPositions(RectangleF rect)
        {
            bool overlap = false;
            foreach(RectangleF r in _PlacedPositions)
            {                
                if (Helper.IsOverlap(r, rect) == true)
                {
                    overlap = true;
                    break;
                }
            }
            return overlap;
        }
    }
}
