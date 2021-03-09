using NUnit.Framework;

namespace Sedol
{
    [TestFixture]
    public class SedolTest
    {
        private readonly string inputLength = "Input string was not 7-characters long";
        private readonly string inputCheckSum = "Checksum digit does not agree with the rest of the input";
        private readonly string inputInvalid = "SEDOL contains invalid characters";

        /// <summary>
        /// **Scenario:**  Null, empty string or string other than 7 characters long
        /// </summary>
        /// <param name="sedol">Input String</param>
        [TestCase(null)]
        [TestCase("")]
        [TestCase("12")]
        [TestCase("123456789")]
        public void SedolsLength(string sedol)
        {
            var actual = new SedolBL().ValidateSedol(sedol);
            var expected = new SedolResult(sedol, false, false, inputLength);
            FinalValidation(expected, actual);
        }

        /// <summary>
        /// **Scenario:**  Invalid Checksum non user defined SEDOL
        /// </summary>
        /// <param name="sedol">Input String</param>
        [TestCase("1234567")]
        public void InvalidNonUserCheckSum(string sedol)
        {
            var actual = new SedolBL().ValidateSedol(sedol);
            var expected = new SedolResult(sedol, false, false, inputCheckSum);
            FinalValidation(expected, actual);
        }

        /// <summary>
        /// **Scenario:**  Valid non user define SEDOL
        /// </summary>
        /// <param name="sedol">Input String</param>
        [TestCase("0709954")]
        [TestCase("B0YBKJ7")]
        public void ValidNonUserCheckSum(string sedol)
        {
            var actual = new SedolBL().ValidateSedol(sedol);
            var expected = new SedolResult(sedol, true, false, null);
            FinalValidation(expected, actual);
        }

        /// <summary>
        /// **Scenario** Invalid Checksum user defined SEDOL
        /// </summary>
        /// <param name="sedol">Input String</param>
        [TestCase("9123451")]
        [TestCase("9ABCDE8")]
        public void InvalidUserCheckSum(string sedol)
        {
            var actual = new SedolBL().ValidateSedol(sedol);
            var expected = new SedolResult(sedol, false, true, inputCheckSum);
            FinalValidation(expected, actual);
        }

        /// <summary>
        /// **Scenario:** Valid user defined SEDOL
        /// </summary>
        /// <param name="sedol">Input String</param>
        [TestCase("9123458")]
        [TestCase("9ABCDE1")]
        public void ValidUserCheckSum(string sedol)
        {
            var actual = new SedolBL().ValidateSedol(sedol);
            var expected = new SedolResult(sedol, true, true, null);
            FinalValidation(expected, actual);
        }

        /// <summary>
        /// **Scenario** Invaid characters found
        /// </summary>
        /// <param name="sedol">Input String</param>
        [TestCase("9123_51")]
        [TestCase("VA.CDE8")]
        public void SedolsContainingNonAlphanumericCharacters(string sedol)
        {
            var actual = new SedolBL().ValidateSedol(sedol);
            var expected = new SedolResult(sedol, false, false, inputInvalid);
            FinalValidation(expected, actual);
        }

        /// <summary>
        /// Final Validation
        /// </summary>
        /// <param name="expected">expected result</param>
        /// <param name="actual">actual result</param>
        private static void FinalValidation(ISedolValidationResult expected, ISedolValidationResult actual)
        {
            Assert.AreEqual(expected.InputString, actual.InputString, "InputString Failed");
            Assert.AreEqual(expected.IsValidSedol, actual.IsValidSedol, "IsValid Failed");
            Assert.AreEqual(expected.IsUserDefined, actual.IsUserDefined, "IsUserDefined Failed");
            Assert.AreEqual(expected.ValidationDetails, actual.ValidationDetails, "ValidationDetails Failed");
        }
    }
}