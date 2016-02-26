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
            var lst = new LinkedList<int> {1, 2, 3};
            int n = 1;
            foreach (var i in lst)
            {
                Assert.AreEqual(n++, i);
            }
            Assert.AreEqual(3, lst.Count);
        }

        [TestMethod]
        public void LinkedListContains()
        {
            var lst = new LinkedList<int> {2};
            Assert.AreEqual(true, lst.Contains(2));
        }
        
        [TestMethod]
        public void LinkedListRemove()
        {
            var lst = new LinkedList<int> {2};
            lst.Remove(2);
            Assert.AreEqual(0, lst.Count);
        }

        [TestMethod]
        public void LinkedListLinq()
        {
            var lst = new LinkedList<int> {1, 2};
            Assert.AreEqual(true, lst.Any(x => x == 2));
        }

        [TestMethod]
        public void IndexerTest_Get()
        {
            var lst = new LinkedList<int>() {0,1,2,3,4,5,6,7,8,9};
            for (int i = 0; i < 10; i++)
            {
                Assert.AreEqual(i, lst[i]);
            }
        }

        [TestMethod]
        public void IndexerTest_Set()
        {
            var lst = new LinkedList<int>() {9,8,7,6,5,4,3,2,1,0};
            for (int i = 0; i < 10; i++)
            {
                lst[i] = i;
                Assert.AreEqual(i, lst[i]);
            }
        }
    }
}
