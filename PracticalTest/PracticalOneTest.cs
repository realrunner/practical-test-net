using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PracticalTest
{
    [TestClass]
    public class PracticalOneTest
    {
        readonly IPracticalOne _practicalOne;

        public PracticalOneTest()
        {
            //TODO: Instantiate your implementation
            _practicalOne = new PracticalOne();
        }

        [TestMethod]
        public void ReverseWordsInStringTest()
        {
            Assert.AreEqual("phil is name my Hello", _practicalOne.ReverseWordsInString("Hello my name is phil"));
            Assert.AreEqual("shins my kicking stop George,", _practicalOne.ReverseWordsInString("George, stop kicking my shins"));
            Assert.AreEqual("Strings-with-hyphens-are-still-one-word", _practicalOne.ReverseWordsInString("Strings-with-hyphens-are-still-one-word"));
            Assert.AreEqual("?  spaces  Two", _practicalOne.ReverseWordsInString("Two  spaces  ?"));
        }

        [TestMethod]
        public void IsPalindromeTest()
        {
            Assert.AreEqual(true, _practicalOne.IsPalindrome("racecar"));
            Assert.AreEqual(true, _practicalOne.IsPalindrome("Hannah"));
            Assert.AreEqual(true, _practicalOne.IsPalindrome("Able was I ere I saw Elba"));
            Assert.AreEqual(false, _practicalOne.IsPalindrome("Kevin likes to climb rocks"));
            Assert.AreEqual(false, _practicalOne.IsPalindrome("Hannahash"));
        }

        [TestMethod]
        public void DoCalculationTest()
        {
            Assert.AreEqual(2, _practicalOne.DoCalculation("1+1"));
            Assert.AreEqual(4, _practicalOne.DoCalculation("1+1+1+1"));
            Assert.AreEqual(3, _practicalOne.DoCalculation("1+3-1"));
            Assert.AreEqual(2, _practicalOne.DoCalculation("1-1+2"));
            Assert.AreEqual(7, _practicalOne.DoCalculation("1-1+2+3+4+5-3-5-2+2-2+3"));
        }
    }
}
