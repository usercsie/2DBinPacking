using _2DBinPacking.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DBinPacking
{
    public interface IForm
    {
        IDocument Drawer { get; }
        int RectMargin { get; }
        int BinPadding { get; }
        int RectCount { get; }
    }
}
