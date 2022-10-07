﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DBinPacking.PackingAlgorithms
{
    public interface IPackingAlgorithm
    {
        bool Place(ref RectangleF rect);
    }
}
