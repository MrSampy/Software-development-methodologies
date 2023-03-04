using SecondLab;
namespace TestProject
{
    [TestClass]
    public class OneWayLinkedRingListTest
    {
        [TestMethod]
        public void TestAppend()
        {
            var list = new OneWayLinkedRingList<int>();
            var expectedListToString = "2 3 ";
            var expectedLength = 2;

            list.Append(2);
            list.Append(3);
            var actualListToString = list.ToString();

            Assert.AreEqual(expectedListToString,actualListToString);
            Assert.AreEqual(expectedLength, list.Length);
        }
    }
}