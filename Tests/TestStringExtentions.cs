using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;

namespace SLIDDES.Tests
{
    public class TestStringExtentions
    {
        [Test]
        public void GetNthCharIndex()
        {
            Assert.AreEqual("AGaGtGT".GetNthCharIndex('t', 2), 6);
        }

        [Test]
        public void GetUntilOrEmpty()
        {
            Assert.AreEqual("aaataa".GetUntilOrEmpty("t"), "aaa");
        }

        [Test]
        public void SubstringBetween()
        {
            Assert.AreEqual("value0value1value2".SubstringBetween("value0", "value2"), "value1");
        }
    }
}