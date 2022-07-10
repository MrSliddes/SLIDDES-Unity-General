using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using SLIDDES;

namespace SLIDDES.Tests
{
    public class TestMathC
    {
        [Test]
        public void PositionOnCircle()
        {
            Assert.AreEqual(new Vector3(0, 1, 0), MathC.PositionOnCircle(Vector3.zero, 1, 0));
            Assert.IsTrue(new Vector3(0, 1, 0) == MathC.PositionOnCircle(Vector3.zero, 1, 360));
            Assert.IsTrue(new Vector3(0, 1, 0) == MathC.PositionOnCircle(Vector3.zero, 1, 720));
            Assert.IsTrue(new Vector3(0, -1, 0) == MathC.PositionOnCircle(Vector3.zero, 1, 180));
            Assert.IsTrue(new Vector3(1, 0, 0) == MathC.PositionOnCircle(Vector3.zero, 1, 90));
            Assert.IsTrue(new Vector3(-1, 0, 0) == MathC.PositionOnCircle(Vector3.zero, 1, -90));
            Assert.IsTrue(new Vector3(-1, 0, 0) == MathC.PositionOnCircle(Vector3.zero, 1, 270));
            Assert.IsTrue(new Vector3(1, 0, 0) == MathC.PositionOnCircle(Vector3.zero, 1, -270));
        }

        [Test]
        public void SnapToGrid()
        {
            Assert.AreEqual(new Vector2(0, 0), MathC.SnapToGrid(new Vector2(0, 0), new Vector2(10, 10)));
            Assert.AreEqual(new Vector2(10, 10), MathC.SnapToGrid(new Vector2(10, 10), new Vector2(10, 10)));
            Assert.AreEqual(new Vector2(10, 10), MathC.SnapToGrid(new Vector2(6, 6), new Vector2(10, 10)));
            Assert.AreEqual(new Vector2(0, 0), MathC.SnapToGrid(new Vector2(4, 4), new Vector2(10, 10)));
            Assert.AreEqual(new Vector2(0, 0), MathC.SnapToGrid(new Vector2(5, 5), new Vector2(10, 10)));
            Assert.AreEqual(new Vector2(10, 10), MathC.SnapToGrid(new Vector2(5.5f, 5.5f), new Vector2(10, 10)));
            Assert.AreEqual(new Vector3(0, 0, 0), MathC.SnapToGrid(new Vector3(0, 0, 0), new Vector3(10, 10, 10)));
            Assert.AreEqual(new Vector3(10, 10, 10), MathC.SnapToGrid(new Vector3(10, 10, 10), new Vector3(10, 10, 10)));
            Assert.AreEqual(new Vector3(0, 0, 0), MathC.SnapToGrid(new Vector3(4, 4, 4), new Vector3(10, 10, 10)));
            Assert.AreEqual(new Vector3(10, 40, 0), MathC.SnapToGrid(new Vector3(5.1f, 40, 4), new Vector3(10, 10, 10)));
            Assert.AreEqual(new Vector3(100, 0, 0), MathC.SnapToGrid(new Vector3(50.1f, 40, 4), new Vector3(100, 100, 100)));
            Assert.AreEqual(0, MathC.SnapValue(0, 10));
            Assert.AreEqual(10, MathC.SnapValue(10, 10));
            Assert.AreEqual(0, MathC.SnapValue(4, 10));
            Assert.AreEqual(10, MathC.SnapValue(6, 10));
            Assert.AreEqual(10, MathC.SnapValue(5.1f, 10));
            Assert.AreEqual(10, MathC.SnapValue(5.5f, 10));
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator WithEnumeratorPasses()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return null;
        }

        
    }
}
