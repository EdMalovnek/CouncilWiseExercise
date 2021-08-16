using Microsoft.VisualStudio.TestTools.UnitTesting;
using CouncilWise;

namespace ReceiptTest
{
    [TestClass]
    public class ReceiptUnitTests
    {
        [TestMethod]
        public void CheckIfPalidrome_ReturnsTrue()
        {
            string sampleString = "racecar";

            Assert.IsTrue(Program.CheckIfPalindrome(sampleString));
        }

        [TestMethod]
        public void CheckIfPalidrome_ReturnsFalse()
        {
            string sampleString = "Edward Malovek";

            Assert.IsFalse(Program.CheckIfPalindrome(sampleString));
        }
    }
}
