using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _2DBinPacking.PackingAlgorithms;
using System.Drawing;

namespace _2DBinPackingTest.PackingAlgorithms
{
    [TestClass]
    public class FCNR_ShelvesTest
    {
        private RectangleF _Shelf = new RectangleF(0, 0, 100, 50);
        private FCNR_ShelvesAlgorithm _Inst;

        [TestInitialize]
        public void TestInitialize()
        {
            _Inst = new FCNR_ShelvesAlgorithm(_Shelf);
        }

        [TestMethod]
        public void Place_Rect_BigThan_Shelf_Return_False()
        {            
            RectangleF rect1 = new RectangleF(0, 0, 101, 50);
            RectangleF rect2 = new RectangleF(0, 0, 100, 51);

            Assert.IsFalse(_Inst.Place(ref rect1));
            Assert.IsFalse(_Inst.Place(ref rect2));
        }

        [TestMethod]
        public void Place_One_Rect_Return_True()
        {            
            RectangleF rect1 = new RectangleF(0, 0, 50, 50);

            Assert.IsTrue(_Inst.Place(ref rect1));
            Assert.AreEqual(0, rect1.Left);
            Assert.AreEqual(0, rect1.Top);
            Assert.AreEqual(50, rect1.Width);
            Assert.AreEqual(50, rect1.Height);
        }

        [TestMethod]
        public void Place_Two_Rects_Return_True()
        {
            RectangleF rect1 = new RectangleF(0, 0, 50, 50);
            RectangleF rect2 = new RectangleF(0, 0, 50, 30);

            Assert.IsTrue(_Inst.Place(ref rect1));
            Assert.IsTrue(_Inst.Place(ref rect2));
            Assert.AreEqual(0, rect1.Left);
            Assert.AreEqual(0, rect1.Top);
            Assert.AreEqual(50, rect1.Width);
            Assert.AreEqual(50, rect1.Height);
            Assert.AreEqual(50, rect2.Left);
            Assert.AreEqual(0, rect2.Top);
            Assert.AreEqual(50, rect2.Width);
            Assert.AreEqual(30, rect2.Height);
        }

        [TestMethod]
        public void Place_Three_Rects_Third_Rect_On_Ceiling_Return_True()
        {
            RectangleF rect1 = new RectangleF(0, 0, 50, 50);
            RectangleF rect2 = new RectangleF(0, 0, 50, 30);
            RectangleF rect3 = new RectangleF(0, 0, 40, 15);

            Assert.IsTrue(_Inst.Place(ref rect1));
            Assert.IsTrue(_Inst.Place(ref rect2));
            Assert.IsTrue(_Inst.Place(ref rect3));
            Assert.AreEqual(0, rect1.Left);
            Assert.AreEqual(0, rect1.Top);
            Assert.AreEqual(50, rect1.Width);
            Assert.AreEqual(50, rect1.Height);

            Assert.AreEqual(50, rect2.Left);
            Assert.AreEqual(0, rect2.Top);
            Assert.AreEqual(50, rect2.Width);
            Assert.AreEqual(30, rect2.Height);

            Assert.AreEqual(60, rect3.Left);
            Assert.AreEqual(35, rect3.Top);
            Assert.AreEqual(40, rect3.Width);
            Assert.AreEqual(15, rect3.Height);
        }

        [TestMethod]
        public void Place_Four_Rects_Fourth_Rect_Out_Of_Shelf_Return_False()
        {
            RectangleF rect1 = new RectangleF(0, 0, 50, 50);
            RectangleF rect2 = new RectangleF(0, 0, 50, 30);
            RectangleF rect3 = new RectangleF(0, 0, 40, 15);
            RectangleF rect4 = new RectangleF(0, 0, 60, 10);

            Assert.IsTrue(_Inst.Place(ref rect1));
            Assert.IsTrue(_Inst.Place(ref rect2));
            Assert.IsTrue(_Inst.Place(ref rect3));
            Assert.IsFalse(_Inst.Place(ref rect4));

            Assert.AreEqual(0, rect1.Left);
            Assert.AreEqual(0, rect1.Top);
            Assert.AreEqual(50, rect1.Width);
            Assert.AreEqual(50, rect1.Height);

            Assert.AreEqual(50, rect2.Left);
            Assert.AreEqual(0, rect2.Top);
            Assert.AreEqual(50, rect2.Width);
            Assert.AreEqual(30, rect2.Height);

            Assert.AreEqual(60, rect3.Left);
            Assert.AreEqual(35, rect3.Top);
            Assert.AreEqual(40, rect3.Width);
            Assert.AreEqual(15, rect3.Height);

            Assert.AreEqual(0, rect4.Left);
            Assert.AreEqual(0, rect4.Top);
            Assert.AreEqual(60, rect4.Width);
            Assert.AreEqual(10, rect4.Height);

        }
    }
}
