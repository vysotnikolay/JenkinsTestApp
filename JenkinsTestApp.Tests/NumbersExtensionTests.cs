using Microsoft.VisualStudio.TestTools.UnitTesting;
using BitOperations;
using System;

namespace JenkinsTestApp.Tests
{
    [TestClass]
    public class NumbersExtensionTests
    {
        [DataTestMethod]
        [DataRow(2728, 655, 3, 8, 2680)]
        [DataRow(554216104, 15, 0, 31, 15)]
        [DataRow(-55465467, 345346, 0, 31, 345346)]
        [DataRow(554216104, 4460559, 11, 18, 554203816)]
        [DataRow(-1, 0, 31, 31, 2147483647)]
        [DataRow(-2147483648, 2147483647, 0, 30, -1)]
        [DataRow(-2223, 5440, 18, 23, -16517295)]
        [DataRow(2147481425, 5440, 18, 23, 2130966353)]
        public void InsertNumberIntoAnother_ReturnsInsertedInFirstNumberJMinusIPlusOneBitsSequenceFromSecondNumberIntoFirstNumberFromIToJPosition(int sourceNumber, int anotherNumber, int i, int j, int expected)
        {
            int actual = NumbersExtension.InsertNumberIntoAnother(sourceNumber, anotherNumber, i, j);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void InsertNumberIntoAnother_i_MoreThan_j_ThrowArgumentException()
        {
            Assert.ThrowsException<ArgumentException>(() => NumbersExtension.InsertNumberIntoAnother(8, 15, 8, 3),
                message: "i should be less than or equal to j");
        }

        [TestMethod]
        public void InsertNumberIntoAnother_i_Equals_MinusOne_ThrowArgumentOutOfRangeException()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => NumbersExtension.InsertNumberIntoAnother(8, 15, -1, 3),
                message: "i range is from 0 to 31 (including)");
        }

        [TestMethod]
        public void InsertNumberIntoAnother_i_Equals_32_ThrowArgumentOutOfRangeException()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => NumbersExtension.InsertNumberIntoAnother(8, 15, 32, 32),
                message: "i range is from 0 to 31 (including)");
        }

        [TestMethod]
        public void InsertNumberIntoAnother_j_Equals_32_ThrowArgumentOutOfRangeException()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => NumbersExtension.InsertNumberIntoAnother(8, 15, 0, 32),
                message: "j range is from 0 to 31 (including)");
        }
    }
}