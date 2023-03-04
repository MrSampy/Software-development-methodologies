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
        [DataRow(4, 10, "2 3 4 7 10 10 ")]
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
            const int insertData = 1;

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => list.Delete(index));
        }
    }
}