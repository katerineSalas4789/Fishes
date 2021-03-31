using NUnit.Framework;

namespace AlgorithmsTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            int[] fishSizes = new int[] { 4, 3, 2, 1, 5 };
            int[] fishDirections = new int[] { 0, 1, 0, 0, 0 };
            var response = MainSolution.Program.solution(fishSizes, fishDirections);
            Assert.AreEqual(response, 2);
        }
    }
}