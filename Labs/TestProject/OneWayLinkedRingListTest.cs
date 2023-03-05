using SecondLab;
namespace TestProject
{
    [TestClass]
    public class OneWayLinkedRingListTest
    {
        private OneWayLinkedRingList<int> GetTestList()
        {

            var list = new OneWayLinkedRingList<int>();
            list.Append(2);
            list.Append(3);
            list.Append(4);
            list.Append(7);
            list.Append(10);
            return list;
        }

        private OneWayLinkedRingList<int> GetTestListWithSameNumbers() 
        {
            var list = new OneWayLinkedRingList<int>();
            list.Append(1);
            list.Append(1);
            list.Append(1);
            list.Append(2);
            list.Append(2);
            list.Append(1);
            return list;
        }

        [TestMethod]
        public void TestLength() 
        {
            var list = new OneWayLinkedRingList<int>();
            const int expectedLength = 0;

            var actualLength = list.Length;

            Assert.AreEqual(expectedLength,actualLength);
        
        }

        [TestMethod]
        public void TestAppend()
        {
            var list = new OneWayLinkedRingList<int>();
            const string expectedListToString = "2 3 ";
            const int expectedLength = 2;

            list.Append(2);
            list.Append(3);
            var actualListToString = list.ToString();

            Assert.AreEqual(expectedListToString, actualListToString);
            Assert.AreEqual(expectedLength, list.Length);
        }

        [DataTestMethod]
        [DataRow(0, 99, "99 2 3 4 7 10 ")]
        [DataRow(1, 1, "2 1 3 4 7 10 ")]
        [DataRow(3, 2, "2 3 4 2 7 10 ")]
        [DataRow(4, 11, "2 3 4 7 11 10 ")]
        public void TestInsert(int index, int insertData, string expectedListToString)
        {
            var list = GetTestList();
            const int expectedLength = 6;

            list.Insert(insertData, index);
            var actualListToString = list.ToString();

            Assert.AreEqual(expectedListToString, actualListToString);
            Assert.AreEqual(expectedLength, list.Length);
        }

        [DataTestMethod]
        [DataRow(-1)]
        [DataRow(6)]
        [DataRow(5)]
        public void TestInsertThrowException(int index)
        {
            var list = GetTestList();
            const int insertData = 1;

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => list.Insert(insertData, index));
        }

        [DataTestMethod]
        [DataRow(0, "3 4 7 10 ")]
        [DataRow(1, "2 4 7 10 ")]
        [DataRow(3, "2 3 4 10 ")]
        [DataRow(4, "2 3 4 7 ")]
        public void TestDelete(int index, string expectedListToString)
        {
            var list = GetTestList();
            const int expectedLength = 4;

            list.Delete(index);
            var actualListToString = list.ToString();

            Assert.AreEqual(expectedListToString, actualListToString);
            Assert.AreEqual(expectedLength, list.Length);

        }

        [DataTestMethod]
        [DataRow(-1)]
        [DataRow(6)]
        [DataRow(5)]
        public void TestDeleteThrowException(int index)
        {
            var list = GetTestList();

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => list.Delete(index));
        }

        [DataTestMethod]
        [DataRow(1,2, "2 2 ")]
        [DataRow(2,4, "1 1 1 1 ")]
        [DataRow(3,6, "1 1 1 2 2 1 ")]
        public void TestDeleteAll(int numberToDelete, int expectedLength, string expectedListToString) 
        {

            var list = GetTestListWithSameNumbers();

            list.DeleteAll(numberToDelete);
            var actualLength = list.Length;
            var actualListTostring = list.ToString();

            Assert.AreEqual(expectedLength,actualLength);
            Assert.AreEqual(expectedListToString,actualListTostring);

        }

        [DataTestMethod]
        [DataRow(0, 2)]
        [DataRow(1, 3)]
        [DataRow(3, 7)]
        [DataRow(4, 10)]
        public void TestGet(int index, int expected)
        {
            var list = GetTestList();

            var actual = list.Get(index);

            Assert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DataRow(-1)]
        [DataRow(6)]
        [DataRow(5)]
        public void TestGetThrowException(int index)
        {
            var list = GetTestList();

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => list.Get(index));
        }
        [TestMethod]
        public void TestClone()
        { 

            var firstList = GetTestList();

            var secondList = firstList.Clone();
            var isEqualRefers = firstList == secondList;
            var isEqualValues = firstList.Equals(secondList);

            Assert.IsFalse(isEqualRefers);
            Assert.IsTrue(isEqualValues);
        }

        [TestMethod]
        public void TestReverse() 
        {
            var list = GetTestList();
            const string expectedListToString = "10 7 4 3 2 ";
            const int expectedLength = 5;

            list.Reverse();
            var actualListToString = list.ToString();
            var actualLength = list.Length;

            Assert.AreEqual(expectedListToString,actualListToString);
            Assert.AreEqual(expectedLength,actualLength);
        }

        [DataTestMethod]
        [DataRow(1,0)]
        [DataRow(2,3)]
        public void TestFindFirst(int element, int expectedIndex)
        {
            var list = GetTestListWithSameNumbers();
            
            var actualIndex = list.FindFirst(element);

            Assert.AreEqual(expectedIndex,actualIndex);
        }

        [DataTestMethod]
        [DataRow(1, 5)]
        [DataRow(2, 4)]
        public void TestFindLast(int element, int expectedIndex)
        {
            var list = GetTestListWithSameNumbers();

            var actualIndex = list.FindLast(element);

            Assert.AreEqual(expectedIndex, actualIndex);
        }
    }
}