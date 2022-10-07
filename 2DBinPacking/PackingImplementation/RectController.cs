using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DBinPacking
{
    public class RectController
    {        
        public RectController()
        {
        
        }

        public void Adjust(ref RectDataCollection rectDatas)
        {
            List<RectData> result = new List<RectData>();
            for (int n = 0; n < rectDatas.Count; n++)
            {
                RectData rect = rectDatas[n];
                SwapWidthHeight(rect);
                result.Add(rect);
            }

            SortByDecendingHeight(ref rectDatas);
        }

        private void SwapWidthHeight(RectData data)
        {
            if (data.Rect.Width < data.Rect.Height)
            {
                data.SwapWidthAndHeight();        
            }
        }

        private void SortByDecendingHeight(ref RectDataCollection rectDatas)
        {
            //rectDatas.OrderByDescending(v => v.Height);
            rectDatas.ToArray().OrderByDescending(v => v.Rect.Height);
            RectData[] data = rectDatas.ToArray().OrderByDescending(v => v.Rect.Height).ToArray();

            rectDatas.Clear();

            foreach (RectData d in data)
            {
                rectDatas.Add(d);
            }
        }

    }
}
