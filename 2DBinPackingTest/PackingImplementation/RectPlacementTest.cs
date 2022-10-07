using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _2DBinPacking;
using System.Drawing;

namespace _2DBinPackingTest
{
    [TestClass]
    public class RectPlacementTest
    {
        RectPlacement _Inst;

        [TestInitialize]
        public void TestInitialize()
        {
            _Inst = new RectPlacement(100, 40);
        }

        [TestMethod]
        public void Place_3_Rects_In_One_Shelf()
        {            
            RectDataCollection rects = new RectDataCollection();
            rects.Add(new RectData("1", 40, 30));
            rects.Add(new RectData("2", 50, 20));
            rects.Add(new RectData("3", 40, 10));

            _Inst.Place(rects);

            Assert.IsTrue(rects.IsAllPlaced());
            Assert.AreEqual(new RectangleF(0, 0, 40, 30), rects[0].Rect);
            Assert.AreEqual(new RectangleF(40, 0, 50, 20), rects[1].Rect);
            Assert.AreEqual(new RectangleF(60, 20, 40, 10), rects[2].Rect);
        }

        [TestMethod]
        public void Place_4_Rects_In_Two_Shelves()
        {            
            RectDataCollection rects = new RectDataCollection();
            rects.Add(new RectData("1", 40, 30));
            rects.Add(new RectData("2", 50, 20));
            rects.Add(new RectData("3", 40, 10));
            rects.Add(new RectData("4", 30, 10));//put on the second shelf.

            _Inst.Place(rects);

            Assert.IsTrue(rects.IsAllPlaced());
            Assert.AreEqual(new RectangleF(0, 0, 40, 30), rects[0].Rect);
            Assert.AreEqual(new RectangleF(40, 0, 50, 20), rects[1].Rect);
            Assert.AreEqual(new RectangleF(60, 20, 40, 10), rects[2].Rect);
            Assert.AreEqual(new RectangleF(0, 30, 30, 10), rects[3].Rect);
        }

        [TestMethod]
        public void Place_4_Rects_In_Two_Shelves_Third_Rect_On_2nd_Shelf()
        {            
            RectDataCollection rects = new RectDataCollection();
            rects.Add(new RectData("1", 40, 30));
            rects.Add(new RectData("2", 50, 20));
            rects.Add(new RectData("3", 70, 10));//put on the second shelf.
            rects.Add(new RectData("4", 30, 10));//put on the first shelf.

            _Inst.Place(rects);

            Assert.IsTrue(rects.IsAllPlaced());
            Assert.AreEqual(new RectangleF(0, 0, 40, 30), rects[0].Rect);
            Assert.AreEqual(new RectangleF(40, 0, 50, 20), rects[1].Rect);
            Assert.AreEqual(new RectangleF(70, 20, 30, 10), rects[2].Rect);
            Assert.AreEqual(new RectangleF(0, 30, 70, 10), rects[3].Rect);
        }
        
        [TestMethod]
        public void Place_5_Rects_In_Two_Shelves_Third_Rect_On_2nd_Shelf()
        {            
            RectDataCollection rects = new RectDataCollection();
            rects.Add(new RectData("1", 40, 30));
            rects.Add(new RectData("2", 50, 20));
            rects.Add(new RectData("3", 90, 10));
            rects.Add(new RectData("4", 30, 10));
            rects.Add(new RectData("5", 20, 10));

            _Inst.Place(rects);

            Assert.IsTrue(rects.IsAllPlaced());
            Assert.AreEqual(new RectangleF(0, 0, 40, 30), rects[0].Rect);
            Assert.AreEqual(new RectangleF(40, 0, 50, 20), rects[1].Rect);
            Assert.AreEqual(new RectangleF(70, 20, 30, 10), rects[2].Rect);            
            Assert.AreEqual(new RectangleF(50, 20, 20, 10), rects[3].Rect);
            Assert.AreEqual(new RectangleF(0, 30, 90, 10), rects[4].Rect);
        }

        [TestMethod]
        public void Place_6_Rects_In_Two_Shelves_Last_Rect_Placed_By_MaxRectAlgorithm()
        {
            RectDataCollection rects = new RectDataCollection();
            rects.Add(new RectData("1", 40, 30));
            rects.Add(new RectData("2", 50, 20));
            rects.Add(new RectData("3", 90, 10));
            rects.Add(new RectData("4", 30, 10));
            rects.Add(new RectData("5", 20, 10));
            rects.Add(new RectData("6", 20, 10));//Place by MaxRect

            _Inst.Place(rects);

            Assert.IsTrue(rects.IsAllPlaced());
            Assert.AreEqual(new RectangleF(0, 0, 40, 30), rects[0].Rect);
            Assert.AreEqual(new RectangleF(40, 0, 50, 20), rects[1].Rect);
            Assert.AreEqual(new RectangleF(70, 20, 30, 10), rects[2].Rect);
            Assert.AreEqual(new RectangleF(50, 20, 20, 10), rects[3].Rect);
            Assert.AreEqual(new RectangleF(90, 0, 10, 20), rects[4].Rect);
            Assert.AreEqual(new RectangleF(0, 30, 90, 10), rects[5].Rect);
        }

        [TestMethod]
        public void Place_4_Rects_In_Two_Shelves_Margin_Is_10()
        {
            RectPlacement inst = new RectPlacement(120, 60);

            RectDataCollection rects = new RectDataCollection();            
            rects.Add(new RectData("1", 40, 30));
            rects.Add(new RectData("2", 50, 20));
            rects.Add(new RectData("3", 40, 10));
            rects.Add(new RectData("4", 30, 10));            

            inst.Margin = 10;
            inst.Place(rects);

            Assert.IsTrue(rects.IsAllPlaced());
            Assert.AreEqual(new RectangleF(10, 10, 40, 30), rects[0].Rect);
            Assert.AreEqual(new RectangleF(50, 10, 50, 20), rects[1].Rect);
            Assert.AreEqual(new RectangleF(70, 30, 40, 10), rects[2].Rect);

            Assert.AreEqual(new RectangleF(10, 40, 30, 10), rects[3].Rect);
        }

        [TestMethod]
        public void Place_5_Rects_In_Two_Shelves_Last_Rect_Placed_By_MaxRectAlgorithm_Margin_Is_10()
        {
            RectPlacement inst = new RectPlacement(120, 60);

            RectDataCollection rects = new RectDataCollection();
            rects.Add(new RectData("1", 40, 30));
            rects.Add(new RectData("2", 50, 20));
            rects.Add(new RectData("3", 50, 10));
            rects.Add(new RectData("4", 30, 10));
            rects.Add(new RectData("5", 20, 10));//placed by max rect algorithm

            inst.Margin = 10;
            inst.Place(rects);

            Assert.IsTrue(rects.IsAllPlaced());
            Assert.AreEqual(new RectangleF(10, 10, 40, 30), rects[0].Rect);
            Assert.AreEqual(new RectangleF(50, 10, 50, 20), rects[1].Rect);
            Assert.AreEqual(new RectangleF(60, 30, 50, 10), rects[2].Rect);
            Assert.AreEqual(new RectangleF(100, 10, 10, 20), rects[3].Rect);

            Assert.AreEqual(new RectangleF(10, 40, 30, 10), rects[4].Rect);
        }

        [TestMethod]
        public void Place_4_Rects_In_Two_Shelves_Padding_Is_10()
        {
            RectPlacement inst = new RectPlacement(120, 60);

            RectDataCollection rects = new RectDataCollection();
            rects.Add(new RectData("1", 40, 30));
            rects.Add(new RectData("2", 50, 20));
            rects.Add(new RectData("3", 40, 10));
            rects.Add(new RectData("4", 30, 10));

            inst.Padding = 10;
            inst.Place(rects);

            Assert.IsTrue(rects.IsAllPlaced());
            Assert.AreEqual(new RectangleF(0, 0, 40, 30), rects[0].Rect);
            Assert.AreEqual(new RectangleF(50, 0, 50, 20), rects[1].Rect);
            Assert.AreEqual(new RectangleF(0, 40, 40, 10), rects[2].Rect);
            Assert.AreEqual(new RectangleF(50, 40, 30, 10), rects[3].Rect);
        }

        [TestMethod]
        public void Place_1_Rect_Padding_Margin_Are_2()
        {
            RectPlacement inst = new RectPlacement(20, 20);

            RectDataCollection rects = new RectDataCollection();
            rects.Add(new RectData("1", 16, 16));

            inst.Padding = 2;
            inst.Margin = 2;

            inst.Place(rects);

            Assert.IsTrue(rects.IsAllPlaced());
            Assert.AreEqual(new RectangleF(2, 2, 16, 16), rects[0].Rect);
        }

        /// <summary>        
        /// 測試最後一個Shelf的Rects使用MaxRects的效果如果比較好, 則採用
        /// </summary>
        [TestMethod]
        public void RectsInLastShelft_Use_MaxRectAlgorithm()
        {
            RectPlacement inst = new RectPlacement(110, 60);

            RectDataCollection rects = new RectDataCollection();
            rects.Add(new RectData("1", 50, 30));
            rects.Add(new RectData("2", 50, 20));
            rects.Add(new RectData("3", 30, 20));//in last shlef
            rects.Add(new RectData("4", 20, 20));//in last shlef

            inst.Place(rects);
            Assert.IsTrue(rects.IsAllPlaced());
            Assert.AreEqual(new RectangleF(0, 0, 50, 30), rects[0].Rect);
            Assert.AreEqual(new RectangleF(50, 0, 50, 20), rects[1].Rect);
            Assert.AreEqual(new RectangleF(80, 20, 30, 20), rects[2].Rect);
            Assert.AreEqual(new RectangleF(60, 20, 20, 20), rects[3].Rect);
        }

        /// <summary>        
        /// 測試有rect原本放不下, 但使用MaxRectAlgorithm後就可以放入
        /// </summary>
        [TestMethod]
        public void Rect_Out_Of_Bin_Use_MaxRectAlgorithm_To_Place()
        {
            RectPlacement inst = new RectPlacement(110, 40);

            RectDataCollection rects = new RectDataCollection();
            rects.Add(new RectData("1", 50, 30));
            rects.Add(new RectData("2", 50, 20));
            rects.Add(new RectData("3", 30, 20));//out of bin

            inst.Place(rects);
            Assert.IsTrue(rects.IsAllPlaced());
            Assert.AreEqual(new RectangleF(0, 0, 50, 30), rects[0].Rect);
            Assert.AreEqual(new RectangleF(50, 0, 50, 20), rects[1].Rect);
            Assert.AreEqual(new RectangleF(80, 20, 30, 20), rects[2].Rect);            
        }

        [TestMethod]
        public void Place_Width_120_Rect_Paddind_2_Margin_0()
        {
            RectPlacement inst = new RectPlacement(120, 60);

            RectDataCollection rects = new RectDataCollection();
            rects.Add(new RectData("1", 120, 30));

            inst.Padding = 10;
            inst.Margin = 0;

            inst.Place(rects);

            Assert.IsTrue(rects.IsAllPlaced());
        }

        [TestMethod]
        public void Place_Width_120_And_Width_20_Rects_Paddind_2_Margin_0()
        {
            RectPlacement inst = new RectPlacement(120, 70);

            RectDataCollection rects = new RectDataCollection();
            rects.Add(new RectData("1", 20, 20));
            rects.Add(new RectData("2", 120, 30));
           
            inst.Padding = 10;
            inst.Margin = 0;

            inst.Place(rects);

            Assert.IsTrue(rects.IsAllPlaced());
            Assert.AreEqual(new RectangleF(0, 0, 20, 20), rects[0].Rect);
            Assert.AreEqual(new RectangleF(0, 30, 120, 30), rects[1].Rect);
        }
    }
}
