using ARS;

namespace UnitTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void ValidateUserName()
        {
            // Assign 
            string userName = "Abraham";
            
            // Act
            bool result = Validator.IsValidUserName(userName);

            // Assert
            Assert.IsTrue(result);

        }
        [Test]
        public void ValidateEmail()
        {
            // Assign 
            string password = "johnsmith12@gmail.com";
            
            // Act
            bool result = Validator.IsValidEmail(password);

            // Assert
            Assert.IsTrue(result);
        }
    }
}