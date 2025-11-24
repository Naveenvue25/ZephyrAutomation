using NUnit.Framework;

namespace SampleTests
{
    [TestFixture]
    public class BasicTests
    {
        [SetUp]
        public void SetUp()
        {
            // This runs before every test
            TestContext.WriteLine("Setup: Initializing test data");
        }

        [Test]
        [Property("ZephyrTestCaseKey", "QA-101")]
        public void AddNumbers_ReturnsCorrectSum()
        {
            // Arrange
            int a = 5;
            int b = 3;

            // Act
            int result = a + b;

            // Assert
            Assert.That(result, Is.EqualTo(8), "Sum calculation is incorrect");
        }

        [Test]
        public void IsStringNotEmpty()
        {
            // Arrange
            string name = "Nunit Test";

            // Act & Assert
            Assert.IsNotEmpty(name, "String should not be empty");
        }

        [TearDown]
        public void TearDown()
        {
            // This runs after every test
            TestContext.WriteLine("TearDown: Cleaning up after test");
        }
    }
}
