using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _2DBinPacking;
using System.Drawing;

namespace _2DBinPackingTest
{
    [TestClass]
    public class HelperTest
    {
        [TestMethod]
        public void Overlap_2_RectangleF_Test()
        {
            RectangleF box = new RectangleF(0, 0, 300, 100);
            Assert.IsFalse(Helper.IsOverlap(new RectangleF(301, 0, 10, 10), box));
            Assert.IsFalse(Helper.IsOverlap(new RectangleF(300, 0, 10, 10), box));
            Assert.IsFalse(Helper.IsOverlap(new RectangleF(0, 100, 10, 10), box));
            Assert.IsFalse(Helper.IsOverlap(new RectangleF(0, 101, 10, 10), box));

            Assert.IsTrue(Helper.IsOverlap(new RectangleF(299, 0, 10, 10), box));
            Assert.IsTrue(Helper.IsOverlap(new RectangleF(0, 99, 10, 10), box));


            box = new RectangleF(10, 10, 10, 100);
            Assert.IsFalse(Helper.IsOverlap(new RectangleF(0, 0, 11, 10), box));
            Assert.IsFalse(Helper.IsOverlap(new RectangleF(0, 0, 10, 11), box));

            Assert.IsTrue(Helper.IsOverlap(new RectangleF(0, 0, 11, 11), box));
        }

        [TestMethod]
        public void IsContainedIn_2_RectangleF_Test()
        {
            Assert.IsTrue(Helper.IsFullyOverlap(new RectangleF(0, 0, 10, 10), new RectangleF(0, 0, 10, 10)));
            Assert.IsTrue(Helper.IsFullyOverlap(new RectangleF(0, 0, 10, 10), new RectangleF(0, 0, 11, 11)));
            Assert.IsTrue(Helper.IsFullyOverlap(new RectangleF(0, 0, 11, 11), new RectangleF(0, 0, 11, 11)));
            Assert.IsTrue(Helper.IsFullyOverlap(new RectangleF(1, 1, 9, 9), new RectangleF(0, 0, 10, 10)));

            Assert.IsFalse(Helper.IsFullyOverlap(new RectangleF(1, 1, 10, 10), new RectangleF(0, 0, 10, 10)));
            Assert.IsFalse(Helper.IsFullyOverlap(new RectangleF(1, 0, 10, 10), new RectangleF(0, 0, 10, 10)));
            Assert.IsFalse(Helper.IsFullyOverlap(new RectangleF(0, 1, 10, 10), new RectangleF(0, 0, 10, 10)));
        }
    }
}
