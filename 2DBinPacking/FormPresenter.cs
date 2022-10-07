using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DBinPacking
{
    public class FormPresenter
    {
        private static readonly int MinRectDimension = 30;
        private static readonly int MaxRectDimension = 300;
        private IForm _View;        

        public FormPresenter(IForm view)
        {
            _View = view;
        }

        public void Place(float binWidth, float binHeight, RectDataCollection collection, out float coverage)
        {            
            RectPlacement placement = new RectPlacement(binWidth, binHeight);
            placement.Padding = _View.BinPadding;
            placement.Margin = _View.RectMargin;

            placement.Place(collection);

            coverage = placement.SpaceCoverage;
        }

        public RectDataCollection GenerateRandomRectDatas(int count)
        {
            RectDataCollection collection = new RectDataCollection();

            collection.Clear();

            Random random = new Random();
            for (int n = 0; n < count; n++)
            {
                int width = random.Next(MinRectDimension, MaxRectDimension);
                int height = random.Next(MinRectDimension, MaxRectDimension);
                collection.Add(new RectData((n + 1).ToString(), width, height));
            }

            return collection;
        }
    }
}
