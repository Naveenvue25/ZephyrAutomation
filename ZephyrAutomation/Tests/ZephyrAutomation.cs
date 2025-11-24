using NUnit.Framework;

namespace ZephyrAutomation.Tests
{
    [TestFixture]
    public class ZephyrAutomation
    {
        [SetUp]
        public void SetUp()
        {
            // This runs before every test
            TestContext.WriteLine("Setup: Initializing test data");
        }

        [Test]
        [Property("ZephyrTestCaseKey", "SCRUM-T1")]
        public async Task AddNumbers_ReturnsCorrectSum()
        {
            var tester = new ZephyrConnectionTester();
            await tester.TestConnection();

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
