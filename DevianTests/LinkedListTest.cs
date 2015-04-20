using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Devian.Collections;
using System.Linq;

namespace DevianTests
{
    [TestClass]
    public class LinkedListTest
    {
        [TestMethod]
        public void LinkedListAdd()
        {
            var lst = new LinkedList<int>();
            lst.Add(1);
            lst.Add(1);
            lst.Add(1);
            foreach (var i in lst)
            {
                Assert.AreEqual(1, i);
            }
            Assert.AreEqual(3, lst.Count);
        }

        [TestMethod]
        public void LinkedListContains()
        {
            var lst = new LinkedList<int>();
            lst.Add(2);
            Assert.AreEqual(true, lst.Contains(2));
        }
        
        [TestMethod]
        public void LinkedListRemove()
        {
            var lst = new LinkedList<int>();
            lst.Add(2);
            lst.Remove(2);
            Assert.AreEqual(0, lst.Count);
        }

        [TestMethod]
        public void LinkedListLinq()
        {
            var lst = new LinkedList<int>();
            lst.Add(1);
            lst.Add(2);
            Assert.AreEqual(true, lst.Any(x => x == 2));
        }
    }
}
