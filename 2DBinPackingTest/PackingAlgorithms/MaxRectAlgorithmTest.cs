using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _2DBinPacking.PackingAlgorithms;
using System.Drawing;

namespace _2DBinPackingTest.PackingAlgorithms
{
    [TestClass]
    public class MaxRectAlgorithmTest
    {
        private RectangleF _Shelf = new RectangleF(0, 0, 100, 30);
        private MaxRectAlgorithm _Inst;

        [TestInitialize]
        public void TestInitialize()
        {
            _Inst = new MaxRectAlgorithm(_Shelf);
        }

        [TestMethod]
        public void Place_1_Rect_Out_Shelf_Return_False()
        {            
            RectangleF rect1 = new RectangleF(0, 0, 100, 31);

            Assert.IsFalse(_Inst.Place(ref rect1));
            Assert.AreEqual(0, rect1.Left);
            Assert.AreEqual(0, rect1.Top);
            Assert.AreEqual(100, rect1.Width);
            Assert.AreEqual(31, rect1.Height);
        }
        [TestMethod]
        public void Place_1_FullSizeRect_Return_True()
        {
            RectangleF rect1 = new RectangleF(0, 0, 100, 30);

            Assert.IsTrue(_Inst.Place(ref rect1));
            Assert.AreEqual(0, rect1.Left);
            Assert.AreEqual(0, rect1.Top);
            Assert.AreEqual(100, rect1.Width);
            Assert.AreEqual(30, rect1.Height);
        }
        [TestMethod]
        public void Place_1_FullSizeRect_Rotation_Return_True()
        {
            RectangleF rect1 = new RectangleF(0, 0, 30, 100);

            Assert.IsTrue(_Inst.Place(ref rect1));
            Assert.AreEqual(0, rect1.Left);
            Assert.AreEqual(0, rect1.Top);
            Assert.AreEqual(100, rect1.Width);
            Assert.AreEqual(30, rect1.Height);
        }
        [TestMethod]
        public void Place_1_FullHieghtRect_Return_True()
        {
            RectangleF rect1 = new RectangleF(0, 0, 50, 30);

            Assert.IsTrue(_Inst.Place(ref rect1));
            Assert.AreEqual(50, rect1.Left);
            Assert.AreEqual(0, rect1.Top);
            Assert.AreEqual(50, rect1.Width);
            Assert.AreEqual(30, rect1.Height);
        }
        [TestMethod]
        public void Place_1_FullWidthRect_Return_True()
        {
            RectangleF rect1 = new RectangleF(0, 0, 100, 10);

            Assert.IsTrue(_Inst.Place(ref rect1));
            Assert.AreEqual(0, rect1.Left);
            Assert.AreEqual(0, rect1.Top);
            Assert.AreEqual(100, rect1.Width);
            Assert.AreEqual(10, rect1.Height);
        }
        [TestMethod]
        public void Place_1_Rect_Return_True()
        {
            RectangleF rect1 = new RectangleF(0, 0, 50, 10);
            Assert.IsTrue(_Inst.Place(ref rect1));
            Assert.AreEqual(50, rect1.Left);
            Assert.AreEqual(0, rect1.Top);
            Assert.AreEqual(50, rect1.Width);
            Assert.AreEqual(10, rect1.Height);

            Assert.AreEqual(2, _Inst.FreeRectangles.Length);
            Assert.AreEqual(new RectangleF(0, 10, 100, 20), _Inst.FreeRectangles[0]);
            Assert.AreEqual(new RectangleF(0, 0, 50, 30), _Inst.FreeRectangles[1]);
        }
        [TestMethod]
        public void Place_2_Rects_Return_True()
        {     
            RectangleF rect1 = new RectangleF(0, 0, 50, 10);
            //注意, 這個會做旋轉
            RectangleF rect2 = new RectangleF(0, 0, 20, 10);

            Assert.IsTrue(_Inst.Place(ref rect1));
            Assert.IsTrue(_Inst.Place(ref rect2));
            Assert.AreEqual(new RectangleF(50, 0, 50, 10), rect1);
            Assert.AreEqual(new RectangleF(90, 10, 10, 20), rect2);

            Assert.AreEqual(2, _Inst.FreeRectangles.Length);            
            Assert.AreEqual(new RectangleF(0, 0, 50, 30), _Inst.FreeRectangles[0]);
            Assert.AreEqual(new RectangleF(0, 10, 90, 20), _Inst.FreeRectangles[1]);
        }
        [TestMethod]
        public void Place_3_Rects_Return_True()
        {
            RectangleF rect1 = new RectangleF(0, 0, 50, 10);            
            RectangleF rect2 = new RectangleF(0, 0, 20, 10);
            RectangleF rect3 = new RectangleF(0, 0, 30, 10);

            Assert.IsTrue(_Inst.Place(ref rect1));
            Assert.IsTrue(_Inst.Place(ref rect2));
            Assert.IsTrue(_Inst.Place(ref rect3));
            Assert.AreEqual(50, rect1.Left);
            Assert.AreEqual(0, rect1.Top);
            Assert.AreEqual(50, rect1.Width);
            Assert.AreEqual(10, rect1.Height);
            Assert.AreEqual(90, rect2.Left);
            Assert.AreEqual(10, rect2.Top);
            Assert.AreEqual(10, rect2.Width);
            Assert.AreEqual(20, rect2.Height);
            Assert.AreEqual(60, rect3.Left);
            Assert.AreEqual(10, rect3.Top);
            Assert.AreEqual(30, rect3.Width);
            Assert.AreEqual(10, rect3.Height);

            Assert.AreEqual(3, _Inst.FreeRectangles.Length);
            Assert.AreEqual(new RectangleF(0, 0, 50, 30), _Inst.FreeRectangles[0]);
            Assert.AreEqual(new RectangleF(0, 20, 90, 10), _Inst.FreeRectangles[1]);
            Assert.AreEqual(new RectangleF(0, 10, 60, 20), _Inst.FreeRectangles[2]);
        }

        [TestMethod]
        public void Set_1_Rect_Algin_Right()
        {
            RectangleF rect1 = new RectangleF(50, 0, 50, 10);

            _Inst.Set(rect1);

            Assert.AreEqual(2, _Inst.FreeRectangles.Length);
            Assert.AreEqual(new RectangleF(0, 10, 100, 20), _Inst.FreeRectangles[0]);
            Assert.AreEqual(new RectangleF(0, 0, 50, 30), _Inst.FreeRectangles[1]);
        }

        [TestMethod]
        public void Set_1_Rect_Algin_Left()
        {
            RectangleF rect1 = new RectangleF(0, 0, 50, 10);

            _Inst.Set(rect1);

            Assert.AreEqual(2, _Inst.FreeRectangles.Length);
            Assert.AreEqual(new RectangleF(0, 10, 100, 20), _Inst.FreeRectangles[0]);
            Assert.AreEqual(new RectangleF(50, 0, 50, 30), _Inst.FreeRectangles[1]);
        }

        [TestMethod]
        public void Set_2_Rects()
        {
            RectangleF rect1 = new RectangleF(50, 0, 50, 10);            
            RectangleF rect2 = new RectangleF(90, 10, 10, 20);

            _Inst.Set(rect1);
            _Inst.Set(rect2);

            Assert.AreEqual(2, _Inst.FreeRectangles.Length);
            Assert.AreEqual(new RectangleF(0, 0, 50, 30), _Inst.FreeRectangles[0]);
            Assert.AreEqual(new RectangleF(0, 10, 90, 20), _Inst.FreeRectangles[1]);
        }
        [TestMethod]
        public void Set_3_Rects()
        {
            RectangleF rect1 = new RectangleF(50, 0, 50, 10);            
            RectangleF rect2 = new RectangleF(90, 10, 10, 20);
            RectangleF rect3 = new RectangleF(60, 10, 30, 10);

            _Inst.Set(rect1);
            _Inst.Set(rect2);
            _Inst.Set(rect3);

            Assert.AreEqual(3, _Inst.FreeRectangles.Length);
            Assert.AreEqual(new RectangleF(0, 0, 50, 30), _Inst.FreeRectangles[0]);
            Assert.AreEqual(new RectangleF(0, 20, 90, 10), _Inst.FreeRectangles[1]);
            Assert.AreEqual(new RectangleF(0, 10, 60, 20), _Inst.FreeRectangles[2]);
        }

        [TestMethod]
        public void MergeFreeList()
        {
            RectangleF rect1 = new RectangleF(0, 0, 50, 30);
            RectangleF rect2 = new RectangleF(0, 30, 60, 20);

            MaxRectAlgorithm inst = new MaxRectAlgorithm(new RectangleF(0, 0, 100, 60));

            inst.Set(rect1);
            inst.Set(rect2);

            Assert.AreEqual(3, inst.FreeRectangles.Length);
            Assert.AreEqual(new RectangleF(0, 50, 100, 10), inst.FreeRectangles[0]);
            Assert.AreEqual(new RectangleF(50, 0, 50, 30), inst.FreeRectangles[1]);            
            Assert.AreEqual(new RectangleF(60, 0, 40, 60), inst.FreeRectangles[2]);
        }
    }
}
