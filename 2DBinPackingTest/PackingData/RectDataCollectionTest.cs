using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _2DBinPacking;

namespace _2DBinPackingTest
{
    [TestClass]
    public class RectDataCollectionTest
    {
        RectDataCollection _Inst;

        [TestInitialize]
        public void TestInit()
        {
            _Inst = new RectDataCollection();
        }

        [TestMethod]
        public void IsAllPlaced_All_ShelfId_GratherOrEqual_0_Return_True()
        {
            _Inst.Add(new RectData("1", 10, 10));
            _Inst.Add(new RectData("1", 10, 10));
            _Inst.Add(new RectData("1", 10, 10));

            foreach(var r in _Inst)
            {
                r.ShelfId = 0;
            }

            Assert.IsTrue(_Inst.IsAllPlaced());
            Assert.AreEqual(0, _Inst.UnPlacedCount);
        }

        [TestMethod]
        public void IsAllPlaced_One_Of_ShelfId_Is_0_Return_False()
        {
            _Inst.Add(new RectData("1", 10, 10));
            _Inst.Add(new RectData("1", 10, 10));
            _Inst.Add(new RectData("1", 10, 10));

            _Inst[0].ShelfId = 0;
            _Inst[1].ShelfId = 1;

            Assert.IsFalse(_Inst.IsAllPlaced());
            Assert.AreEqual(1, _Inst.UnPlacedCount);
        }

        [TestMethod]
        public void SetPadding_Add_Paddinig_To_Size()
        {
            _Inst.Add(new RectData("1", 10, 11));
            _Inst.Add(new RectData("1", 11, 12));
            _Inst.Add(new RectData("1", 22, 23));

            _Inst.SetPadding(5, 5);

            Assert.AreEqual(15, _Inst[0].Rect.Width);
            Assert.AreEqual(16, _Inst[0].Rect.Height);
            Assert.AreEqual(16, _Inst[1].Rect.Width);
            Assert.AreEqual(17, _Inst[1].Rect.Height);
            Assert.AreEqual(27, _Inst[2].Rect.Width);
            Assert.AreEqual(28, _Inst[2].Rect.Height);
        }

        [TestMethod]
        public void Reset_Set_ShelfId_To_minusOne()
        {
            _Inst.Add(new RectData("1", 10, 10));
            _Inst.Add(new RectData("1", 10, 10));
            _Inst.Add(new RectData("1", 10, 10));

            foreach (var r in _Inst)
            {
                r.ShelfId = 0;
            }

            _Inst.Reset();

            foreach(var r in _Inst)
            {
                Assert.AreEqual(-1, r.ShelfId);
            }
        }

        [TestMethod]
        public void AddRange()
        {
            _Inst.Add(new RectData("1", 10, 10));
            _Inst.Add(new RectData("1", 10, 10));
            _Inst.Add(new RectData("1", 10, 10));

            RectData[] data = _Inst.Select(v => v).ToArray();

            _Inst.AddRange(data);

            Assert.AreEqual(6, _Inst.Count());
        }
    }
}
