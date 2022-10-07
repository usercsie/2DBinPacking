using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _2DBinPacking;

namespace _2DBinPackingTest
{
    [TestClass]
    public class RectControllerTest
    {
        RectController _Inst = new RectController();
        [TestMethod]
        public void Adjust_One_Rect_Width_less_Height_Should_Be_Swap()
        {
            RectDataCollection rects = new RectDataCollection();
            rects.Add(new RectData("1", 20, 50));
            
            _Inst.Adjust(ref rects);

            Assert.AreEqual(50, rects[0].Rect.Width);
            Assert.AreEqual(20, rects[0].Rect.Height);            
        }

        [TestMethod]
        public void Adjust_One_Rect_Width_grater_Height_Should_Not_Be_Swap()
        {
            RectDataCollection rects = new RectDataCollection();
            rects.Add(new RectData("1", 50, 20));
            
            _Inst.Adjust(ref rects);

            Assert.AreEqual(50, rects[0].Rect.Width);
            Assert.AreEqual(20, rects[0].Rect.Height);
        }

        [TestMethod]
        public void Adjust_2_Rects()
        {
            RectDataCollection rects = new RectDataCollection();
            rects.Add(new RectData("1", 50, 20));
            rects.Add(new RectData("2", 20, 50));
            
            _Inst.Adjust(ref rects);

            foreach (RectData r in rects)
            {
                Assert.AreEqual(50, r.Rect.Width);
                Assert.AreEqual(20, r.Rect.Height);
            }
        }

        [TestMethod]
        public void Adjust_2_Rects_Order_By_DecendingHeight()
        {
            RectDataCollection rects = new RectDataCollection();
            rects.Add(new RectData("1", 50, 20));
            rects.Add(new RectData("2", 30, 50));

            _Inst.Adjust(ref rects);

            Assert.AreEqual(50, rects[0].Rect.Width);
            Assert.AreEqual(30, rects[0].Rect.Height);
            Assert.AreEqual(50, rects[1].Rect.Width);
            Assert.AreEqual(20, rects[1].Rect.Height);
        }
    }
}
