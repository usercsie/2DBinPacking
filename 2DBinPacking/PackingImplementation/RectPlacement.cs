using _2DBinPacking.PackingAlgorithms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DBinPacking
{
    public class RectPlacement
    {
        private float _BinWidth;
        private float _BinHeight;

        private List<RectangleF> _AvailableShelves;

        private List<IPackingAlgorithm> _PackingAlgorithms = new List<IPackingAlgorithm>();

        public int Padding { get; set; }
        public int Margin { get; set; }

        public float SpaceCoverage
        {
            get;
            private set;
        }

        private RectangleF BinBoundary
        {
            get
            {
                RectangleF box = new RectangleF(0, 0, _BinWidth, _BinHeight);
                box.X += Margin;// Math.Max(Margin, Padding);
                box.Y += Margin;// Math.Max(Margin, Padding);

                if (Padding < Margin)
                {
                    box.Width -= (2 * Margin - Padding);
                    box.Height -= (2 * Margin - Padding);
                }
                else
                {
                    box.Width -= Margin;
                    box.Height -= Margin;
                }
                return box;
            }
        }

        private int CurrentShelfId
        {
            get { return _AvailableShelves.Count() - 1; }
        }

        public RectPlacement(float binWidth, float binHeight)
        {
            _BinWidth = binWidth;
            _BinHeight = binHeight;
            Padding = 0;
            Margin = 0;

            _AvailableShelves = new List<RectangleF>();
        }

        public void Place(RectDataCollection rectDatas)
        {
            rectDatas.Reset();

            Size[] paddingSizes = CalculatePaddingSize(rectDatas);

            SetPaddingTo(rectDatas, paddingSizes);

            PlaceCore(rectDatas);

            ReplaceLastShelfByMaxRectAlgorithm(rectDatas);

            ResetPaddingTo(rectDatas, paddingSizes);
        }

        private Size[] CalculatePaddingSize(RectDataCollection rectDatas)
        {
            List<Size> result = new List<Size>();
            foreach (var rect in rectDatas)
            {
                int paddingWidth = Padding;
                int paddingHeight = Padding;
                if (rect.Rect.Width + Padding > _BinWidth)
                {
                    paddingWidth = 0;
                }
                if (rect.Rect.Height + paddingHeight >= _BinHeight)
                {
                    paddingHeight = 0;
                }
                result.Add(new Size(paddingWidth, paddingHeight));
            }

            return result.ToArray();
        }

        private void SetPaddingTo(RectDataCollection rectDatas, Size[] paddings)
        {
            for (int n = 0; n < paddings.Length; n++)
            {
                rectDatas.SetPadding(n, paddings[n].Width, paddings[n].Height);
            }
        }

        private void ResetPaddingTo(RectDataCollection rectDatas, Size[] paddings)
        {
            for (int n = 0; n < paddings.Length; n++)
            {
                rectDatas.SetPadding(n, -paddings[n].Width, -paddings[n].Height);
            }
        }

        private void PlaceCore(RectDataCollection rectDatas)
        {
            bool flag = true;
            int unPlacedCount = rectDatas.UnPlacedCount;

            if (unPlacedCount == 0)
                return;

            AddShelf(rectDatas.Where(v => v.Placed == false).First().Rect.Height);

            foreach(IPackingAlgorithm alg in _PackingAlgorithms)
            {
                SetPlacedRectsToMaxRectAlgorithm(alg as MaxRectAlgorithm, rectDatas);

                foreach (RectData rect in rectDatas)
                {
                    if (rect.Placed == true)
                        continue;

                    flag &= PlaceByAlgorithm(alg, rect);
                }
            }

            //未排列數量有減少, 繼續下一輪排列
            if (rectDatas.UnPlacedCount < unPlacedCount && flag == false)
            {
                SortByPlaced(rectDatas);
                PlaceCore(rectDatas);
            }
        }

        private void AddShelf(float rectHeight)
        {
            _AvailableShelves.Add(CreateShelf(rectHeight, BinBoundary));

            _PackingAlgorithms.Clear();
            _PackingAlgorithms.Add(new FCNR_ShelvesAlgorithm(_AvailableShelves.Last()));
            _PackingAlgorithms.Add(new MaxRectAlgorithm(_AvailableShelves.Last()));
        }

        private RectangleF CreateShelf(float height, RectangleF boundary)
        {
            float top = _AvailableShelves.Count == 0 ? BinBoundary.Y : _AvailableShelves.Last().Bottom;
            top = Math.Max(top, BinBoundary.Y);

            return RectangleF.Intersect(new RectangleF(boundary.Left, top, boundary.Width, height), boundary);
        }

        private void SortByPlaced(RectDataCollection rectDatas)
        {
            List<RectData> temp = new List<RectData>();

            temp.AddRange(rectDatas.Where(v => v.Placed == true));
            temp.AddRange(rectDatas.Where(v => v.Placed == false));

            rectDatas.Clear();
            rectDatas.AddRange(temp.ToArray());
        }

        private bool PlaceByAlgorithm(IPackingAlgorithm algo, RectData rect)
        {
            RectangleF r = rect.Rect;

            if (algo.Place(ref r) == true)
            {
                rect.Rect = r;
                rect.ShelfId = CurrentShelfId;
                return true;
            }

            rect.ShelfId = -1;
            return false;
        }

        private void SetPlacedRectsToMaxRectAlgorithm(MaxRectAlgorithm algorithm, RectDataCollection rectDatas)
        {
            if (algorithm == null)
                return;

            //把FCNR已排列過的Rect且在同一層放入MaxRectanglesAlgorithm, 目的是建立可用空間.            
            foreach (RectData rect in rectDatas)
            {
                if (rect.ShelfId == CurrentShelfId)
                {
                    algorithm.Set(rect.Rect);
                }
            }
        }

        private void ReplaceLastShelfByMaxRectAlgorithm(RectDataCollection rectDatas)
        {
            int lastShelfId = _AvailableShelves.Count() - 1;

            if (lastShelfId == 0)
                return;

            List<RectData> rectsOnLastShelfOrOutBin = new List<RectData>();
            MaxRectAlgorithm alg = new MaxRectAlgorithm(BinBoundary, MaxRectType.TopRight);
            alg.Rotatable = false;

            foreach (RectData r in rectDatas)
            {
                if (r.ShelfId >= 0 && r.ShelfId < lastShelfId)
                {
                    alg.Set(r.Rect);
                }
                else
                    rectsOnLastShelfOrOutBin.Add(r.Clone());
            }

            float orgMaxBottom = GetMaxBottom(rectsOnLastShelfOrOutBin);
            int orgOutBinCount = GetOutOfBinCount(rectsOnLastShelfOrOutBin);
            
            foreach (RectData r in rectsOnLastShelfOrOutBin)
            {
                PlaceByAlgorithm(alg, r);
            }

            if (IsBatterResult(rectsOnLastShelfOrOutBin, orgMaxBottom, orgOutBinCount) == true)
            {
                ReplaceBetterResult(rectsOnLastShelfOrOutBin, rectDatas);
            }
        }

        private bool IsBatterResult(IEnumerable<RectData> datas, float orgMaxBot, int orgOutBinCount)
        {
            float maxBot = GetOutOfBinCount(datas);
            if (maxBot < orgOutBinCount)
            {
                return true;
            }
            else if (maxBot > orgOutBinCount)
            {
                return false;
            }
            else
            {
                return GetMaxBottom(datas) < orgMaxBot;
            }                        
        }

        private void ReplaceBetterResult(IEnumerable<RectData> newRectData, RectDataCollection orgRectData)
        {
            foreach (RectData r in newRectData)
            {
                if (r.ShelfId == -1)
                    continue;
                foreach (RectData r2 in orgRectData)
                {
                    if (r2.Key == r.Key)
                    {
                        r2.Rect = r.Rect;
                        r2.ShelfId = r.ShelfId;
                    }
                }
            }
        }

        private float GetMaxBottom(IEnumerable<RectData> datas)
        {
            float max = 0;
            foreach(var r in datas)
            {
                if (r.ShelfId >= 0 && r.Rect.Bottom > max)
                {
                    max = r.Rect.Bottom;
                }
            }
            return max;
        }

        private int GetOutOfBinCount(IEnumerable<RectData> datas)
        {
            return datas.Where(v => v.ShelfId == -1).Count();
        }

        private float GetSpaceCoverage(RectDataCollection rects)
        {
            if (_AvailableShelves.Count <= 1)
                return 0;

            float allSpace = 0;
            float allRect = 0;

            for (int n = 0; n < _AvailableShelves.Count - 1; n++)
            {
                allSpace += (_AvailableShelves[n].Width * _AvailableShelves[n].Height);
            }

            foreach(var r in rects)
            {
                if (r.ShelfId != -1 && r.ShelfId < _AvailableShelves.Count - 1)
                {
                    allRect += r.Width * r.Height;
                }
            }

            return allRect / allSpace;
        }
    }
}
